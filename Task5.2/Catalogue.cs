
using System.Text.RegularExpressions;

namespace Task5._2
{
    public class Catalogue
    {
        private string _isbnVer = @"^\d{3}-\d-\d{2}-\d-\d{5}-\d";
        private HashSet<string> _authors = new HashSet<string>();
        private Dictionary<string, Book> _catalogue = new Dictionary<string, Book>();

        public void Add(string key, Book value)
        {
            if (value == null || key == null)
            {
                throw new ArgumentNullException();
            }

            if (_catalogue.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            var ISBN = ISBNCheck(key);
            _catalogue.Add(ISBN, value);

            foreach(var val in value.GetAuthors())
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

        public Book? GetBook(string key)
        {
            key = ISBNCheck(key);

            return (_catalogue.ContainsKey(key)) ? _catalogue.Where(x => x.Key == key).Select(x => x.Value).First() : null;
        }

        public IEnumerable<string> AlphabitOrder()
        {
            return _catalogue.OrderBy(x => x.Value.Title).Select(x => x.Value.Title);
        }

        public IEnumerable<string> BooksList(string author)
        {
            return _catalogue.Where(x => x.Value.GetAuthors().Contains(author)).OrderBy(x => x.Value.PublishingDate).Select(x => x.Value.ToString());
        }

        public IEnumerable<(string, int)> BooksAmount()
        {
            foreach (var author in _authors)
            {
                int count = _catalogue.Values.Count(auth => auth.GetAuthors().Contains(author.ToString()));
                yield return (author.ToString(), count);
            }
        }
    }
}
