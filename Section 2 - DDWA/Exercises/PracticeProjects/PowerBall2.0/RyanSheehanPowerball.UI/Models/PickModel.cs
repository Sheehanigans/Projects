using RyanSheehanPowerball.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RyanSheehanPowerball.UI.Models
{
    public class PickModel
    {
        public int PickID { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        public string LastName { get; set; }

        [PickNumbers(ErrorMessage = "Invalid Number")]
        [Required(ErrorMessage = "Please enter a number")]
        public List<int> PickNumbers { get; set; } = new List<int>();

        [Required(ErrorMessage = "Please enter a number")]
        public int Powerball { get; set; }
    }
}