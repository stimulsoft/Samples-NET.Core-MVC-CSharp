using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.Web;

namespace Using_the_Web_API_with_Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/viewer")]
    public class ViewerController : Controller
    {
        static ViewerController()
        {
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Setting the required options on the server side
            /*var requestParams = StiNetCoreViewer.GetRequestParams(this);
            if (requestParams.Action == StiAction.Undefined)
            {
                var options = new StiNetCoreViewerOptions();
                options.Appearance.BookmarksPrint = false;

                return StiNetCoreViewer.GetScriptsResult(this, options);
            }*/

            return StiNetCoreViewer.ProcessRequestResult(this);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var requestParams = StiNetCoreViewer.GetRequestParams(this);
            switch (requestParams.Action)
            {
                case StiAction.GetReport:
                    return GetReportResult();

                default:
                    return StiNetCoreViewer.ProcessRequestResult(this);
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }

        // ---

        private IActionResult GetReportResult()
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(StiNetCoreHelper.MapPath(this, "Reports/Data/Demo.xml"));

            var report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists.mrt"));
            report.RegData(dataSet);

            return StiNetCoreViewer.GetReportResult(this, report);
        }
    }
}
