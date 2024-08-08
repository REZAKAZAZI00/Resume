namespace Resume.DataLayer.FluentConfigs;
public class FluentBlogConfig : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(b => b.PictureName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(b => b.Description)
               .IsRequired();

        builder.Property(b => b.Title)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(b => b.Tags)
               .HasMaxLength(400)
               .IsRequired();


        #region Relations

        builder.HasMany(c => c.Comments)
               .WithOne(c => c.Blog)
               .HasForeignKey(c => c.BlogId)
               .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}
