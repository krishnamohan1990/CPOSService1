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
    
    public partial class Purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            this.Purchase_Join = new HashSet<Purchase_Join>();
        }
    
        public int ST_ID { get; set; }
        public string InvoiceNo { get; set; }
        public System.DateTime Date { get; set; }
        public string PurchaseType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal Discount { get; set; }
        public decimal PreviousDue { get; set; }
        public decimal FreightCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal Total { get; set; }
        public decimal RoundOff { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal PaymentDue { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase_Join> Purchase_Join { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
