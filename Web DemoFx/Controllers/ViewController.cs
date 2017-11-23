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
    public class ViewController : Controller
    {
        // GET: View
        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult GetReport(string id)
        {
            // Create the report object and load data from xml file
            var report = new StiReport();

            // Load report from MDZ document file
            // If not found - load from MRT template
            switch (id)
            {
                // Interactive Reports
                case "DrillDownSorting":

                // Parameters
                case "ParametersDetailedCategories":
                case "ParametersDetailedOrders":
                case "ParametersHighlightCondition":
                case "ParametersSelectingCountry":
                case "ParametersInvoice":

                // {Today} function is used
                case "MultiColumnListContainers":
                    var data = new DataSet("Demo");
                    data.ReadXml(StiMvcHelper.MapPath(this, "Data/Demo.xml"));
                    report.Load(StiMvcHelper.MapPath(this, "ReportTemplates/" + id + ".mrt"));
                    report.RegData(data);
                    break;

                default:
                    report.LoadPackedDocument(StiMvcHelper.MapPath(this, "ReportSnapshots/" + id + ".mdz"));
                    break;
            }

            return StiMvcViewerFx.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiMvcViewerFx.ViewerEventResult(this);
        }

        public IActionResult Design(string id)
        {
            return RedirectToAction("Reports", "Design", new { id = id });
        }
    }
}