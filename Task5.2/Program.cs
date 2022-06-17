using System;
using System.Collections.Generic;

namespace Task5._2
{
    class Program
    {
        static void Main()
        {
            Catalogue catalogue1 = new Catalogue();
            var date = new DateOnly(2022, 09, 13);
            var date2 = new DateOnly(2021, 08, 10);
            var date3 = new DateOnly(2022, 03, 03);
            Book b1 = new Book("ABook1", date, "auth1", "auth2", "auth3");
            Book b2 = new Book("BBook2", date2, "auth3", "auth4", "auth5","auth1");
            Book b3 = new Book("CBook3", date3, "auth7", "auth1", "auth6");
            Book b4 = new Book("AMook3", date2, "auth5", "auth2", "auth9", "Ben Simons");
            Book b5 = new Book("FBook", null, "Ben Simons");
            catalogue1.Add("123-2-34-5-87654-8",b1);
            catalogue1.Add("122-2-34-5-87654-8", b2);
            catalogue1.Add("125-2-34-5-87654-8", b3);
            catalogue1.Add("125-2-34-5-85654-8", b4);
            catalogue1.Add("125-2-34-5-85654-4", b5);
            Book b6 = new Book("FаBook", null);
            catalogue1.Add("123-2-34-5-87657-8", b6);

            Console.WriteLine(catalogue1.GetBook("123-2-34-5-87654-8").ToString());

            Console.WriteLine("Alphabit order");
            foreach (var book in catalogue1.AlphabitOrder())
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("auth1");
            foreach(var book in catalogue1.BooksList("auth1"))
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("Ben Simons");
            foreach (var book in catalogue1.BooksList("Ben Simons"))
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("Books amount");
            foreach (var item in catalogue1.BooksAmount())
            {
                Console.WriteLine(item);
            }
        }
    }
}
