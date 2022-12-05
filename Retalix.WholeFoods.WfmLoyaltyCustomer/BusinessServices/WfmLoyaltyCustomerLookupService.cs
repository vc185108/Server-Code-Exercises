using Common.Logging;
using Retalix.StoreServices.Model.Infrastructure.Service;
using Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer;
using Retalix.WholeFoods.Common.Services;
using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;
using System.Collections.Generic;
using System.Linq;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.BusinessServices
{
    public class WfmLoyaltyCustomerLookupService : BusinessServiceBase<WfmLoyaltyCustomerLookupRequest, WfmLoyaltyCustomerLookupResponse>
    {
        private readonly IWfmLoyaltyCustomerLookup _loyaltyCustomerLookup;
        private IList<IWfmLoyaltyCustomer> _loyaltyCustomerResponse;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public WfmLoyaltyCustomerLookupService(IWfmLoyaltyCustomerLookup loyaltyCustomerLookup)
        {
            _loyaltyCustomerLookup = loyaltyCustomerLookup;
        }
        protected override void DoExecute()
        {
            _loyaltyCustomerResponse = new List<IWfmLoyaltyCustomer>();
            if (Request.SearchCriteria != null)
            {
                if (Request.SearchCriteria.Id>0)
                {
                    _loyaltyCustomerResponse.Add(_loyaltyCustomerLookup.GetLoyaltyCustomerById(Request.SearchCriteria.Id));
                }
                else
                {
                    _loyaltyCustomerResponse = _loyaltyCustomerLookup.FindLoyaltyCustomers(Request.SearchCriteria);
                }
            }

            else
            {
                _loyaltyCustomerResponse = _loyaltyCustomerLookup.GetAllLoyaltyCustomers();
            }
        }

        protected override IDocumentResponse BuildResponse(WfmLoyaltyCustomerLookupResponse lookupResponse)
        {
            base.BuildResponse(lookupResponse);
            if (_loyaltyCustomerResponse.Any())
            {
                lookupResponse.WfmLoyaltyCustomer = _loyaltyCustomerResponse.Select(ConvertFromConcreteToDto).ToArray();
            }
            //lookupResponse.Header = new RetalixCommonHeaderType
            //{
            //    Response = new RetalixResponseCommonData
            //    {
            //        ResponseCode = "OK",
            //        RequestID = Request.Header.MessageId.Value
            //    }
            //};

            return new DocumentResponse(lookupResponse);
        }
        private WfmLoyaltyCustomerType ConvertFromConcreteToDto(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            return new WfmLoyaltyCustomerType
            {
                Store = loyaltyCustomer.Store,
                Customer = loyaltyCustomer.Customer,
                Mobile = loyaltyCustomer.Mobile,
                Address = loyaltyCustomer.Address,
                LoyaltyCode = loyaltyCustomer.LoyaltyCode,
                Id=loyaltyCustomer.Id
            };
        }

    }
}
