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
            for (int i = 0; i < menu_handler.menu_items.Count; i++)
            {
                Tree tree = new Tree(menu_handler.menu_items[i]);

                if (menu_handler.menu_items[i].parent_id == 0)
                {
                    menu.Add(tree);

                    if (menu_handler.menu_items[i + 1].parent_id == 1)
                    {
                        SetSubMenu(tree, i);
                    }
                }

            }
        }

        public void SetSubMenu(Tree root, int position)
        {
            for (int i = position + 1; i < menu_handler.menu_items.Count; i++)
            {
                Tree tree = new Tree(menu_handler.menu_items[i]);

                if (menu_handler.menu_items[i].parent_id == root.root.menu_order + 1)
                {
                    root.children.Add(tree);
                }

                else if (menu_handler.menu_items[i].parent_id == root.root.menu_order + 2)
                {
                    SetSubMenu(root.children.Last(), i - 1);
                    continue;
                }

                else break;
            }
        }
    }
}
