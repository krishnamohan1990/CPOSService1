//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPOSLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestaurantPOS_BillingInfoEB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantPOS_BillingInfoEB()
        {
            this.RestaurantPOS_OrderedProductBillEB = new HashSet<RestaurantPOS_OrderedProductBillEB>();
        }
    
        public int Id { get; set; }
        public string BillNo { get; set; }
        public System.DateTime BillDate { get; set; }
        public decimal EBDiscountPer { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public string PaymentMode { get; set; }
        public string BillNote { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public string EB_Status { get; set; }
        public string DiscountReason { get; set; }
        public string Member_ID { get; set; }
    
        public virtual Registration Registration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantPOS_OrderedProductBillEB> RestaurantPOS_OrderedProductBillEB { get; set; }
    }
}
