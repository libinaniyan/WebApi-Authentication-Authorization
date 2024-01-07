using System.ComponentModel.DataAnnotations;

namespace AuthenticationAuthorization.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [MaxLength(15)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password required.")]
        [MaxLength(15)]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
