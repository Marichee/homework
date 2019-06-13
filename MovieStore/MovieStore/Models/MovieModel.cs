using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MovieModel
    {
        
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
