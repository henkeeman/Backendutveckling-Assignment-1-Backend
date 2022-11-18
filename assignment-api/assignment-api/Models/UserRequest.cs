using System.ComponentModel.DataAnnotations;

namespace assignment_api.Models
{
    public class UserRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNr { get; set; }
    }
}
