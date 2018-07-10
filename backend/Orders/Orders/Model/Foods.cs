using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Model
{
    public class Foods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Model.Enums.TimeOfDayEnum TimeOfDay { get; set; }
    }
}
