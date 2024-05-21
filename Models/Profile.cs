using System.ComponentModel.DataAnnotations;

namespace ProjFinRBEM.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public string LookingFor { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Interest> Interests { get; set; }

        public ICollection<Message> Messages { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        [DataType(DataType.Upload)]
        public string ProfileImage { get; set; }

    }
}
