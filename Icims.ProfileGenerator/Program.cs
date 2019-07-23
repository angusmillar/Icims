using System;
using Icims.Profile.CapabilityStatementGen;
using Icims.Profile.ImplementationGuideGen;
using Icims.Profile.ExampleGen;
using Icims.Profile.StructureDefinitionGen;
using Icims.Profile.Annotation;
using System.IO;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Icims.ProfileGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      string ResourceOutputDirectoryName = "resources";
      DirectoryInfo BaseOutputDirectory = GetBaseOutputDirectory();
      DirectoryInfo TargetResourceOutputDirectoryInfo = new DirectoryInfo(Path.Combine(BaseOutputDirectory.FullName, ResourceOutputDirectoryName));
      if (!TargetResourceOutputDirectoryInfo.Exists)
      {
        throw new ApplicationException($"The resource output directory does not exists: '{TargetResourceOutputDirectoryInfo.FullName}'");
      }

      //Delete all files in the directory
      Console.WriteLine($"Output directory is : {TargetResourceOutputDirectoryInfo.FullName}");
      Console.WriteLine("Delete resource in output directory");
      if (TargetResourceOutputDirectoryInfo.GetFiles().Length == 0)
        Console.WriteLine("No resource in output directory to delete");
      foreach (FileInfo file in TargetResourceOutputDirectoryInfo.GetFiles())
      {
        Console.WriteLine($"Delete {file.Name}");
        file.Delete();
      }

      Console.WriteLine("Generate resources");
      List<Resource> ResourceList = CapabilityStatementFactory.GetAllResources();
      ResourceList.AddRange(StructureDefinitionFactory.GetAllResources());
      var ExampleResourceList = ExampleFactory.GetAllResources();
      ResourceList.AddRange(ExampleResourceList);
      ResourceList.Add(ImplementationGuideFactory.GetIcimsImplementationGuide(ResourceList));

      foreach (Resource Res in ResourceList)
      {
        var AnnotationList = Res.Annotations(typeof(IcimsResourceAnnotation));
        if (AnnotationList.FirstOrDefault() is IcimsResourceAnnotation IcimsAnnotation)
        {
          Console.WriteLine($"Resource: {IcimsAnnotation.Filename}.xml");
          FhirXmlSerializer FhirXmlSerializer = new FhirXmlSerializer();
          FhirXmlSerializer.Settings.Pretty = true;
          File.WriteAllText(Path.Combine(TargetResourceOutputDirectoryInfo.FullName, IcimsAnnotation.Filename + ".xml"), FhirXmlSerializer.SerializeToString(Res));
        }
      }

      var ExampleMarkDownList = ExampleMarkdownGenerator.GetAllMarkdownFiles(ExampleResourceList);
      foreach (var MarkDownFile in ExampleMarkDownList)
      {
        File.WriteAllText(Path.Combine(BaseOutputDirectory.FullName, MarkDownFile.RelativeFilePath), MarkDownFile.FileContent);
      }

      Console.WriteLine($"Total of {ResourceList.Count} resources output");
    }

    private static DirectoryInfo GetBaseOutputDirectory()
    {
      var test = System.IO.Directory.GetCurrentDirectory();
      // Console.WriteLine($"#####################################################################");
      // Console.WriteLine($"OLD Path {test}");
      // Console.WriteLine($"#####################################################################");
      DirectoryInfo CurrentDirectory = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
      DirectoryInfo TargetOutputDirectoryInfo = new DirectoryInfo(CurrentDirectory.FullName);
      bool found = false;
      while (!found)
      {
        if (CurrentDirectory.Parent == null)
        {
          throw new ApplicationException($"The path the application was run from was expectd to have a parent directory named 'Icims.ProfileGenerator'");
        }
        if (CurrentDirectory.Name == "Icims.ProfileGenerator")
        {
          TargetOutputDirectoryInfo = new DirectoryInfo(System.IO.Path.Combine(CurrentDirectory.Parent.FullName, $@"Icims.FhirIgPublisher"));
          found = true;
        }
        else
        {
          CurrentDirectory = CurrentDirectory.Parent;
          // Console.WriteLine($"TempPath {CurrentDirectory.FullName}");
        }
      }
      // Console.WriteLine($"#####################################################################");
      // Console.WriteLine($"New Path {TargetOutputDirectoryInfo.FullName}");
      // Console.WriteLine($"#####################################################################");
      return TargetOutputDirectoryInfo;
    }
  }
}
