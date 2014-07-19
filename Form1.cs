using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tremulous_Server_Search
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter PlayerSorter;
        public List<Server> ServerList;
        private ListViewColumnSorter ServerSorter;
        private Label txtPlayers;
        private Label txtServers;
        private ListViewColumnSorter VarSorter;

        private static WebClient wc = new WebClient();
        public Form1()
        {
            InitializeComponent();
            ServerSorter = new ListViewColumnSorter();
            PlayerSorter = new ListViewColumnSorter();
            VarSorter = new ListViewColumnSorter();
            lstServers.ListViewItemSorter = ServerSorter;
            lstPlayers.ListViewItemSorter = PlayerSorter;
            lstVars.ListViewItemSorter = VarSorter;
            btnStart_Click(this, EventArgs.Empty);
            wc.DownloadString("http://tremulous.net/");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            new Form2(this).Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            chkEmpty.Enabled = false;
            lstServers.Items.Clear();
            Server.Reset();
            ServerList = GetServerList("http://master.tremulous.net/list/");
            txtPlayers.Text = "Players: " + Player.NumPlayers.ToString();
            txtServers.Text = "Servers: " + Server.NumServers.ToString();
            foreach (Server server in chkEmpty.Checked ? ServerList : GetServersWithPlayers())
            {
                string[] items = new string[] { server.Name, server.Map, server.Game, server.NumPlayers.ToString(), server.MaxPlayers.ToString(), server.IP };
                lstServers.Items.Add(new ListViewItem(items));
            }
            chkEmpty.Enabled = true;
        }

        private void chkEmpty_CheckedChanged(object sender, EventArgs e)
        {
            lstServers.Items.Clear();
            if (chkEmpty.Checked)
            {
                foreach (Server server in ServerList)
                {
                    string[] items = new string[] { server.Name, server.Map, server.Game, server.NumPlayers.ToString(), server.MaxPlayers.ToString(), server.IP };
                    lstServers.Items.Add(new ListViewItem(items));
                }
            }
            else
            {
                foreach (Server server2 in GetServersWithPlayers())
                {
                    string[] strArray2 = new string[] { server2.Name, server2.Map, server2.Game, server2.NumPlayers.ToString(), server2.MaxPlayers.ToString(), server2.IP };
                    lstServers.Items.Add(new ListViewItem(strArray2));
                }
            }
        }

        public List<ServerPlayer> findPlayer(string playerName, bool exact)
        {
            List<ServerPlayer> list = new List<ServerPlayer>();
            foreach (Server server in ServerList)
            {
                if (!exact)
                {
                    foreach (Player player in server.Players)
                    {
                        if (player.Name.ToUpper().Contains(playerName.ToUpper()))
                        {
                            list.Add(new ServerPlayer(server, player));
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Player player2 in server.Players)
                    {
                        if (player2.Name.ToUpper() == playerName.ToUpper())
                        {
                            list.Add(new ServerPlayer(server, player2));
                            break;
                        }
                    }
                }
            }
            return list;
        }

        private List<Server> GetServerList(string url)
        {
            List<string> list = new List<string>();
            List<Server> list2 = new List<Server>();
            string input = HTMLSource(url).Replace("\r", "").Replace("\n", "").Replace("\t", "");
            if (input == "")
                return list2;
            Regex regex = new Regex("<tbody>.*</tbody>", RegexOptions.Multiline);
            input = regex.Match(input).Value;
            Match match = new Regex("<tr xmlns=\"\" class=\"server\" id=\"server_.+?\">").Match(input);
            while (match.Success && match.NextMatch().Success)
            {
                list.Add(input.Substring(input.IndexOf(match.Value), input.IndexOf(match.NextMatch().Value) - input.IndexOf(match.Value)));
                match = match.NextMatch();
            }
            list.Add(input.Substring(input.IndexOf(match.Value), input.LastIndexOf("</tbody>") - input.IndexOf(match.Value)));
            foreach (string str2 in list)
            {
                list2.Add(new Server(str2));
            }
            return list2;
        }

        private List<Server> GetServersWithPlayers()
        {
            List<Server> list = new List<Server>();
            foreach (Server server in ServerList)
            {
                if (server.Players.Count > 0)
                {
                    list.Add(server);
                }
            }
            return list;
        }

        public void GoToPlayer(ServerPlayer sp)
        {
            Server server = sp.server;
            Player player = sp.player;
            base.Focus();
            for (int i = 0; i < lstServers.Items.Count; i++)
            {
                ListViewItem.ListViewSubItemCollection subItems = lstServers.Items[i].SubItems;
                Server s = new Server(subItems[0].Text, subItems[5].Text, subItems[1].Text, subItems[2].Text, int.Parse(subItems[3].Text), int.Parse(subItems[4].Text));
                if (server.Similar(s))
                {
                    lblServerName.Text = "Server: " + server.Name;
                    lstServers.Items[i].Selected = true;
                    break;
                }
            }
            for (int j = 0; j < lstPlayers.Items.Count; j++)
            {
                Player player2 = new Player(lstPlayers.Items[j].SubItems[0].Text, int.Parse(lstPlayers.Items[j].SubItems[1].Text), int.Parse(lstPlayers.Items[j].SubItems[2].Text));
                if (player.Equals(player2))
                {
                    lstPlayers.Focus();
                    lstPlayers.Items[j].Selected = true;
                    lstPlayers.Items[j].Focused = true;
                    return;
                }
            }
        }

        public void GoToPlayer(Server s, Player p)
        {
            base.Focus();
            for (int i = 0; i < lstServers.Items.Count; i++)
            {
                ListViewItem.ListViewSubItemCollection subItems = lstServers.Items[i].SubItems;
                Server server = new Server(subItems[0].Text, subItems[5].Text, subItems[1].Text, subItems[2].Text, int.Parse(subItems[3].Text), int.Parse(subItems[4].Text));
                if (s.Similar(server))
                {
                    lblServerName.Text = "Server: " + s.Name;
                    lstServers.Items[i].Selected = true;
                    break;
                }
            }
            for (int j = 0; j < lstPlayers.Items.Count; j++)
            {
                Player player = new Player(lstPlayers.Items[j].SubItems[0].Text, int.Parse(lstPlayers.Items[j].SubItems[1].Text), int.Parse(lstPlayers.Items[j].SubItems[2].Text));
                if (p.Equals(player))
                {
                    lstPlayers.Focus();
                    lstPlayers.Items[j].Selected = true;
                    lstPlayers.Items[j].Focused = true;
                    return;
                }
            }
        }

        private string HTMLSource(string URL)
        {
            string str = "";
            try
            {
                str = wc.DownloadString(URL);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
            }
            return str;
        }

        private void lstPlayers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView view = (ListView)sender;
            if (e.Column == PlayerSorter.SortColumn)
            {
                if (PlayerSorter.Order == SortOrder.Ascending)
                {
                    PlayerSorter.Order = SortOrder.Descending;
                }
                else
                {
                    PlayerSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                PlayerSorter.SortColumn = e.Column;
                PlayerSorter.Order = SortOrder.Ascending;
            }
            view.Sort();
        }

        private void lstServers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView view = (ListView)sender;
            if (e.Column == ServerSorter.SortColumn)
            {
                if (ServerSorter.Order == SortOrder.Ascending)
                {
                    ServerSorter.Order = SortOrder.Descending;
                }
                else
                {
                    ServerSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                ServerSorter.SortColumn = e.Column;
                ServerSorter.Order = SortOrder.Ascending;
            }
            view.Sort();
        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListView))
                return;
            ListView view = (ListView)sender;
            if (view.SelectedItems.Count == 0)
                return;
            lstVars.Items.Clear();
            lstPlayers.Items.Clear();
            ListViewItem.ListViewSubItemCollection subItems = view.SelectedItems[0].SubItems;
            Server server = new Server(subItems[0].Text, subItems[5].Text, subItems[1].Text, subItems[2].Text, int.Parse(subItems[3].Text), int.Parse(subItems[4].Text));
            Server server2 = new Server();
            foreach (Server server3 in ServerList)
            {
                if (server.Similar(server3))
                {
                    server2 = server3;
                    break;
                }
            }
            foreach (Player player in server2.Players)
            {
                string[] items = new string[] { player.Name, player.Score.ToString(), player.Ping.ToString() };
                lstPlayers.Items.Add(new ListViewItem(items));
            }
            foreach (ServerVar var in server2.Variables)
            {
                string[] strArray2 = new string[] { var.Name, var.Value };
                lstVars.Items.Add(new ListViewItem(strArray2));
            }
            lblServerName.Text = "Server: " + server2.Name;
        }

        private void lstVars_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView view = (ListView)sender;
            if (e.Column == VarSorter.SortColumn)
            {
                if (VarSorter.Order == SortOrder.Ascending)
                {
                    VarSorter.Order = SortOrder.Descending;
                }
                else
                {
                    VarSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                VarSorter.SortColumn = e.Column;
                VarSorter.Order = SortOrder.Ascending;
            }
            view.Sort();
        }
    }
}
