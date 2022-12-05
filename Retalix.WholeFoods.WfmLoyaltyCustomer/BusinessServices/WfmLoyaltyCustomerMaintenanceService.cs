using Common.Logging;
using Retalix.Contracts.Generated.Common;
using Retalix.StoreServices.Model.Infrastructure.Exceptions;
using Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer;
using Retalix.WholeFoods.Common.Exceptions;
using Retalix.WholeFoods.Common.Services;
using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.BusinessServices
{
    public class WfmLoyaltyCustomerMaintenanceService : BusinessServiceBase<WfmLoyaltyCustomerMaintenanceRequest, WfmLoyaltyCustomerMaintenanceResponse>
    {
        private readonly IWfmLoyaltyCustomerMaintenance _loyaltyCustomerMaintenance;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private IWfmLoyaltyCustomer loyaltyCustomer;
        private readonly IWfmLoyaltyCustomerFactory _loyaltyCustomerFactory;
        public WfmLoyaltyCustomerMaintenanceService(IWfmLoyaltyCustomerMaintenance loyaltyCustomerMaintenance, IWfmLoyaltyCustomerFactory loyaltyCustomerFactory)
        {
            _loyaltyCustomerMaintenance = loyaltyCustomerMaintenance;
            _loyaltyCustomerFactory = loyaltyCustomerFactory;
        }
        protected override void DoExecute()
        {
            var loyaltyCustomers = Request.WfmLoyaltyCustomer;
            foreach (var loyaltyCustomer in loyaltyCustomers)
            {
                HandleLoyaltyCustomerMaintenance(loyaltyCustomer);
            }
        }

        private void HandleLoyaltyCustomerMaintenance(WfmLoyaltyCustomerType loyaltyCustomerType)
        {
            loyaltyCustomer = _loyaltyCustomerFactory.Create();
            MapContractToModel(loyaltyCustomerType, loyaltyCustomer);
            switch (loyaltyCustomerType.Action)
            {
                case ActionTypeCodes.Add:
                    ValidateBeforeSaving(loyaltyCustomer);
                    _loyaltyCustomerMaintenance.Add(loyaltyCustomer);
                    break;
                case ActionTypeCodes.AddOrUpdate:
                    ValidateBeforeSaving(loyaltyCustomer);
                    _loyaltyCustomerMaintenance.AddOrUpdate(loyaltyCustomer);
                    break;
                case ActionTypeCodes.Update:
                    ValidateBeforeSaving(loyaltyCustomer);
                    _loyaltyCustomerMaintenance.Update(loyaltyCustomer);
                    break;
                case ActionTypeCodes.Delete:
                    ValidateBeforeDeleting(loyaltyCustomer);
                    _loyaltyCustomerMaintenance.Delete(loyaltyCustomer);
                    break;
                default:
                    throw new NotSupportedActionException("Add, Delete, Update, AddOrUpdate");
            }

        }
        private void ValidateBeforeDeleting(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            if (loyaltyCustomer.Id==0)
            {
                Log.Error(string.Format("There is no loyality customer to delete."));
                throw new RequiredItemFieldsMissingException("Id");
            }
        }
        private void ValidateBeforeSaving(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            if (loyaltyCustomer == null)
            {
                Log.Error(string.Format("There is no loyality customer data to save."));
                throw new BusinessException("There is no loyality customer data to save.");
            }
            if (loyaltyCustomer.Id==0)
            {
                Log.Error(string.Format("Id data is empty."));
                throw new RequiredItemFieldsMissingException("Id");
            }
            if (string.IsNullOrEmpty(loyaltyCustomer.Store))
            {
                Log.Error(string.Format("Store data is empty."));
                throw new RequiredItemFieldsMissingException("Store");
            }
            if (string.IsNullOrEmpty(loyaltyCustomer.Customer))
            {
                Log.Error(string.Format("Customer data is empty."));
                throw new RequiredItemFieldsMissingException("Customer");
            }
            if (string.IsNullOrEmpty(loyaltyCustomer.LoyaltyCode))
            {
                Log.Error(string.Format("Loyality code value is empty"));
                throw new RequiredItemFieldsMissingException("LoyaltyCode");
            }

        }
        private void MapContractToModel(WfmLoyaltyCustomerType loyaltyCustomerTypeContract, IWfmLoyaltyCustomer loyaltyCustomer)
        {
            loyaltyCustomer.Store = loyaltyCustomerTypeContract.Store;
            loyaltyCustomer.Customer = loyaltyCustomerTypeContract.Customer;
            loyaltyCustomer.Mobile = loyaltyCustomerTypeContract.Mobile;
            loyaltyCustomer.Address = loyaltyCustomerTypeContract.Address;
            loyaltyCustomer.LoyaltyCode = loyaltyCustomerTypeContract.LoyaltyCode;
            loyaltyCustomer.Id = loyaltyCustomerTypeContract.Id;
        }
    }
}
