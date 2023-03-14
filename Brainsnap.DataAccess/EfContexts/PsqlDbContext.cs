using Brainsnap.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brainsnap.DataAccess.EfContexts;

public class PsqlDbContext : DbContext
{
	public PsqlDbContext(DbContextOptions<PsqlDbContext> options) : base(options)
	{ }

	public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<IdeaEntity> Ideas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectEntity>()
            .HasKey(p => p.Name);

        base.OnModelCreating(modelBuilder);
    }
}
