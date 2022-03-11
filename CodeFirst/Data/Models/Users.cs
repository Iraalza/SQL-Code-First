using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data.Models
{
    public partial class Users
    {
        public Users()
        {
            Bets = new HashSet<Bets>();
        }
        public int UserId { get; set; }
        public int Balance { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Bets> Bets { get; set; }
    }
}
