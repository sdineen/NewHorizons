using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entity
{
    public class Film
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int Stock { get; set; }
        public Genre Genre { get; set; }

        [NotMapped]
        public int Year
        {
            get { return Released.Year; }
            set { Released = new DateTime(value, 1, 1); }
        }
    }

    public enum Genre
    {
        Crime,
        Suspense,
        Horror,
        Comedy,
        Science_Fiction,
        Action,
        Adventure,
        Fantasy,
        Musical,
        Family,
        Drama,
        Animated,
        Documentary
    }
}
