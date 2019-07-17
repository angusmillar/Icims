using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace Icims.Profile
{
  public class IcimsResourceAnnotation
  {
    public IcimsResourceAnnotation(ResourceType ResourceType, string Filename, bool IsExample = false)
    {
      this.ResourceType = ResourceType;
      this.Filename = Filename;
      this.IsExample = IsExample;
    }
    public ResourceType ResourceType { get; set; }
    public string Filename { get; set; }    
    public bool IsExample { get; set; }
  }
}
