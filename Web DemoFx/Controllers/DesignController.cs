using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;
using System.Data;
using Stimulsoft.Report;

namespace Web_DemoFx.Controllers
{
    public class DesignController : Controller
    {
        // GET: Design
        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult GetReport(string id)
        {
            // Create the report object and load data from xml file
            var report = new StiReport();
            report.Load(StiMvcDesignerFx.MapPath(this, "ReportTemplates/" + id + ".mrt"));

            return StiMvcDesignerFx.GetReportResult(this, report);
        }

        public IActionResult SaveReport()
        {
            StiReport report = StiMvcDesignerFx.GetReportObject(this);

            // string packedReport = report.SavePackedReportToString();
            // ...
            // The save report code here
            // ...

            // Completion of the report saving without dialog box
            return StiMvcDesignerFx.SaveReportResult(this);
        }

        public IActionResult PreviewReport()
        {
            // Get the report template
            StiReport report = StiMvcDesignerFx.GetReportObject(this);

            // Register data, if necessary
            var data = new DataSet("Demo");
            data.ReadXml(StiMvcDesignerFx.MapPath(this, "Data/Demo.xml"));
            report.Dictionary.Databases.Clear();
            report.RegData(data);

            // Return the report snapshot result to the client
            return StiMvcDesignerFx.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiMvcDesignerFx.DesignerEventResult(this);
        }

        public IActionResult ExitDesigner(string id)
        {
            return RedirectToAction("Reports", "View", new { id = id });
        }
    }
}