using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionHouse.Models.ViewModels
{
    public class BidItem
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public string ItemName { get; set; }

        public string Buyer { get; set; }

        public decimal BidAmount { get; set; }

        public DateTime Timestamp { get; set; }
    }
}