using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Report
/// </summary>
public class Parameters
{
    public Parameters(object PrValue, int PrRow, int PrColl)
    {
        this.PrValue = PrValue;
        this.PrRow = PrRow;
        this.PrColl = PrColl;
    }
    public object PrValue;//Giá trị
    public int PrRow;
    public int PrColl;
}

public class Tables
{
    public Tables(DataTable PrValue, int PrRow, int PrColl)
    {
        this.PrValue = PrValue;
        this.PrRow = PrRow;
        this.PrColl = PrColl;
    }
    public DataTable PrValue;//Giá trị
    public int PrRow;
    public int PrColl;
}

public class Report1
{
    public string Template; // Đường dẫn file report
    public bool GenHeader;
    public List<Tables> lsTable; // Danh sách lớp Table        
    public List<Parameters> lsParameter; // Danh sách lớp Parameter   
    public Report1()
    {
        this.lsParameter = new List<Parameters>();
        this.lsTable = new List<Tables>();
    }
}