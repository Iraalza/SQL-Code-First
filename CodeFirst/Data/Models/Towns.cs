using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Teams = new HashSet<Teams>();
        }
        public int TownId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
