using System;
namespace Task5._2
{
    public class Book
    {
        public string Title { get; set; }
        public DateOnly? PublishingDate { get; set; }
        private HashSet<string> _authors = new();

        public Book(string title, DateOnly? date = null, params string[] authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException();
            }
            Title = title;
            PublishingDate = date;

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    _authors.Add(author);
                }
            }
        }

        public override string ToString()
        {
            var str = Title + " " + PublishingDate.ToString() + " ";
            var amount = _authors.Count;
            var k = 0;
            foreach (var author in _authors)
            {
                if (k + 1 == amount)
                {
                    str += author;
                }
                else
                {
                    str += author + ", ";
                    k++;
                }
            }
            return str;
        }

        public IEnumerable<string> GetAuthors()
        {
            return _authors.Select(x => x.ToString());
        }
    }
}

