using System;
using System.Collections.Generic;
using System.Text;
using Icims.Profile.Annotation;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Icims.Common.Tools;
using Hl7.Fhir.Model;


namespace Icims.Profile.StructureDefinitionGen
{
  public class BundleProfile : BaseStructureDefinitionProfile
  {
    public BundleProfile() :
      base(ResourceType.Bundle)
    { }

    public override Resource GetResource()
    {
      Def.Version = "0.0.1";
      Def.Status = PublicationStatus.Draft;
      Def.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 24, 09, 12, 00, new TimeSpan(10, 0, 0)));
      Def.BaseDefinition = "http://hl7.org/fhir/StructureDefinition/Bundle";

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
        ElementId = $"{ResourceName}.type",
        Path = $"{ResourceName}.type",
        Fixed = new Code("message")
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.link",
        Path = $"{ResourceName}.link",
        Max = "0"
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.entry",
        Path = $"{ResourceName}.entry",
      });



      // Def.Differential.Element.Add(new ElementDefinition()
      // {
      //   ElementId = $"{ResourceName}.entry",
      //   Path = $"{ResourceName}.entry",
      //   Slicing = new ElementDefinition.SlicingComponent(){
      //     Discriminator = new List<ElementDefinition.DiscriminatorComponent>(){
      //       new ElementDefinition.DiscriminatorComponent(){
      //         Type = ElementDefinition.DiscriminatorType.Pattern,
      //         Path = "type"
      //       },
      //       new ElementDefinition.DiscriminatorComponent(){
      //         Type = ElementDefinition.DiscriminatorType.Value,
      //         Path = "resource"
      //       }
      //     },
      //     Rules = ElementDefinition.SlicingRules.Open
      //   }
      // });


      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.entry.fullUrl",
        Path = $"{ResourceName}.entry.fullUrl",
        Min = 1,
        Max = "1"
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.entry.resource",
        Path = $"{ResourceName}.entry.resource",
        Min = 1,
        Max = "1"
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.entry.search",
        Path = $"{ResourceName}.entry.search",
        Max = "0"
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.entry.request",
        Path = $"{ResourceName}.entry.request",
        Max = "0"
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.entry.response",
        Path = $"{ResourceName}.entry.response",
        Max = "0"
      });

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = $"{ResourceName}.signature",
        Path = $"{ResourceName}.signature",
        Max = "0"
      });

      return Def;

    }
  }
}
