//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleTracking.Reports
{
    using System;
    using System.Collections.Generic;
    
    public partial class IST_User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string StatusID { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ModifyBy { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public string UserNameNormalized { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string EmailNormalized { get; set; }
    }
}
