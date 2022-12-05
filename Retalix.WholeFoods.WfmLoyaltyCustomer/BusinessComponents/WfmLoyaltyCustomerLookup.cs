using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;
using System.Collections.Generic;
using Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.BusinessComponents
{
    public class WfmLoyaltyCustomerLookup : IWfmLoyaltyCustomerLookup
    {
        private readonly IWfmLoyaltyCustomerDAO _loyaltyCustomerDao;
        public WfmLoyaltyCustomerLookup(IWfmLoyaltyCustomerDAO loyaltyCustomerDao)
        {
            _loyaltyCustomerDao = loyaltyCustomerDao;
        }
        public IList<IWfmLoyaltyCustomer> GetAllLoyaltyCustomers()
        {
            return _loyaltyCustomerDao.GetAllLoyaltyCustomers();
        }
        public IWfmLoyaltyCustomer GetLoyaltyCustomerById(int id)
        {
            return _loyaltyCustomerDao.GetLoyaltyCustomerById(id);
        }
        public IList<IWfmLoyaltyCustomer> FindLoyaltyCustomers(SearchCriteriaType searchCriteriaType)
        {
            return _loyaltyCustomerDao.FindLoyaltyCustomers(searchCriteriaType);
        }
    }
}
