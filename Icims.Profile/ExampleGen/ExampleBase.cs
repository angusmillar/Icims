using System;
using System.Collections.Generic;
using System.Text;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Model;

namespace Icims.Profile.ExampleGen
{
  public abstract class ExampleBase
  {
    public ExampleBase(ResourceType ResourceType)
    {
      if (!ModelInfo.IsKnownResource(ResourceType.GetLiteral()))
      {
        throw new ApplicationException($"The provided ResourceType of {ResourceType.GetLiteral()} was not a KnownResource");
      }
      this.ResourceType = ResourceType;
      this.ResourceName = ResourceType.GetLiteral();
    }
    protected string ResourceName { get; private set; }
    protected ResourceType ResourceType { get; private set; }
    public abstract T GetResource<T>() where T : Resource;
    public abstract Resource GetResource();
  }
}