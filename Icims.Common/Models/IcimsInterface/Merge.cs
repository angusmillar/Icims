using System;
using System.Collections.Generic;
using System.Text;
using Icims.Common.Tools;

namespace Icims.Common.Models.IcimsInterface
{
  public class Merge : IcimsModelBase, IValueDictionary
  {
    /** @property {string} action - the ICIMS action string 'addpatient', 'updatepatient', or 'mergepatient' */
    public override string action => BusinessModel.PostActionType.Merge.GetLiteral();

    /** @property {string} prior_ur - prior patient UR number (mandatory) */
    public string prior_ur { get; set; }
      
    /** @property {string} assigning_authority - prior institution id */
    public string prior_assigning_authority { get; set; }

    public override Dictionary<string, string> GetValueDictionary()
    {
      var result = base.GetValueDictionary();
      //Note 'action' is added by the base
      CustomEncode("prior_ur", this.prior_ur);
      CustomEncode("prior_assigning_authority", this.prior_assigning_authority);     
      return result;
    }
  }
}
