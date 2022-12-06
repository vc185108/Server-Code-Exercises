namespace Retalix.Wholefoods.Contracts.Generated.WfmLoyaltyCustomer
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=true)]
    public partial class SearchCriteriaType
    {
        
        private int idField;
        
        private string storeField;
        
        private string customerField;
        
        private string loyaltyCodeField;
        
        private string mobileField;
        
        private bool IdFieldSpecified;
        
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.IdSpecified = true;
            }
        }
        
        public string Store
        {
            get
            {
                return this.storeField;
            }
            set
            {
                this.storeField = value;
            }
        }
        
        public string Customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }
        
        public string LoyaltyCode
        {
            get
            {
                return this.loyaltyCodeField;
            }
            set
            {
                this.loyaltyCodeField = value;
            }
        }
        
        public string Mobile
        {
            get
            {
                return this.mobileField;
            }
            set
            {
                this.mobileField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool IdSpecified
        {
            get
            {
                return this.IdFieldSpecified;
            }
            set
            {
                this.IdFieldSpecified = value;
            }
        }
    }
}
