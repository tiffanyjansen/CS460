using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    public class PurchaseHistory
    {
        public int Orders { get; set; }

        public decimal GrossSales { get; set; }

        public decimal GrossProfit { get; set; }
    }
}