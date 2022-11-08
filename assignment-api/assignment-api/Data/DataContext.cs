using assignment_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace assignment_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ErrandEntity> Errands { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
    }
}
