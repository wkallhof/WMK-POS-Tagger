using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebExample.Models
{
    public class TaggerViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}