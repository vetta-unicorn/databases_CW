using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Menu
{
    public class Item
    {
        public int id {  get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
        public string function_name { get; set; }
        public int menu_order { get; set; }
        public Item(int id, int parent_id, string name, string function_name, int menu_order)
        {
            this.id = id;
            this.parent_id = parent_id;
            this.name = name;
            this.function_name = function_name;
            this.menu_order = menu_order;
        }

        public Item(int parent_id, string name)
        {
            this.parent_id = parent_id;
            this.name = name;
        }

        public Item() { }
    }


    public class Tree
    {
        public Item root { get; private set; }
        public List<Tree> children { get; private set; }

        public Tree(Item root)
        {
            this.root = root;
            children = new List<Tree>();
        }

        public Tree() { }

        public void AddChild(Tree child)
        {
            children.Add(child);
        }
    }


}
