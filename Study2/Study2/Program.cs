using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study2
{
    class Book
    {
        private string title;
        private string author;
        private int pages;
        private int wordCount;

        public Book(string title)
        {
            this.title = title;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Necronomicon");
        }
    }
}
