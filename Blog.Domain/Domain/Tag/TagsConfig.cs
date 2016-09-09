

using System.Data.Entity.ModelConfiguration;

namespace Blog.Domain
{
    public class TagConfig : EntityTypeConfiguration<Tag>
    {
        public TagConfig()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(x => x.Text).IsRequired().HasMaxLength(100);
            this.HasMany(x => x.Posts).WithMany(x => x.Tag);
        }
    }
}
