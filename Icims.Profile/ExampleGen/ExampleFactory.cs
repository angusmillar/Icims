using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Icims.Profile.ExampleGen
{
  public static class ExampleFactory
  {
    public static List<Resource> GetAllResources()
    {
      List<Resource> Result = new List<Resource>();
      Result.Add(GetPatient());
      Result.Add(GetOrganizationIcims());
      Result.Add(GetOrganizationSah());
      Result.Add(GetObservation());
      Result.Add(GetDiagnosticReportExample());
      Result.Add(GetMessageBundleExample());
      Result.Add(GetProvenanceExample());
      return Result;
    }
    public static Patient GetPatient()
    {
      var example = new PatientExample();
      return example.GetResource<Patient>();
    }
    public static Organization GetOrganizationIcims()
    {
      var example = new OrganizationExampleIcims();
      return example.GetResource<Organization>();
    }
    public static Organization GetOrganizationSah()
    {
      var example = new OrganizationExampleSah();
      return example.GetResource<Organization>();
    }
    public static Observation GetObservation()
    {
      var example = new ObservationExampleString();
      return example.GetResource<Observation>();
    }
    public static DiagnosticReport GetDiagnosticReportExample()
    {
      var example = new DiagnosticReportExample();
      return example.GetResource<DiagnosticReport>();
    }
    public static Bundle GetMessageBundleExample()
    {
      var example = new BundleMessageExample();
      return example.GetResource<Bundle>();
    }
    public static Provenance GetProvenanceExample()
    {
      var example = new ProvenanceExample();
      return example.GetResource<Provenance>();
    }


  }
}
