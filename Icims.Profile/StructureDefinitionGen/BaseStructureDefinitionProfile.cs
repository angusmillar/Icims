using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Icims.Profile;
using Icims.Profile.Annotation;

namespace Icims.Profile.StructureDefinitionGen
{
  public abstract class BaseStructureDefinitionProfile : BaseIcimsResource
  {
    protected StructureDefinition Def;

    public override StructureDefinition GetResource<StructureDefinition>()
    {
      return GetResource() as StructureDefinition;
    }
    public BaseStructureDefinitionProfile(ResourceType ResourceType) :
      base(ResourceType)
    {
      Def = new StructureDefinition();
      Def.Id = $"{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}-def";
      //Def.Id = $"{ResourceType.StructureDefinition.GetLiteral().ToLower()}-{IcimsInfo.IcimsCode}-{ResourceName.ToLower()}";
      Def.AddAnnotation(new IcimsResourceAnnotation(ResourceType.StructureDefinition, Def.Id));
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
      StringBuilder Des = new StringBuilder();
      Des.AppendLine($"# ICIMS Austrlian {ResourceName} resource profile.");
      // Des.AppendLine($"");
      // Des.AppendLine($"## Heading 2");
      // Des.AppendLine($"");
      // Des.AppendLine($"### Heading 3");
      // Des.AppendLine($"");
      // Des.AppendLine($"no bold");
      // Des.AppendLine($"");     
      // Des.AppendLine($"");
      // Des.AppendLine($"");
      // Des.AppendLine($"[Google](https://www.google.com)");
      // Des.AppendLine($"");
      // Des.AppendLine($"**Some bold text** but this is not bold");
      // Des.AppendLine($"");
      // Des.AppendLine($"*italicized text* but not over here");
      // Des.AppendLine($"");
      // Des.AppendLine($"- First item");
      // Des.AppendLine($"- Second item");
      // Des.AppendLine($"- Third item");
      // Des.AppendLine($"- Four item");
      // Des.AppendLine($"");
      // Des.AppendLine($"Below is a horizontal line");
      // Des.AppendLine($"---");
      // Des.AppendLine($"");



      Def.Description = new Markdown(Des.ToString());

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
