using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTracking.Reports.Services
{
    public class Patient
    {
        public string PatId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MidInit { get; set; }
        public string ABO { get; set; }
        public string Relation { get; set; }
        public string DoctorName { get; set; }
        public string HospitalId { get; set; }
        public string Status { get; set; }
        public bool Wp { get; set; }
        public bool UnosActive { get; set; }
        public string Organ { get; set; }
        public bool Kidney { get; set; }
        public bool Pancreas { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Disease { get; set; }
        public string LambdaName { get; set; }
        public bool AboIncompatible { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string PriorTranplants { get; set; }
        public string Comments { get; set; }
        public string Pregnancy { get; set; }
        public string Transfusion { get; set; }
        public bool SmallIntestine { get; set; }
        public bool Liver { get; set; }
        public bool BoneMarrow { get; set; }
        public bool Lung { get; set; }
        public bool Heart { get; set; }
        public bool AddOrgan1 { get; set; }
        public bool AddOrgan2 { get; set; }
        public string Hiv { get; set; }
        public string UnosNumber { get; set; }
        public bool Misc { get; set; }
        public bool Qc { get; set; }
        public bool Islet { get; set; }
        public string Age { get; set; }
        public string HospitalPatId { get; set; }
        public string MnrId { get; set; }
        public bool Altruistic { get; set; }
        public bool Sensitized { get; set; }
        public string DonorSsan { get; set; }
        public bool AutoAb { get; set; }
        public string AutoAbText { get; set; }
        public bool Adsorb { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Alias { get; set; }
        public string PatCode { get; set; }
        public bool NkrPat { get; set; }
        public string NkrCode { get; set; }
        public DateTime ListingDate { get; set; }
        public bool HepC { get; set; }
        public string A1SubType { get; set; }
        public string RbcAb { get; set; }
        public bool Edta { get; set; }
    }
}