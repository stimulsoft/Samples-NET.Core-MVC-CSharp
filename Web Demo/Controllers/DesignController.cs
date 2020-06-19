using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;

namespace Web_Demo.Controllers
{
    public class DesignController : Controller
    {
        // GET: Design
        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult GetReport(string id = "SimpleList")
        {
            // Create the report object and load data from xml file
            var report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "ReportTemplates/" + id + ".mrt"));

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult SaveReport()
        {
            var report = StiNetCoreDesigner.GetReportObject(this);

            // string packedReport = report.SavePackedReportToString();
            // ...
            // The save report code here
            // ...

            // Completion of the report saving without dialog box
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult PreviewReport()
        {
            // Get the report template
            var report = StiNetCoreDesigner.GetActionReportObject(this);

            // Register data, if necessary
            var data = new DataSet("Demo");
            data.ReadXml(StiNetCoreHelper.MapPath(this, "Data/Demo.xml"));
            report.Dictionary.Databases.Clear();
            report.RegData(data);

            // Return the report snapshot result to the client
            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }

        public IActionResult ExitDesigner(string id)
        {
            return RedirectToAction("Reports", "View", new { id });
        }
    }
}