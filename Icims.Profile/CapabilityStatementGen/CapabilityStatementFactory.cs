using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace Icims.Profile.CapabilityStatementGen
{
  public static class CapabilityStatementFactory
  {
    public static List<Resource> GetAllResources()
    {
      List<Resource> Result = new List<Resource>();
      Result.Add(GetCapabilityStatement());
      return Result;

    }

    public static CapabilityStatement GetCapabilityStatement()
    {
      var Cap = new IcimsCapabilityStatement();
      return Cap.GetResource<CapabilityStatement>();
    }

  }
}
