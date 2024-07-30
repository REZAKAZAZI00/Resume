namespace Resume.DataLayer.FluentConfigs;
public class FluentWorkExperiencesConfig : IEntityTypeConfiguration<WorkExperiences>
{
    public void Configure(EntityTypeBuilder<WorkExperiences> builder)
    {
        

        builder.Property(e => e.StartDate)
               .IsRequired();

        builder.Property(e => e.JobTitle)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(e => e.CompanyName)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(e => e.Description)
               .HasMaxLength(500);
    }
}
