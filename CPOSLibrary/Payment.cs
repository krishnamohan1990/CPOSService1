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
    
    public partial class Payment
    {
        public int T_ID { get; set; }
        public string TransactionID { get; set; }
        public System.DateTime Date { get; set; }
        public string PaymentMode { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string PaymentModeDetails { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
