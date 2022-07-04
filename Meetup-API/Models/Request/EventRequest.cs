using System.ComponentModel.DataAnnotations;

namespace Meetup_API.Models.Request
{
    public class EventRequest
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Topic is required")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Schedule is required")]
        public string Schedule { get; set; }

        [Required(ErrorMessage = "DateTime is required")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Place is required")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Organizer(s) is required")]
        public ICollection<OrganizerRequest> Organizers { get; set; }

        [Required(ErrorMessage = "Speaker(s) is required")]
        public ICollection<SpeakerRequest> Speakers { get; set; }
    }
}
