namespace Tremulous_Server_Search
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.lstServers = new System.Windows.Forms.ListView();
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGame = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstPlayers = new System.Windows.Forms.ListView();
            this.colPlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlayerScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlayerPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstVars = new System.Windows.Forms.ListView();
            this.colVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVarVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtServers = new System.Windows.Forms.Label();
            this.txtPlayers = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Location = new System.Drawing.Point(-2, 339);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(826, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Refresh";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstServers
            // 
            this.lstServers.AllowColumnReorder = true;
            this.lstServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colServer,
            this.colMap,
            this.colGame,
            this.colPlayers,
            this.colMaxPlayers,
            this.colIP});
            this.lstServers.FullRowSelect = true;
            this.lstServers.Location = new System.Drawing.Point(-1, -1);
            this.lstServers.MultiSelect = false;
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(529, 321);
            this.lstServers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstServers.TabIndex = 2;
            this.lstServers.UseCompatibleStateImageBehavior = false;
            this.lstServers.View = System.Windows.Forms.View.Details;
            this.lstServers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstServers_ColumnClick);
            this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
            // 
            // colServer
            // 
            this.colServer.Text = "Server Name";
            this.colServer.Width = 186;
            // 
            // colMap
            // 
            this.colMap.Text = "Map";
            this.colMap.Width = 76;
            // 
            // colGame
            // 
            this.colGame.Text = "Game";
            this.colGame.Width = 58;
            // 
            // colPlayers
            // 
            this.colPlayers.Text = "Players";
            this.colPlayers.Width = 24;
            // 
            // colMaxPlayers
            // 
            this.colMaxPlayers.Text = "Max Players";
            this.colMaxPlayers.Width = 24;
            // 
            // colIP
            // 
            this.colIP.Text = "IP";
            this.colIP.Width = 140;
            // 
            // lstPlayers
            // 
            this.lstPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPlayerName,
            this.colPlayerScore,
            this.colPlayerPing});
            this.lstPlayers.FullRowSelect = true;
            this.lstPlayers.Location = new System.Drawing.Point(527, 16);
            this.lstPlayers.MultiSelect = false;
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(296, 163);
            this.lstPlayers.TabIndex = 3;
            this.lstPlayers.UseCompatibleStateImageBehavior = false;
            this.lstPlayers.View = System.Windows.Forms.View.Details;
            this.lstPlayers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstPlayers_ColumnClick);
            // 
            // colPlayerName
            // 
            this.colPlayerName.Text = "Player Name";
            this.colPlayerName.Width = 185;
            // 
            // colPlayerScore
            // 
            this.colPlayerScore.Text = "Score";
            this.colPlayerScore.Width = 45;
            // 
            // colPlayerPing
            // 
            this.colPlayerPing.Text = "Ping";
            this.colPlayerPing.Width = 45;
            // 
            // lstVars
            // 
            this.lstVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVarName,
            this.colVarVal});
            this.lstVars.Location = new System.Drawing.Point(527, 178);
            this.lstVars.MultiSelect = false;
            this.lstVars.Name = "lstVars";
            this.lstVars.Size = new System.Drawing.Size(296, 163);
            this.lstVars.TabIndex = 4;
            this.lstVars.UseCompatibleStateImageBehavior = false;
            this.lstVars.View = System.Windows.Forms.View.Details;
            this.lstVars.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVars_ColumnClick);
            // 
            // colVarName
            // 
            this.colVarName.Text = "Name";
            this.colVarName.Width = 135;
            // 
            // colVarVal
            // 
            this.colVarVal.Text = "Value";
            this.colVarVal.Width = 140;
            // 
            // chkEmpty
            // 
            this.chkEmpty.AutoSize = true;
            this.chkEmpty.Checked = true;
            this.chkEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmpty.Location = new System.Drawing.Point(1, 323);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(55, 17);
            this.chkEmpty.TabIndex = 5;
            this.chkEmpty.Text = "Empty";
            this.chkEmpty.UseVisualStyleBackColor = true;
            this.chkEmpty.CheckedChanged += new System.EventHandler(this.chkEmpty_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(62, 319);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 22);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find Player";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtServers
            // 
            this.txtServers.AutoSize = true;
            this.txtServers.Location = new System.Drawing.Point(143, 324);
            this.txtServers.Name = "txtServers";
            this.txtServers.Size = new System.Drawing.Size(55, 13);
            this.txtServers.TabIndex = 8;
            this.txtServers.Text = "Servers: 0";
            // 
            // txtPlayers
            // 
            this.txtPlayers.AutoSize = true;
            this.txtPlayers.Location = new System.Drawing.Point(208, 324);
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.Size = new System.Drawing.Size(53, 13);
            this.txtPlayers.TabIndex = 9;
            this.txtPlayers.Text = "Players: 0";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(528, 2);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(70, 13);
            this.lblServerName.TabIndex = 10;
            this.lblServerName.Text = "Server: None";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 360);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.txtPlayers);
            this.Controls.Add(this.txtServers);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lstServers);
            this.Controls.Add(this.lstVars);
            this.Controls.Add(this.chkEmpty);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Tremulous_Server_Search.Properties.Resources.favicon;
            this.Name = "Form1";
            this.Text = "Tremulous Server List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkEmpty;
        private System.Windows.Forms.ColumnHeader colGame;
        private System.Windows.Forms.ColumnHeader colIP;
        private System.Windows.Forms.ColumnHeader colMap;
        private System.Windows.Forms.ColumnHeader colMaxPlayers;
        private System.Windows.Forms.ColumnHeader colPlayerName;
        private System.Windows.Forms.ColumnHeader colPlayerPing;
        private System.Windows.Forms.ColumnHeader colPlayers;
        private System.Windows.Forms.ColumnHeader colPlayerScore;
        private System.Windows.Forms.ColumnHeader colServer;
        private System.Windows.Forms.ColumnHeader colVarName;
        private System.Windows.Forms.ColumnHeader colVarVal;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.ListView lstPlayers;
        private System.Windows.Forms.ListView lstServers;
        private System.Windows.Forms.ListView lstVars;
    }
}

