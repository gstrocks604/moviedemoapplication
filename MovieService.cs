using MovieApplication.Movie_Entity;
using MovieApplication.Movie_logic.Models;

namespace MovieApplication.Movie_logic
{

    public interface IMovieLogic
    {
        public Task<List<MovieDashboardView>> GetMovieList();

        public Task<CreateMovieModel> AddNewMovie(CreateMovieModel model);

        public Task<bool> UpdateMovie(CreateMovieModel model);
    }

    public  class MovieService : IMovieLogic
    {
        readonly ICrudService<MovieDashboardView,Movie, DBContext> movieCrudService;
        readonly DBContext dbContext;

        public object ApiError { get; private set; }

        //Constructor for initializing service

        public  MovieService(ICrudService<MovieDashboardView, Movie, DBContext> movieCrudService) :base()
        {
            this.movieCrudService = movieCrudService;
            this.dbContext = dbContext;
        }
        public async  Task<List<MovieDashboardView>> GetMovieList()
        {
            return (await movieCrudService.Repo.GetQuery()
                    .Where(x => x.IsActive)
                    .Select(y => new MovieDashboardView().MapViewModel(y)).ToListAsync());
        }


        public async Task<CreateMovieModel> AddNewMovie(CreateMovieModel model)
        {
            using (var transaction = await movieCrudService.Repo.BeginTransaction())
            {
                try
                {

                    var newCourse = await CreateNewMovie(model);

                    if (newCourse != null)
                    {
                        transaction.Commit();
                        return newCourse;
                    };

                    ///throw some custom exception like wise 500 error 
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                   ///throw some custom exception like wise 500 error 
                }

            }


        }

        public async Task<CreateMovieModel> CreateNewMovie(CreateMovieModel model)
        {
            //Here AddAsync() is custom method that is defned in startup file and via dependency injection we can access all the file but due to some lack of time i will just update flow how to add data in DB
            await movieCrudService.AddAsync(model);
            if(model.Actors.Count() > 0)
            {
                //create proxy object of a actor for updating list
                foreach (var act in model.Actors)
                {
                    var actor = new Actor();
                    actor.IsActive = true;
                    actor.Act_ID = act.Act_ID;
                    actor.Movie_Id = model.Movie_ID;
                    //Savechanges will also be custom function that is also register in startup file 
                    await dbContext.Actor.SaveChangesAsync();

                }
                   
            }
            // update Movie Entity while calling  save change async method
            await dbContext.Movie.SaveChangesAsync();
            return model;
        }

        public async Task<bool> UpdateMovie(CreateMovieModel model)
        {
            //update async is custom method that will update entity in DB
            return await movieCrudService.Repo.GetQuery(s => s.Movie_Id == model.Movie_ID)
                         .UpdateAsync(y => new { 
                         
                         y.movieTitle = model.Movie_Title,
                         y.Producer_Id = model.Producer_Id,
                         y.releaseDate = model.ReleaseDate                                 
                         },
                         return y);

            return true;

        }


    }
}
