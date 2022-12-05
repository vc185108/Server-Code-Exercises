
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.Model
{
    public interface IWfmLoyaltyCustomerMaintenance
    {
        void Add(IWfmLoyaltyCustomer loyaltyCustomer);
        void Update(IWfmLoyaltyCustomer loyaltyCustomer);
        void Delete(IWfmLoyaltyCustomer loyaltyCustomer);
        void AddOrUpdate(IWfmLoyaltyCustomer loyaltyCustomer);
    }
}
