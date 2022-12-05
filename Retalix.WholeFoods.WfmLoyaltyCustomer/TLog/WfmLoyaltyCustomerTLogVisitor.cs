using Common.Logging;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects.RetalixExtension;
using Retalix.DPOS.SystemIntegrity;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using System;
using System.Collections.Generic;
using System.Xml;
namespace Retalix.WholeFoods.WfmLoyaltyCustomer.TLog
{
    public class WfmLoyaltyCustomerTLogVisitor : IRetailTransactionLogDocumentCreationVisitor
    {
        private DateTime transactionStartTime;
        private DateTime transactionEndTime;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WfmLoyaltyCustomerTLogVisitor));

        public void Visit(IRetailTransaction retailTransaction, IRetailTransactionLogDocumentWriter writer)
        {
            using (PerformanceLogger.CreateAndStart("Retalix.WholeFoods.WfmLoyaltyCustomer.TLog.WfmLoyaltyCustomerTransactionCalculateVisitor.Visit"))
            {
                 Logger.Debug("WfmLoyaltyCustomerTLogVisitor::Visit");
                 transactionStartTime = retailTransaction.StartTime;
                 transactionEndTime = retailTransaction.EndTime;
                 var transaction = (TransactionDomainSpecific)writer.ObjectContent;
                 transaction.Any = new List<XmlElement> { GetTimeDifference() };
                 writer.UpdateArtsTransaction(transaction);
            }
        }
        private XmlElement GetTimeDifference()
        {
            var extension = new R10Extension();
            var timeDiffXmlEle = extension.CreateXmlElement("TransactionTime");
            TimeSpan timeDifference = transactionEndTime - transactionStartTime;
            timeDiffXmlEle.InnerText = timeDifference.ToString();
            return timeDiffXmlEle;
        }
    }
}
