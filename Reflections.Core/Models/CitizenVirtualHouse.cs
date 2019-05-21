using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class CitizenVirtualHouse
    {
        public int CitizenVirtualHouseId { get; set; }
        public int CitizenId { get; set; }
        public int VirtualHouseId { get; set; }
        public DateTime RegistrationTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual VirtualHouse VirtualHouse { get; set; }
    }
}
