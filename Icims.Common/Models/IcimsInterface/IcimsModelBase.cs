using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.IcimsInterface
{
  public abstract class IcimsModelBase
  {
    private const string EmptyStringCode = "empty_str"; 
    protected Dictionary<string, string> ValueDictionay;

    public IcimsModelBase()
    {
      this.ValueDictionay = new Dictionary<string, string>();
    }

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

    /** @property {string} MedicareNumberValue - patient's Medicare number 10 or 11 digits */
    public string MedicareNumberValue { get; set; }
    
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
      this.ValueDictionay = new Dictionary<string, string>();
               
      CustomEncode("action", this.action);
      CustomEncode("msgid", this.msgid);
      CustomEncode("msg_datetime", this.msg_datetime);
      CustomEncode("ur_num", this.ur_num);
      CustomEncode("assigning_authority", this.assigning_authority);
      CustomEncode("MedicareNumberValue", this.MedicareNumberValue);
      CustomEncode("fname", this.fname);
      CustomEncode("surname", this.surname);
      CustomEncode("dob", this.dob);
      CustomEncode("sex", this.sex);
      CustomEncode("addr_line_1", this.addr_line_1);
      CustomEncode("addr_line_2", this.addr_line_2);
      CustomEncode("suburb", this.suburb);
      CustomEncode("state", this.state);
      CustomEncode("postcode", this.postcode);
      CustomEncode("phone", this.phone);
      CustomEncode("mobile", this.mobile);
      CustomEncode("marital_status", this.marital_status);
      CustomEncode("language", this.language);
      CustomEncode("aboriginality", this.aboriginality);
      return this.ValueDictionay;
    }


    protected void CustomEncode(string Name, string Value)
    {
      if (Value != null)
      {
        if (Value == "\"\"")
        {
          //Note ICIMS is requiring that HL7 Null e.g |""| is to be sent as "empty_str";
          this.ValueDictionay.Add(Name, EmptyStringCode);
        }
        else
        {
          this.ValueDictionay.Add(Name, Value);
        }
      }
    }
  }
}
