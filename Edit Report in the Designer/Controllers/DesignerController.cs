using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;

namespace Edit_Report_in_the_Designer.Controllers
{
    public class DesignerController : Controller
    {
        static DesignerController()
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
            StiReport report = new StiReport();
            report.Load(StiMvcDesigner.MapPath(this, "Reports/TwoSimpleLists.mrt"));
            
            return StiMvcDesigner.GetReportResult(this, report);
        }

        public IActionResult PreviewReport()
        {
            DataSet data = new DataSet("Demo");
            data.ReadXml(StiMvcDesigner.MapPath(this, "Reports/Data/Demo.xml"));

            StiReport report = StiMvcDesigner.GetActionReportObject(this);
            report.RegData(data);

            return StiMvcDesigner.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiMvcDesigner.DesignerEventResult(this);
        }
    }
}