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
    
    public partial class IST_ScanDetails
    {
        public int ScanDetailId { get; set; }
        public int ScanId { get; set; }
        public Nullable<int> ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Nullable<int> PositionNumber { get; set; }
        public string PositionText { get; set; }
        public string AliquotID { get; set; }
        public string ScannerType { get; set; }
        public Nullable<System.DateTime> InsertDateTime { get; set; }
    }
}
