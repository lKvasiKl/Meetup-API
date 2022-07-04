namespace Business.Models
{
    public class SpeakerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventModel> EventModels { get; set; }
    }
}
