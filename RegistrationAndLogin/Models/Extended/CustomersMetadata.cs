﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Models
{
    public class CustomersMetadata
    {
       public int id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [DisplayName("Customer Name")]
        public string name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Type is required")]
        [DisplayName("Type")]
        public string type { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        public string emailAddress { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Telephone # is required")]
        [DisplayName("Telephone #")]
        public string contact { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Date Added")]
        public DateTime? addedDate { get; set; }

       // [Required(ErrorMessage = "Added By is required")]
        [DisplayName("Added By")]
        public int addedBy { get; set; }
             }
            [MetadataType(typeof(CustomersMetadata))]
            public partial class customer
            {

            }
        }


