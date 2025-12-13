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
        private RichTextBox richTextBox;
        string filePath = 
            @"C:\Users\lisal\source\repos\databases_CW\databases_CW\HelpForms\testHTML.html";
        public ShowHelpTabForm()
        {
            InitializeComponent();

            //richTextBox = new RichTextBox();
            //richTextBox.Dock = DockStyle.Fill;
            //richTextBox.ReadOnly = true;
            //this.Controls.Add(richTextBox);

            //// Простая конвертация HTML в RTF
            //string htmlString = WorkerHTML.GetFromHtml(filePath);
            //LoadSimpleHtml(htmlString);
            richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.ReadOnly = true;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.BackColor = SystemColors.Window;
            this.Controls.Add(richTextBox);

            // Загрузка и отображение HTML
            LoadAndDisplayHtml();
        }

        private void LoadAndDisplayHtml()
        {
            try
            {
                string html = WorkerHTML.GetFromHtml(filePath);

                if (!string.IsNullOrEmpty(html))
                {
                    // Вариант 1: Использовать улучшенный конвертер
                    string rtf = ConvertHtmlToRtfAdvanced(html);
                    richTextBox.Rtf = rtf;

                    // Или вариант 2: Использовать простой текст с форматированием
                    //DisplayAsPlainTextWithFormatting(html);
                }
            }
            catch (Exception ex)
            {
                richTextBox.Text = $"Ошибка загрузки файла: {ex.Message}";
            }

            DialogResult = DialogResult.OK;
        }

        private string ConvertHtmlToRtfAdvanced(string html)
        {
            // Более продвинутая конвертация
            StringBuilder rtf = new StringBuilder();

            // Начало RTF документа
            rtf.Append(@"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset204 Calibri;}}");
            rtf.Append(@"\viewkind4\uc1\pard\f0\fs24 "); // Основной шрифт

            // Простая замена HTML тегов на RTF коды
            string processed = html
                // Удаляем DOCTYPE и комментарии
                .Replace("<!DOCTYPE html>", "")
                .Replace("<!--.*?-->", "")
                // Заголовки
                .Replace("<h1>", @"\fs36\b ")
                .Replace("</h1>", @"\b0\fs24\par ")
                .Replace("<h2>", @"\fs32\b ")
                .Replace("</h2>", @"\b0\fs24\par ")
                .Replace("<h3>", @"\fs28\b ")
                .Replace("</h3>", @"\b0\fs24\par ")
                // Жирный текст
                .Replace("<b>", @"\b ")
                .Replace("<strong>", @"\b ")
                .Replace("</b>", @"\b0 ")
                .Replace("</strong>", @"\b0 ")
                // Курсив
                .Replace("<i>", @"\i ")
                .Replace("<em>", @"\i ")
                .Replace("</i>", @"\i0 ")
                .Replace("</em>", @"\i0 ")
                // Подчеркивание
                .Replace("<u>", @"\ul ")
                .Replace("</u>", @"\ul0 ")
                // Переносы строк
                .Replace("<br>", @"\line ")
                .Replace("<br/>", @"\line ")
                .Replace("<br />", @"\line ")
                // Абзацы
                .Replace("<p>", @"\par ")
                .Replace("</p>", @"\par ")
                // Списки (упрощенно)
                .Replace("<li>", @"\bullet ")
                .Replace("</li>", @"\par ")
                // Удаляем остальные теги
                .Replace("<html>", "")
                .Replace("</html>", "")
                .Replace("<head>", "")
                .Replace("</head>", "")
                .Replace("<body>", @"\par ")
                .Replace("</body>", "")
                // Специальные символы
                .Replace("&nbsp;", " ")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&amp;", "&")
                .Replace("&quot;", "\"");

            // Удаляем оставшиеся HTML теги
            processed = System.Text.RegularExpressions.Regex.Replace(
                processed, "<.*?>", string.Empty);

            rtf.Append(processed);
            rtf.Append("}");

            return rtf.ToString();
        }

        //private void DisplayAsPlainTextWithFormatting(string html)
        //{
        //    // Удаляем все HTML теги
        //    string plainText = System.Text.RegularExpressions.Regex.Replace(
        //        html, "<.*?>", string.Empty);

        //    // Декодируем HTML entities
        //    plainText = System.Net.WebUtility.HtmlDecode(plainText);

        //    richTextBox.Text = plainText;

        //    // Базовое форматирование через выделение и свойства шрифта
        //    // (это более сложно, требует парсинга и применения форматирования к конкретным фрагментам)
        //}

        //private void LoadSimpleHtml(string html)
        //{
        //    // Упрощенная конвертация
        //    string rtf = @"{\rtf1\ansi" + ConvertHtmlToRtf(html) + "}";
        //    richTextBox.Rtf = rtf;
        //}

        //private string ConvertHtmlToRtf(string html)
        //{
        //    // Простая замена тегов (для базового форматирования)
        //    return html
        //        .Replace("<b>", @"\b ")
        //        .Replace("</b>", @"\b0 ")
        //        .Replace("<i>", @"\i ")
        //        .Replace("</i>", @"\i0 ")
        //        .Replace("<br/>", @"\line ")
        //        .Replace("<h1>", @"\fs36\b ")
        //        .Replace("</h1>", @"\b0\fs24 ");
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
