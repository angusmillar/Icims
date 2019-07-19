using System;
using System.Collections.Generic;
using System.Text;
using Icims.Profile.Annotation;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Icims.Common.Tools;
using Hl7.Fhir.Model;


namespace Icims.Profile.ImplementationGuideGen
{
  public class IcimsImplementationGuide : BaseIcimsResource
  {
    private readonly List<ImplementationGuide.ResourceComponent> ResourceComponentList;
    public IcimsImplementationGuide(List<ImplementationGuide.ResourceComponent> ResourceComponentList) :
      base(ResourceType.ImplementationGuide)
    {
      this.ResourceComponentList = ResourceComponentList;
    }

    public override ImplementationGuide GetResource<ImplementationGuide>()
    {
      return GetResource() as ImplementationGuide;
    }

    public override Resource GetResource()
    {
      var Ig = new ImplementationGuide();

      Ig.AddAnnotation(new IcimsResourceAnnotation(this.ResourceType, "Ig"));

      Ig.Id = IcimsInfo.IcimsCode;
      Ig.Url = $"{IcimsInfo.IcimsProfileUrlBase}/ImplementationGuide/{IcimsInfo.IcimsCode}";
      Ig.Version = "1.0.0";
      Ig.Name = $"{StringSupport.FirstCharToUpper(IcimsInfo.IcimsCode)} Implementation Guide";
      Ig.Status = PublicationStatus.Draft;
      Ig.Experimental = true;
      Ig.DateElement = new FhirDateTime(new DateTimeOffset(2019, 07, 16, 09, 12, 00, new TimeSpan(10, 0, 0)));
      Ig.Publisher = PyrohealthInfo.PublisherName;
      Ig.Contact = new List<ContactDetail>()
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
      Ig.FhirVersion = "3.0.1";
      Ig.Package = new List<ImplementationGuide.PackageComponent>();
      Ig.Package.Add(new ImplementationGuide.PackageComponent()
      {
        Name = "base",
        Description = $"Guidance on the implementation of {StringSupport.FirstCharToUpper(IcimsInfo.IcimsCode)}'s FHIR inferfaces.",
        Resource = this.ResourceComponentList
      });

      Ig.Page = new ImplementationGuide.PageComponent()
      {
        Source = "index.html",
        Title = IcimsInfo.IcimsCode.ToUpper(),
        Kind = ImplementationGuide.GuidePageKind.Page
      };

      return Ig;
    }
  }
}
