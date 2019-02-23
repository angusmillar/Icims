using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.IcimsInterface
{
  public abstract class IcimsModelBase
  {
    /** @property {string} action - the ICIMS action string 'addpatient', 'updatepatient' */
    public abstract string action { get; }

    /** @property {string} msgid - unique message id sent by the HL7 caller */
    public string msgid { get; set; }

    /** @property {string} msg_datetime - datetime string sent by the HL7 caller ISO8601 format */
    public string msg_datetime { get; set; }

    /** @property {string} ur_num - patient UR number */
    public string ur_num { get; set; }

    /** @property {string} assigning_authority - institution id */
    public string assigning_authority { get; set; }   

    /** @property {string} fname - patient first name */
    public string fname { get; set; }

    /** @property {string} surname - patient surname */
    public string surname { get; set; }

    /** @property {string} dob - patient DOB ISO8601 format */
    public string dob { get; set; }

    /** @property {string} sex - patient sex */
    public string sex { get; set; }

    /** @property {string} addr_line_1 - Patient's address line 1 */
    public string addr_line_1 { get; set; }

    /** @property {string} addr_line_2 - Patient's address line 2 */
    public string addr_line_2 { get; set; }

    /** @property {string} suburb - Patient's suburb name */
    public string suburb { get; set; }

    /** @property {string} state - Patient's state */
    public string state { get; set; }

    /** @property {string} postcode - Patient's postcode */
    public string postcode { get; set; }

    /** @property {string} phone - Patient home phone number */
    public string phone { get; set; }

    /** @property {string} mobile - Patient mobile number */
    public string mobile { get; set; }

    /** @property {string} marital_status - Patient marital status */
    public string marital_status { get; set; }

    /** @property {string} language - Patient's language code*/
    public string language { get; set; }

    /** @property {string} aboriginality - The Patient's ATSI code value*/
    public string aboriginality { get; set; }


    public virtual Dictionary<string, string> GetValueDictionary()
    {
      var result = new Dictionary<string, string>();
      result.Add("action", this.action);
      result.Add("msgid", this.msgid);
      result.Add("msg_datetime", this.msg_datetime);
      result.Add("ur_num", this.ur_num);
      result.Add("assigning_authority", this.assigning_authority);
      result.Add("fname", this.fname);
      result.Add("surname", this.surname);
      result.Add("dob", this.dob);
      result.Add("sex", this.sex);
      result.Add("addr_line_1", this.addr_line_1);
      result.Add("addr_line_2", this.addr_line_2);
      result.Add("suburb", this.suburb);
      result.Add("state", this.state);
      result.Add("postcode", this.postcode);
      result.Add("phone", this.phone);
      result.Add("mobile", this.mobile);
      result.Add("marital_status", this.marital_status);
      result.Add("language", this.language);
      result.Add("aboriginality", this.aboriginality);
      return result;
    }
  }
}
