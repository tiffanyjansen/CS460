using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    public class ItemsPurchased
    {
        public int StockItemID { get; set; }

        public string Description { get; set; }

        public decimal Profit { get; set; }

        public Person Salesperson { get; set; }
    }
}