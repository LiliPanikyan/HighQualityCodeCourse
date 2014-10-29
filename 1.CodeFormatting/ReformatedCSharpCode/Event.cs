using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReformatCSharpCode
{
    internal class Event : IComparable, IEnumerable
    {
        private DateTime date;
        private String location;
        private String title;

        public Event(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Title { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Event;
            int byDate = date.CompareTo(other.date);
            int byTitle = title.CompareTo(other.title);
            int byLocation = location.CompareTo(other.location);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }

            return byDate;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
            sb.Append(" | " + title);

            if (String.IsNullOrEmpty(location))
            {
                sb.Append(" | " + location);
            }

            return sb.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            // TO DO
            throw new NotImplementedException();
        }
    }
}
