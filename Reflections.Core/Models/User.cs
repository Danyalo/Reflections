using System.ComponentModel.DataAnnotations;

namespace Reflections.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public int? CitizenId { get; set; }
        [Required]
        public int? RoleId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
