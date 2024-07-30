namespace Resume.DataLayer.FluentConfigs;
public class FluentCategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        
        builder.Property(c => c.Title)
               .HasMaxLength(200)
               .IsRequired();
    }
}
