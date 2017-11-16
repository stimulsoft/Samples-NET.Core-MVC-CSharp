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

namespace Manage_Report_Printing_and_Exporting.Controllers
{
    public class ViewerController : Controller
    {
        static ViewerController()
        {
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
            report.Load(StiMvcViewer.MapPath(this, "Reports/TwoSimpleLists.mrt"));

            // Load data from XML file for report template
            DataSet data = new DataSet("Demo");
            data.ReadXml(StiMvcViewer.MapPath(this, "Reports/Data/Demo.xml"));

            report.RegData(data);
            
            return StiMvcViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult(this);
        }

        public IActionResult PrintReport()
        {
            StiReport report = StiMvcViewer.GetReportObject(this);

            // Some actions with report when printing

            return StiMvcViewer.PrintReportResult(this, report);
        }

        public IActionResult ExportReport()
        {
            StiReport report = StiMvcViewer.GetReportObject(this);
            StiRequestParams parameters = StiMvcViewer.GetRequestParams(this);

            if (parameters.ExportFormat == StiExportFormat.Pdf)
            {
                // Some actions with report when exporting to PDF
            }
            
            return StiMvcViewer.ExportReportResult(this, report);
        }
    }
}