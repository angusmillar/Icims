using System;
using System.Collections.Generic;
using System.Text;
using Icims.Common.Models.Icims;
using Icims.Profile.Annotation;
using Icims.Common.Models.Pyrohealth;
using Icims.Common.Tools;
using Hl7.Fhir.Model;


namespace Icims.Profile.StructureDefinitionGen
{
  public class DiagnosticReportProfile : BaseStructureDefinitionProfile
  {
    public DiagnosticReportProfile() :
      base(ResourceType.DiagnosticReport)
    { }
    public override Resource GetResource()
    {
      Def.Version = "0.0.1";
      Def.Status = PublicationStatus.Draft;
      Def.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 16, 09, 12, 00, new TimeSpan(10, 0, 0)));
      Def.BaseDefinition = "http://hl7.org.au/fhir/StructureDefinition/au-diagnosticreport";

      Def.Differential.Element.Add(new ElementDefinition()
      {
        ElementId = ResourceName,
        Path = ResourceName,
        Short = $"{IcimsInfo.IcimsCode.ToUpper()} {ResourceName} Resource"
      });



      return Def;
    }
  }
}