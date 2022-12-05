using Retalix.StoreServices.Model.Infrastructure.Exceptions;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.Exception
{
    public class WfmLoyaltyCustomerExistsException : BusinessException
    {
        private const string errorCode = "WfmLoyaltyCustomerExistsException";
        public WfmLoyaltyCustomerExistsException(string errorMessage) : base(errorMessage, errorCode) { }
    }
}
