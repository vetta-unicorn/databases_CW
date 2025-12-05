using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.DB
{
    public class Roles
    {
        public static Dictionary<string, int> role_dict {  get; set; }
        public Roles()
        {
            role_dict = new Dictionary<string, int>()
            {
                { "admin", 0 },
                { "master", 1 },
                { "manager", 2 },
                { "commodity_expert", 3 },
                { "accountant", 4 }
            };
        }
    }
}
