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
    
    public partial class R_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public R_Table()
        {
            this.RestaurantPOS_OrderedProductBillKOT = new HashSet<RestaurantPOS_OrderedProductBillKOT>();
            this.RestaurantPOS_OrderInfoKOT = new HashSet<RestaurantPOS_OrderInfoKOT>();
            this.TempRestaurantPOS_OrderInfoKOT = new HashSet<TempRestaurantPOS_OrderInfoKOT>();
        }
    
        public string TableNo { get; set; }
        public string Status { get; set; }
        public int BkColor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantPOS_OrderedProductBillKOT> RestaurantPOS_OrderedProductBillKOT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantPOS_OrderInfoKOT> RestaurantPOS_OrderInfoKOT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TempRestaurantPOS_OrderInfoKOT> TempRestaurantPOS_OrderInfoKOT { get; set; }
    }
}