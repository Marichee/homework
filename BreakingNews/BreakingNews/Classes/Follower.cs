using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingNews.Classes
{
    public class Follower
    {
        public string Name { get; set; }
        public Follower(string name)
        {
            Name = name;
        }
        public void Subscribe(Medium medium)
        {
            medium.News += new Medium.BreakingNews(News);
        }
        public void News(Medium medium)
        {
            Console.WriteLine($"Follower : {this.Name}\n News :\n {medium.NewsOne}\n{medium.NewsTwo}\n Date: {medium.DateTime}\n");
        }
    }
}
