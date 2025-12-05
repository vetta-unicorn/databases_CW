using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using databases_CW.Instances;
using databases_CW.DB;

namespace databases_CW
{
    public partial class Authorise : Form
    {
        public Authorise()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthService service = new AuthService();
            DB_User user = service.AuthenticateUser("adm.elisabeth", "adm");
            //service.HashAllUsers();
        }
    }
}
