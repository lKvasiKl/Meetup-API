using System.ComponentModel.DataAnnotations;

namespace Meetup_API.Models.Request
{
    public class OrganizerRequest
    {
        [Required(ErrorMessage = "Organizer name is required")]
        public string Name { get; set; }
    }
}
