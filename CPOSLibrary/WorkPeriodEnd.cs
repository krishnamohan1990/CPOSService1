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
    
    public partial class WorkPeriodEnd
    {
        public int Id { get; set; }
        public System.DateTime WPEnd { get; set; }
    
        public virtual WorkPeriodStart WorkPeriodStart { get; set; }
    }
}
