using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Towns = new HashSet<Towns>();
        }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Towns> Towns { get; set; }
        
    }
}
