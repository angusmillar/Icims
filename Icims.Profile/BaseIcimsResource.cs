using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Text;


namespace Icims.Profile
{
  public abstract class BaseIcimsResource
  {
    public BaseIcimsResource(ResourceType ResourceType)
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
    public abstract Resource GetResource();
    public abstract T GetResource<T>() where T : Resource;
  }
}
