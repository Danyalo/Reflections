using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class Citizen
    {
        public Citizen()
        {
            Candidate = new HashSet<Candidate>();
            ChiefHouseOfficer = new HashSet<ChiefHouseOfficer>();
            ChiefRegionOfficer = new HashSet<ChiefRegionOfficer>();
            CitizenFeedback = new HashSet<CitizenFeedback>();
            CitizenVirtualHouse = new HashSet<CitizenVirtualHouse>();
            Observer = new HashSet<Observer>();
            Vote = new HashSet<Vote>();
        }

        public int CitizenId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Ipn { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<ChiefHouseOfficer> ChiefHouseOfficer { get; set; }
        public virtual ICollection<ChiefRegionOfficer> ChiefRegionOfficer { get; set; }
        public virtual ICollection<CitizenFeedback> CitizenFeedback { get; set; }
        public virtual ICollection<CitizenVirtualHouse> CitizenVirtualHouse { get; set; }
        public virtual ICollection<Observer> Observer { get; set; }
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
