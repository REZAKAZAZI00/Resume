namespace Resume.DataLayer.FluentConfigs;
public class FluentAboutMeConfig : IEntityTypeConfiguration<AboutMe>
{
    public void Configure(EntityTypeBuilder<AboutMe> builder)
    {

        builder.Property(a => a.PictureName)
               .IsRequired()
               .HasMaxLength(200);


        builder.Property(a => a.Location)
               .IsRequired()
               .HasMaxLength(30);

        builder.Property(a => a.Position)
               .HasMaxLength(100);
    }
}
