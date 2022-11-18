using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace assignment_api.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNr { get; set; }

        ICollection<ErrandEntity> Errands { get; set; }

    }
}
