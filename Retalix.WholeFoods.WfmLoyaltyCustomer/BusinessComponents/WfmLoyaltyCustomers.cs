using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.BusinessComponents
{
    public class WfmLoyaltyCustomers:IWfmLoyaltyCustomer
    {
        public virtual int Id { get; set; }
        public virtual string Store { get; set; }
        public virtual string Customer { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Address { get; set; }
        public virtual string LoyaltyCode { get; set; }
    }
}
