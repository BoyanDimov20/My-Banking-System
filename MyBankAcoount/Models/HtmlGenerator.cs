using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAcoount.Models
{
    public class HtmlGenerator
    {
        public static void CreateReport(Income[] incomes)
        {
            var result = new StringBuilder();
            StringBuilder tabs = new StringBuilder();
            result.AppendLine("<!DOCTYPE html>");
            result.AppendLine(@"<html lang=""en"">");
            result.AppendLine("<head>");
            result.AppendLine("<title>Report</title>");

            result.AppendLine(@"<link rel=""stylesheet"" type=""text/css"" href=""Resources/css/util.css"">");
            result.AppendLine(@"<link rel=""stylesheet"" type=""text/css"" href=""Resources/css/main.css"">");


            result.AppendLine("</head>");

            result.AppendLine("<body>");

            result.AppendLine("<div class=\"limiter\">");

            result.AppendLine("<div class=\"container - table100\">");

            result.AppendLine("<div class=\"wrap - table100\">");

            result.AppendLine("<div class=\"table\">");

            result.AppendLine("<div class=\"row header\">");

            // Table Headers
            result.AppendLine($"<div class=\"cell\">Date Aquired</div>");
            result.AppendLine($"<div class=\"cell\">Value</div>");


            result.AppendLine("</div>");

            for (var i = 0; i < incomes.Length; i++)
            {
                result.AppendLine("<div class=\"row\">");

                // Table Values
                result.AppendLine($"<div class=\"cell\" data-title=\"Date Aquired\">{incomes[i].DateAcuired}</div>");
                result.AppendLine($"<div class=\"cell\" data-title=\"Value\">{incomes[i].Value:f2} lv.</div>");

                result.AppendLine("</div>");

            }
            result.AppendLine("<div class=\"row\">");
            // Total Sum
            result.AppendLine($"<div class=\"cell\" data-title=\"Date Aquired\"></div>");
            result.AppendLine($"<div class=\"cell\" data-title=\"Value\">In Total: {incomes.Sum(x => x.Value):f2} lv. </div>");

            result.AppendLine("</div>");

            result.AppendLine("</div>");

            result.AppendLine("</div>");

            result.AppendLine("</div>");

            result.AppendLine("</div>");

            result.AppendLine(@"<script src=""Resources/js/main.js""></script>");

            result.AppendLine("</body>");
            result.AppendLine("</html>");

            using (var stream = new StreamWriter($"report_{DateTime.Now.ToString("yyyy-MM-ddTimeHH-mm")}.html"))
            {
                stream.WriteLine(result.ToString());
            }
        }
    }
}
