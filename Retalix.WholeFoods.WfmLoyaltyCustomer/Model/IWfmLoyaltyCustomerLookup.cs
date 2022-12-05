using Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer;
using System.Collections.Generic;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.Model
{
    public interface IWfmLoyaltyCustomerLookup
    {
        IList<IWfmLoyaltyCustomer> GetAllLoyaltyCustomers();
        IWfmLoyaltyCustomer GetLoyaltyCustomerById(int id);
        IList<IWfmLoyaltyCustomer> FindLoyaltyCustomers(SearchCriteriaType searchCriteriaType);
    }
}
