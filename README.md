# Bidbot
The bot is designed to read Everquest log files and extract well formatted bids for the items after an event.

![BidBot main screen](https://github.com/mbeamer/bidbot/blob/master/BidBot.png "BidBot in action")

## Configuration
To get started the bot requires:
* A Guild roster dump
  * Include Offline
  * Include Alts
* The url to crimsontempest dkp
  * Set as a default to http://www.crimsontempest.net/dfp/listmembers.php?show=all
* Path to your EQ log file
  * Local or over a network is fine
* Select whether users pay their bid, or the next highest

## Usage
Run the app on the computer which has access to your log files.

1. To monitor for bids, click Open Bids
  * You will see bids flow in
  * You can select the various Bid Items to see who is bidding on them
  * The (#) displayed to the right of an item is the number of bidders for it

2. After you are satisfied all bids are in, click Close Bids
  * Note: Open Bids also clears the current bids, so beware!

3. Copy Item Links
  * For the current item, create a copy buffer suitable for pasting into EQ of the winner and relevant details

4. Optionally: Copy All Links
  * To get a copy buffer with all items in it, use this button

## Bidding
The format of bids matters!

```[Item Link] [Bid Amount]```

Item links: come from ctrl+click on the icon in the gear window.
Bid Amount: Simply the amount you'd like to spend for the item.

Bids which do not conform to this format will be disregarded.  As well, bids from players no in the guild dump will be ignored.

