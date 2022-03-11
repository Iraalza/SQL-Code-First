using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Players = new HashSet<Players>();
        }
        public int PositionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Players> Players { get; set; }
    }
}
