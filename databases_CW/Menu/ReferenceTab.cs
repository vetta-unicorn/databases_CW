using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class Tab 
    {
        public string parent_name { get; set; }
        public List<Tree> Children { get; set; }
        public List<string> childrenNames {  get; set; }

        public Tab()
        {
            parent_name = "default";
            Children = new List<Tree>();
            childrenNames = new List<string>();
        }

        public List<Tree> MakeTreeChildren()
        {
            List<Tree> tempTrees = new List<Tree>();
            foreach (var child in childrenNames)
            {
                tempTrees.Add(new Tree(new Item(child, "default")));
            }
            return tempTrees;
        }

        public void InsertTabs(List<Tree> menu)
        {
            foreach (Tree tree in menu)
            {
                if (tree.root.name == parent_name)
                {
                    foreach (Tree refTree in Children)
                    {
                        tree.AddChild(refTree);
                    }
                }
            }
        }
    }

    public class RefTab : Tab // справка
    {
        public RefTab()
        {
            base.parent_name = "Справка";
            base.childrenNames.Add("Руководство пользователя");
            base.childrenNames.Add("О программе");
            base.Children = MakeTreeChildren();
        }
    }

    public class OtherTab : Tab // разное
    {
        public OtherTab()
        {
            base.parent_name = "Разное";
            base.childrenNames.Add("Смена пароля");
            base.childrenNames.Add("Настройка");
            base.Children = MakeTreeChildren();
        }
    }
}
