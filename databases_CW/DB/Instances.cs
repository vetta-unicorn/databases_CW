using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.DB
{
    public class Author
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string surname { get; set; }

        public List<Book> books { get; set; } = new List<Book>();
    }

    public class Book
    {
        public int id { get; set; }
        public string title {  get; set; }
        public int copyrightdate { get; set; }
        public int pages { get; set; }
        public string theme { get; set; }
        public string annotation { get; set; }

        public List<Author> authors { get; set; } = new List<Author>();
    }
}
