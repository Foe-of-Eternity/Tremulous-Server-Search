using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tremulous_Server_Search
{
    public partial class Form2 : Form
    {
        private Form1 form;
        private List<ServerPlayer> Servers;
        private TextBox txtPlayerName;
        public Form2(Form1 Sender)
        {
            InitializeComponent();
            form = Sender;
            Servers = new List<ServerPlayer>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ServerPlayer> list = form.findPlayer(txtPlayerName.Text, chkExact.Checked);
            Servers.Clear();
            lstServers.Items.Clear();
            foreach (ServerPlayer player in list)
            {
                lstServers.Items.Add(player.server.ToString());
                Servers.Add(player);
            }
        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServers.Items.Count != 0 && lstServers.SelectedIndex >= 0 && lstServers.SelectedIndex < lstServers.Items.Count)
                form.GoToPlayer(Servers[lstServers.SelectedIndex]);
        }
    }
}
