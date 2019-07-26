using System;
using System.Collections.Generic;
using System.Text;
using Icims.Profile.Annotation;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Model;

namespace Icims.Profile.ExampleGen
{
  public class OrganizationExampleSah : ExampleBase
  {
    public OrganizationExampleSah() : base(ResourceType.Organization) { }
    public override Organization GetResource<Organization>()
    {
      return GetResource() as Organization;
    }
    public override Resource GetResource()
    {
      var Org = new Organization();
      Org.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-example-sah";

      Org.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Org.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "Example-SAH";
      ExampleAnnotation.Filename = Org.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = $"Sydney Adventist Hospital {ResourceName} example";
      Org.AddAnnotation(ExampleAnnotation);

      Org.Meta = new Meta();
      Org.Meta.Profile = new List<string>(){
          "http://hl7.org.au/fhir/StructureDefinition/au-organisation",
          $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}"
      };
      Org.Name = "SAH";
      Org.Alias = new List<string>(){
        "SAN",
        "Sydney Adventist Hospital"
      };

      return Org;
    }
  }
}