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
    
    public partial class EmailSetting
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string SMTPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string TLS_SSL_Required { get; set; }
        public string IsDefault { get; set; }
        public string IsActive { get; set; }
    }
}