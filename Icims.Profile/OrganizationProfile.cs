using System;
using System.Collections.Generic;
using System.Text;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Icims.Common.Tools;
using Hl7.Fhir.Model;


namespace Icims.Profile
{
    public class OrganizationProfile : BaseStructureDefinitionProfile
    {
        public OrganizationProfile() :
          base(ResourceType.Organization)
        { }

        public override Resource GetResource()
        {
            Def.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Def.Id));

            Def.Version = "0.0.1";
            Def.Status = PublicationStatus.Draft;
            Def.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 16, 09, 12, 00, new TimeSpan(10, 0, 0)));
            Def.BaseDefinition = "http://hl7.org.au/fhir/StructureDefinition/au-organisation";

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = ResourceName,
                Path = ResourceName,
                Short = $"{IcimsInfo.IcimsCode.ToUpper()} {ResourceName} Resource"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.active",
                Path = $"{ResourceName}.active",
                Max = "0"
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
                ElementId = $"{ResourceName}.identifier",
                Path = $"{ResourceName}.identifier",
                Short = "Organisation Directory Entry Identifiers",
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:acn",
                Path = $"{ResourceName}.identifier",
                SliceName = "acn",
                Short = "Australian Company Number (ACN)",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:arbn",
                Path = $"{ResourceName}.identifier",
                SliceName = "arbn",
                Short = "Australian Registered Body Number (ARBN)",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:paio",
                Path = $"{ResourceName}.identifier",
                SliceName = "paio",
                Short = "My Health Record Assigned Identity for Organisations (PAI-O)",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.identifier:csp",
                Path = $"{ResourceName}.identifier",
                SliceName = "csp",
                Short = "Contracted Service Provider (CSP) Number",
                Max = "0"
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.name",
                Path = $"{ResourceName}.name",
                SliceName = "csp",
                Short = "Name of Directroy Entry Organisation",
                Min = 1
            });

            Def.Differential.Element.Add(new ElementDefinition()
            {
                ElementId = $"{ResourceName}.address",
                Path = $"{ResourceName}.address",
                Short = "Addresses of Directroy Entry Organisation",
            });



            return Def;

        }
    }
}
