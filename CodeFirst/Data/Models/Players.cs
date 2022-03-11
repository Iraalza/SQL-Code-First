using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeFirst.Data.Models
{
    public partial class Players
    {
        public Players()
        {
            PlayerStatistics = new HashSet<PlayerStatistics>();
        }
        public int PlayerId { get; set; }
        public string IsInjured { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public int SquadNumber { get; set; }
        public int TeamId { get; set; }

        public virtual Positions Position { get; set; }
        public virtual Teams Team { get; set; }

        public virtual ICollection<PlayerStatistics> PlayerStatistics { get; set; }
    }
}
