using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class PlayerStatistics
    {
        public PlayerStatistics()
        {

        }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int ScoredGoals { get; set; }

        public virtual Players Player { get; set; }
        public virtual Games Game { get; set; }
    }
}
