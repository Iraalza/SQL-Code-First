using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Bets
    {
        public enum ResourceType
        {
            win = 1,
            draw = 2,
            defeat = 3
        }
        public Bets()
        {

        }

        public int BetId { get; set; }
        public int Amount { get; set; }
        public int GameId { get; set; }
        public ResourceType Prediction{get; set;} 
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual Games Game { get; set; }
    }
}
