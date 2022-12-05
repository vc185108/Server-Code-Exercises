using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.DAL.DTO
{
    [Serializable]
    class WfmLoyaltyCustomerDto : IMovable
    {
        public virtual string FromUnitOfMeasure { get; set; }
        public virtual string ToUnitOfMeasure { get; set; }
        public virtual int Id { get; set; }
        public virtual string Store { get; set; }
        public virtual string Customer { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Address { get; set; }
        public virtual string LoyaltyCode { get; set; }

        public virtual string EntityName
        {
            get { return "WfmLoyaltyCustomerDtoDMS"; }
        }
    }
}
