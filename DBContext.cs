namespace MovieApplication.Movie_logic
{
    public partial class DBContext
    {
        public virtual DbSet<ActionItems> Movie { get; set; }
        public virtual DbSet<ActionItems> Producer { get; set; }
        public virtual DbSet<ActionItems> Actor { get; set; }

    }
}