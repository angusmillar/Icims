using System;
using System.Collections.Generic;
using System.Text;
using Icims.Common.Models.Icims;
using Icims.Common.Models.Pyrohealth;
using Icims.Common.Tools;
using Hl7.Fhir.Model;

namespace Icims.Profile.ExampleGen
{
  public abstract class ExampleBase
  {
    public abstract T GetResource<T>() where T : Resource;
    public abstract Resource GetResource();
  }
}