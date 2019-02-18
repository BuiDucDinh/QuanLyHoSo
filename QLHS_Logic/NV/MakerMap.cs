using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MakerMap
/// </summary>
public class MarkerMap
{
	public MarkerMap()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string content { get; set; }
    public float lat { get; set; }
    public float lng { get; set; }

}