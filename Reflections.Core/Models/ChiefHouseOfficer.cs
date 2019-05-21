using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class ChiefHouseOfficer
    {
        public int ChiefHouseOfficerId { get; set; }
        public int ElectionId { get; set; }
        public int VirtualHouseId { get; set; }
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual Election Election { get; set; }
        public virtual VirtualHouse VirtualHouse { get; set; }
    }
}
