using System;
using System.Collections.Generic;
using System.Text;
using Icims.Profile.Annotation;
using Icims.Common.Models.Icims;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Model;

namespace Icims.Profile.ExampleGen
{
  public class DiagnosticReportExample : ExampleBase
  {
    public DiagnosticReportExample() : base(ResourceType.DiagnosticReport) { }
    public override DiagnosticReport GetResource<DiagnosticReport>()
    {
      return GetResource() as DiagnosticReport;
    }
    public override Resource GetResource()
    {
      var Diag = new DiagnosticReport();
      Diag.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-example-1";

      Diag.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Diag.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "Example-One";
      ExampleAnnotation.Filename = Diag.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = "DiagnosticReport example";
      Diag.AddAnnotation(ExampleAnnotation);

      Diag.Meta = new Meta();
      Diag.Meta.Profile = new List<string>(){
          "http://hl7.org.au/fhir/StructureDefinition/au-diagnosticreport",
          $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}"
      };
      Diag.Identifier = new List<Identifier>(){
        new Identifier(){
          Use = Identifier.IdentifierUse.Official,
          Type = new CodeableConcept(){
            Coding = new List<Coding>() {
              new Coding("http://hl7.org/fhir/identifier-type", "FILL", "Filler Identifier")
            },
            Text = "Report Identifier"
          },
          System = "urn:uuid:2f9f1a5a-7347-46ba-be2f-9f2970d26eb2",
          Value = "149"
        }
      };
      Diag.Status = DiagnosticReport.DiagnosticReportStatus.Final;
      Diag.Category = new CodeableConcept()
      {
        Coding = new List<Coding>(){
          new Coding(){
            System = "http://hl7.org/fhir/v2/0074",
            Code = "OTH"
          }
        },
        Text = "Diagnostic Service Section Codes"
      };
      Diag.Code = new CodeableConcept()
      {
        Coding = new List<Coding>(){
          new Coding(){
            System = "http://loinc.org",
            Code = "29554-3",
            Display = "Procedure Report"
          }
        }
      };
      Diag.Subject = new ResourceReference($"{ResourceType.Patient.GetLiteral()}/f5aa957a-b2f7-4dc6-89dd-3c4a7120ee2f", "Mr LEE, Thomas");
      Diag.Effective = new FhirDateTime(new DateTimeOffset(2018, 08, 22, 18, 07, 09, new TimeSpan(10, 0, 0)));
      Diag.Issued = new DateTimeOffset(2019, 05, 29, 14, 12, 54, new TimeSpan(10, 0, 0));
      Diag.Result = new List<ResourceReference>(){
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/53df86b8-b206-48f8-952a-ca5f2d8579ce", "Date of Surgery"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/1cc556f8-f045-4049-ac0a-b152cdbf95d8", "Lead Surgeon"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/669ffc87-1828-4d66-becd-0f235a2b8fb1", "Indication"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/04c80a12-2c3d-4c88-987e-2a6a86d34d64", "Procedure Text"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/8718bc1c-3199-44c5-a35e-ee3d8a36290a", "Clinical details"),
        new ResourceReference($"{ResourceType.Observation.GetLiteral()}/a142f6b4-f92f-49e8-8531-359067b81a0d", "Findings")
      };

      return Diag;
    }
  }
}