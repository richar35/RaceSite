using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RaceSite.ViewModels;

namespace RaceSite.Models
{
    public class Shoe
    {
        // EF will instruct the database to automatically generate this value
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a Brand.")]
        public string Brand { get; set; }


        [Required(ErrorMessage = "Please enter a Name.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter shoe use; Road or Trail.")]
        public string Use { get; set; }


        [Required(ErrorMessage = "Pleasse enter a support Type; Neutral or Stability.")]
        public string Support { get; set; }

        public ICollection<Registrant> Registrants { get; set; }


    }
}
