using Microsoft.EntityFrameworkCore;
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
            List<int> rootList = new List<int>() { 1, 10, 15, 22, 26, 29 };
            for (i = 0; i < menu_handler.menu_items.Count - 1; i++)
            {
                Tree tree = new Tree(menu_handler.menu_items[i]);

                if (menu_handler.menu_items[i].parent_id == 0)
                {
                    menu.Add(tree);
                    if (rootList.Contains(menu_handler.menu_items[i + 1].parent_id))
                    {
                        int position = SetSubMenu(tree, i);
                        i = position - 1;
                    }
                }
            }
            i++;
            Tree tree1 = new Tree(menu_handler.menu_items.Last());
            if (menu_handler.menu_items.Last().parent_id == 0) { menu.Add(tree1); }
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
