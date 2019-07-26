using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Icims.Profile.Annotation;

namespace Icims.Profile.StructureDefinitionGen
{
  public static class StructureDefinitionFactory
  {
    public static List<Resource> GetAllResources()
    {
      List<Resource> Result = new List<Resource>();
      Result.Add(GetPatientStructureDefinition());
      Result.Add(GetOrganisationStructureDefinition());
      Result.Add(GetDiagnosticReportStructureDefinition());
      Result.Add(GetObservationStructureDefinition());
      Result.Add(GetProvenanceStructureDefinition());
      Result.Add(GetBundleStructureDefinition());
      return Result;
    }

    // public static ImplementationGuide GetIcimsImplementationGuide()
    // {
    //   List<Resource> Result = GetAllResourcesExceptIG();
    //   return GetImplementationGuide(Result).GetResource() as ImplementationGuide;
    // }

    public static StructureDefinition GetPatientStructureDefinition()
    {
      var Profile = new PatientProfile();
      return Profile.GetResource() as StructureDefinition;
    }

    public static StructureDefinition GetOrganisationStructureDefinition()
    {
      var Profile = new OrganizationProfile();
      return Profile.GetResource() as StructureDefinition;
    }
    public static StructureDefinition GetDiagnosticReportStructureDefinition()
    {
      var Profile = new DiagnosticReportProfile();
      return Profile.GetResource() as StructureDefinition;
    }
    public static StructureDefinition GetObservationStructureDefinition()
    {
      var Profile = new ObservationProfile();
      return Profile.GetResource() as StructureDefinition;
    }
    public static StructureDefinition GetProvenanceStructureDefinition()
    {
      var Profile = new ProvenanceProfile();
      return Profile.GetResource() as StructureDefinition;
    }
    public static StructureDefinition GetBundleStructureDefinition()
    {
      var Profile = new BundleProfile();
      return Profile.GetResource() as StructureDefinition;
    }


    // private static List<Resource> GetAllResourcesExceptIG()
    // {
    //   List<Resource> Result = new List<Resource>();
    //   Result.Add(GetIcimsCapabilityStatement());
    //   Result.Add(GetPatientStructureDefinition());
    //   Result.Add(GetOrganisationStructureDefinition());
    //   Result.Add(GetDiagnosticReportStructureDefinition());
    //   Result.Add(GetObservationStructureDefinition());
    //   return Result;
    // }

    // private static IcimsImplementationGuide GetImplementationGuide(List<Resource> ImplementationResourcelist)
    // {
    //   var ResourceComponentList = new List<ImplementationGuide.ResourceComponent>();
    //   foreach (Resource Res in ImplementationResourcelist)
    //   {
    //     var AnnotationList = Res.Annotations(typeof(IcimsResourceAnnotation));
    //     if (AnnotationList.FirstOrDefault() is IcimsResourceAnnotation IcimsAnnotation)
    //     {
    //       ResourceComponentList.Add(new ImplementationGuide.ResourceComponent()
    //       {
    //         Example = IcimsAnnotation.IsExample,
    //         Source = new ResourceReference($"{IcimsAnnotation.ResourceType.GetLiteral()}/{IcimsAnnotation.Filename}")
    //       });
    //     }
    //   }
    //   var Ig = new IcimsImplementationGuide(ResourceComponentList);
    //   return Ig;
    // }

  }
}
