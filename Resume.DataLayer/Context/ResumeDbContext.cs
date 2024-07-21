using Resume.DataLayer.Entities.ContactUs;

namespace Resume.DataLayer.Context
{
    public class ResumeDbContext : DbContext
    {
        #region Constructor

        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {

        }
        #endregion

        #region User

        public DbSet<User> Users { get; set; }
        #endregion

        #region ContactUs

        public DbSet<ContactUs> ContactUs { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data
            modelBuilder.Entity<User>()
            .HasData(new User
            {
                Phone = "09389253640",
                BirthDate = DateTime.Now,
                CreateDate = DateTime.Now,
                FirstName = "reza",
                Email = "rezakazazy8@yahoo.com",
                IaActive = true,
                Id = 1,
                LastName = "Kazazi",
                Password = "5600715f42bf51c40dc330d750cd996f58fead4ddea56466ce7498d17801b3a5"
            });
            #endregion

            #region User
            modelBuilder.Entity<User>()
               .Property(x => x.Phone)
               .IsRequired()
               .HasMaxLength(15);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<User>()
              .Property(u => u.FirstName)
              .IsRequired()
              .HasMaxLength(150)
              .IsUnicode();

            modelBuilder.Entity<User>()
              .Property(u => u.LastName)
              .IsRequired()
              .HasMaxLength(150)
              .IsUnicode();

            modelBuilder.Entity<User>()
              .Property(u => u.Password)
              .IsRequired()
              .HasMaxLength(150);
            #endregion

            #region ContactUs
            modelBuilder.Entity<ContactUs>()
             .Property(x => x.PhoneNumber)
             .HasMaxLength(15);

            modelBuilder.Entity<ContactUs>()
             .Property(x => x.Email)
             .HasMaxLength(200);

            modelBuilder.Entity<ContactUs>()
            .Property(x => x.FirstName)
            .HasMaxLength(150);

            modelBuilder.Entity<ContactUs>()
             .Property(x => x.LastName)
             .HasMaxLength(150);
            modelBuilder.Entity<ContactUs>()
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(300);

            #endregion

        }

    }
}
