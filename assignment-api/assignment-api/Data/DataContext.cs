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
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
    }
}
