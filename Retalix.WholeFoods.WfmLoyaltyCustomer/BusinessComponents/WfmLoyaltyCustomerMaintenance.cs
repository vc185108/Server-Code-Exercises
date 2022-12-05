using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.BusinessComponents
{
    public class WfmLoyaltyCustomerMaintenance : IWfmLoyaltyCustomerMaintenance
    {
        private readonly IWfmLoyaltyCustomerDAO _loyaltyCustomerDao;

        public WfmLoyaltyCustomerMaintenance(IWfmLoyaltyCustomerDAO loyaltyCustomerDao)
        {
            _loyaltyCustomerDao = loyaltyCustomerDao;
        }

        public void Add(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            _loyaltyCustomerDao.AddLoyaltyCustomer(loyaltyCustomer);
        }

        public void Update(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            _loyaltyCustomerDao.UpdateLoyaltyCustomer(loyaltyCustomer);
        }
        public void Delete(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            _loyaltyCustomerDao.DeleteLoyaltyCustomer(loyaltyCustomer);
        }
        public void AddOrUpdate(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            _loyaltyCustomerDao.AddOrUpdate(loyaltyCustomer);
        }
    }
}
