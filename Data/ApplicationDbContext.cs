namespace PRG_Game.Data;

using Microsoft.EntityFrameworkCore;

using Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<PlayerModel> Players { get; set; } = null!;
}
