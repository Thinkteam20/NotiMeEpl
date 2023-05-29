using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<EplTeam> EplTeams { get; set; }
    }
}