using Icims.Common.Tools;

namespace Icims.Common.Models.BusinessModel
{

  public enum StatusCode
  {
    [EnumLiteral("ok")]
    ok,
    [EnumLiteral("error")]
    error,
    [EnumLiteral("queue")]
    queue
  };

  public enum PostActionType
  {
    [EnumLiteral("addpatient")]
    Add,
    [EnumLiteral("updatepatient")]
    Update,
    [EnumLiteral("mergepatient")]
    Merge
  };

  public enum Gender
  {
    [EnumLiteral("M")]
    Male,
    [EnumLiteral("F")]
    Female,
    [EnumLiteral("O")]
    Other,
    [EnumLiteral("U")]
    Unknown
  };

  public enum AddressType
  {
    [EnumLiteral("1")]
    Business,
    [EnumLiteral("2")]
    MailingAddress,
    [EnumLiteral("3")]
    TemporaryAddress,
    [EnumLiteral("4")]
    ResidentialHome,
    [EnumLiteral("9")]
    NotSpecified
  };

  /**
   * Enum of all knowen PhoneUse at RMH, Component 2
   * @readonly
   * @enum {string}
  */
  public enum PhoneUseType
  {
    [EnumLiteral("ASN")]
    AnsweringService,
    [EnumLiteral("BPN")]
    Beeper,
    [EnumLiteral("NET")]
    EmailAddress,
    [EnumLiteral("EMR")]
    Emergency,
    [EnumLiteral("ORN")]
    Other,
    [EnumLiteral("PRN")]
    Primary,
    [EnumLiteral("TTY")]
    Teletype,
    [EnumLiteral("VHN")]
    Vacation,
    [EnumLiteral("WPN")]
    Work
  };

  /**
    * Enum of all knowen PhoneUse at RMH, Component 3
    * @readonly
    * @enum {string}
   */
  public enum PhoneEquipmentType
  {
    [EnumLiteral("FX")]
    FacsimileMachine,
    [EnumLiteral("INTERNET")]
    Internet,
    [EnumLiteral("CP")]
    Mobile,
    [EnumLiteral("MD")]
    Modem,
    [EnumLiteral("BP")]
    Pager,
    [EnumLiteral("PH")]
    Telephone,
    [EnumLiteral("TTY")]
    Teletype
  };

}
