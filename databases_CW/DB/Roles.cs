using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace databases_CW.DB
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
        public IGetLevel SetUser(string currUserPath)
        {
            string jsonString = File.ReadAllText(currUserPath);
            DB_User currUser = JsonSerializer.Deserialize<DB_User>(jsonString);
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
                {"Справочники", 2 },
                {"Документы", 2 }
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
            base.Access.Add("Книги", 2);
            base.Access.Add("Заказы", 2);
            base.Access.Add("Поставки", 2);
            base.Access.Add("Отдел кадров", 2);
        }
    }

    // владелец магазина
    public class Master : Role, IGetLevel
    {
        public Master()
        {
            base.Access.Add("Книги", 2);
            base.Access.Add("Заказы", 2);
            base.Access.Add("Поставки", 2);
            base.Access.Add("Отдел кадров", 2);
        }
    }

    // менеджер
    public class Manager : Role, IGetLevel
    {
        public Manager()
        {
            base.Access.Add("Книги", 1);
            base.Access.Add("Заказы", 2);
        }
    }

    // товаровед
    public class CommodityExpert : Role, IGetLevel
    {
        public CommodityExpert()
        {
            base.Access.Add("Книги", 2);
            base.Access.Add("Поставки", 2);
        }
    }

    // бухгалтер
    public class Accountant : Role, IGetLevel
    {
        public Accountant()
        {
            base.Access.Add("Книги", 0);
            base.Access.Add("Заказы", 0);
            base.Access.Add("Поставки", 0);
            base.Access.Add("Отдел кадров", 2);
        }
    }

}
