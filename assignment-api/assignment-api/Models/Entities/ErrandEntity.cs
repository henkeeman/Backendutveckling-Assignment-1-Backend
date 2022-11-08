using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace assignment_api.Models.Entities
{
    public class ErrandEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        public int StatusId { get; set; }
        public StatusEntity Status { get; set; }



    }
}
