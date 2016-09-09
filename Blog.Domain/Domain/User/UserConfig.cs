
using System.Data.Entity.ModelConfiguration;

namespace Blog.Domain
{
    public class UserConfig:EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfig()
        {
            this.Property(x => x.Name).HasMaxLength(50).IsRequired();
            this.Property(x => x.AboutMe).HasMaxLength(3000).IsOptional();
            //this.HasOptional(x => x.SocialNetwork).WithRequired(x => x.User);            
        }
    }
}
