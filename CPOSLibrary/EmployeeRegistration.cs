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
    
    public partial class EmployeeRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeRegistration()
        {
            this.RestaurantPOS_BillingInfoHD = new HashSet<RestaurantPOS_BillingInfoHD>();
        }
    
        public int EmpId { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfJoining { get; set; }
        public byte[] Photo { get; set; }
        public string Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantPOS_BillingInfoHD> RestaurantPOS_BillingInfoHD { get; set; }
    }
}
