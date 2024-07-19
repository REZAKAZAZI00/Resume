namespace Resume.DataLayer.Context
{
    public class ResumeDbContext:DbContext
    {
        #region Constructor

        public ResumeDbContext(DbContextOptions<ResumeDbContext> options):base(options)
        {
                
        }
        #endregion

        #region User

        public DbSet<User> Users { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
