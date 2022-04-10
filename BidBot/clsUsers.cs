using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text.RegularExpressions;

namespace BidBot
{
    class clsUser
    {
        public string name;
        public int currentDKP;
        public string eqClass;
        public int attendance90;
        public int attendance30;
        public string rank;
        public bool alt;
        public bool primeAlt;

        /*
         * getBidOrder sorts details of the user in order to rank bids coming from this user
         */
        public int getBidOrder()
        {
            if (alt)
            {
                return clsUsers.BID_ORDER_ALT;
            }
            if (primeAlt)
            {
                return clsUsers.BID_ORDER_PRIME_ALT;
            }
            if (rank == clsUsers.RANK_RECRUIT)
            {
                return clsUsers.BID_ORDER_RECRUIT;
            }
            if (attendance90 < clsUsers.MAIN_RAIDER_THRESHOLD)
            {
                return clsUsers.BID_ORDER_RAIDER_LOW_RA;
            }
            return clsUsers.BID_ORDER_PRIME_RAIDER;
        }
    }
    class clsUsers
    {
        // 90-day attendance required to be considered top tier bidder
        public const int MAIN_RAIDER_THRESHOLD = 60;

        // BID ORDER definitions
        public const int BID_ORDER_PRIME_RAIDER = 0;
        public const int BID_ORDER_RAIDER_LOW_RA = 1;
        public const int BID_ORDER_RECRUIT = 2;
        public const int BID_ORDER_PRIME_ALT = 3;
        public const int BID_ORDER_ALT = 4;
        public static readonly IList<int> BID_ORDER =
            new ReadOnlyCollection<int>(new List<int> { BID_ORDER_PRIME_RAIDER, BID_ORDER_RAIDER_LOW_RA, BID_ORDER_RECRUIT, BID_ORDER_PRIME_ALT, BID_ORDER_ALT });

        // BID ORDER names
        public const string BID_NAME_PRIME_RAIDER = "60+";
        public const string BID_NAME_RAIDER_LOW_RA = "<60";
        public const string BID_NAME_RECRUIT = "RECRUIT";
        public const string BID_NAME_PRIME_ALT = "PRIME";
        public const string BID_NAME_ALT = "ALT";
        public static readonly IList<string> BID_ORDER_NAMES =
            new ReadOnlyCollection<string>(new List<string> { BID_NAME_PRIME_RAIDER, BID_NAME_RAIDER_LOW_RA, BID_NAME_RECRUIT, BID_NAME_PRIME_ALT, BID_NAME_ALT });

        public const string RANK_LEADER = "Leader";
        public const string RANK_CLASS_LEAD = "Class Leader";
        public const string RANK_OFFICER = "Officer";
        public const string RANK_RAIDER = "Raider";
        public const string RANK_RECRUIT = "Recruit";
        public static readonly IList<string> RANKS =
            new ReadOnlyCollection<string>(new List<string> { RANK_LEADER, RANK_CLASS_LEAD, RANK_OFFICER, RANK_RAIDER, RANK_RECRUIT });

        public List<clsUser> users = new List<clsUser>();

        private void loadFromRoster(string roster)
        {
            string[] rosterLines = System.IO.File.ReadAllLines(roster);

            int COL_NAME = 0;
            int COL_LEVEL = 1;
            int COL_CLASS = 2;
            int COL_RANK = 3;
            int COL_IS_ALT = 4;
            int COL_LAST_ON = 5;
            int COL_ZONE = 6;
            int COL_NOTE_1 = 7;
            int COL_UNKNOWN = 8;
            int COL_BOOL_1 = 9;
            int COL_BOOL_2 = 10;
            int COL_INT_1 = 11;
            int COL_JOINED = 12;
            int COL_NOTE_2 = 13;
            int COL_TAB_1 = 14;

            // Name | Level | class | Rank | A? | LastOn | Zone | Note | ??? | on? | on? | int | date | Note | \cr\lf
            //   0  |    1  |   2   |   3  |  4 |   5    |   6  |  7   |  8  |  9  |  10 |  11  |  12  | 13  | 14

            // Display the file contents by using a foreach loop.
            foreach (string line in rosterLines)
            {
                string sep = "\t";

                // Use a tab to split each line of the file.
                string[] splitLine = line.Split(sep.ToCharArray());
                clsUser currentUser;
                if (this.users.Any((x => x.name.Equals(splitLine[0]))))
                {
                    currentUser = this.users.SingleOrDefault(x => x.name.Equals(splitLine[0]));
                } else
                {
                    currentUser = new clsUser();
                    this.users.Add(currentUser);
                }
                currentUser.name = splitLine[COL_NAME];
                currentUser.eqClass = splitLine[COL_CLASS];
                currentUser.rank = splitLine[COL_RANK];
                currentUser.primeAlt = currentUser.rank == "Prime Alt";
                if (!currentUser.primeAlt)
                {
                    currentUser.alt = splitLine[COL_IS_ALT] == "A";
                }
            }
        }

        private string lookupPattern(string pattern, string data)
        {
            Regex rg = new Regex(pattern);
            Match matches = rg.Match(data);
            return matches.Groups[1].Captures[0].Value;
        }

        private void mergeUser(clsUser tempUser)
        {
            clsUser matchingUser;

            matchingUser = this.users.Find(x => x.name == tempUser.name);
            if (matchingUser != null)
            {
                matchingUser.attendance90 = tempUser.attendance90;
                matchingUser.currentDKP = tempUser.currentDKP;
                matchingUser.rank = tempUser.rank;
                matchingUser.eqClass = tempUser.eqClass;
                matchingUser.attendance30 = tempUser.attendance30;
            }
        }

        public int getBidType(string bidder)
        {
            return this.users.SingleOrDefault(x => x.name.Equals(bidder)).getBidOrder();
        }

        public string getBidTypeName(int bidType)
        {
            return BID_ORDER_NAMES[bidType];
        }
        private async void loadFromDkp(string dkpSite)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            string pattern;
            string tempData;
            string content = await client.GetStringAsync(dkpSite);

            clsUser tempUser = new clsUser();
            bool foundUser = false;
            int bodyIndex = 0;
            using (StringReader reader = new StringReader(content))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (foundUser)
                    {
                        switch(bodyIndex)
                        {
                            case 0:
                                // Checkbox column
                                tempUser = new clsUser();
                                break;
                            case 1:
                                // Page index
                                break;
                            case 2:
                                // 90 day
                                pattern = "    <td.*>(\\d+)%</td>";
                                tempData = lookupPattern(pattern, line);
                                tempUser.attendance90 = Int32.Parse(tempData);
                                break;
                            case 3:
                                // Name
                                pattern = "    <td .*>(.*)</a></td>";
                                tempUser.name = lookupPattern(pattern, line);
                                break;
                            case 4:
                                // DKP Balance
                                pattern = "    <td .*>(.*)</td>";
                                tempUser.currentDKP = Int32.Parse(lookupPattern(pattern, line));
                                break;
                            case 5:
                                // Rank
                                pattern = "    <td .*>(.*)</a>";
                                tempUser.rank= lookupPattern(pattern, line);
                                break;
                            case 6:
                                // Class
                                pattern = "    <td .*>(.*)</td>";
                                tempUser.eqClass= lookupPattern(pattern, line);
                                break;
                            case 7:
                                // Lifetime Earned
                                break;
                            case 8:
                                //Last Raid
                                break;
                            case 9:
                                // 30 day
                                pattern = "    <td .*>(\\d+)%</td>";
                                tempUser.attendance30= Int32.Parse(lookupPattern(pattern, line));
                                break;
                            default:
                                bodyIndex = -1;
                                foundUser = false;
                                mergeUser(tempUser);
                                break;
                        }
                        bodyIndex += 1;
                    }
                    else
                    {
                        foundUser = line.StartsWith("  <tr class=\"row1\">");
                        foundUser |= line.StartsWith("  <tr class=\"row2\">");
                    }

                }
            }
        }

        public void loadUsers(string roster, string dkpSite)
        {
            loadFromRoster(roster);
            loadFromDkp(dkpSite);
        }
    }
}
