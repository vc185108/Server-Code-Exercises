using ProtoBuf;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.DMS
{
    [ProtoContract]
    public class WfmLoyaltyCustomerDtoDms : INamedObject
    {
        [ProtoMember(2)]
        public int Id { get; set; }
        [ProtoMember(3)]
        public string Store { get; set; }
        [ProtoMember(4)]
        public string Customer { get; set; }
        [ProtoMember(5)]
        public string Mobile { get; set; }
        [ProtoMember(6)]
        public string Address { get; set; }
        [ProtoMember(7)]
        public string LoyaltyCode { get; set; }

        public string EntityName
        {
            get { return "WfmLoyaltyCustomerDtoDMS"; }
            set { }
        }
    }
}
