using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;
using System.Data;
using Stimulsoft.Report;

namespace Showing_Interactive_Reports.Controllers
{
    public class ViewerController : Controller
    {
        static ViewerController()
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

        public IActionResult GetReport(int? id)
        {
            // Create the report object
            StiReport report = new StiReport();

            switch (id)
            {
                // Dynamic sorting
                case 1:
                    report.Load(StiNetCoreHelper.MapPath(this, "Reports/DrillDownSorting.mrt"));
                    break;

                // Drill down
                case 2:
                    report.Load(StiNetCoreHelper.MapPath(this, "Reports/DrillDownListOfProducts.mrt"));
                    break;

                // Collapsing
                case 3:
                    report.Load(StiNetCoreHelper.MapPath(this, "Reports/DrillDownGroupWithCollapsing.mrt"));
                    break;

                // Bookmarks
                case 4:
                    report.Load(StiNetCoreHelper.MapPath(this, "Reports/ParametersSelectingCountry.mrt"));
                    break;

                // Parameters
                case 5:
                    report.Load(StiNetCoreHelper.MapPath(this, "Reports/InteractiveCharts.mrt"));
                    break;

                default:
                    report.Load(StiNetCoreHelper.MapPath(this, "Reports/DrillDownSorting.mrt"));
                    break;
            }

            // Load data from XML file for report template
            DataSet data = new DataSet("Demo");
            data.ReadXml(StiNetCoreHelper.MapPath(this, "Reports/Data/Demo.xml"));
            report.Dictionary.Databases.Clear();
            report.RegData(data);

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}