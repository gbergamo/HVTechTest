using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Model
{
    public class APIOptions
    {
        public string[] AllowedTimeOfDays { get; set; }
        public int[] AllowedFoodIds { get; set; }
    }
}
