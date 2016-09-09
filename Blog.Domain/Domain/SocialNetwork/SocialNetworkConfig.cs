
using System.Data.Entity.ModelConfiguration;

namespace Blog.Domain
{
    public class SocialNetworkConfig:EntityTypeConfiguration<SocialNetwork>
    {
        public SocialNetworkConfig()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(x => x.LinkedinLink).IsOptional().HasMaxLength(300);
            this.Property(x => x.FaceBookLink).IsOptional().HasMaxLength(300);
            this.Property(x => x.TwitterLink).IsOptional().HasMaxLength(300);
            //this.HasRequired(x => x.User).WithOptional(x => x.SocialNetwork);
        }
    }
}
