using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DHM_Report
{
    public class Querry
    {
        public string SqlQuerry; // Query cần chạy
        public string TableName; // Tên bảng cần fill
        public Querry(string SqlQuerry, string TableName)
        {
            this.SqlQuerry = SqlQuerry;
            this.TableName = TableName;
        }
    }
    public class Parameters
    {
        public Parameters(string PrName, object PrValue)
        {
            this.PrName = PrName;
            this.PrValue = PrValue;
        }
        public string PrName;//Tên parameter
        public string PrType;//kiểu parameter string, int, datetime
        public object PrValue;//Giá trị
    }
    public class Hiddens
    {
        public Hiddens(string PrName)
        {
            this.PrName = PrName;
        }
        public string PrName;//Tên bookmark hidden                
    }
    public class CS_Report
    {
        public string Title;//Tiêu đề cửa sổ
        public string Path; // Đường dẫn file report
        public List<Querry> lsQuerry; // Danh sách lớp Query
        public List<DataTable> lsDataTable; // Danh sách lớp Query
        public List<Parameters> lsParameter; // Danh sách lớp Parameter    
        public List<Hiddens> lsHidden; // Danh sách lớp Parameter    
        public List<string> lsSectionsHide;//Danh sách cần 
        public bool IsPrint;//false:Preview, true: Print
        public int nCopies;//Số lượng bản in trực tiếp
        public CS_Report()
        {
            this.lsParameter = new List<Parameters>();
            this.lsHidden = new List<Hiddens>();
            this.lsQuerry = new List<Querry>();
            this.lsDataTable = new List<DataTable>();
            this.lsSectionsHide = new List<string>();
        }
        public DataTable ConvertListParameterToDataTable()
        {
            // New table.
            DataTable table = new DataTable();

            // Add columns.            
            table.Columns.Add(new DataColumn("ItemID"));
            table.Columns.Add(new DataColumn("ItemValue"));
            // Add rows.
            foreach (var array in lsParameter)
            {
                table.Rows.Add(array.PrName, array.PrValue);
            }

            return table;
        }
        public DataTable ConvertListHiddenToDataTable()
        {
            // New table.
            DataTable table = new DataTable();

            // Add columns.            
            table.Columns.Add(new DataColumn("ItemID"));
            // Add rows.
            foreach (var array in lsHidden)
            {
                table.Rows.Add(array.PrName);
            }

            return table;
        }
    }
}
