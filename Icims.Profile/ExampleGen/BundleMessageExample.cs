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
  public class BundleMessageExample : ExampleBase
  {
    public BundleMessageExample() : base(ResourceType.Bundle) { }
    public override Bundle GetResource<Bundle>()
    {
      return GetResource() as Bundle;
    }
    public override Resource GetResource()
    {
      var Bun = new Bundle();
      Bun.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-message-example";

      Bun.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Bun.Id, true));

      var ExampleAnnotation = new ExampleResourceAnnotation();
      ExampleAnnotation.ExampleName = "MessageBundleExample";
      ExampleAnnotation.Filename = Bun.Id;
      ExampleAnnotation.ResourceType = this.ResourceType;
      ExampleAnnotation.Description = $"{IcimsInfo.IcimsCode.ToUpper()} Message Bunlde example";
      Bun.AddAnnotation(ExampleAnnotation);

      Bun.Meta = new Meta();
      Bun.Meta.Profile = new List<string>(){
          "http://hl7.org/fhir/StructureDefinition/Bundle",
          $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}"
      };
      Bun.Type = Bundle.BundleType.Message;
      Bun.Entry = new List<Bundle.EntryComponent>(){
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:1f546115-c238-4389-b7c1-52abbde11f49",
          Resource = new MessageHeader(){
            Id = "1f546115-c238-4389-b7c1-52abbde11f49"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:c21f3e69-f1b2-4293-bc56-db6d1e45234b",
          Resource = new DiagnosticReport(){
            Id = "c21f3e69-f1b2-4293-bc56-db6d1e45234b"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:f5aa957a-b2f7-4dc6-89dd-3c4a7120ee2f",
          Resource = new Patient(){
            Id = "f5aa957a-b2f7-4dc6-89dd-3c4a7120ee2f"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:53df86b8-b206-48f8-952a-ca5f2d8579ce",
          Resource = new Observation(){
            Id = "53df86b8-b206-48f8-952a-ca5f2d8579ce"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:1cc556f8-f045-4049-ac0a-b152cdbf95d8",
          Resource = new Observation(){
            Id = "1cc556f8-f045-4049-ac0a-b152cdbf95d8"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:669ffc87-1828-4d66-becd-0f235a2b8fb1",
          Resource = new Observation(){
            Id = "669ffc87-1828-4d66-becd-0f235a2b8fb1"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:04c80a12-2c3d-4c88-987e-2a6a86d34d64",
          Resource = new Observation(){
            Id = "04c80a12-2c3d-4c88-987e-2a6a86d34d64"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:8718bc1c-3199-44c5-a35e-ee3d8a36290a",
          Resource = new Observation(){
            Id = "8718bc1c-3199-44c5-a35e-ee3d8a36290a"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:a142f6b4-f92f-49e8-8531-359067b81a0d",
          Resource = new Observation(){
            Id = "a142f6b4-f92f-49e8-8531-359067b81a0d"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:bab13701-776a-41fd-86a9-7aa19df2825d",
          Resource = new Organization(){
            Id = "bab13701-776a-41fd-86a9-7aa19df2825d"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:95f4641f-6de7-470c-a44c-90ef5eb17faf",
          Resource = new Organization(){
            Id = "95f4641f-6de7-470c-a44c-90ef5eb17faf"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:ef5815fd-d1ec-4dd8-990e-7ffb125198a3",
          Resource = new Provenance(){
            Id = "ef5815fd-d1ec-4dd8-990e-7ffb125198a3"
          }
        },
        new Bundle.EntryComponent(){
          FullUrl = "urn:uuid:ef5815fd-d1ec-4dd8-990e-7ffb125198a3",
          Resource = new Provenance(){
            Id = "ef5815fd-d1ec-4dd8-990e-7ffb125198a3"
          }
        }
      };

      return Bun;
    }
  }
}