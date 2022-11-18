using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace assignment_api.Models.Entities
{
    public class ErrandEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

    }
}
