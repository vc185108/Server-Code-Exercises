namespace Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class WfmLoyaltyCustomerLookupResponse : Retalix.Contracts.Interfaces.IHeaderResponse
    {
        
        private RetalixCommonHeaderType headerField;
        
        private WfmLoyaltyCustomerType[] wfmLoyaltyCustomerField;
        
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("WfmLoyaltyCustomer")]
        public WfmLoyaltyCustomerType[] WfmLoyaltyCustomer
        {
            get
            {
                return this.wfmLoyaltyCustomerField;
            }
            set
            {
                this.wfmLoyaltyCustomerField = value;
            }
        }
    }
}
