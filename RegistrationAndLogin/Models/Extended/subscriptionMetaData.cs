using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    public class subscriptionMetaData
    {
        public int id { get; set; }
        [StringLength(90)]
        [Required(ErrorMessage = "Subscription name is required")]
        [DisplayName("Subscription Name")]
         public string name { get; set; }

        [StringLength(90)]
        [Required(ErrorMessage = "Category name is required")]
        [DisplayName("Category")]
        public string category { get; set; }

        [StringLength(120)]
        [Required(ErrorMessage = "Description is required")]
        [DisplayName("Description")]
        public string description { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Price")]
        public Nullable<decimal> price { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [DisplayName("Quantity")]
        public Nullable<int> quantity { get; set; }



        [DisplayName("Date Added")]

        public DateTime? dateAdded { get; set; }

        [DisplayName("Added By")]
        public int addedBy { get; set; }
    }
    [MetadataType(typeof(subscriptionMetaData))]
    public partial class subscription
    {

    }
}