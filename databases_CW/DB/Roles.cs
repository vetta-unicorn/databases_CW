using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.DB
{
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
