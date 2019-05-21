using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class Vote
    {
        public int VoteId { get; set; }
        public int ElectionId { get; set; }
        public int VirtualHouseId { get; set; }
        public int CitizenId { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Citizen Citizen { get; set; }
        public virtual Election Election { get; set; }
        public virtual VirtualHouse VirtualHouse { get; set; }
    }
}
