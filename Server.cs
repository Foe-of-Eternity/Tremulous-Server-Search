using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tremulous_Server_Search
{
    public class Server
    {
        public static List<Server> MasterList = new List<Server>();
        public string Game { get; private set; }
        public string IP { get; private set; }
        public string Map { get; private set; }
        public int MaxPlayers { get; private set; }
        public string Name { get; private set; }
        public int NumPlayers { get; private set; }
        public static int NumServers { get { return MasterList.Count; } }
        public List<Player> Players { get; private set; }
        public List<ServerVar> Variables { get; private set; }

        public Server()
        {
            MasterList.Add(this);
        }

        public Server(string ServerHTML)
        {
            if (ServerHTML.Length > 0)
            {
                try
                {
                    ServerVar[] varArray = new ServerVar[8];
                    List<Player> list = new List<Player>();
                    List<ServerVar> list2 = new List<ServerVar>();
                    Regex regex = new Regex("<tr xmlns=\"\" class=\"server\" id=\"server_.+?\">.+?</tr>");
                    string input = regex.Match(ServerHTML).Value;
                    regex = new Regex("<td class=\".+?\">.*?</td>");
                    Match match = regex.Match(input);
                    Regex regex2 = new Regex("<td class=\".+?\">");
                    for (int i = 0; i < 8; i++)
                    {
                        string str4;
                        string str2 = match.Value;
                        string str3 = regex2.Match(str2).Value;
                        if (str3.Length > 0)
                        {
                            str4 = str2.Substring(11, str2.IndexOf("\">") - 11);
                            str2 = str2.Substring(str3.Length);
                            str2 = str2.Substring(0, str2.IndexOf("</td>"));
                        }
                        else
                        {
                            str4 = "N/A";
                            str2 = "N/A";
                        }
                        varArray[i] = new ServerVar(str4, str2);
                        match = match.NextMatch();
                    }
                    Name = varArray[1].Value;
                    IP = varArray[7].Value;
                    Map = varArray[2].Value;
                    Game = varArray[3].Value;
                    NumPlayers = int.Parse(varArray[4].Value);
                    MaxPlayers = int.Parse(varArray[6].Value);
                    string str5 = "<table class=\"players\"><thead><tr><td class=\"name\">Name</td><td class=\"score\">Score</td><td class=\"ping\">Ping</td></tr></thead>";
                    string str6 = ServerHTML.Substring(ServerHTML.IndexOf(str5) + str5.Length);
                    str6 = str6.Substring(7, str6.IndexOf("</table>") - 15);
                    regex = new Regex("<tr>.+?</tr>");
                    regex2 = new Regex("<td class=\".+?\">.+?</td>");
                    for (match = regex.Match(str6); match.Success; match = match.NextMatch())
                    {
                        regex2 = new Regex("<td class=\".+?\">.+?</td>");
                        Match match2 = regex2.Match(match.Value);
                        string name = getVal(match2.Value).Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
                        match2 = match2.NextMatch();
                        int score = int.Parse(getVal(match2.Value));
                        match2 = match2.NextMatch();
                        int ping = int.Parse(getVal(match2.Value));
                        list.Add(new Player(name, score, ping));
                    }
                    Players = list;
                    regex = new Regex("<table class=\"rules\">.+?</table>");
                    string str8 = regex.Match(ServerHTML).Value;
                    str8 = str8.Substring(str8.IndexOf("<tbody>"), (str8.Length - str8.IndexOf("<tbody>")) - 0x10);
                    regex = new Regex("<tr>.+?</tr>");
                    for (match = regex.Match(str8); match.Success; match = match.NextMatch())
                    {
                        Match match3 = new Regex("<td class=\".+?\">.+?</td>").Match(match.Value);
                        string str9 = getVal(match3.Value).Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
                        match3 = match3.NextMatch();
                        string str10 = getVal(match3.Value).Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
                        list2.Add(new ServerVar(str9, str10));
                    }
                    Variables = list2;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error: Unable to parse server\n\nDetails:\n" + exception.ToString());
                }
            }
            fixVars();
            MasterList.Add(this);
        }

        public Server(string name, string ip, string map, string game, int numplayers, int maxplayers)
        {
            Name = name;
            IP = ip;
            Map = map;
            Game = game;
            NumPlayers = numplayers;
            MaxPlayers = maxplayers;
            MasterList.Add(this);
        }

        public Server(string name, string ip, string map, string game, int numplayers, int maxplayers, List<ServerVar> vars, List<Player> players)
        {
            Name = name;
            IP = ip;
            Map = map;
            Game = game;
            NumPlayers = numplayers;
            MaxPlayers = maxplayers;
            Variables = vars;
            Players = players;
            MasterList.Add(this);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Server))
                return false;
            Server server = (Server)obj;
            if (server.Game == Game && server.IP == IP && server.Map == Map && server.MaxPlayers == MaxPlayers && server.Name == Name && server.NumPlayers == NumPlayers)
            {
                if (Variables.Count != server.Variables.Count || Players.Count != server.Players.Count)
                    return false;
                for (int i = 0; i < Variables.Count; i++)
                    if (server.Variables[i] != Variables[i])
                        return false;
                for (int j = 0; j < Players.Count; j++)
                    if (server.Players[j] != Players[j])
                        return false;
                return true;
            }
            return false;
        }

        public static List<Server> FindPlayer(string name)
        {
            List<Server> list = new List<Server>();
            foreach (Server server in MasterList)
            {
                foreach (Player player in server.Players)
                {
                    if (player.Name == name)
                    {
                        list.Add(server);
                        break;
                    }
                }
            }
            return list;
        }

        private void fixVars()
        {
            Name = Name.Replace("&gt;", ">");
            Name = Name.Replace("&lt;", "<");
            Name = Name.Replace("&amp;", "&");
            Map = Map.Replace("&gt;", ">");
            Map = Map.Replace("&lt;", "<");
            Map = Map.Replace("&amp;", "&");
            Game = Game.Replace("&gt;", ">");
            Game = Game.Replace("&lt;", "<");
            Game = Game.Replace("&amp;", "&");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private string getVal(string td)
        {
            Match match = new Regex("<td class=\".+?\">").Match(td);
            return td.Substring(match.Value.Length, (td.Length - match.Value.Length) - 5);
        }

        public bool isEmpty()
        {
            if (Name == "" && IP == "" && Map == "" && Game == "" && NumPlayers == 0 && NumServers == 0 && MaxPlayers == 0 && Variables.Count == 0)
                return (Players.Count != 0);
            return true;
        }

        public static void Reset()
        {
            MasterList.Clear();
        }

        public bool Similar(Server s)
        {
            return s.Game == Game && s.IP == IP && s.Map == Map && s.MaxPlayers == MaxPlayers && s.Name == Name && s.NumPlayers == NumPlayers;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
