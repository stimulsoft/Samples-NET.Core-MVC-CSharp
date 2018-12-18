using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using System.Data;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;
using Stimulsoft.Report.Export;

namespace Manage_Report_Printing_and_Exporting.Controllers
{
    public class ViewerController : Controller
    {
        static ViewerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            // Create the report object
            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists.mrt"));

            // Load data from XML file for report template
            DataSet data = new DataSet("Demo");
            data.ReadXml(StiNetCoreHelper.MapPath(this, "Reports/Data/Demo.xml"));

            report.RegData(data);
            
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult PrintReport()
        {
            StiReport report = StiNetCoreViewer.GetReportObject(this);

            // Some actions with report when printing

            return StiNetCoreViewer.PrintReportResult(this, report);
        }

        public IActionResult ExportReport()
        {
            StiReport report = StiNetCoreViewer.GetReportObject(this);
            StiRequestParams parameters = StiNetCoreViewer.GetRequestParams(this);

            // Some actions with report when exporting
            report.ReportName = "MyReportName";
            report.ReportAlias = report.ReportName;

            if (parameters.ExportFormat == StiExportFormat.Pdf)
            {
                // Change some export settings when exporting to PDF
                StiPdfExportSettings settings = (StiPdfExportSettings)StiNetCoreViewer.GetExportSettings(this);
                settings.CreatorString = "My Company";

                return StiNetCoreViewer.ExportReportResult(this, report, settings);
            }
            
            return StiNetCoreViewer.ExportReportResult(this, report);
        }
    }
}