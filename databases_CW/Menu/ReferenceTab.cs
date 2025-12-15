using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class RefTab // справка
    {
        //string filePath { get; set; }
        string parent_name { get; set; }
        public List<Tree> refChildren { get; set; }
        public string[] childrenNames = { "Руководство пользователя", "О программе" };

        public RefTab()
        {
            parent_name = "Справка";
            refChildren = MakeTreChildren();
        }

        public List<Tree> MakeTreChildren()
        {
            List<Tree> tempTrees = new List<Tree>();
            foreach (var child in childrenNames)
            {
                tempTrees.Add(new Tree(new Item(child, "default")));
            }
            return tempTrees;
        }

        public void InsertRefTabs(List<Tree> menu)
        {
            foreach (Tree tree in menu)
            {
                if (tree.root.name == parent_name)
                {
                    foreach (Tree refTree in refChildren)
                    {
                        tree.AddChild(refTree);
                    }
                }
            }
        }

        //public void InsertRefTab(List<Tree> menu)
        //{
        //    foreach (Tree tree in menu)
        //    {
        //        if (tree.root.name == parent_name)
        //        {
        //            foreach (Tree refTree in refChildren)
        //            {
        //                tree.AddChild(refTree);
        //            }
        //        }
        //    }
        //}
    }


}
