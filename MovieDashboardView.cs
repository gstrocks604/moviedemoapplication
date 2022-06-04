using MovieApplication.Movie_Entity;

namespace MovieApplication.Movie_logic.Models
{
    public class MovieDashboardView : ICrudModel<MovieDashboardView, Movie>
    {
        [JsonProperty("movie_title")]
        public string Movie_Title { get; set; }
        [JsonProperty("producer_name")]
        public string Producer_Name { get; set; }
        [JsonProperty("dateOfrelease")]
        public DateTime DateOfRelease { get; set; }

        public List<Actor> Actors { get; set; }





        public MovieDashboardView MapViewModel(Movie data)
        {
            this.Movie_Title = data.Mov_Name;
            this.Producer_Name = data.Mov_Name;
            this.DateOfRelease = data.Release_Date;
            this.Actors = data.Actors.ToList();
            return this;
        }
    
    
    
    }

    public class CreateMovieModel
    {
        public int Movie_ID { get; set;}
        public string Movie_Title { get; set; }

        public string Movie_Plot { get; set;}

        public DateTime ReleaseDate { get; set; }

        public List<Actor> Actors { get; set;}
        public int Producer_Id { get; set; }
    }

}
