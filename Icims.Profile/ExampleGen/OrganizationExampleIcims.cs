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
  public class OrganizationExampleIcims : ExampleBase
  {
    public OrganizationExampleIcims() : base(ResourceType.Organization) { }
    public override Organization GetResource<Organization>()
    {
      return GetResource() as Organization;
    }
    public override Resource GetResource()
    {
      var Org = new Organization();
      Org.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-example-icims";

      Org.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Org.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "Example-ICIMS";
      ExampleAnnotation.Filename = Org.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = "Simple Organisation example from Angus";
      Org.AddAnnotation(ExampleAnnotation);

      Org.Meta = new Meta();
      Org.Meta.Profile = new List<string>(){
          "http://hl7.org.au/fhir/StructureDefinition/au-organisation",
          $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}"
      };
      Org.Name = IcimsInfo.IcimsCode.ToUpper();
      Org.Alias = new List<string>(){
        "Innovative Clinical Information Management Systems"
      };

      return Org;
    }
  }
}