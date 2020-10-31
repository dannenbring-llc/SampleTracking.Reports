using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace SampleTracking.Reports.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string StatusId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserNameNormalized { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string EmailNormalized { get; set; }
    }
}