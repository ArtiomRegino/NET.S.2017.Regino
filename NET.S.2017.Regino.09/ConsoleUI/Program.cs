using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet < Book > book = new SortedSet<Book>();
            Book b = new Book("The Catcher in the Rye", "J. D. Salinger", "Realism", 1951, 4);
            Book d = new Book("The Catcher the Rye", "J. D. Saliner", "Realism", 1952, 4);
            book.Add(b);
            book.Add(d);


          
        }
    }
}
