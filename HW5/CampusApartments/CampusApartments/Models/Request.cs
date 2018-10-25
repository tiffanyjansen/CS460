﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampusApartments.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        [Required]
        [Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string MaintenanceRequired { get; set; }

        public DateTime TimeOfRequest
        {
            get
            {
                var today = DateTime.Today;
                return today;
            }
        }

        public bool Check
        {
            get { return Permission == 1; }
            set
            {
                if (value)
                    Permission = 1;
                else
                    Permission = 0;
            }
        }

        [Display(Name = "Permission to enter if no one answers door? Check for yes.")]
        public int Permission { get; set; }
    }
}