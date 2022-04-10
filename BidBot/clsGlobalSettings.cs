using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidBot
{
    public class GlobalSettings
    {
        public const string DEFAULT_ROSTER_URL = "http://www.crimsontempest.net/dfp/listmembers.php?show=all";
        public const string DEFAULT_ROSTER_PATH = "C:\\EQ\\roster.txt";
        public const string DEFAULT_EQ_LOG_PATH = "C:\\EQ\\Logs\\player.log";
        public const string DEFAULT_PAY_SECOND_BID = "false";

        [JsonProperty("rosterUrl")]
        public string rosterUrl;
        [JsonProperty("rosterPath")]
        public string rosterPath;
        [JsonProperty("eqLogPath")]
        public string eqLogPath;
        [JsonProperty("paySecondBid")]
        public bool paySecondBid;

        public DialogResult GetDefaults()
        {
            this.rosterUrl = GlobalSettings.DEFAULT_ROSTER_URL;
            this.rosterPath = GlobalSettings.DEFAULT_ROSTER_PATH;
            this.eqLogPath = GlobalSettings.DEFAULT_EQ_LOG_PATH;
            this.paySecondBid = GlobalSettings.DEFAULT_PAY_SECOND_BID == "true";

            frmSettings settings = new();
            settings.LoadSettings(this);
            return settings.ShowDialog();
        }
        public void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(this);

            string settingsPath = @"%AppData%\bidbot_settings.cfg";
            settingsPath = Environment.ExpandEnvironmentVariables(settingsPath);
            using StreamWriter settingsFile = new(settingsPath);
            settingsFile.Write(json);
        }
    }
}
