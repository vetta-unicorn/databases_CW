using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using databases_CW.DB_Write;
using System.Web;


namespace databases_CW.HelpForms
{
    public partial class ShowHelpTabForm : Form
    {
        WebBrowser webBrowser1;
        private Panel panelContainer;
        public ShowHelpTabForm(string filePath)
        {
            InitializeComponent();

            panelContainer = new Panel();
            panelContainer.Dock = DockStyle.Fill;
            this.Controls.Add(panelContainer);

            webBrowser1 = new WebBrowser();
            webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.ScriptErrorsSuppressed = true;
            panelContainer.Controls.Add(webBrowser1);

            button1.Dock = DockStyle.Bottom;

            LoadHtmlFile(filePath);
        }

        private void LoadHtmlFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string uriString = "file:///" + filePath.Replace('\\', '/');
                    webBrowser1.Navigate(uriString);
                }
                else
                {
                    webBrowser1.DocumentText =
                        $"<html><body><h1>Файл не найден</h1><p>{filePath}</p></body></html>";
                }
            }
            catch (Exception ex)
            {
                webBrowser1.DocumentText =
                    $"<html><body><h1>Ошибка загрузки</h1><p>{ex.Message}</p></body></html>";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
