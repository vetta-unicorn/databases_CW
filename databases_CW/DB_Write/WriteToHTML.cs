using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.DB_Write
{
    public class WorkerHTML
    {
        public static void ExportToHtml(DataTable dt, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<html><head><style>");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            sb.AppendLine("th { background-color: #f2f2f2; }");
            sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
            sb.AppendLine("</style></head><body>");
            sb.AppendLine($"<h2>Data Export - {DateTime.Now}</h2>");
            sb.AppendLine("<table>");

            // Заголовки
            sb.AppendLine("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.AppendLine($"<th>{column.ColumnName}</th>");
            }
            sb.AppendLine("</tr>");

            // Данные
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("<tr>");
                foreach (var item in row.ItemArray)
                {
                    sb.AppendLine($"<td>{item}</td>");
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table></body></html>");

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
