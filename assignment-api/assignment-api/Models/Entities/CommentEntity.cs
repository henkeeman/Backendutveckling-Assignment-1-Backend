namespace assignment_api.Models.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public int ErrandId { get; set; }
        public ErrandEntity Errand { get; set; }
    }
}
