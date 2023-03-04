using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Brainsnap.DataAccess.EfContexts;

public class PsqlDbContextFactory : IDesignTimeDbContextFactory<PsqlDbContext>
{
	public PsqlDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PsqlDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost:5432;Database=brainsnap;Username=root;Password=root");

        return new PsqlDbContext(optionsBuilder.Options);
    }
}

