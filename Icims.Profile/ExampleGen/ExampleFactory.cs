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
      return Result;

    }

    public static Patient GetPatient()
    {
      var example = new PatientExample();
      return example.GetResource<Patient>();
    }

  }
}
