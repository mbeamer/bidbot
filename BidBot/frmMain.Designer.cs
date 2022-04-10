
namespace BidBot
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musMain = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenBids = new System.Windows.Forms.Button();
            this.btnCopyAllItemLinks = new System.Windows.Forms.Button();
            this.btnCopyItemLinks = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBidAmounts = new System.Windows.Forms.ListView();
            this.chBidder = new System.Windows.Forms.ColumnHeader();
            this.chAmount = new System.Windows.Forms.ColumnHeader();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chTime = new System.Windows.Forms.ColumnHeader();
            this.lblBidAmounts = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbxBidItems = new System.Windows.Forms.ListBox();
            this.lblBidItems = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cmsItems.SuspendLayout();
            this.musMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsItems
            // 
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeleteItem});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(108, 26);
            // 
            // tsmDeleteItem
            // 
            this.tsmDeleteItem.Name = "tsmDeleteItem";
            this.tsmDeleteItem.Size = new System.Drawing.Size(107, 22);
            this.tsmDeleteItem.Text = "Delete";
            // 
            // musMain
            // 
            this.musMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmHelp});
            this.musMain.Location = new System.Drawing.Point(0, 0);
            this.musMain.Name = "musMain";
            this.musMain.Size = new System.Drawing.Size(724, 24);
            this.musMain.TabIndex = 3;
            this.musMain.Text = "mnuMain";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSettings,
            this.toolStripSeparator1,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(37, 20);
            this.tsmFile.Text = "File";
            // 
            // tsmSettings
            // 
            this.tsmSettings.Name = "tsmSettings";
            this.tsmSettings.ShortcutKeyDisplayString = "s";
            this.tsmSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSettings.Size = new System.Drawing.Size(128, 22);
            this.tsmSettings.Text = "Settings";
            this.tsmSettings.Click += new System.EventHandler(this.tsmSettings_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.ShortcutKeyDisplayString = "x";
            this.tsmExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmExit.Size = new System.Drawing.Size(128, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_ItemClicked);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmHelp.Text = "Help";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(107, 22);
            this.tsmAbout.Text = "About";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenBids);
            this.panel1.Controls.Add(this.btnCopyAllItemLinks);
            this.panel1.Controls.Add(this.btnCopyItemLinks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(599, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 462);
            this.panel1.TabIndex = 11;
            // 
            // btnOpenBids
            // 
            this.btnOpenBids.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenBids.Location = new System.Drawing.Point(2, 12);
            this.btnOpenBids.Name = "btnOpenBids";
            this.btnOpenBids.Size = new System.Drawing.Size(123, 31);
            this.btnOpenBids.TabIndex = 13;
            this.btnOpenBids.Text = "Open Bids";
            this.btnOpenBids.UseVisualStyleBackColor = true;
            this.btnOpenBids.Click += new System.EventHandler(this.btnOpenBids_Click_1);
            // 
            // btnCopyAllItemLinks
            // 
            this.btnCopyAllItemLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyAllItemLinks.Location = new System.Drawing.Point(2, 411);
            this.btnCopyAllItemLinks.Name = "btnCopyAllItemLinks";
            this.btnCopyAllItemLinks.Size = new System.Drawing.Size(123, 31);
            this.btnCopyAllItemLinks.TabIndex = 12;
            this.btnCopyAllItemLinks.Text = "Copy All Links";
            this.btnCopyAllItemLinks.UseVisualStyleBackColor = true;
            // 
            // btnCopyItemLinks
            // 
            this.btnCopyItemLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyItemLinks.Location = new System.Drawing.Point(2, 374);
            this.btnCopyItemLinks.Name = "btnCopyItemLinks";
            this.btnCopyItemLinks.Size = new System.Drawing.Size(123, 31);
            this.btnCopyItemLinks.TabIndex = 11;
            this.btnCopyItemLinks.Text = "Copy Item Links";
            this.btnCopyItemLinks.UseVisualStyleBackColor = true;
            this.btnCopyItemLinks.Click += new System.EventHandler(this.btnCopyItemLinks_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lsvBidAmounts);
            this.panel2.Controls.Add(this.lblBidAmounts);
            this.panel2.Location = new System.Drawing.Point(256, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 462);
            this.panel2.TabIndex = 12;
            // 
            // lsvBidAmounts
            // 
            this.lsvBidAmounts.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lsvBidAmounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBidAmounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chBidder,
            this.chAmount,
            this.chType,
            this.chTime});
            this.lsvBidAmounts.HideSelection = false;
            this.lsvBidAmounts.Location = new System.Drawing.Point(0, 32);
            this.lsvBidAmounts.Name = "lsvBidAmounts";
            this.lsvBidAmounts.Size = new System.Drawing.Size(342, 429);
            this.lsvBidAmounts.TabIndex = 11;
            this.lsvBidAmounts.UseCompatibleStateImageBehavior = false;
            this.lsvBidAmounts.View = System.Windows.Forms.View.Details;
            // 
            // chBidder
            // 
            this.chBidder.Text = "Bidder";
            // 
            // chAmount
            // 
            this.chAmount.Text = "Amount";
            // 
            // chType
            // 
            this.chType.Text = "Rank";
            // 
            // chTime
            // 
            this.chTime.Text = "Timestamp";
            this.chTime.Width = 155;
            // 
            // lblBidAmounts
            // 
            this.lblBidAmounts.AutoSize = true;
            this.lblBidAmounts.Location = new System.Drawing.Point(0, 14);
            this.lblBidAmounts.Name = "lblBidAmounts";
            this.lblBidAmounts.Size = new System.Drawing.Size(76, 15);
            this.lblBidAmounts.TabIndex = 10;
            this.lblBidAmounts.Text = "Bid Amounts";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbxBidItems);
            this.panel3.Controls.Add(this.lblBidItems);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 462);
            this.panel3.TabIndex = 13;
            // 
            // lbxBidItems
            // 
            this.lbxBidItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxBidItems.FormattingEnabled = true;
            this.lbxBidItems.ItemHeight = 15;
            this.lbxBidItems.Location = new System.Drawing.Point(4, 37);
            this.lbxBidItems.Name = "lbxBidItems";
            this.lbxBidItems.Size = new System.Drawing.Size(235, 424);
            this.lbxBidItems.TabIndex = 10;
            this.lbxBidItems.SelectedIndexChanged += new System.EventHandler(this.lbxBidItems_SelectedIndexChanged);
            // 
            // lblBidItems
            // 
            this.lblBidItems.AutoSize = true;
            this.lblBidItems.Location = new System.Drawing.Point(0, 14);
            this.lblBidItems.Name = "lblBidItems";
            this.lblBidItems.Size = new System.Drawing.Size(56, 15);
            this.lblBidItems.TabIndex = 9;
            this.lblBidItems.Text = "Bid Items";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(240, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 462);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 486);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.musMain);
            this.MainMenuStrip = this.musMain;
            this.Name = "frmMain";
            this.Text = "BidBot";
            this.cmsItems.ResumeLayout(false);
            this.musMain.ResumeLayout(false);
            this.musMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip musMain;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenBids;
        private System.Windows.Forms.Button btnCopyAllItemLinks;
        private System.Windows.Forms.Button btnCopyItemLinks;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBidAmounts;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBidItems;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView lsvBidAmounts;
        private System.Windows.Forms.ColumnHeader chBidder;
        private System.Windows.Forms.ColumnHeader chAmount;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ListBox lbxBidItems;
    }
}

