using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SampleTracking.Reports.Services;
using SampleTracking.Reports.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleTracking.Reports.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IgtRepository _igtRepository;

        public ReportsController()
        {
            _igtRepository = new IgtRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var test = _igtRepository.GetClearMiniData("051-50-3354", "K901047");
            return View();
        }

        [HttpGet]
        [Route("ClearMiniReport")]
        public ActionResult ClearMiniReport()
        {
            return View();
        }

        [HttpPost]
        [Route("ClearMiniReport")]
        public ActionResult ClearMiniReport(ClearMiniViewModel vm)
        {
            var test = vm;
            var result = _igtRepository.GetClearMiniData(vm.PatId, vm.LogNumber);

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/IgtReports"), "ClearMini.rpt"));

            rd.SetDataSource(result);

            rd.SetParameterValue("paramLogNumber", vm.LogNumber);
            rd.SetParameterValue("paramPatID", vm.PatId);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Report");
            return RedirectToAction("Index", "Reports");

            //Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
            //stream.Seek(0, SeekOrigin.Begin);
            //return File(stream, "application/pdf", "CustomerList.pdf");
        }


        [HttpGet]
        [Route("ClearMini/{PatId}/{LogNumber}")]
        public ActionResult ClearMini(string patId, string logNumber)
        {
            var result = _igtRepository.GetClearMiniData(patId, logNumber);
            var patient = _igtRepository.GetPatient(patId);
            

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/IgtReports"), "ClearMini.rpt"));

            rd.DataSourceConnections.Clear();
            rd.Refresh();
            //            rd.SetDataSource(result);
            var patientDt = _igtRepository.GetPatient(patId);
            var sampleDt = _igtRepository.GetSample(logNumber);

            rd.Database.Tables["Patients"].SetDataSource(patientDt);
            rd.Database.Tables["Samples"].SetDataSource(sampleDt);

            rd.SetParameterValue("paramLogNumber", logNumber);
            rd.SetParameterValue("paramPatID", patId);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Report");
            return RedirectToAction("Index", "Reports");

            //Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
            //stream.Seek(0, SeekOrigin.Begin);
            //return File(stream, "application/pdf", "CustomerList.pdf");
        }

        //[HttpGet]
        //[Route("ClearMiniReport/{patId}/{logNumber}")]
        //public ActionResult ClearMiniReport(string patId, string logNumber)
        //{
        //    var vm = new ClearMiniViewModel();
        //    vm.PatId = patId;
        //    vm.LogNumber = logNumber;

        //    return View(vm);
        //}

    }
}