using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPolice.Citys
{
    public  class City
    {
        public string name { get; set; }
        public List<Town> towns { get; set; }
    }
}
