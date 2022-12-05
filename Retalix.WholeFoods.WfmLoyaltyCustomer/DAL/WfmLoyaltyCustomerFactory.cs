using Retalix.WholeFoods.WfmLoyaltyCustomer.BusinessComponents;
using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.DAL
{
    public class WfmLoyaltyCustomerFactory : IWfmLoyaltyCustomerFactory
    {
        public IWfmLoyaltyCustomer Create()
        {
            return new WfmLoyaltyCustomers();
        }
    }
}
