using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaceSite.Models;

namespace RaceSite.ViewModels
{
    public class ParticipantsViewModel
    {

        public List<Race> Race { get; set; }
        public List<Registrant> Registrant { get; set; }

    }
}
