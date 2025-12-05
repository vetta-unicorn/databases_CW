using databases_CW.Instances;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.DB
{
    public class AuthService
    {
        private string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";

        public DB_User AuthenticateUser(string username, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();


                string query = "SELECT login, password, db_role FROM db_users WHERE login = @username";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedLogin = reader.GetString(0);
                            string storedHash = reader.GetString(1);
                            string storedRole = reader.GetString(2);

                            if (Pbkdf2Hasher.VerifyPassword(password, storedHash))
                            {
                                return new DB_User
                                {
                                    Login = storedLogin,
                                    Password = password,
                                    HashPassword = storedHash,
                                    Role = storedRole
                                };
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
