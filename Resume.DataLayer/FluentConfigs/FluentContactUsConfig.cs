namespace Resume.DataLayer.FluentConfigs;
public class FluentContactUsConfig : IEntityTypeConfiguration<ContactUs>
{
    public void Configure(EntityTypeBuilder<ContactUs> builder)
    {
        builder.Property(x => x.PhoneNumber)
               .HasMaxLength(15);

        builder.Property(x => x.Email)
               .HasMaxLength(200);

        builder.Property(x => x.FirstName)
               .HasMaxLength(150);

        builder.Property(x => x.LastName)
               .HasMaxLength(150);

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(300);

    }
}
