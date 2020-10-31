using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTracking.Reports.Models
{
    public class ClearMiniRecord
    {
        public string ABO { get; set; }
        public string LogNumber { get; set; }
        public DateTime SampleDate { get; set; }
        public string HospitalID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool ABS { get; set; }
        public string PatID { get; set; }
    }
}