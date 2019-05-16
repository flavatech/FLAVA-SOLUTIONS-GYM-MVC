using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    public class categoryMetaData
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [StringLength(120)]
        public string description { get; set; }


        [Display(Name="Date Added")]
        public DateTime? dateAdded { get; set; }

        // public Nullable<System.DateTime> dateAdded { get; set; }
        [Required(ErrorMessage = "Added By is required")]
        [Display(Name = "Added By")]
        public int addedBy { get; set; }
    }
    [MetadataType(typeof(categoryMetaData))]
    public partial class category
    {

    }
}