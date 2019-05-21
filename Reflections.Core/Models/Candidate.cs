using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class Candidate
    {
        public Candidate()
        {
            ObserverFeedback = new HashSet<ObserverFeedback>();
            Vote = new HashSet<Vote>();
        }

        public int CandidateId { get; set; }
        public int BallotNumber { get; set; }
        public int ElectionId { get; set; }
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual ICollection<ObserverFeedback> ObserverFeedback { get; set; }
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
