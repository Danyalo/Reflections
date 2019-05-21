using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class ChiefRegionOfficer
    {
        public int ChiefRegionOfficerId { get; set; }
        public int ElectionId { get; set; }
        public int VirtulRegionId { get; set; }
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual Election Election { get; set; }
        public virtual VirtualRegion VirtulRegion { get; set; }
    }
}
