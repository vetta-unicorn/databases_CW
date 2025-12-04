using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Instances
{
    public class DB_User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }

    }
}
