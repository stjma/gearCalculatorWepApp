using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gearCalculator.Models
{
    public class GearViewModel
    {
  
        public string Cogmax { get; set; }
       
        public string Cogmin { get; set; }
        
        public string Chainringmax { get; set; }
       
        public string Chainringmin { get; set; }
    }
}
