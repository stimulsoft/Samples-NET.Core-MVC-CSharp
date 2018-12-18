using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;

namespace Using_Localizations_in_the_DesignerFx.Controllers
{
    public class DesignerFxController : Controller
    {
        static DesignerFxController()
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
            
            return StiNetCoreDesignerFx.GetReportResult(this, report);
        }

        public IActionResult PreviewReport()
        {
            DataSet data = new DataSet("Demo");
            data.ReadXml(StiNetCoreHelper.MapPath(this, "Reports/Data/Demo.xml"));
            
            StiReport report = StiNetCoreDesignerFx.GetReportObject(this);
            report.RegData(data);

            return StiNetCoreDesignerFx.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesignerFx.DesignerEventResult(this);
        }
    }
}