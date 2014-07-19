using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tremulous_Server_Search
{
    public class Player
    {
        public static List<Player> MasterList = new List<Player>();
        public string Name { get; private set; }
        public static int NumPlayers { get { return MasterList.Count; } }
        public int Ping { get; private set; }
        public int Score { get; private set; }

        public Player()
        {
            MasterList.Add(this);
        }

        public Player(string name, int score, int ping)
        {
            this.Name = name;
            this.Score = score;
            this.Ping = ping;
            MasterList.Add(this);
        }

        public override bool Equals(object obj)
        {
            try
            {
                Player player = (Player)obj;
                return (((player.Name == this.Name) && (player.Score == this.Score)) && (player.Ping == this.Ping));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool isEmpty()
        {
            return (((Name == "") && (Score == 0)) && (Ping == 0));
        }

        public static void Reset()
        {
            MasterList.Clear();
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
