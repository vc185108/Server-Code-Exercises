using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.DMS
{
    class WfmLoyaltyCustomerServiceResolver : ICompatibilityMovableServicesResolver
    {
        private readonly IWfmLoyaltyCustomerDAO _loyaltyCustomerDAO;

        public WfmLoyaltyCustomerServiceResolver(IWfmLoyaltyCustomerDAO loyaltyCustomerDAO)
        {
            _loyaltyCustomerDAO = loyaltyCustomerDAO;
        }

        public IMovableFormatter Formatter { get { return null; } }

        public IMovableDao MovableDao { get { return _loyaltyCustomerDAO; } }

        public IEntityToDtoMapper EntityToDtoMapper { get { return new WfmLoyaltyCustomerDtoMapper(); } }

        public string ComponentName { get { return "WfmRetail"; } }
    }
}
