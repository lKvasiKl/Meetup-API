using System.ComponentModel.DataAnnotations;

namespace Meetup_API.Models.Request
{
    public class SpeakerRequest
    {
        [Required(ErrorMessage = "Speaker name is required")]
        public string Name { get; set; }
    }
}
