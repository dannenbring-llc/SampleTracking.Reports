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
    
    public partial class IST_Arch_AliquotLocation
    {
        public int AliquotLocationID { get; set; }
        public Nullable<int> TrayID { get; set; }
        public Nullable<int> TubeLocation { get; set; }
        public string TubeGridLocation { get; set; }
        public Nullable<int> UserCustodian { get; set; }
        public Nullable<int> SampleAliquotID { get; set; }
        public string StatusID { get; set; }
        public Nullable<int> SessionID { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ArchiveBy { get; set; }
        public Nullable<System.DateTime> ArchiveDate { get; set; }
        public string ArchiveAction { get; set; }
    }
}