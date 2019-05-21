using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class VirtualHouse
    {
        public VirtualHouse()
        {
            ChiefHouseOfficer = new HashSet<ChiefHouseOfficer>();
            CitizenFeedback = new HashSet<CitizenFeedback>();
            CitizenVirtualHouse = new HashSet<CitizenVirtualHouse>();
            ObserverFeedback = new HashSet<ObserverFeedback>();
            Vote = new HashSet<Vote>();
        }

        public int VirtualHouseId { get; set; }
        public int VirtualHouseNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int VirtualRegionId { get; set; }

        public virtual ICollection<ChiefHouseOfficer> ChiefHouseOfficer { get; set; }
        public virtual ICollection<CitizenFeedback> CitizenFeedback { get; set; }
        public virtual ICollection<CitizenVirtualHouse> CitizenVirtualHouse { get; set; }
        public virtual ICollection<ObserverFeedback> ObserverFeedback { get; set; }
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
