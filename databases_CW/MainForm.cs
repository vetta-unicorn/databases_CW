using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuLibrary;
using databases_CW.Menu;

namespace databases_CW
{
    public partial class MainForm : Form
    {
        //private MenuLibrary.Menu menu;
        //private string filePath = "Menu.txt";
        //private delegate void PrintDelegate(string message);
        public MainForm()
        {
            InitializeComponent();
            ProcessMenu menu = new ProcessMenu();
            //menu = new MenuLibrary.Menu(filePath);
            //InitializeMenuStrip(menu.menu);
            //menuStrip1.BackColor = Color.FromArgb(224, 255, 255);
            //menuStrip1.Font = new Font("STFangsong", 13f, FontStyle.Regular);
        }

        //public void SetStatus(ToolStripMenuItem menuItem, Tree tree)
        //{
        //    menuItem.Visible = true;
        //    menuItem.Enabled = true;
        //    //string jsonString = File.ReadAllText(currUserPath);
        //    //User currUser = JsonSerializer.Deserialize<User>(jsonString);
        //    //int status = authorize.GetAccessLevel(tree.root.name, currUser);
        //    //switch (status)
        //    //{
        //    //    case 0:
        //    //        menuItem.Visible = true;
        //    //        menuItem.Enabled = true;
        //    //        break;
        //    //    case 1:
        //    //        menuItem.Visible = true;
        //    //        menuItem.Enabled = false;
        //    //        break;
        //    //    case 2:
        //    //        menuItem.Visible = false;
        //    //        menuItem.Enabled = false;
        //    //        break;
        //    //    case -1:
        //    //        MessageBox.Show("Unable to set entry status!");
        //    //        break;
        //    //}
        //}

        //private void InitializeMenuStrip(List<Tree> trees)
        //{
        //    foreach (var tree in trees)
        //    {
        //        ToolStripMenuItem menuItem = new ToolStripMenuItem(tree.root.name);
        //        PrintDelegate printMethod;

        //        if (tree.children == null || tree.children.Count() == 0)
        //        {
        //            printMethod = (message) =>
        //            {
        //                MessageBox.Show($"You have calles method: {message}");
        //            };
        //        }

        //        else
        //        {
        //            printMethod = (message) => { };
        //        }

        //        menuItem.Click += (sender, e) => printMethod(tree.root.clickName);
        //        SetStatus(menuItem, tree);

        //        if (tree.children != null && tree.children.Count > 0)
        //        {
        //            InitializeSubMenu(menuItem, tree.children);
        //        }

        //        menuStrip1.Items.Add(menuItem);
        //    }
        //}

        //private void InitializeSubMenu(ToolStripMenuItem parentMenuItem, List<Tree> children)
        //{
        //    foreach (var child in children)
        //    {
        //        ToolStripMenuItem childMenuItem = new ToolStripMenuItem(child.root.name);

        //        PrintDelegate printMethod;
        //        if (child.children == null || child.children.Count() == 0)
        //        {
        //            printMethod = (message) =>
        //            {
        //                MessageBox.Show($"You have called method: {message}");
        //            };
        //        }

        //        else
        //        {
        //            printMethod = (message) => { };
        //        }

        //        childMenuItem.Click += (sender, e) => printMethod(child.root.clickName);
        //        SetStatus(childMenuItem, child);

        //        if (child.children != null && child.children.Count > 0)
        //        {
        //            InitializeSubMenu(childMenuItem, child.children);
        //        }

        //        parentMenuItem.DropDownItems.Add(childMenuItem);
        //    }
        //}

        // выйти
        private void button1_Click(object sender, EventArgs e)
        {
            var Form2 = new Authorise();
            Form2.Show();
            this.Hide();
        }
    }
}
