using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplication.Movie_Entity
{
    public partial class Movie
    {
        [Key]
        public int Mov_Id { get; set; }
        public int Prod_Id { get; set; }
        public bool IsActive { get; set; }
        public string Mov_Name { get; set; }
        public string Mov_Plot { get; set; }

        public DateTime Release_Date { get; set; }
        public string Poster_Image { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        [ForeignKey("UserKey")]
        public virtual Producer  Producer { get; set; }

    }
}
