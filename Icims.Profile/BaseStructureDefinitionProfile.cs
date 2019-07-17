using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;


namespace Icims.Profile
{
  public abstract class BaseStructureDefinitionProfile : BaseIcimsResource
  {    
    protected StructureDefinition Def;

    public BaseStructureDefinitionProfile(ResourceType ResourceType) :
      base(ResourceType)
    { 
      if (!ModelInfo.IsKnownResource(ResourceType.GetLiteral()))
      {
        throw new ApplicationException($"The provided ResourceType of {ResourceType.GetLiteral()} was not a KnownResource");
      }

      Def = new StructureDefinition();      

      Def.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}";
      Def.Text = new Narrative()
      {
        Status = Narrative.NarrativeStatus.Generated,
        Div = $"<p>{IcimsInfo.IcimsCode.ToUpper()} {ResourceName} profile for use within Australia</p>",
      };
      Def.Url = $"{IcimsInfo.IcimsProfileUrlBase}/StructureDefinition/{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}";
      Def.Version = "0.0.1";
      Def.Name = $"{Icims.Common.Tools.StringSupport.FirstCharToUpper(IcimsInfo.IcimsCode)}{ResourceName}";
      Def.Title = $"{Icims.Common.Tools.StringSupport.FirstCharToUpper(IcimsInfo.IcimsCode)} {ResourceName}";
      Def.Status = PublicationStatus.Draft;
      Def.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 16, 09, 12, 00, new TimeSpan(10, 0, 0)));
      Def.Publisher = PyrohealthInfo.PublisherName;
      Def.Contact = new List<ContactDetail>()
      {
        new ContactDetail()
        {
           Telecom = new List<ContactPoint>()
           {
              new ContactPoint()
              {
                 System = ContactPoint.ContactPointSystem.Url,
                 Value = PyrohealthInfo.WebSite,
                 Use = ContactPoint.ContactPointUse.Work
              }
           }
        }
      };
      Def.Description = new Markdown($"### ICIMS Austrlian {ResourceName} Resource  &#xa;&#xa;#### This is a {ResourceName} resource profile to be used by ICIMS within Australia.");
      Def.FhirVersion = "3.0.1";
      Def.Kind = StructureDefinition.StructureDefinitionKind.Resource;
      Def.Abstract = false;
      Def.Type = ResourceName;
      Def.BaseDefinition = "http://hl7.org.au/fhir/StructureDefinition/au-organisation";
      Def.Derivation = StructureDefinition.TypeDerivationRule.Constraint;

      Def.Differential = new StructureDefinition.DifferentialComponent();
      Def.Differential.Element = new List<ElementDefinition>();



    }   

  }
}
