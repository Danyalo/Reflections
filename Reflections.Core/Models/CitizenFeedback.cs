using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class CitizenFeedback
    {
        public int CitizenFeedbackId { get; set; }
        public int ElectionId { get; set; }
        public int VirtualHouseId { get; set; }
        public int CitizenId { get; set; }
        public string CitizenFeedbackText { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual Election Election { get; set; }
        public virtual VirtualHouse VirtualHouse { get; set; }
    }
}
