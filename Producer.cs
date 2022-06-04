using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MovieApplication.Movie_Entity
{
    public partial class Producer
    {
        [Key]
        public int Prod_Id { get; set; }

        public bool IsActive { get; set; }
        public string Prod_Name { get; set; }
        public string Prod_Bio { get; set; }

        public DateTime Prod_DOB { get; set; }
        public string Prod_Company_Name  { get; set; }

        public string Gender { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
