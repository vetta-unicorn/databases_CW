using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Instances
{
    public class Bank
    {
        public int id { get; set; } 
        public string name { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Street
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Job
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Profession
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Qualification
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Specialization
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class StructuralDivision
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
