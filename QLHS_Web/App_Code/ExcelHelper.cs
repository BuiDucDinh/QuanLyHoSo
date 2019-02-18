using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Xml.Linq;
using System.Data;
using NPOI.HSSF.UserModel;


public class ExcelHelper
{
    public static byte[] DataTableToExcel(Report1 myReport)
    {
        try
        {
            int delta = 0;
            // Opening the Excel template...
            FileStream fs =
                new FileStream(myReport.Template, FileMode.Open, FileAccess.Read);

            // Getting the complete workbook...
            HSSFWorkbook templateWorkbook = new HSSFWorkbook(fs, true);

            // Getting the worksheet by its name...
            HSSFSheet sheet = templateWorkbook.GetSheetAt(0);

            //Xử lý Parameters
            for (int t = 0; t < myReport.lsParameter.Count; t++)
            {
                Parameters myParam = myReport.lsParameter[t];
                HSSFCellStyle cs = sheet.GetRow(myParam.PrRow - 1).GetCell(myParam.PrColl - 1).CellStyle;
                HSSFCell myCell = sheet.GetRow(myParam.PrRow - 1).CreateCell(myParam.PrColl - 1);
                myCell.SetCellValue(myParam.PrValue.ToString());
                myCell.CellStyle = cs;
            }

            //Đoạn này thêm vào cho bên atcom xuất báo cáo có header
            if (myReport.GenHeader)
                CreateHeader(myReport.lsTable, sheet);
            //kết thúc header


            //Xử lý Tables            
            for (int t = 0; t < myReport.lsTable.Count; t++)
            {
                Tables myTable = myReport.lsTable[t];
                HSSFCellStyle[] cs = new HSSFCellStyle[myTable.PrValue.Columns.Count];

                if (myTable.PrValue != null && myTable.PrColl!= null && myTable.PrRow!= null && myTable!=null)
                {
                    //Get cell styles in the first row
                    for (int i = 0; i < myTable.PrValue.Columns.Count; i++)
                    {
                        cs[i] = sheet.GetRow(myTable.PrRow - 1 + delta).GetCell(myTable.PrColl - 1 + i).CellStyle;
                    }

                    //Shift rows to take place for the table's rows
                    if (myTable.PrValue.Rows.Count > 1)
                    {
                        sheet.ShiftRows(myTable.PrRow + delta, sheet.LastRowNum + 1 + delta, myTable.PrValue.Rows.Count - 1);
                    }

                    //Fill table data & style
                    for (int i = 0; i < myTable.PrValue.Rows.Count; i++)
                    {
                        HSSFRow row = sheet.CreateRow(myTable.PrRow - 1 + i + delta);

                        for (int j = 0; j < myTable.PrValue.Columns.Count; j++)
                        {
                            HSSFCell cell = row.CreateCell(myTable.PrColl - 1 + j);
                            //Trường hợp cell là kiểu DateTime --> chuyển value sang dạng dd/MM/yyyy
                            if (myTable.PrValue.Rows[i][j].GetType() == typeof(DateTime))
                            {
                                cell.SetCellValue(((DateTime)myTable.PrValue.Rows[i][j]).ToString("dd/MM/yyyy"));
                            }
                            else
                            {
                                cell.SetCellValue(myTable.PrValue.Rows[i][j].ToString());
                            }
                            cell.CellStyle = cs[j];
                        }
                    }
                    delta += myTable.PrValue.Rows.Count - 1;
                }
            }
            sheet.ForceFormulaRecalculation = true;

            MemoryStream ms = new MemoryStream();

            // Writing the workbook content to the FileStream...
            templateWorkbook.Write(ms);

            // Sending the server processed data back to the user computer...
            //return ms. .ToString();
            return ms.ToArray();
        }
        catch
        {            
            return null;
        }
    }

    //Hàm tạo header của atcom
    public static void CreateHeader(List<Tables> lstTable, HSSFSheet sheet)
    {
        int ColCount = lstTable[0].PrValue.Columns.Count;
        int StartColumnIndex = lstTable[0].PrColl - 1;
        int HeaderRowIndex = lstTable[0].PrRow - 2 - 1;
        int SeriesRowIndex = lstTable[0].PrRow - 1 - 1;
        string[] ColNames = new string[ColCount];
        HSSFRow HeaderRow = sheet.GetRow(HeaderRowIndex);
        HSSFRow SeriesRow = sheet.GetRow(SeriesRowIndex);
         
        for (int i = 0; i <= 72; i++)
        {
            if (i < ColCount)
            {
                SeriesRow.GetCell(StartColumnIndex + i).SetCellValue(i + 1);
                HeaderRow.GetCell(StartColumnIndex + i).SetCellValue(lstTable[0].PrValue.Columns[i].ColumnName);
            }
            else
                sheet.SetColumnHidden(StartColumnIndex + i, true);
        }
    }
    #region excel Helper
    // XPath like: Workbook/Worksheet/Table/Row
    public static XElement GetElementByXPath(XDocument root, string XPath)
    {
        XElement result = null;
        XElement tempElement = null;
        string[] xPathItems = XPath.Split('/');

        tempElement = root.Elements().ElementAt(0);

        for (int i = 1; i < xPathItems.Count(); i++)
        {
            if (tempElement != null)
            {
                tempElement = tempElement.Element((xPathItems[i]));
            }
            else
            {
                break;
            }
        }

        result = tempElement;

        return result;
    }

    public static string GetSubElementValue(XElement element, string item)
    {
        if (element != null && element.Value != null)
        {
            if (element.Element(item) != null)
            {
                return element.Element(item).Value;
            }
        }
        return null;
    }

    public static XElement GetElement(XElement element, string item)
    {
        if (element != null)
            return element.Element(item);

        return null;
    }

    public static XElement GetElement(XDocument document, string item)
    {
        if (document != null)
            return document.Descendants("item").FirstOrDefault();
        return null;
    }

    public static string CreateExcelContentXmlVersion(string[,] range, string xmlTemplate)
    {
        string excelTemlateContent = GetResourceTextFile(xmlTemplate);
        XDocument doc = XDocument.Parse(excelTemlateContent);
        XNamespace ns = "urn:schemas-microsoft-com:office:spreadsheet";
        XElement table = doc.Element(ns + "Workbook").Element(ns + "Worksheet").Element(ns + "Table");
        IEnumerable<XElement> lstRows = table.Elements();

        XElement rowHeader = null;
        XElement rowData = null;
        List<int> lstRemoveColumn = new List<int>();
        List<XElement> lstRealRows = new List<XElement>();


        for (int i = 0; i < lstRows.Count(); i++)
        {
            XElement row = lstRows.ElementAt(i);
            if (row.Name.LocalName.Contains("Row"))
            {
                rowHeader = lstRows.ElementAt(i);
                lstRealRows.Add(rowHeader);
                rowData = lstRows.ElementAt(i + 1);
                break;
            }
        }

        XElement rowToAdd = null;
        Dictionary<string, int> dictHeader = new Dictionary<string, int>();

        IEnumerable<XElement> lstCellHeaders = rowHeader.Elements();
        for (int i = 0; i < lstCellHeaders.Count(); i++)
        {
            XElement cell = lstCellHeaders.ElementAt(i);
            dictHeader.Add(cell.Value, i);
        }

        IEnumerable<XElement> lstCells = rowData.Elements();
        for (int i = 0; i < lstCells.Count(); i++)
        {
            XElement cell = lstCells.ElementAt(i);
            if (cell.HasElements)
            {
                lstCellHeaders.ElementAt(i).Value = "<Data ss:Type=\"String\">" + cell.Element(ns + "Data").Value + "</Data>";
            }
            else
            {
                lstRemoveColumn.Add(i);
            }
        }


        // scan input array
        for (int i = 1; i < range.GetLength(0); i++)
        {
            if (i == 1)
            {
                rowToAdd = rowData;
            }
            else
            {
                rowToAdd = new XElement(rowData);
            }
            lstCells = rowToAdd.Elements();
            lstRealRows.Add(rowToAdd);

            for (int j = 0; j < range.Length / range.GetLength(0); j++)
            {
                string keyMap = range[0, j];    // row 0 fo array contain header name to map
                int columnMap = -1;

                if (dictHeader.TryGetValue(keyMap, out columnMap))
                {
                    lstCells.ElementAt(columnMap).SetValue("<Data ss:Type=\"String\">" + range[i, j] + "</Data>");
                }
            }

            if (i != 1)
            {
                table.Add(rowToAdd);
            }
        }

        //delete unnessary column
        for (int i = lstRemoveColumn.Count - 1; i > 0; i--)
        {
            foreach (XElement row in lstRealRows)
            {
                lstCells = row.Elements();
                lstCells.ElementAt(lstRemoveColumn[i]).Remove();
            }
        }

        return "<?xml version=\"1.0\"?>\n" + doc.ToString().Replace("ExpandedRowCount=\"2\"", "ExpandedRowCount=\"" + (range.GetLength(0) + 1).ToString() + "\"").Replace("&lt;", "<").Replace("&gt;", ">");

    }

    private string CreateExcelContent(string[,] range)
    {
        string excelXmlContent = "";
        string xmlExcelHeader = GetResourceTextFile("ResourceData/xmlExcelHeader.xml");
        string xmlExcelTrailer = GetResourceTextFile("ResourceData/xmlExcelTrailer.xml");
        string rangeContent = "";
        string row = "";
        string rows = "";
        string cell = "";
        string style = "HeaderStyle";
        for (int i = 0; i < range.GetLength(0); i++)
        {
            if (i > 0) style = "ItemStyle";
            row = "      <Row ss:Index=\"" + (i + 1).ToString() + "\" ss:AutoFitHeight=\"0\" ss:Height=\"24\">\n";

            for (int j = 0; j < range.Length / range.GetLength(0); j++)
            {
                cell = "        <Cell ss:Index=\"" + (j + 1).ToString() + "\" ss:StyleID=\"" + style + "\" ss:MergeAcross=\"0\">\n";
                cell += "          <Data ss:Type=\"String\">" + range[i, j] + "</Data>\n";
                cell += "        </Cell>\n";
                row += cell;
            }
            row += "      </Row>\n";
            rows += row;
        }

        excelXmlContent = xmlExcelHeader + "\n" + rows + xmlExcelTrailer;
        return excelXmlContent;
    }

    public static string GetResourceTextFile(string filename)
    {
        return System.IO.File.ReadAllText(filename);
    }
    #endregion excel Helper
}

