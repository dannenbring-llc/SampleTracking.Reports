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
    
    public partial class IST_tray_map_vw
    {
        public int TrayID { get; set; }
        public string Description { get; set; }
        public Nullable<int> TrayCapacity { get; set; }
        public string StatusID { get; set; }
        public Nullable<int> TrayTypeID { get; set; }
        public Nullable<int> SessionID { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string TrayLocation { get; set; }
        public Nullable<int> SampleAliquotID { get; set; }
        public string trayRow { get; set; }
        public string traycol { get; set; }
        public string AliquotID { get; set; }
        public string SampleID { get; set; }
        public string unknownAliquot { get; set; }
        public string RelocatedAliquotId { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string sample_aliquot { get; set; }
    }
}
