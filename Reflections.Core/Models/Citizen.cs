using System;
using System.ComponentModel.DataAnnotations;

namespace Reflections.Core.Models
{
    public class Citizen
    {
        [Key]
        public int CitizenId { get; set; }

        [Required]
        public int IPN { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Surname { get; set; }

        [Required, StringLength(255)]
        public string Patronym { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
