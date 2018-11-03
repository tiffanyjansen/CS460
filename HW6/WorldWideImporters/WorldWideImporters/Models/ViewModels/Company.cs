using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    public class Company
    {
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string CompPhoneNumber { get; set; }

        [StringLength(20)]
        [Display(Name = "Fax Number")]
        public string CompFaxNumber { get; set; }

        [StringLength(256)]
        [Display(Name = "Website")]
        public string Website { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Member Since")]
        public DateTime ValidFrom { get; set; }
    }
}