using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    public class Information
    {

        public Human Person { get; set; }

        public Company Company { get; set; }

        public PurchaseHistory PurchaseHistory { get; set; }

        public ItemsPurchased ItemsPurchased { get; set; }
    }
}