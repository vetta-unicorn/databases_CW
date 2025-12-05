using databases_CW.DB;
using databases_CW.Instances;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class ProcessMenu
    {
        private string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";

        public List<Item> menu_items { get; private set; }

        public ProcessMenu()
        {
            menu_items = GetMenuStrings();
        }

        public List<Item> GetMenuStrings()
        {
            var result = new List<Item>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, parent_id, name, function_name, menu_order FROM db_struct";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item(Convert.ToInt32(reader["id"]),
                                Convert.ToInt32(reader["parent_id"]), Convert.ToString(reader["name"]),
                                Convert.ToString(reader["function_name"]), Convert.ToInt32(reader["menu_order"]));
                            result.Add(item);
                        }
                    }
                }
            }

            return result;
        }
    }
}
