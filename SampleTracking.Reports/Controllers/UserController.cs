using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleTracking.Reports.Controllers
{
    public class UserController : Controller
    {
        private SampleTrackingEntities context = new SampleTrackingEntities();
        
        public ActionResult Index()
        {
            var userList = context.IST_User.ToList();
            return View(userList);
        }

        public ActionResult ExportUsers()
        {
            List<IST_User> allUsers = new List<IST_User>();
            allUsers = context.IST_User.ToList();

            foreach (var item in allUsers)
            {
                if (item.ModifyDate == null)
                {
                    item.ModifyDate = DateTime.MinValue;
                }
                if (item.CreateDate == null)
                {
                    item.CreateDate = DateTime.MinValue;
                }
                if (item.ModifyBy == null)
                {
                    item.ModifyBy = 0;
                }
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "TestReport.rpt"));

            rd.SetDataSource(allUsers);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CustomerList.pdf");
        }
    }
}