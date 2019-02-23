using System.Collections.Generic;
using Icims.Common.Tools;

namespace Icims.Common.Models.IcimsInterface
{
  public class Update : AddUpdateBase, IValueDictionary
  {
    /** @property {string} action - the ICIMS action string 'addpatient', 'updatepatient', or 'mergepatient' */
    public override string action => BusinessModel.PostActionType.Update.GetLiteral();
   
  }
}
