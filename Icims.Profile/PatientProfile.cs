using System;
using System.Collections.Generic;
using System.Text;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Icims.Common.Tools;
using Hl7.Fhir.Model;


namespace Icims.Profile
{
    public class PatientProfile : BaseStructureDefinitionProfile
    {
        public PatientProfile() :
          base(ResourceType.Patient)
        { }

        public override Resource GetResource()
        {
            Def.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Def.Id));

            Def.Version = "0.0.1";
            Def.Status = PublicationStatus.Draft;
            Def.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 16, 09, 12, 00, new TimeSpan(10, 0, 0)));
            Def.BaseDefinition = "http://hl7.org.au/fhir/StructureDefinition/au-patient";

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = ResourceName,
                Path = ResourceName,
                Short = $"{IcimsInfo.IcimsCode.ToUpper()} {ResourceName} Resource"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.implicitRules",
                Path = $"{ResourceName}.implicitRules",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.language",
                Path = $"{ResourceName}.language",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:birthPlace",
                Path = $"{ResourceName}.extension",
                SliceName = "birthPlace",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:birthPlace.valueAddress:valueAddress",
                Path = $"{ResourceName}.extension.valueAddress",
                SliceName = "valueAddress",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:indigenousStatus",
                Path = $"{ResourceName}.extension",
                SliceName = "indigenousStatus",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:indigenousStatus.valueCoding:valueCoding",
                Path = $"{ResourceName}.extension.valueCoding",
                SliceName = "indigenousStatus",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:closingTheGapRegistration",
                Path = $"{ResourceName}.extension",
                SliceName = "closingTheGapRegistration",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:mothersMaidenName",
                Path = $"{ResourceName}.extension",
                SliceName = "mothersMaidenName",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.extension:mothersMaidenName.valueString:valueString",
                Path = $"{ResourceName}.extension.valueString",
                SliceName = "valueString",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier",
                Path = $"{ResourceName}.identifier",
                Min = 1,
                Max = "3"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:ihiNumber",
                Path = $"{ResourceName}.identifier",
                SliceName = "ihiNumber",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:medicareNumber",
                Path = $"{ResourceName}.identifier",
                SliceName = "medicareNumber",
                Max = "1"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:dvaNumber",
                Path = $"{ResourceName}.identifier",
                SliceName = "dvaNumber",
                Max = "1"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:healthcareCard",
                Path = $"{ResourceName}.identifier",
                SliceName = "healthcareCard",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:pensionerConcessionCard",
                Path = $"{ResourceName}.identifier",
                SliceName = "pensionerConcessionCard",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:commonwealthSeniorsHealthCard",
                Path = $"{ResourceName}.identifier",
                SliceName = "commonwealthSeniorsHealthCard",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:medicalRecordNumber",
                Path = $"{ResourceName}.identifier",
                SliceName = "medicalRecordNumber",
                Min = 1,
                Max = "1"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:insurerNumber",
                Path = $"{ResourceName}.identifier",
                SliceName = "insurerNumber",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.active",
                Path = $"{ResourceName}.active",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.name",
                Path = $"{ResourceName}.name",
                Min = 1,
                Max = "1"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.name.family",
                Path = $"{ResourceName}.name.family",
                Min = 1,
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.name.period",
                Path = $"{ResourceName}.name.period",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.telecom",
                Path = $"{ResourceName}.telecom",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.telecom.rank",
                Path = $"{ResourceName}.telecom.rank",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.telecom.period",
                Path = $"{ResourceName}.telecom.period",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.gender",
                Path = $"{ResourceName}.gender",
                Min = 1
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.birthDate",
                Path = $"{ResourceName}.birthDate",
                Min = 1,
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.birthDate.extension",
                Path = $"{ResourceName}.birthDate.extension",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.birthDate.extension:accuracyIndicator",
                Path = $"{ResourceName}.birthDate.extension",
                SliceName = "accuracyIndicator",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.birthDate.extension:birthTime",
                Path = $"{ResourceName}.birthDate.extension",
                SliceName = "birthTime",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.birthDate.extension:birthTime.valueDateTime:valueDateTime",
                Path = $"{ResourceName}.birthDate.extension.valueDateTime",
                SliceName = "valueDateTime",
                Min = 1,
                Max = "1"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.deceased[x]",
                Path = $"{ResourceName}.deceased[x]",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.deceasedBoolean:deceasedBoolean",
                Path = $"{ResourceName}.deceasedBoolean",
                SliceName = "deceasedBoolean",
                Max = "0"
            });

            //Def.Differential.Element.Add(new ElementDefinition()
            //{
            //  ElementId = $"{ResourceName}.deceased[x]:deceasedDateTime.extension:accuracyIndicator",
            //  Path = $"{ResourceName}.deceased[x].extension",
            //  SliceName = "accuracyIndicator",
            //  Max = "0"
            //});

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.address",
                Path = $"{ResourceName}.address",
                Max = "1"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.address.district",
                Path = $"{ResourceName}.address.district",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.address.period",
                Path = $"{ResourceName}.address.period",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.multipleBirth[x]",
                Path = $"{ResourceName}.multipleBirth[x]",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.photo",
                Path = $"{ResourceName}.photo",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.contact",
                Extension = new List<Extension>()
        {
          new Extension()
          {
             Url = "http://hl7.org/fhir/StructureDefinition/structuredefinition-explicit-type-name",
             Value = new FhirString("Contact")
          }
        },
                Path = $"{ResourceName}.contact",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.animal",
                Extension = new List<Extension>()
        {
          new Extension()
          {
             Url = "http://hl7.org/fhir/StructureDefinition/structuredefinition-explicit-type-name",
             Value = new FhirString("Animal")
          }
        },
                Path = $"{ResourceName}.animal",
                Max = "0"
            });


            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.communication",
                Path = $"{ResourceName}.communication",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.generalPractitioner",
                Path = $"{ResourceName}.generalPractitioner",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.managingOrganization",
                Path = $"{ResourceName}.managingOrganization",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.link",
                Path = $"{ResourceName}.link",
                Max = "0"
            });

            return Def;

        }
    }
}
