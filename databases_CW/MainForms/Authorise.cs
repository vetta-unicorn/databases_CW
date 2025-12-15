using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using databases_CW.DB;
using System.Text.Json;
using databases_CW.DB_Models;

namespace databases_CW
{
    public partial class Authorise : Form
    {
        public Authorise()
        {
            InitializeComponent();
            textBox1.Font = new Font("STFangsong", 14f, FontStyle.Regular);
            textBox2.Font = new Font("STFangsong", 14f, FontStyle.Regular);
            textBox2.PasswordChar = '*';
        }

        // вход
        private void button1_Click(object sender, EventArgs e)
        {
            string username = "default";
            string password = "default";
            string fileCurrentUser = "User.json";
            try
            {
                username = Convert.ToString(textBox1.Text);
                password = Convert.ToString(textBox2.Text);
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            AuthService service = new AuthService();
            DB_User user = service.AuthenticateUser(username, password);
            if (user != null)
            {
                var jsonString = JsonSerializer.Serialize(user);
                File.WriteAllText(fileCurrentUser, jsonString);

                var Form2 = new MainForm();
                Form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль!");
            }
        }

        // очистить
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
