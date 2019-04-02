using System;
using System.Collections.Generic;
using System.Text;

namespace Generetic_collections.Models
{
    public class Person
    {

        public Person(string firstname, string lastname, int id, int age, Genre genre)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            FavoriteMusicType = genre;
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public Genre FavoriteMusicType { get; set; }
        public List<Song> FavoriteSongs { get; set; }

        public void GetFavSongs()
        {
            if (FavoriteSongs.Count == 0)
            {
                Console.WriteLine("this person hates music");
            }
            else
            {
                foreach (Song song in FavoriteSongs)
                {
                    Console.WriteLine(song.Title);
                }
            }
        }
    }
}
