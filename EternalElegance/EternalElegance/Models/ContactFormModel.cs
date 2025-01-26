using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EternalElegance.Models
{
    public class ContactFormModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Message cannot be longer than 1000 characters.")]
        public string Message { get; set; }
    }

}