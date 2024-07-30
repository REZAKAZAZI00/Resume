namespace Resume.DataLayer.FluentConfigs;
public class FluentEducationConfig : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {

        builder.Property(e => e.InstitutionName)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(e => e.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(e => e.Degree)
               .IsRequired()
               .HasMaxLength(150);
    }
}
