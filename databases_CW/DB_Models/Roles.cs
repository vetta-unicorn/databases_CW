using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace databases_CW.DB_Models
{
    public class DB_User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }

        public DB_User()
        {
            Login = "default";
            Password = "default";
            HashPassword = "default";
            Role = "default";
        }

        public DB_User SetUser(string currUserPath)
        {
            string jsonString = File.ReadAllText(currUserPath);
            DB_User currUser = JsonSerializer.Deserialize<DB_User>(jsonString);
            return currUser;
        }
        public IGetLevel SetRole(string currUserPath, DB_User currUser)
        {
            string jsonString = File.ReadAllText(currUserPath);
            currUser = JsonSerializer.Deserialize<DB_User>(jsonString);
            if (currUser != null)
            {
                if (currUser.Role == "master") { return new Master(); }
                else if (currUser.Role == "admin") { return new Admin(); }
                else if (currUser.Role == "manager") { return new Manager(); }
                else if (currUser.Role == "commodity_expert") { return new CommodityExpert(); }
                else if (currUser.Role == "accountant") { return new Accountant(); }
                else { return new Role(); }
            }
            else
            {
                return new Role();
            }
        }

        public bool CheckChangePassword(string old_pass, string new_pass, string repeat)
        {
            if (old_pass == Password && new_pass == repeat) { return true; }
            else { return false; }
        }
    }

    public interface IGetLevel
    {
        int GetAccessLevel(string tableName);
    }

    public class Role : IGetLevel
    {
        // пункт - уровень доступа
        // 0 - SELECT, 1 - INS , 2 - UPD / DEL
        public Dictionary<string, int> Access {  get; set; }
        public Role()
        {
            Access = new Dictionary<string, int>
            {
                { "Справочники", 2 },
                { "Документы", 2 },
                { "Справка", 2 },
                { "Разное", 2 },
                { "Аналитика", 2 }
            };
        }

        public int GetAccessLevel(string tableName)
        {
            if (Access.ContainsKey(tableName))
            {
                return Access[tableName];
            }
            else
            {
                return -1;
            }
        }
    }

    public class Admin : Role, IGetLevel
    {
        public Admin()
        {
            Access.Add("Книги", 2);
            Access.Add("Заказы", 2);
            Access.Add("Поставки", 2);
            Access.Add("Отдел кадров", 2);
        }
    }

    // владелец магазина
    public class Master : Role, IGetLevel
    {
        public Master()
        {
            Access.Add("Книги", 2);
            Access.Add("Заказы", 2);
            Access.Add("Поставки", 2);
            Access.Add("Отдел кадров", 2);
        }
    }

    // менеджер
    public class Manager : Role, IGetLevel
    {
        public Manager()
        {
            Access.Add("Книги", 1);
            Access.Add("Заказы", 2);
        }
    }

    // товаровед
    public class CommodityExpert : Role, IGetLevel
    {
        public CommodityExpert()
        {
            Access.Add("Книги", 2);
            Access.Add("Поставки", 2);
        }
    }

    // бухгалтер
    public class Accountant : Role, IGetLevel
    {
        public Accountant()
        {
            Access.Add("Книги", 0);
            Access.Add("Заказы", 0);
            Access.Add("Поставки", 0);
            Access.Add("Отдел кадров", 2);
        }
    }

}
