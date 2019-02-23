using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.BusinessModel
{
  
  public class DomainModel
  {
    public DomainModel()
    {
      this.HL7Message = new HL7Message();
      this.Patient = new Patient();
      this.Doctor = new Doctor();
    }

    public PostActionType Action { get; set; }
    public HL7Message HL7Message { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }


  }
}
