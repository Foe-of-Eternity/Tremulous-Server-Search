using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tremulous_Server_Search
{
    public class ServerPlayer
    {
        public Player player;
        public Server server;

        public ServerPlayer()
        {
            server = new Server();
            player = new Player();
        }

        public ServerPlayer(Server s, Player p)
        {
            server = s;
            player = p;
        }

        public bool isEmpty(ServerPlayer sp)
        {
            return server.isEmpty() && player.isEmpty();
        }

        public override string ToString()
        {
            return server.Name;
        }
    }
}
