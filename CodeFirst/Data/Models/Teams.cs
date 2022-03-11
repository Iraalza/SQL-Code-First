using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Teams
    {
        public Teams()
        {
            AwayTeam = new HashSet<Games>();
            HomeTeam = new HashSet<Games>();
            Players = new HashSet<Players>();
        }
        public int TeamId { get; set; }
        public int Budget { get; set; }
        public int Initials { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public int PrimaryKitColorId { get; set; }
        public int SecondaryKitColorId { get; set; }
        public int TownId { get; set; }
        
        public virtual Towns Town { get; set; }
        public virtual Colors PrimaryKitColor { get; set; }
        public virtual Colors SecondaryKitColor { get; set; }
        public virtual ICollection<Games> AwayTeam { get; set; }
        public virtual ICollection<Games> HomeTeam { get; set; }
        public virtual ICollection<Players> Players { get; set; }


    }
}
