using System.Data.Entity;

namespace Caching.Samples
{
  public partial class AdventureWorksLTDbContext : DbContext
  {
    public AdventureWorksLTDbContext() : base("name=AdventureWorksLT")
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      // Don't let EF create migrations or check database for model consistency
      Database.SetInitializer<AdventureWorksLTDbContext>(null);

      base.OnModelCreating(modelBuilder);
    }
  }
}
