using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorldWideImporters.Models.ViewModels
{
    public class Human
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        [Display(Name = "Fax Number")]
        public string FaxNumber { get; set; }

        [StringLength(256)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Member Since")]
        public DateTime ValidFrom { get; set; }
    }
}