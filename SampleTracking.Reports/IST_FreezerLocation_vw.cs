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
    
    public partial class IST_FreezerLocation_vw
    {
        public int FreezerID { get; set; }
        public string FreezerName { get; set; }
        public int DrawerID { get; set; }
        public string DrawerName { get; set; }
        public Nullable<int> DrawerCapacity { get; set; }
        public int DrawerSlotID { get; set; }
        public string Slot { get; set; }
        public string FreezerStatus { get; set; }
        public string DrawerStatus { get; set; }
        public string SlotStatus { get; set; }
        public Nullable<int> TrayLocationID { get; set; }
        public Nullable<int> TrayID { get; set; }
    }
}