using System;
using System.Collections.Generic;
using System.Text;
using Icims.Profile.Annotation;
using Hl7.Fhir.Model;


namespace Icims.Profile.MarkdownGen
{
  public enum MarkdownFileType { ResourceExample, Unkown };
  public class MarkdownFile
  {
    public MarkdownFileType FileType { get; set; }
    public string FileName { get; set; }
    public string RelativeFilePath { get; set; }
    public string FileContent { get; set; }

  }
}
