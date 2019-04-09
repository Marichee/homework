using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingNews.Classes
{
    public class Medium
    {
        public string NewsOne { get; set; }
        public string NewsTwo { get; set; }
        public DateTime DateTime { get; set; }
        public delegate void BreakingNews(Medium medium);
        public event BreakingNews News;
        public void SendBreakingNews(string newsOne, string newsTwo, DateTime dateTime)
        {
            NewsOne = newsOne;
            NewsTwo = newsTwo;
            DateTime = dateTime;
            if (News != null)
            {
                News(this);
            }
        }
    }
}
