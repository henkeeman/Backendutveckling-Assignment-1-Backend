using System.ComponentModel.DataAnnotations;

namespace assignment_api.Models
{
    public class ErrandRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int StatusId { get; set; }


    }
}
