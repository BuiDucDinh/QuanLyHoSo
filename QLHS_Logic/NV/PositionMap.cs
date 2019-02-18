using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace QLHS_Logic.NV
{
    /// <summary>
    /// Summary description for MakerMap
    /// </summary>
    public class PositionMap
    {
        public PositionMap()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string address { get; set; }
        public string content { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }

    }
}