using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Colors
    {
        public Colors()
        {
            Color1 = new HashSet<Teams>();
            Color2 = new HashSet<Teams>();
        }
        public int ColorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Teams> Color1 { get; set; }
        public virtual ICollection<Teams> Color2 { get; set; }
    }
}
