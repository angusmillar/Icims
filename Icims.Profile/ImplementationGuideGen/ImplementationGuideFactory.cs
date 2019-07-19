using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Icims.Profile.Annotation;

namespace Icims.Profile.ImplementationGuideGen
{
  public static class ImplementationGuideFactory
  {
    public static ImplementationGuide GetIcimsImplementationGuide(List<ImplementationGuide.ResourceComponent> ResourceComponentList)
    {
      var example = new IcimsImplementationGuide(ResourceComponentList);
      return example.GetResource<ImplementationGuide>();
    }

    public static ImplementationGuide GetIcimsImplementationGuide(List<Resource> Resourcelist)
    {
      var ResourceComponentList = new List<ImplementationGuide.ResourceComponent>();
      foreach (Resource Res in Resourcelist)
      {
        var AnnotationList = Res.Annotations(typeof(IcimsResourceAnnotation));
        if (AnnotationList.FirstOrDefault() is IcimsResourceAnnotation IcimsAnnotation)
        {
          ResourceComponentList.Add(new ImplementationGuide.ResourceComponent()
          {
            Example = IcimsAnnotation.IsExample,
            Source = new ResourceReference($"{IcimsAnnotation.ResourceType.GetLiteral()}/{IcimsAnnotation.Filename}")
          });
        }
      }
      return new IcimsImplementationGuide(ResourceComponentList).GetResource<ImplementationGuide>();
    }

  }
}
