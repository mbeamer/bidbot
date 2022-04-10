using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidBot
{
    public partial class frmSettings : Form
    {
        GlobalSettings globalSettings;
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LoadSettings(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
            txtPathToEQLog.Text = globalSettings.eqLogPath;
            txtURLtoRoster.Text = globalSettings.rosterUrl;
            chbPaySecondBid.Checked = globalSettings.paySecondBid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.globalSettings.eqLogPath = txtPathToEQLog.Text;
            this.globalSettings.rosterPath = txtPathToRoster.Text;
            this.globalSettings.rosterUrl = txtURLtoRoster.Text;
            this.globalSettings.paySecondBid = chbPaySecondBid.Checked;

            this.globalSettings.SaveSettings();
        }
    }
}
