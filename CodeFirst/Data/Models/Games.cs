using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Games
    {
        public Games()
        {
            Bets = new HashSet<Bets>();
            PlayerStatistics = new HashSet<PlayerStatistics>();
        }
        public int GameId { get; set; }
        public int AwayTeamBetRate { get; set; }
        public int AwayTeamGoals { get; set; }
        public int AwayTeamId { get; set; }
        public int DrowBetRate { get; set; }
        public int HomeTeamBetRate { get; set; }
        public int HomeTeamGoals { get; set; }
        public int HomeTeamId { get; set; }
        public string Result { get; set; }
        public DateTime DateTime { get; set; }


        public virtual Teams TeamHome { get; set; }
        public virtual Teams TeamAway { get; set; }

        public virtual ICollection<Bets> Bets { get; set; }
        public virtual ICollection<PlayerStatistics> PlayerStatistics { get; set; }
    }
}
