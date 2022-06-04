using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplication.Movie_Entity
{
    public partial  class Actor
    {
        [Key]
        public int Act_ID { get; set; }

        public int Movie_Id { get; set;}

        public bool IsActive { get; set; }
        public string Act_Name { get; set; }
        public string Act_Bio { get; set; }
        public DateTime Act_DOB { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Movie_ID")]
        [InverseProperty("Actor")]
        public virtual Movie Movie { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

    }
}
