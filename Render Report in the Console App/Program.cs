using Stimulsoft.Report;
using System;
using System.Data;
using System.IO;

namespace Render_Report_in_the_Console_App
{
    class Program
    {
        private const string ReportsDirectory = "../../../Reports";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

            Console.Write("Loading report and data... ");

            var report = new StiReport();
            report.Load($"{ReportsDirectory}/TwoSimpleLists.mrt");

            Console.WriteLine("OK");
            Console.Write("Rendering and exporting a report... ");

            var exportFilePath = $"{ReportsDirectory}/TwoSimpleLists_{DateTime.Now.ToString("yyyy-dd-MM_HH-mm-ss")}.pdf";
            report.Render(false);
            report.ExportDocument(StiExportFormat.Pdf, exportFilePath);

            Console.WriteLine("OK");
            Console.WriteLine("Exported to:");
            Console.WriteLine(Path.GetFullPath(exportFilePath));
            Console.ReadKey();
        }
    }
}
