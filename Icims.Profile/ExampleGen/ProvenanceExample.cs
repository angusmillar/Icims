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
  public class ProvenanceExample : ExampleBase
  {
    public ProvenanceExample() : base(ResourceType.Provenance) { }
    public override Provenance GetResource<Provenance>()
    {
      return GetResource() as Provenance;
    }
    public override Resource GetResource()
    {
      var Prov = new Provenance();
      Prov.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-example";

      Prov.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Prov.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "Example-1";
      ExampleAnnotation.Filename = Prov.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = $"{ResourceName} example 1";
      Prov.AddAnnotation(ExampleAnnotation);

      Prov.Meta = new Meta();
      Prov.Meta.Profile = new List<string>(){
          "http://hl7.org/fhir/StructureDefinition/Provenance",
          $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}"
      };
      Prov.Target = new List<ResourceReference>(){
        new ResourceReference($"{ResourceType.MessageHeader.GetLiteral()}/1f546115-c238-4389-b7c1-52abbde11f49", $"{ResourceType.MessageHeader.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Patient.GetLiteral()}/f5aa957a-b2f7-4dc6-89dd-3c4a7120ee2f", $"{ResourceType.Patient.GetLiteral()}"),
        new ResourceReference($"{ResourceType.DiagnosticReport.GetLiteral()}/c21f3e69-f1b2-4293-bc56-db6d1e45234b", $"{ResourceType.DiagnosticReport.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/53df86b8-b206-48f8-952a-ca5f2d8579ce", $"{ResourceType.Observation.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/1cc556f8-f045-4049-ac0a-b152cdbf95d8", $"{ResourceType.Observation.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/669ffc87-1828-4d66-becd-0f235a2b8fb1", $"{ResourceType.Observation.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/04c80a12-2c3d-4c88-987e-2a6a86d34d64", $"{ResourceType.Observation.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/8718bc1c-3199-44c5-a35e-ee3d8a36290a", $"{ResourceType.Observation.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/a142f6b4-f92f-49e8-8531-359067b81a0d", $"{ResourceType.Observation.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Organization.GetLiteral()}/bab13701-776a-41fd-86a9-7aa19df2825d", $"{ResourceType.Organization.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Organization.GetLiteral()}/95f4641f-6de7-470c-a44c-90ef5eb17faf", $"{ResourceType.Organization.GetLiteral()}"),
        new ResourceReference($"{ResourceType.Organization.GetLiteral()}/95f4641f-6de7-470c-a44c-90ef5eb17faf", $"{ResourceType.Organization.GetLiteral()}"),
      };


      return Prov;
    }
  }
}