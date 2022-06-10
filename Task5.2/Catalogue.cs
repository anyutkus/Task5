using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Task5._2
{
    public class Catalogue
    {
        private string _isbnVer = @"^\d{3}-\d-\d{2}-\d-\d{5}-\d";
        private HashSet<string> _authors = new HashSet<string>();
        private Dictionary<string, Book> _catalogue = new Dictionary<string, Book>();

        public void Add(string key, Book value)
        {
            if (_catalogue.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            if (value == null || key == null)
            {
                throw new ArgumentNullException();
            }

            var ISBN = ISBNCheck(key);
            _catalogue.Add(ISBN, value);

            foreach(var val in value.Authors)
            {
                _authors.Add(val);
            }
        }

        private string ISBNCheck(string key)
        {
            if (Regex.IsMatch(key, _isbnVer))
            {
                return Regex.Replace(key, @"\W", "");
            }
            else
            {
                throw new FormatException();
            }
        }

        public Book GetBook(string key)
        {
            key = ISBNCheck(key);
            if(_catalogue.ContainsKey(key))
            {
                return _catalogue.Where(x => x.Key == key).Select(x => x.Value).First();

            }
            else
            {
                throw new ArgumentOutOfRangeException();

            }
        }

        public IEnumerable<string> AlphabitOrder()
        {
            var books = _catalogue.OrderBy(x => x.Value.Title).Select(x => x.Value.Title);

            foreach(var b in books)
            {
                yield return b;
            }
        }

        public IEnumerable<string> BooksList(string author)
        {
            var books = _catalogue.Where(x => x.Value.Authors.Contains(author)).OrderBy(x => x.Value.PublishingDate).Select(x => x.Value);

            foreach (var a in books)
            {
                 yield return a.ToString();
            }
        }

        public IEnumerable<(string, int)> BooksAmount()
        {
            foreach (var author in _authors)
            {
                int count = _catalogue.Values.Count(auth => auth.Authors.Contains(author.ToString()));
                yield return (author.ToString(), count);
            }
        }
    }
}
