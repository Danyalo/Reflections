using System;
using System.Collections.Generic;

namespace Reflections
{
    public partial class Observer
    {
        public Observer()
        {
            ObserverFeedback = new HashSet<ObserverFeedback>();
        }

        public int ObserverId { get; set; }
        public int ElectionId { get; set; }
        public int VirtualHouseId { get; set; }
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual ICollection<ObserverFeedback> ObserverFeedback { get; set; }
    }
}
