using NHibernate;
using NHibernate.Criterion;
using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.Exceptions;
using Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer;
using Retalix.WholeFoods.WfmLoyaltyCustomer.Exception;
using Retalix.WholeFoods.WfmLoyaltyCustomer.Model;
using System.Collections.Generic;
using System.Linq;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.DAL
{
    public class WfmLoyaltyCustomerDAO:IWfmLoyaltyCustomerDAO
    {
        ISessionProvider<ISession> _sessionProvider;
        public WfmLoyaltyCustomerDAO(ISessionProvider<ISession> sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }
        #region ILoyaltyCustomer
        public void AddLoyaltyCustomer(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            if (GetLoyaltyCustomerById(loyaltyCustomer.Id) != null)
            {
                throw new WfmLoyaltyCustomerExistsException(string.Format(" Wfm Loyalty customer already exsists for Id {0} ", loyaltyCustomer.Id));
            }
            _sessionProvider.Session.Save(loyaltyCustomer);
            _sessionProvider.Session.Flush();
        }
        public void UpdateLoyaltyCustomer(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            var item = GetLoyaltyCustomerById(loyaltyCustomer.Id);
            if (item == null)
            {
                throw new BusinessException("Wfm loyalty Customer was not found. Please check input value.");
            }
            item.Customer = loyaltyCustomer.Customer;
            item.Mobile = loyaltyCustomer.Mobile;
            item.Address = loyaltyCustomer.Address;
            item.Store = loyaltyCustomer.Store;
            item.LoyaltyCode = loyaltyCustomer.LoyaltyCode;
            _sessionProvider.Session.SaveOrUpdate(item);
        }      
        public IList<IWfmLoyaltyCustomer> GetAllLoyaltyCustomers()
        {
            List<IWfmLoyaltyCustomer> loyaltyCustomers = _sessionProvider.Session.Query<IWfmLoyaltyCustomer>().ToList(); 
            return loyaltyCustomers;
            //var query = _sessionProvider.Session.GetNamedQuery("WfmLoyaltyCustomerAll");
            //return query.List<IWfmLoyaltyCustomer>();
        }
        public IWfmLoyaltyCustomer GetLoyaltyCustomerById(int id)
        {
            var query = _sessionProvider.Session.GetNamedQuery("WfmLoyaltyCustomerById");
            query.SetParameter("Id", id);
            return (IWfmLoyaltyCustomer)query.UniqueResult();
        }
        public void DeleteLoyaltyCustomer(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            var query = _sessionProvider.Session.GetNamedQuery("WfmLoyaltyCustomerById");
            query.SetParameter("Id", loyaltyCustomer.Id);
            var loyalCustomer = (IWfmLoyaltyCustomer)query.UniqueResult();
            if (loyalCustomer != null)
            {
                _sessionProvider.Session.Delete(loyalCustomer);
                _sessionProvider.Session.Flush();
            }
        }
        public void AddOrUpdate(IWfmLoyaltyCustomer loyaltyCustomer)
        {
            var loyaltyData = GetLoyaltyCustomerById(loyaltyCustomer.Id);
            if (loyaltyData != null)
            {
                UpdateLoyaltyCustomer(loyaltyCustomer);
            }
            else
            {
                AddLoyaltyCustomer(loyaltyCustomer);
            }
        }
        public IList<IWfmLoyaltyCustomer> FindLoyaltyCustomers(SearchCriteriaType searchCriteriaType)
        {
            var query = _sessionProvider.Session.GetNamedQuery("LoyaltyCustomerLookupByCriteria");
            query.SetParameter("store", searchCriteriaType.Store);
            query.SetParameter("customer", searchCriteriaType.Customer);
            query.SetParameter("loyaltyCode", searchCriteriaType.LoyaltyCode);
            var loyalityCustomerList= query.List<IWfmLoyaltyCustomer>();
            if (loyalityCustomerList.Any())
            {
                return loyalityCustomerList;
            }
            else
            {
               throw new WfmLoyaltyCustomerDataNotFoundException(string.Format("Wfm Loyalty customers not found.Please check input value."));
            }
        }
        #endregion

        #region DMS

        public void Add(IEnumerable<IMovable> movables)
        {
            foreach (var movable in movables)
            {
                _sessionProvider.Session.Save(movable);
            }
        }

        public void Update(IEnumerable<IMovable> movables)
        {
            movables.ToList().ForEach(_sessionProvider.Session.Update);
        }

        public void Delete(IEnumerable<IMovable> movables)
        {
            movables.ToList().ForEach(_sessionProvider.Session.Delete);
        }

        #endregion DMS
    }
}
