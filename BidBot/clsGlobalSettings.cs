using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidBot
{
    public class GlobalSettings
    {
        public const string DEFAULT_ROSTER_URL = "http://www.crimsontempest.net/dfp/listmembers.php?show=all";
        public const string DEFAULT_ROSTER_PATH = "C:\\EQ\\roster.txt";
        public const string DEFAULT_EQ_LOG_PATH = "C:\\EQ\\Logs\\player.log";
        public const string DEFAULT_PAY_SECOND_BID = "false";

        public string rosterUrl;
        public string rosterPath;
        public string eqLogPath;
        public bool paySecondBid;

        public GlobalSettings()
        {
            string settingsPath = @"%AppData%\bidbot_settings.cfg";
            settingsPath = Environment.ExpandEnvironmentVariables(settingsPath);
            if (File.Exists(settingsPath))
            {
                using StreamReader settingsFile = new(settingsPath);
                string json = settingsFile.ReadToEnd();
                dynamic settings = JsonConvert.DeserializeObject(json);
                this.rosterUrl = settings.RosterUrl;
                this.rosterPath = settings.RosterPath;
                this.eqLogPath = settings.EQLogPath;
                this.paySecondBid = settings.paySecondBid;
            }
            else
            {
                this.rosterUrl = GlobalSettings.DEFAULT_ROSTER_URL;
                this.rosterPath = GlobalSettings.DEFAULT_ROSTER_PATH;
                this.eqLogPath = GlobalSettings.DEFAULT_EQ_LOG_PATH;
                this.paySecondBid = GlobalSettings.DEFAULT_PAY_SECOND_BID == "true";
            }
        }
        public void SaveSettings()
        {
            string json = $"{{'RosterUrl': '{rosterUrl}', 'RosterPath': '{rosterPath}', 'EQLogPath': '{eqLogPath}', 'paySecondBid': '{paySecondBid}'}}";

            string settingsPath = @"%AppData%\bidbot_settings.cfg";
            settingsPath = Environment.ExpandEnvironmentVariables(settingsPath);
            using StreamWriter settingsFile = new(settingsPath);
            settingsFile.Write(json);
        }
    }
}
