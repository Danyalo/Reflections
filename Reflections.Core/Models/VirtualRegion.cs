using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class VirtualRegion
    {
        public VirtualRegion()
        {
            ChiefRegionOfficer = new HashSet<ChiefRegionOfficer>();
        }

        public int VirtualRegionId { get; set; }
        public int VirtualRegionNumber { get; set; }
        public string Name { get; set; }
        public string Center { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ChiefRegionOfficer> ChiefRegionOfficer { get; set; }
    }
}
