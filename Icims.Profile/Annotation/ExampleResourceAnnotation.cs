using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace Icims.Profile.Annotation
{
  public class ExampleResourceAnnotation
  {
    public ExampleResourceAnnotation()
    {
    }
    public ResourceType ResourceType { get; set; }
    public string Filename { get; set; }
    public string ExampleName { get; set; }
    public string Description { get; set; }

  }
}
