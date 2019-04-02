using System;
using System.Collections.Generic;
using System.Text;

namespace Generetic_collections.Models
{
   public class Song
    {
        public Song(string title, int length, Genre genre)
        {
            Title = title;
            Length = length;
            Genre = genre;
        }
        public string Title { get; set; }
        public int Length { get; set; }
        public Genre Genre { get; set; }
    }
}

