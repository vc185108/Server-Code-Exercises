using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer;
using System.Collections.Generic;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.Model
{
    public interface IWfmLoyaltyCustomerDAO : IMovableDao
    {
        void AddLoyaltyCustomer(IWfmLoyaltyCustomer loyaltyCustomers);
        void UpdateLoyaltyCustomer(IWfmLoyaltyCustomer loyaltyCustomers);
        void DeleteLoyaltyCustomer(IWfmLoyaltyCustomer loyaltyCustomers);
        void AddOrUpdate(IWfmLoyaltyCustomer loyaltyCustomer);
        IList<IWfmLoyaltyCustomer> GetAllLoyaltyCustomers();
        IWfmLoyaltyCustomer GetLoyaltyCustomerById(int id);
        IList<IWfmLoyaltyCustomer> FindLoyaltyCustomers(SearchCriteriaType searchCriteriaType);
    }
}
