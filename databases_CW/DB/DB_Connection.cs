using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace databases_CW.DB
{
 
        //public void HashAllUsers()
        //{
        //    using (var connection = new NpgsqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        // 1. Сначала получаем всех пользователей
        //        var users = new List<(string login, string password)>();
        //        string selectQuery = "SELECT login, password FROM db_users";

        //        using (var selectCommand = new NpgsqlCommand(selectQuery, connection))
        //        using (var reader = selectCommand.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                users.Add((reader.GetString(0), reader.GetString(1)));
        //            }
        //        }

        //        // 2. Хэшируем и обновляем пароли для каждого пользователя
        //        foreach (var user in users)
        //        {
        //            string hash_pass = Pbkdf2Hasher.HashPassword(user.password);

        //            string updateQuery = "UPDATE db_users SET password = @password WHERE login = @login";

        //            using (var updateCommand = new NpgsqlCommand(updateQuery, connection))
        //            {
        //                updateCommand.Parameters.AddWithValue("@password", hash_pass);
        //                updateCommand.Parameters.AddWithValue("@login", user.login);

        //                updateCommand.ExecuteNonQuery(); // <- Это критически важно!
        //            }
        //        }
        //    }
        //}

 

   
}
