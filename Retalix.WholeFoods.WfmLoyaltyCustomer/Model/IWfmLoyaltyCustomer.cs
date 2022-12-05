
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.Model
{
    public interface IWfmLoyaltyCustomer
    {
        int Id { get; set; }
        string Store { get; set; }
        string Customer { get; set; }
        string Mobile { get; set; }
        string Address { get; set; }
        string LoyaltyCode { get; set; }
    }
}
