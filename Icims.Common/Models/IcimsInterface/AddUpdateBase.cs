using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.IcimsInterface
{
  public abstract class AddUpdateBase : IcimsModelBase
  {
    //public override string action { get => BusinessModel.PostActionType.Add.GetLiteral(); }
    public abstract override string action { get; }

    /** @property {string} gp_fname - usual GP first name*/
    public string gp_fname { get; set; }

    /** @property {string} gp_surname - usual GP surname name*/
    public string gp_surname { get; set; }

    /** @property {string} gp_addr_line_1 - GP street address line 1*/
    public string gp_addr_line_1 { get; set; }

    /** @property {string} gp_addr_line_2 - GP street address line 2*/
    public string gp_addr_line_2 { get; set; }
    
    /** @property {string} gp_suburb - usual GP suburb*/    
    public string gp_suburb { get; set; }

    /** @property {string} gp_state - usual GP state*/    
    public string gp_state { get; set; }

    /** @property {string} gp_postcode - usual GP post code*/
    public string gp_postcode { get; set; }

    /** @property {string} gp_email - usual GP email*/
    public string gp_email { get; set; }

    /** @property {string} gp_fax - usual GP fax number*/
    public string gp_fax { get; set; }

    public override Dictionary<string, string> GetValueDictionary()
    {
      var result = base.GetValueDictionary();
      //Note 'action' is added by the base
      CustomEncode("gp_fname", this.gp_fname);
      CustomEncode("gp_surname", this.gp_surname);
      CustomEncode("gp_addr_line_1", this.gp_addr_line_1);
      CustomEncode("gp_addr_line_2", this.gp_addr_line_2);
      CustomEncode("gp_suburb", this.gp_suburb);
      CustomEncode("gp_state", this.gp_state);
      CustomEncode("gp_postcode", this.gp_postcode);
      CustomEncode("gp_email", this.gp_email);
      CustomEncode("gp_fax", this.gp_fax);
      return result;
    }
    

  }
}
