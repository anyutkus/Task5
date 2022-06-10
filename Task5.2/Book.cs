using System;
namespace Task5._2
{
	public class Book
	{
		public string Title { get; set; }
		public DateOnly? PublishingDate { get; set; }
		public HashSet<string> Authors = new HashSet<string>();

		public Book(string title, DateOnly? date = null, params string[] authors)
		{
			if(String.IsNullOrEmpty(title))
            {
				throw new ArgumentException();
            }
			Title = title;
			PublishingDate = date;

			if(authors != null)
            {
				foreach(var author in authors)
                {
					Authors.Add(author);
                }
            }
		}

        public override string ToString()
        {
			var str = Title + " " + PublishingDate.ToString() + " ";
			var amount = Authors.Count;
			var k = 0;
			foreach(var author in Authors)
            {
				if(k + 1 == amount)
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
    }
}

