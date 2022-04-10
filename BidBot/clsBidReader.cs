using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Text.RegularExpressions;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace BidBot
{
    class Bid : IComparable<Bid>
    {
        public DateTime timestamp = new DateTime();
        public string bidTimeStamp;
        public string item;
        public string bidder;
        public int amount;
        public int bidType;
        public string bidTypeName;
        public bool alt;

        public int CompareTo(Bid compareBid)
        {
            // Check bidder type precidence
            if (this.bidType > compareBid.bidType)
            {
                return -1;
            } else if (this.bidType < compareBid.bidType) {
                return 1;
            }

            // Check bid amount
            if (this.amount > compareBid.amount)
            {
                return -1;
            } else if (this.amount < compareBid.amount) 
            {
                return 1;
            }

            // Check timestamp
            if (this.timestamp > compareBid.timestamp)
            {
                return 1;
            }  else if (this.timestamp < compareBid.timestamp)
            {
                return -1;
            }
            return 0;
        }
    }
    class BidItem
    {
        public string item;
        public List<Bid> itemBids = new List<Bid>();

        public override string ToString()
        {
            return string.Format("{0}", item);
        }
    }
    class ClsBidReader : INotifyPropertyChanged
    {
        private const string BID_PATTERN = "\\[(.*)\\] (.*) tells you, \\'(.*) ([0-9]+)([alt]?)\\'";
        private const string DATE_TIME_PATTERN = "ddd MMM dd HH:mm:ss yyyy";
        private string readerFile;
        private long previousReadPosition;
        private BindingSource bsItems;
        clsUsers users;
        System.Timers.Timer aTimer;
        public BindingList<BidItem> bidItems;
        public event PropertyChangedEventHandler PropertyChanged;

        /*
         * updateBids - Manage bidItems.  
         */
        private void updateBids(Bid bid)
        {
            // Find item in bids list, or add new.
            BidItem bidForItem;
            if (this.bidItems.Any(x => x.item.Contains(bid.item + " (")))
            {
                bidForItem = this.bidItems.SingleOrDefault(x => x.item.Contains(bid.item + " ("));
            }
            else
            {
                bidForItem = new BidItem();
                this.bidItems.Add(bidForItem);
            }
            updateItemBids(bidForItem, bid);
        }
        /*
         * updateItemBids - 
         */
        private void updateItemBids(BidItem bidForItem, Bid bid)
        {       
            // Find bid for this bidder, or add new
            if (bidForItem.itemBids.Any(x => x.bidder.Equals(bid.bidder)))
            {
                // Updating bid
                Bid bidToUpdate = bidForItem.itemBids.Single(x => x.bidder.Equals(bid.bidder));
                bidToUpdate.amount = bid.amount;
            } else
            {
                // New bid
                bidForItem.itemBids.Add(bid);
            }

            bidForItem.itemBids.Sort();
            // Update item property to indicate the number of bids in place.
            bidForItem.item = bid.item + " (" + bidForItem.itemBids.Count().ToString() + ")";
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ClsBidReader(string logFile)
        {
            readerFile = logFile;
            this.bidItems = new BindingList<BidItem>();

            // Create a timer with a ten second interval.
            this.aTimer = new(3000);
            this.aTimer.Elapsed += new ElapsedEventHandler(timerCallback);
        }

        public bool startMonitorLog(BindingSource bs, clsUsers users)
        {
            this.bsItems = bs;
            this.users = users;
            try
            {
                using (FileStream fs = new FileStream(this.readerFile, FileMode.Open))
                {
                    previousReadPosition = fs.Length;
                }
                this.aTimer.Enabled = true;
                return true;
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
        }

        public void endMonitorLog()
        {
            this.aTimer.Enabled = false;
        }
        /*
         * findBids - From the newly available logLines, extract all bids found and return them as a list.
         */
        private List<Bid> findBids(byte[] logLines)
        {
            var stream = new StreamReader(new MemoryStream(logLines));
            string strLogLines;
            List<Bid> bids = new();

            strLogLines = stream.ReadToEnd();

            MatchCollection regexBid = Regex.Matches(strLogLines, ClsBidReader.BID_PATTERN);
            foreach (Match regexMatch in regexBid)
            {
                GroupCollection groups = regexMatch.Groups;

                Bid newBid = new();
                try
                {
                    DateTime.TryParseExact(groups[1].Value.Trim(), ClsBidReader.DATE_TIME_PATTERN, CultureInfo.InvariantCulture, DateTimeStyles.None, out newBid.timestamp);
                    newBid.bidTimeStamp = groups[1].Value;
                    newBid.bidder = groups[2].Value;
                    newBid.item = groups[3].Value;
                    newBid.amount = Int32.Parse(groups[4].Value);
                    newBid.bidType = this.users.getBidType(newBid.bidder);
                    newBid.bidTypeName = this.users.getBidTypeName(newBid.bidType);
                    newBid.alt = groups.Count > 3;

                    bids.Add(newBid);
                } catch
                {
                    Form dlgMsg = new Form();
                    dlgMsg.Text = "Error processing log line from: " + newBid.bidder;
                    dlgMsg.ShowDialog();
                }
            }

            return bids;
        }
        private async void timerCallback(object source, ElapsedEventArgs e)
        {
            byte[] result;
            this.aTimer.Enabled = false;
            try
            {
                using (FileStream SourceStream = File.Open(this.readerFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    ArrayList Bid = new ArrayList();

                    long thisReadPosition = this.previousReadPosition;
                    this.previousReadPosition = SourceStream.Length;
                    if (SourceStream.Length > thisReadPosition)
                    {
                        result = new byte[SourceStream.Length - thisReadPosition + 1];
                        SourceStream.Seek(thisReadPosition, SeekOrigin.Begin);
                        SourceStream.Read(result, 0, (int)(this.previousReadPosition - thisReadPosition));

                        List<Bid> bids = findBids(result);

                        // Put the new bids into their apprioriate bidItems structure
                        foreach (Bid bid in bids)
                        {
                            updateBids(bid);
                        }
                        NotifyPropertyChanged();
                    }
                }
            } finally
            {
                this.aTimer.Enabled = true;
            }

        }
    }


}
