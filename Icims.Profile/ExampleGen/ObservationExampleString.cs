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
  public class ObservationExampleString : ExampleBase
  {
    public ObservationExampleString() : base(ResourceType.Observation) { }
    public override Observation GetResource<Observation>()
    {
      return GetResource() as Observation;
    }
    public override Resource GetResource()
    {
      var Obs = new Observation();
      Obs.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-example-string";

      Obs.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Obs.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "Example-String";
      ExampleAnnotation.Filename = Obs.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = "Simple string datatype Observation example";
      Obs.AddAnnotation(ExampleAnnotation);

      Obs.Meta = new Meta();
      Obs.Meta.Profile = new List<string>(){
          "http://hl7.org/fhir/StructureDefinition/Observation",
          $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}"
      };
      Obs.Status = ObservationStatus.Final;
      Obs.Category = new List<CodeableConcept>(){
        new CodeableConcept("http://hl7.org/fhir/observation-category",
        "procedure", "Procedure")
      };
      Obs.Code = new CodeableConcept("https://www.sah.org.au/systems/fhir/observation/procedure-observation", "DOS", "Date of Surgery");
      Obs.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/f5aa957a-b2f7-4dc6-89dd-3c4a7120ee2f", "Mr LEE, Thomas");
      Obs.Effective = new FhirDateTime(new DateTimeOffset(2019, 05, 29, 14, 12, 54, new TimeSpan(10, 0, 0)));
      Obs.Issued = new DateTimeOffset(2019, 06, 05, 16, 42, 27, new TimeSpan(10, 0, 0));
      Obs.Value = new FhirString("20171212");
      return Obs;
    }
  }
}