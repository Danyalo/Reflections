using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class Election
    {
        public Election()
        {
            ChiefHouseOfficer = new HashSet<ChiefHouseOfficer>();
            ChiefRegionOfficer = new HashSet<ChiefRegionOfficer>();
            CitizenFeedback = new HashSet<CitizenFeedback>();
            ObserverFeedback = new HashSet<ObserverFeedback>();
            Vote = new HashSet<Vote>();
        }

        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
        public DateTime ElectionYear { get; set; }
        public int Tur { get; set; }
        public DateTime BeginningTime { get; set; }
        public DateTime EndingTime { get; set; }
        public int ChiefOfficerId { get; set; }

        public virtual ICollection<ChiefHouseOfficer> ChiefHouseOfficer { get; set; }
        public virtual ICollection<ChiefRegionOfficer> ChiefRegionOfficer { get; set; }
        public virtual ICollection<CitizenFeedback> CitizenFeedback { get; set; }
        public virtual ICollection<ObserverFeedback> ObserverFeedback { get; set; }
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
