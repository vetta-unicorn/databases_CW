using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databases_CW.DB_Models;
using Npgsql;

namespace databases_CW.DB_Write
{
    public class WriteNewPassword
    {
        public bool ChangeUserPassword(DB_User user, string newPass, string connectionString)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE db_users SET password = @password WHERE login = @login";
                    string hash_pass = Pbkdf2Hasher.HashPassword(newPass);

                    using (var command = new NpgsqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@password", hash_pass);
                        command.Parameters.AddWithValue("@login", user.Login);

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Вызвано исключение: {ex}");
                return false;
            }
        }
    }
}
