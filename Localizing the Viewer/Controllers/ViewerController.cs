using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;

namespace Localizing_the_Viewer.Controllers
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
            StiReport report = new StiReport();
            report.LoadDocument(StiMvcHelper.MapPath(this, "Reports/SimpleList.mdc"));
            
            return StiMvcViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult(this);
        }
    }
}