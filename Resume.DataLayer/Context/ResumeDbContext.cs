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

        #region Project

        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories  { get; set; }
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

            modelBuilder.ApplyConfiguration(new FluentUserConfig());
            #endregion

            #region ContactUs
            modelBuilder.ApplyConfiguration(new FluentContactUsConfig());
            #endregion


            #region AboutMe
           
            modelBuilder.ApplyConfiguration(new FluentAboutMeConfig());

            #endregion

            #region Skills

            modelBuilder.ApplyConfiguration(new FluentSkillsConfig());
            #endregion

            #region Education
            modelBuilder.ApplyConfiguration(new FluentEducationConfig());

            #endregion

            #region WorkExperiences

            modelBuilder.ApplyConfiguration(new FluentWorkExperiencesConfig());
            

            #endregion


            #region Project

            modelBuilder.ApplyConfiguration(new FluentProjectConfig());
            #endregion

            #region Category    


            modelBuilder.ApplyConfiguration(new FluentCategoryConfig());

            #endregion
        }

    }
}
