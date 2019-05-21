using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class ObserverFeedback
    {
        public int ObserverFeeedbackId { get; set; }
        public int ElectionId { get; set; }
        public int VirtualHouseId { get; set; }
        public int ObserverId { get; set; }
        public string FeedbackText { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Election Election { get; set; }
        public virtual Observer Observer { get; set; }
        public virtual VirtualHouse VirtualHouse { get; set; }
    }
}
