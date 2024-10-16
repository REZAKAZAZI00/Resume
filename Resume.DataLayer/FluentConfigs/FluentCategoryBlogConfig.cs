﻿
namespace Resume.DataLayer.FluentConfigs;
public class FluentCategoryBlogConfig : IEntityTypeConfiguration<CategoryBlog>
{
    public void Configure(EntityTypeBuilder<CategoryBlog> builder)
    {

        builder.Property(c => c.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.PictureName)
               .HasMaxLength(200);
        #region Relations

        builder.HasMany(b => b.Blogs)
               .WithOne(c => c.CategoryBlog)
               .HasForeignKey(b => b.CategoryId);

        


        #endregion
    }
}
