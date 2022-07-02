namespace Business.Models
{
    public class OrganizerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventModel> EventModels { get; set; }
    }
}
