using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;

namespace Save_Report_Template_in_the_Designer.Controllers
{
    public class DesignerController : Controller
    {
        static DesignerController()
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
            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists.mrt"));
            
            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult PreviewReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);

            DataSet data = new DataSet("Demo");
            data.ReadXml(StiNetCoreHelper.MapPath(this, "Reports/Data/Demo.xml"));

            report.RegData(data);

            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        public IActionResult SaveReport()
        {
            StiReport report = StiNetCoreDesigner.GetReportObject(this);
            
            // Save the report template, for example to JSON string
            string json = report.SaveToJsonString();
            
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult SaveReportAs()
        {
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}