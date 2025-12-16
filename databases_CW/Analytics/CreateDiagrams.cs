using databases_CW.DB_Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace databases_CW.Analytics
{
    public static class MonthToNum
    {
        public static int ReturnNum(string month)
        {
            month = month.Trim();
            if (month == "January") { return 1; }
            else if (month == "February") { return 2; }
            else if (month == "March") { return 3; }
            else if (month == "April") { return 4; }
            else if (month == "May") { return 5; }
            else if (month == "June") { return 6; }
            else if (month == "July") { return 7; }
            else if (month == "August") { return 8; }
            else if (month == "September") { return 9; }
            else if (month == "October") { return 10; }
            else if (month == "November") { return 11; }
            else if (month == "December") { return 12; }
            else { return -1; }
        }
    }

    public class CountDiagram
    {
        public Dictionary<string, int> ItemsToCount;

        public CountDiagram()
        {
            ItemsToCount = new Dictionary<string, int>();
        }

        public bool CreateDiag(string connectionString, string query)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                ItemsToCount.Add(
                                    reader.GetString(0),
                                    reader.GetInt32(1) 
                                );
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }

}
