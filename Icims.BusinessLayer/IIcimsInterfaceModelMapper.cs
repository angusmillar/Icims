using Icims.Common.Models.BusinessModel;
using Icims.Common.Models.IcimsInterface;

namespace Icims.BusinessLayer
{
  public interface IIcimsInterfaceModelMapper
  {
    Add MapToAdd(DomainModel Domain);
    Update MapToUpdate(DomainModel Domain);
  }
}