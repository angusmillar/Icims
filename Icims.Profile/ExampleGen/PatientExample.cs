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
  public class PatientExample : ExampleBase
  {
    public PatientExample() : base(ResourceType.Patient) { }
    public override Patient GetResource<Patient>()
    {
      return GetResource() as Patient;
    }
    public override Resource GetResource()
    {
      var Pat = new Patient();
      Pat.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-example-1";

      Pat.AddAnnotation(new IcimsResourceAnnotation(ResourceType.Patient, Pat.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "Example-1";
      ExampleAnnotation.Filename = Pat.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = "Simple Patient example from Angus";
      Pat.AddAnnotation(ExampleAnnotation);

      Pat.Meta = new Meta();
      Pat.Meta.Profile = new List<string>(){
          "http://hl7.org.au/fhir/StructureDefinition/au-patient",
          "https://www.icims.com.au/fhir/StructureDefinition/icims-patient"
      };
      Pat.Identifier = new List<Identifier>(){
      new Identifier(){
        Use = Identifier.IdentifierUse.Official,
        Type = new CodeableConcept(){
          Coding = new List<Coding>(){
            new Coding(){
              Code= "MR",
              System = "http://hl7.org/fhir/v2/0203",
              Display = "Medical record number"
            },
          },
          Text = "Medical record number",
        },
        System = "https://www.sah.org.au/systems/fhir/pas/medical-record-number",
        Value = "1084783"
      },
      new Identifier(){
        Use = Identifier.IdentifierUse.Official,
        Type = new CodeableConcept(){
          Coding = new List<Coding>(){
            new Coding(){
              Code= "MC",
              System = "http://hl7.org/fhir/v2/0203",
              Display = "Medicare Number"
            },
          },
          Text = "Medicare Number",
        },
        System = "http://ns.electronichealth.net.au/id/medicare-number",
        Value = "21706279671"
      }};
      Pat.Name = new List<HumanName>(){
        new HumanName(){
          Use = HumanName.NameUse.Official,
          Text = "Mr LEE, Thomas",
          Family = "Lee",
          Given = new List<string>() { "Thomas"},
          Prefix = new List<string>() { "Mr"}
        }
      };
      Pat.Gender = AdministrativeGender.Male;
      Pat.BirthDateElement = new Date(1945, 06, 12);
      Pat.Address = new List<Address>()
      {
        new Address(){
          Text = "6 Shindys Rd, Dubbo 2830",
          Line = new List<string>(){ "6 Shindys Rd"},
          City = "Dubbo",
          PostalCode = "2830"
        }
      };
      return Pat;
    }
  }
}