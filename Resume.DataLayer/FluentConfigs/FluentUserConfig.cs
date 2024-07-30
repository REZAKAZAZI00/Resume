global using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Resume.DataLayer.FluentConfigs;

public class FluentUserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Phone)
               .IsRequired()
               .HasMaxLength(15);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(250)
               .IsUnicode();

        builder.Property(u => u.FirstName)
               .IsRequired()
               .HasMaxLength(150)
               .IsUnicode();

        builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(150)
               .IsUnicode();

        builder.Property(u => u.Password)
               .IsRequired()
               .HasMaxLength(150);

        #region Relations
        builder.HasMany(u => u.Educations)
               .WithOne(s => s.User)
               .HasForeignKey(s => s.UserId);

        builder.HasMany(s => s.Skills)
               .WithOne(s => s.User)
               .HasForeignKey(s => s.UserId);

        builder.HasMany(e => e.WorkExperiences)
               .WithOne(u => u.User)
               .HasForeignKey(e => e.UserId);

        builder.HasOne(u => u.AboutMe)
               .WithOne(a => a.User)
               .HasForeignKey<AboutMe>(a => a.UserId);

        builder.HasMany(b=> b.Blogs)
               .WithOne(u=> u.User)
               .HasForeignKey(u => u.UserId);
        #endregion
    }
}
