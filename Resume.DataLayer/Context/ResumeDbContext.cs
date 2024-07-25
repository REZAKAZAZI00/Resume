

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

        #region Skils
        public DbSet<Skills> Skills { get; set; }
        #endregion

        #region Eductions

        public DbSet<Education> Educations { get; set; }
        #endregion

        #region AboutMe
        public DbSet<AboutMe> AboutMe { get; set; }
        #endregion

        #region WorkExperiences
        public DbSet<WorkExperiences> WorkExperiences { get; set; }
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
            modelBuilder.Entity<AboutMe>()
                 .HasData(new AboutMe
                 {
                     CreateDate = DateTime.Now,
                     Id = 1,
                     UserId = 1,
                     Location = "",
                     PictureName = "",
                     Bio = "my name is reza kazazi"
                 });
            modelBuilder.Entity<Education>()
                 .HasData(new Education
                 {
                     UserId = 1,
                     Id = 1,
                     InstitutionName="Jabarean ctiy",  
                     CreateDate = DateTime.Now,
                     StartDate = DateOnly.Parse("2020-09-01"),
                     Degree = "Bachelor's",
                     FieldOfStudy = "Computer Engineering",
                     Description = "",
                     EndDate = DateOnly.Parse("2024-07-01")
                 });
            modelBuilder.Entity<WorkExperiences>()
                .HasData(new WorkExperiences
                {
                    CompanyName = "StartUp BlackVers",
                    CreateDate = DateTime.Now,
                    Id = 1,
                    UserId = 1,
                    StartDate=DateOnly.Parse("2023-02-01"),
                    EndDate=DateOnly.Parse("2024-04-01"),
                    JobTitle="Backend Devloper",
                    Description="backend devloper asp.net core"
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

            #region AboutMe
            modelBuilder.Entity<User>()
            .HasOne(u => u.AboutMe)
            .WithOne(a => a.User)
            .HasForeignKey<AboutMe>(a => a.UserId);


            modelBuilder.Entity<AboutMe>()
                .Property(a => a.PictureName)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<AboutMe>()
                .Property(a => a.Location)
                .IsRequired()
                .HasMaxLength(30);

            #endregion

            #region Skills

            modelBuilder.Entity<User>()
                .HasMany(u => u.Skills)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
            #endregion

            #region Education
            modelBuilder.Entity<User>()
               .HasMany(u => u.Educations)
               .WithOne(s => s.User)
               .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Education>()
                .Property(e => e.InstitutionName)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Education>()
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Education>()
                .Property(e => e.Degree)
                .IsRequired()
                .HasMaxLength(150);

            #endregion

            #region WorkExperiences

            modelBuilder.Entity<User>()
                .HasMany(u => u.WorkExperiences)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<WorkExperiences>()
                .Property(e => e.StartDate)
                .IsRequired();

            modelBuilder.Entity<WorkExperiences>()
                .Property(e => e.JobTitle)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<WorkExperiences>()
                .Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<WorkExperiences>()
                .Property(e => e.Description)
                .HasMaxLength(500);

            #endregion
        }

    }
}
