using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class Documents
    {
        public Dictionary<string, string> docs {  get; set; }
        string parent_name {  get; set; }
        public List<Tree> docs_children { get; set; }
        public Documents()
        {
            parent_name = "Документы";
            docs = new Dictionary<string, string>()
            {
                { "Общая статистика", 
                    "SELECT \r\n\t" +
                    "COUNT(id) AS \"общее кол-во экземпляров\"," +
                    "\r\n\tAVG(price) AS \"средняя цена\"," +
                    "\r\n\tMAX(price) AS \"максимальная цена\"," +
                    "\r\n\tMIN(price) AS \"минимальная цена\"," +
                    "\r\n\t(SELECT SUM(price)\r\n\tFROM bought_items) AS \"сумма заказов" +
                    "\"\r\n\t\r\nFROM items;" },

                { "Топ-3 жанра по стоимости книг",
                    "SELECT * FROM " +
                    "(\r\n    SELECT AVG(i.price), b.theme\r\n    " +
                    "FROM items i\r\n    " +
                    "JOIN books b ON b.id = i.book_id\r\n    " +
                    "GROUP BY b.theme, b.title\r\n    " +
                    "ORDER BY AVG(i.price) DESC\r\n    " +
                    "OFFSET 0 LIMIT 3\r\n) AS top_three\r\nORDER BY avg ASC;"},

                { "Заказы за последний месяц", 
                    "SELECT * FROM orders " +
                    "\r\nWHERE order_date > CURRENT_DATE - INTERVAL '30 days';"}
            };
            docs_children = new List<Tree>();
            MakeDocsChildren();
        }

        public void MakeDocsChildren()
        {
            foreach (var doc in docs)
            {
                Tree newTree = new Tree(new Item(name: doc.Key, function_name: doc.Value));
                docs_children.Add(newTree);
            }
        }

        public void InsertIntoTableMenu(List<Tree> menu)
        {
            foreach (Tree tree in menu)
            {
                if (tree.root.name == parent_name)
                {
                    foreach (Tree docTree in docs_children)
                    {
                        tree.AddChild(docTree);
                    }
                }
            }
        }
    }
}
