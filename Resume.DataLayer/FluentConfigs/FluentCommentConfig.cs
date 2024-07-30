namespace Resume.DataLayer.FluentConfigs;
internal class FluentCommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Topic)
            .IsRequired()
            .HasMaxLength(150); 
        
        builder.Property(c => c.Massage)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(c => c.Emeil)
            .IsRequired()
            .HasMaxLength(200); 
        
        builder.Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(200);

       


    }
}
