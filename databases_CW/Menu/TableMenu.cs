using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace databases_CW.Menu
{
    public class TableMenu
    {
        public List<Tree> menu { get; private set; }
        public ProcessMenu menu_handler { get; private set; }

        public TableMenu()
        {
            menu = new List<Tree>();
            menu_handler = new ProcessMenu();
        }

        public void SetMenu()
        {
            int i;
            for (i = 0; i < menu_handler.menu_items.Count; i++)
            {
                Tree tree = new Tree(menu_handler.menu_items[i]);

                if (menu_handler.menu_items[i].parent_id == 0)
                {
                    menu.Add(tree);

                    if (menu_handler.menu_items[i + 1].parent_id == 1 || menu_handler.menu_items[i + 1].parent_id == 10
                        || menu_handler.menu_items[i + 1].parent_id == 15 || menu_handler.menu_items[i + 1].parent_id == 22
                        || menu_handler.menu_items[i + 1].parent_id == 26)
                    {
                        int position = SetSubMenu(tree, i);
                        i = position - 1;
                    }
                }

            }
        }

        public int SetSubMenu(Tree root, int position)
        {
            int i;
            for (i = position + 1; i < menu_handler.menu_items.Count; i++)
            {
                Tree tree = new Tree(menu_handler.menu_items[i]);

                if (menu_handler.menu_items[i].parent_id == root.root.id)
                {
                    root.children.Add(tree);
                }

                else if (menu_handler.menu_items[i].parent_id == menu_handler.menu_items[i - 1].id)
                {
                    int pos = SetSubMenu(root.children.Last(), i);
                    i = pos - 1;
                    continue;
                }

                else break;
            }
            return i;
        }
    }
}
