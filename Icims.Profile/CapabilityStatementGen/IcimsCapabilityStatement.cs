using System;
using System.Collections.Generic;
using System.Text;
using Icims.Profile.Annotation;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;

using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Icims.Profile.CapabilityStatementGen
{
  public class IcimsCapabilityStatement : BaseIcimsResource
  {
    public IcimsCapabilityStatement() :
      base(ResourceType.CapabilityStatement)
    { }

    public override CapabilityStatement GetResource<CapabilityStatement>()
    {
      return GetResource() as CapabilityStatement;
    }

    public override Resource GetResource()
    {
      var Cap = new CapabilityStatement();
      Cap.Id = $"{IcimsInfo.IcimsCode}-capability";
      Cap.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, Cap.Id));
      Cap.Url = $"{IcimsInfo.IcimsProfileUrlBase}/CapabilityStatement/{Cap.Id}";
      Cap.Version = "1.0.0";
      Cap.Name = $"{Icims.Common.Tools.StringSupport.FirstCharToUpper(IcimsInfo.IcimsCode)} {this.ResourceName}";
      Cap.Status = PublicationStatus.Draft;
      Cap.Experimental = true;
      Cap.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 16, 09, 12, 00, new TimeSpan(10, 0, 0)));
      Cap.Publisher = PyrohealthInfo.PublisherName;
      Cap.Contact = new List<ContactDetail>()
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
      Cap.Description = new Markdown($"The {this.ResourceName} for the {Icims.Common.Tools.StringSupport.FirstCharToUpper(IcimsInfo.IcimsCode)} interface");
      Cap.Kind = CapabilityStatement.CapabilityStatementKind.Instance;
      Cap.FhirVersion = "3.0.1";
      Cap.AcceptUnknown = CapabilityStatement.UnknownContentCode.Extensions;
      Cap.Format = new List<string>() { "json" };
      Cap.Rest = new List<CapabilityStatement.RestComponent>();
      Cap.Messaging = new List<CapabilityStatement.MessagingComponent>()
      {
        new CapabilityStatement.MessagingComponent()
        {
          Endpoint= new List<CapabilityStatement.EndpointComponent>()
          {
            new CapabilityStatement.EndpointComponent()
            {
               Protocol = new Coding("http://hl7.org/fhir/message-transport", "http"),
               Address = IcimsInfo.IcimsBaseUrl
            }
          },
          SupportedMessage = new List<CapabilityStatement.SupportedMessageComponent>()
          {
             new CapabilityStatement.SupportedMessageComponent()
             {
               Mode = CapabilityStatement.EventCapabilityMode.Receiver,
               Definition = new ResourceReference($"{IcimsInfo.IcimsProfileUrlBase}/MessageDefinition/{IcimsInfo.IcimsCode}-diagnosticreport-provide")
             }
          },
          Event = new List<CapabilityStatement.EventComponent>()
          {
            new CapabilityStatement.EventComponent()
            {
              Code = new Coding("http://hl7.org/fhir/message-events", "diagnosticreport-provide", "diagnosticreport-provide"),
              Category = MessageSignificanceCategory.Notification,
              Mode = CapabilityStatement.EventCapabilityMode.Receiver,
              Focus = ResourceType.DiagnosticReport,
              Request = new ResourceReference($"{IcimsInfo.IcimsProfileUrlBase}/{ResourceType.StructureDefinition.GetLiteral()}/{IcimsInfo.IcimsCode}-{ResourceType.Bundle}-diagnosticreport-provide-request"),
              Response = new ResourceReference($"{IcimsInfo.IcimsProfileUrlBase}/{ResourceType.StructureDefinition.GetLiteral()}/{IcimsInfo.IcimsCode}-{ResourceType.OperationOutcome}-diagnosticreport-provide-response"),
              Documentation = "The sender will send one FHIR Bundle message containing a collection of FHIR resources to the ICIMS receiver endpoint. " +
              "Once successfully processed ICIMS will return a HTTP status code of ‘204 No Content’ and no data in the HTTP body. " +
              "This then completes a successful message delivery and allows the next sequential FHIR Bundle message to be sent from HL7 Connect." +
              "If an error is encountered by ICIMS in processing the FHIR Bundle message then ICIMS will reply with a HTTP status code between the " +
              "range of 400 to 500 and should also supply a FHIR OperationOutcome resource with additional information"
            }
          }
        }

      };

      return Cap;
    }
  }
}
