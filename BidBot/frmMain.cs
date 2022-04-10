using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidBot
{
    public partial class frmMain : Form
    {
        private const string OPEN_BIDS_TEXT = "Open Bids";
        private const string CLOSE_BIDS_TEXT = "Close Bids";
        private GlobalSettings globalSettings;
        private ClsBidReader bidReader;
        private clsUsers raiders;
        BindingSource bsBids = new BindingSource();

        public frmMain()
        {
            InitializeComponent();
            this.globalSettings = new();
            this.bidReader = new(this.globalSettings.eqLogPath);
            this.bsBids.DataSource = this.bidReader.bidItems;
            this.bidReader.PropertyChanged += BidReader_PropertyChanged;
            lbxBidItems.DataSource = bsBids;
            this.lbxBidItems.DisplayMember = "BidItem";
            this.raiders = new clsUsers();
            this.raiders.loadUsers(this.globalSettings.rosterPath, this.globalSettings.rosterUrl);
        }

        private void BidReader_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Action safeUpdate = delegate
            {
                this.bsBids.ResetBindings(true);
                updateBidView();
            };
            this.Invoke(safeUpdate);
        }

        private void tsmSettings_ItemClicked(object sender, EventArgs e)
        {
            frmSettings settings = new();
            settings.LoadSettings(globalSettings);
            settings.Show();
        }

        private void tsmExit_ItemClicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnOpenBids_Click_1(object sender, EventArgs e)
        {
            if (btnOpenBids.Text == OPEN_BIDS_TEXT)
            {
                if (this.bidReader.startMonitorLog(this.bsBids, this.raiders))
                {
                    btnOpenBids.Text = CLOSE_BIDS_TEXT;
                    this.bsBids.Clear();
                }
            }
            else
            {
                btnOpenBids.Text = OPEN_BIDS_TEXT;
                this.bidReader.endMonitorLog();
            }
        }

        private void updateBidView()
        {
            lsvBidAmounts.Items.Clear();
            if (lbxBidItems.SelectedIndex > -1)
            {
                BindingList<BidItem> bidItems = (BindingList<BidItem>)this.bidReader.bidItems;
                BidItem bidItem = bidItems[lbxBidItems.SelectedIndex];

                int bidItemIndex = 0;
                foreach (Bid bid in bidItem.itemBids)
                {
                    ListViewItem lsvItem = new ListViewItem(bid.bidder, bidItemIndex);
                    lsvItem.SubItems.Add(bid.amount.ToString());
                    lsvItem.SubItems.Add(bid.bidTypeName);
                    lsvItem.SubItems.Add(bid.bidTimeStamp);
                    lsvBidAmounts.Items.Add(lsvItem);
                }
            }
        }

        private void lbxBidItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBidView();
        }

        private void btnCopyItemLinks_Click(object sender, EventArgs e)
        {
            if (lbxBidItems.SelectedIndex > -1)
            {
                string bidWinner = lsvBidAmounts.Items[0].SubItems[0].Text;
                string bidItem = lbxBidItems.Items[lbxBidItems.SelectedIndex].ToString();

                // Trim off the item count
                int index = bidItem.IndexOf("(");
                if (index >= 0)
                    bidItem = bidItem.Substring(0, index);

                if (globalSettings.paySecondBid)
                {
                    string paidAmount = "200";
                    if (lsvBidAmounts.Items.Count > 1)
                    {
                        paidAmount = lsvBidAmounts.Items[1].SubItems[1].Text;
                    }
                    string bidAmount = lsvBidAmounts.Items[0].SubItems[1].Text;
                    string bidAnnouncement = bidItem + ": Won by " + bidWinner + " for " + paidAmount + " (" + bidAmount + ")";
                    Clipboard.SetText(bidAnnouncement);
                } else
                {
                    string paidAmount = lsvBidAmounts.Items[0].SubItems[1].Text;
                    string bidAnnouncement = bidItem + ": Won by " + bidWinner + " for " + paidAmount;
                    Clipboard.SetText(bidAnnouncement);
                }
            }
        }
    }
}
