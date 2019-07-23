using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Icims.Profile.MarkdownGen;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Icims.Profile.Annotation;
using Icims.Common.Models.Icims;
using System.Text;

namespace Icims.Profile.ExampleGen
{
  public static class ExampleMarkdownGenerator
  {
    public static string RelativeOutPutDirectory = @"pages\_includes";
    public static List<MarkdownFile> GetAllMarkdownFiles(List<Resource> ExampleResourceList)
    {
      List<MarkdownFile> Result = new List<MarkdownFile>();
      var ExampleResourceListGrouped = from Example in ExampleResourceList
                                       group Example by Example.ResourceType into newgroup
                                       orderby newgroup.Key
                                       select newgroup;

      foreach (var ResourceGroup in ExampleResourceListGrouped)
      {
        var Mark = new MarkdownFile();
        Mark.FileName = $"{IcimsInfo.IcimsCode}-{ResourceGroup.Key.GetLiteral().ToLower()}-def-examples.md";
        Mark.RelativeFilePath = Path.Combine(RelativeOutPutDirectory, Mark.FileName);
        Mark.FileType = MarkdownFileType.ResourceExample;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"#### {ResourceGroup.Key.GetLiteral()} resource example list");
        sb.AppendLine("");
        sb.AppendLine("|Name|Description|");
        sb.AppendLine("|---|---||");
        foreach (var Res in ResourceGroup)
        {
          var AnnotationList = Res.Annotations(typeof(ExampleResourceAnnotation));
          if (AnnotationList.FirstOrDefault() is ExampleResourceAnnotation ExampleAnnotation)
          {
            sb.AppendLine($"|<a href=\"{ExampleAnnotation.ResourceType.GetLiteral()}-{ExampleAnnotation.Filename}.html\">{ExampleAnnotation.ExampleName}</a>|{ExampleAnnotation.Description}|");
          }
          else
          {
            throw new ApplicationException($"No ExampleResourceAnnotation found on the resource type {Res.ResourceType.GetLiteral()} with id {Res.Id}");
          }
        }
        sb.AppendLine("{:.grid}");
        Mark.FileContent = sb.ToString();
        Result.Add(Mark);
      }
      return Result;
    }
  }
}
