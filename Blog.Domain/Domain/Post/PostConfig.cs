using System.Data.Entity.ModelConfiguration;

namespace Blog.Domain
{
    public class PostConfig:EntityTypeConfiguration<Blog.Domain.Post>
    {
        public PostConfig()
        {
            this.HasKey(x => x.Id);           
            this.Property(x=>x.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(x => x.Title).IsRequired().HasMaxLength(100);
            this.Property(x => x.Text).IsRequired().HasColumnType("ntext");
            this.Property(x => x.PostStatus).IsRequired();
            this.Property(x => x.CreatedDate).IsRequired();
            this.HasMany(x => x.Tag).WithMany(x => x.Posts);            
        }
    }
}
