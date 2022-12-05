using Retalix.StoreServices.Model.Infrastructure.Exceptions;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.Exception
{
    public class WfmLoyaltyCustomerDataNotFoundException:BusinessException
    {
        private const string errorCode = "WfmLoyaltyCustomerDataNotFound";
        public WfmLoyaltyCustomerDataNotFoundException(string errorMessage) : base(errorMessage, errorCode) { }
    }
}
