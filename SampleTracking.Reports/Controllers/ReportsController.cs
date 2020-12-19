using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SampleTracking.Reports.Models;
using SampleTracking.Reports.Services;
using SampleTracking.Reports.ViewModels;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
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

        //[HttpGet]
        //[Route("ClearMini/{PatId}/{LogNumber}")]
        //public ActionResult ClearMini(string patId, string logNumber)
        //{
        //    var result = _igtRepository.GetClearMiniData(patId, logNumber);
        //    var patient = _igtRepository.GetPatient(patId);
            

        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/IgtReports"), "ClearMini.rpt"));

        //    rd.DataSourceConnections.Clear();
        //    rd.Refresh();
        //    //            rd.SetDataSource(result);
        //    var patientDt = _igtRepository.GetPatient(patId);
        //    var sampleDt = _igtRepository.GetSample(logNumber);

        //    rd.Database.Tables["Patients"].SetDataSource(patientDt);
        //    rd.Database.Tables["Samples"].SetDataSource(sampleDt);

        //    rd.SetParameterValue("paramLogNumber", logNumber);
        //    rd.SetParameterValue("paramPatID", patId);

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();

        //    //var report = rd.ExportToStream(ExportFormatType.PortableDocFormat);

        //    //rd.PrintOptions.PrinterName = "NPIF1BE71 (HP LaserJet M402dn)";
        //    rd.PrintOptions.PrinterName = @"\\140.251.218.145\Brother PT-P750W";

        //    //rd.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;
        //    //rd.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
        //    //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;

        //    //var printerSettings = new PrinterSettings { PrinterName = @"\\140.251.218.145\Brother PT-P750W" };
        //    //var test = printerSettings.DefaultPageSettings;
        //    //var printLayout = new PrintLayoutSettings();

        //    //foreach (System.Drawing.Printing.PaperSize oPaperSize in  PrinterSettings.PaperSizes)
        //    //{
        //    //    if (oPaperSize.PaperName == "User Defined Size")
        //    //    {
        //    //        rd.PrintOptions.PaperSize = (PaperSize)oPaperSize.RawKind;
        //    //    }
        //    //}


        //    //rd.PrintToPrinter(printerSettings, printerSettings.DefaultPageSettings,false);

        //    //var printerOptions = rd.PrintOptions;
        //    //var printer = new System.Drawing.Printing.PrinterSettings();
        //    //var pageSettings = new System.Drawing.Printing.PageSettings();
        //    //printer.PrinterName = @"\\140.251.218.145\Brother PT-P750W";
        //    //pageSettings.PrinterSettings.PrinterName = @"\\140.251.218.145\Brother PT-P750W";
        //    //oPrinterSettings.PaperSize = new System.Drawing.Printing.PaperSize("0.94", 94, 6);

        //    //foreach (System.Drawing.Printing.PaperSize oPaperSize in oPrinterSettings.PrinterSettings.PaperSizes)
        //    //{
        //    //    //if (oPaperSize.PaperName == "User Defined Size")
        //    //    //{
        //    //    //    rd.PrintOptions.PaperSize = (PaperSize)oPaperSize.RawKind;
        //    //    //}
        //    //}

        //    //rd.PrintToPrinter(1, false, 0, 0);
        //    //rd.PrintToPrinter(printer, pageSettings, true);

        //    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Report");

        //    //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Report");
        //    return RedirectToAction("Index", "Reports");

        //    //Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
        //    //stream.Seek(0, SeekOrigin.Begin);
        //    //return File(stream, "application/pdf", "CustomerList.pdf");
        //}

        [HttpPost]
        [Route("Test")]
        public ActionResult Test(List<ClearMiniParameter> logNumbers)
        {
            //var parameters = new List<ClearMiniParameter>() { new ClearMiniParameter() { LogNumber= "KB1916976", PatId= "053-54-6899" }, new ClearMiniParameter() {LogNumber= "KB1917066", PatId= "051-44-9725" } };

            //var result = _igtRepository.GetClearMiniDataAll(logNumbers);
            //var patient = _igtRepository.GetPatient(patId);

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/IgtReports"), "ClearMiniNew.rpt"));

            rd.DataSourceConnections.Clear();
            rd.Refresh();

            string logs;
            if (logNumbers.Where(l => l.LogNumber != null).Count() == 1)
            {
                logs = "'" + logNumbers.Select(p => p.LogNumber) + "'";
            }
            else
            {
                logs = "'" + string.Join("','", logNumbers.Select(p => p.LogNumber)) + "'";
            }

            //var patientDt = _igtRepository.GetPatient(pats);
            //var sampleDt = _igtRepository.GetSample(logs);
            var result = _igtRepository.GetClearMiniDataAll(logs);

            //rd.Database.Tables["Patients"].SetDataSource(patientDt);
            //rd.Database.Tables["Samples"].SetDataSource(sampleDt);
            rd.Database.Tables["ClearMiniData"].SetDataSource(result);

            //rd.SetParameterValue("paramLogNumber", logNumber);
            //rd.SetParameterValue("paramPatID", patId);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            //var report = rd.ExportToStream(ExportFormatType.PortableDocFormat);

            //rd.PrintOptions.PrinterName = "NPIF1BE71 (HP LaserJet M402dn)";
            rd.PrintOptions.PrinterName = @"\\140.251.218.145\Brother PT-P750W";

            //rd.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;
            //rd.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
            //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;

            //var printerSettings = new PrinterSettings { PrinterName = @"\\140.251.218.145\Brother PT-P750W" };
            //var test = printerSettings.DefaultPageSettings;
            //var printLayout = new PrintLayoutSettings();

            //foreach (System.Drawing.Printing.PaperSize oPaperSize in  PrinterSettings.PaperSizes)
            //{
            //    if (oPaperSize.PaperName == "User Defined Size")
            //    {
            //        rd.PrintOptions.PaperSize = (PaperSize)oPaperSize.RawKind;
            //    }
            //}


            //rd.PrintToPrinter(printerSettings, printerSettings.DefaultPageSettings,false);

            //var printerOptions = rd.PrintOptions;
            //var printer = new System.Drawing.Printing.PrinterSettings();
            //var pageSettings = new System.Drawing.Printing.PageSettings();
            //printer.PrinterName = @"\\140.251.218.145\Brother PT-P750W";
            //pageSettings.PrinterSettings.PrinterName = @"\\140.251.218.145\Brother PT-P750W";
            //oPrinterSettings.PaperSize = new System.Drawing.Printing.PaperSize("0.94", 94, 6);

            //foreach (System.Drawing.Printing.PaperSize oPaperSize in oPrinterSettings.PrinterSettings.PaperSizes)
            //{
            //    //if (oPaperSize.PaperName == "User Defined Size")
            //    //{
            //    //    rd.PrintOptions.PaperSize = (PaperSize)oPaperSize.RawKind;
            //    //}
            //}

            //rd.PrintToPrinter(1, false, 0, 0);
            //rd.PrintToPrinter(printer, pageSettings, true);

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Report");

            //rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Report");
            return RedirectToAction("Index", "Reports");

            //Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
            //stream.Seek(0, SeekOrigin.Begin);
            //return File(stream, "application/pdf", "CustomerList.pdf");
        }

        [HttpGet]
        [Route("ClearMini")]
        public ActionResult ClearMini(string logNumbers)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/IgtReports"), "ClearMiniNew.rpt"));

            rd.DataSourceConnections.Clear();
            rd.Refresh();

            var logString = logNumbers.Replace(",", "','");
            logString = "'" + logString + "'";

            var result = _igtRepository.GetClearMiniDataAll(logString);

            rd.Database.Tables["ClearMiniData"].SetDataSource(result);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, true, "Report");

            return RedirectToAction("Index", "Reports");
        }

    }
}