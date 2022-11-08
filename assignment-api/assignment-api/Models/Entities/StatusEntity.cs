namespace assignment_api.Models.Entities
{
    public class StatusEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ErrandEntity> Errands { get; set; }
    }
}
