using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using databases_CW.Instances;
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

 

    public static class Pbkdf2Hasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256);

            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(hashedPassword);

                byte[] salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                using var pbkdf2 = new Rfc2898DeriveBytes(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithmName.SHA256);

                byte[] hash = pbkdf2.GetBytes(HashSize);

                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
