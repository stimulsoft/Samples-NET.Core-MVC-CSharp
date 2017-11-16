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
            report.Load(StiMvcDesignerFx.MapPath(this, "Reports/TwoSimpleLists.mrt"));
            
            return StiMvcDesignerFx.GetReportResult(this, report);
        }

        public IActionResult PreviewReport()
        {
            DataSet data = new DataSet("Demo");
            data.ReadXml(StiMvcDesignerFx.MapPath(this, "Reports/Data/Demo.xml"));
            
            StiReport report = StiMvcDesignerFx.GetReportObject(this);
            report.RegData(data);

            return StiMvcDesignerFx.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiMvcDesignerFx.DesignerEventResult(this);
        }
    }
}