using System;
using System.ComponentModel.DataAnnotations;

namespace Reflections.Core.Models
{
    public class Election
    {
        [Key]
        public int ElectionId { get; set; }
        public int? ElectionYear { get; set; }
        public int? ElectionRound { get; set; }
        public DateTime? ElectionBeginningDate { get; set; }
        public DateTime? ElectionEndDate { get; set; }
        public int? ElectionChairman { get; set; }
        public string ElectionName { get; set; }
        public int? CountryId { get; set; }
    }
}
