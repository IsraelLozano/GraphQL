using Microsoft.EntityFrameworkCore;

namespace Dic.GraphQL.Demo.Entities.Context
{
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(DbContextOptions options)
       : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
            modelBuilder.ApplyConfiguration(new OwnerContextConfiguration(ids));
            modelBuilder.ApplyConfiguration(new AccountContextConfiguration(ids));

        }
    }
}
