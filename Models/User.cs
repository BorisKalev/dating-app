using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjFinRBEM.Models
{
    public class User
    {
      
        //public User(int id, string typeOfUser, string firstName, string username, string email, DateTime dateOfBirth, string gender, string password, string confirmPassword, Profile? userProfile)
        //{
        //    Id = id;
        //    TypeOfUser = typeOfUser;
        //    FirstName = firstName;
        //    Username = username;
        //    Email = email;
        //    DateOfBirth = dateOfBirth;
        //    Gender = gender;
        //    Password = password;
        //    ConfirmPassword = confirmPassword;
        //    UserProfile = userProfile;
        //}

        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ Type d'utilisateur est obligatoire.")]
        public string TypeOfUser { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public Profile? UserProfile { get; set; }

        [DataType(DataType.Upload)]
        public string? ProfileImage { get; set; }

    }
}
