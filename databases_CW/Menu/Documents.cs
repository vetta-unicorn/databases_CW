using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class Documents
    {
        public List<string> docs {  get; set; }
        int parent_id {  get; set; }
        public List<Tree> docs_children { get; set; }
        public Documents()
        {
            parent_id = 30;
            docs = new List<string>() 
            {
                "Общая статистика", "Топ-3 жанра по стоимости книг", "Заказы за последнюю неделю"
            };
            docs_children = new List<Tree>();
        }

        public void MakeDocsChildren()
        {
            foreach (var doc in docs)
            {
                Tree newTree = new Tree(new Item(parent_id, doc));
                docs_children.Add(newTree);
            }
        }

        public void InsertIntoTableMenu(List<Tree> menu)
        {
            foreach (Tree tree in menu)
            {
                if (tree.root.parent_id == parent_id)
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
