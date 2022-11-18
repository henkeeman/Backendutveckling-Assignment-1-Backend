using assignment_api.Models.Entities;

namespace assignment_api.Models
{
    public class ErrandResponse
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public ICollection<CommentResponse> Comments { get; set; }

    }
}
