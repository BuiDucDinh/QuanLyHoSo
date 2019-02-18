using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLHS_Logic.NV
{
    public class Address
    {
        public string id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string href { get; set; }
        public int tags { get; set; }
        public List<Address> nodes { get; set; }
    }
}
