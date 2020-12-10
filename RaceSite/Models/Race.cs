using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RaceSite.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceSite.Models
{

    public class Race
    {
       
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Race Date")]
        public DateTime RaceDate { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Please enter your race name.")]
        [Display(Name = "Race Name")]
        public string RaceName { get; set; }

        [StringLength(30, ErrorMessage = "Please enter the city using 30 characters or less.")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter the state using 2 characters.")]
        public string State { get; set; }






        public ICollection<Registrant> Registrants { get; set; }

       

    }
}
