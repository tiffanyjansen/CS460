using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    public class Product
    {
        [Key]
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public decimal Profit { get; set; }
        public string Salesperson { get; set; }
    }
}