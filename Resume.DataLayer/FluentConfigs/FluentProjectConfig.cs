namespace Resume.DataLayer.FluentConfigs;

public class FluentProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(c => c.Title)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(c => c.PictureName)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(c => c.Description)
               .HasMaxLength(500)
               .IsRequired();

        builder.Property(c => c.DeepLink)
               .HasMaxLength(200);
    }
}
