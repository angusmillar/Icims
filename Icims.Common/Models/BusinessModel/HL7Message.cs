using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.BusinessModel
{
  public class HL7Message
  {
    public string MessageControlId { get; set; }
    public DateTimeOffset MessageDateTime { get; set; }
  }
}
