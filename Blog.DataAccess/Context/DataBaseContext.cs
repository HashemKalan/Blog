using Blog.DataAccess.Interface;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.Domain;

namespace Blog.DataAccess.Context
{
    public class DataBaseContext : IdentityDbContext, IUnitOfWork
    {
        static DataBaseContext()
        {            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }
        public DataBaseContext():base("DefaultConnection")
        {

        }        
        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry<TEntity>(entity);
        }
        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Domain.UserConfig());
            modelBuilder.Configurations.Add(new Domain.PostConfig());
            modelBuilder.Configurations.Add(new Domain.TagConfig());
            modelBuilder.Configurations.Add(new Domain.SocialNetworkConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Domain.Post> Posts { get; set; }
        public DbSet<Domain.Tag> Tags { get; set; }
        public DbSet<Domain.SocialNetwork> SocialNetworks { get; set; }                
    }
}
