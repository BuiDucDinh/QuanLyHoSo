using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Ext.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Globalization;
using System.Data;

/// <summary>
/// Summary description for DHM_Common
/// </summary>
public class DHM_Common
{
    public static string[] HO_SO_GOM_CO_CP_DM_LOAI_DON = 
           {"Hồ sơ bao gồm: \n - Loại đơn 1",
            "Hồ sơ bao gồm: \n - Loại đơn 2",
            "Hồ sơ bao gồm: \n - Loại đơn 3",
            "Hồ sơ bao gồm: \n - Loại đơn 4",
            "Hồ sơ bao gồm: \n - Loại đơn 5",
            "Hồ sơ bao gồm: \n - Loại đơn 6",
            "Hồ sơ bao gồm: \n - Loại đơn 7"};

    public static bool IsAge18(DateTime age)
    {
        if (age <= DateTime.Now.AddYears(-18))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static DateTime ConvertToDate(string date)
    {
        DateTime value;
        try
        {
            value = DateTime.ParseExact(date.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        catch
        {
            try
            {
                value = DateTime.ParseExact(date.ToString(), "dd/M/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    value = DateTime.ParseExact(date.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw;
                }
            }
        }

        return value;
    }

    //Load dữ liệu từ json string vào object
    public static void JsonToObject(string json, object obj)
    {
        Dictionary<string, object> items = JSON.Deserialize<Dictionary<string, object>>(json);
        Dictionary<string, object> values = new Dictionary<string, object>(items);
        PropertyInfo prop = null;
        FieldInfo field = null;
        foreach (KeyValuePair<string, object> item in items)
        {
            //Với combobox
            if (item.Key.EndsWith("_Value"))
            {
                field = obj.GetType().GetField(item.Key.Replace("_Value", ""));
                if (null != field)
                {
                    object value;
                    if (item.Value is JArray) value = ((JArray)item.Value).ToArray().GetValue(0).ToString(); else value = item.Value;
                    //if (field.FieldType.Name == "Boolean")
                    //{
                    //    value = Convert.ToBoolean(value);
                    //}
                    if (value == "") value = null;
                    try
                    {
                        field.SetValue(obj, value);
                    }
                    catch
                    {
                        try
                        {
                            field.SetValue(obj, value.ToString() == "0" ? false : true);
                        }
                        catch
                        {
                            try
                            {
                                field.SetValue(obj, ConvertToDate(value.ToString()));
                            }
                            catch
                            {
                                try
                                {
                                    field.SetValue(obj, Convert.ToInt32(value));
                                }
                                catch
                                {
                                    field.SetValue(obj, Convert.ToDecimal(value));
                                }
                            }
                        }
                    }

                    values[item.Key.Replace("_Value", "")] = item.Value;
                }
            }
            else if (item.Key.EndsWith("_Group")) //Radio group
            {

            }
            else //Các trường đơn
            {
                field = obj.GetType().GetField(item.Key);
                if (null != field)
                {
                    object value;
                    if (values[item.Key] is JArray) value = ((JArray)values[item.Key]).ToArray().GetValue(0).ToString(); else value = values[item.Key];

                    if (value == "") value = null;
                    try
                    {
                        field.SetValue(obj, value);
                    }
                    catch
                    {
                        try
                        {
                            field.SetValue(obj, value.ToString() == "0" ? false : true);
                        }
                        catch
                        {
                            try
                            {
                                field.SetValue(obj, ConvertToDate(value.ToString()));
                            }
                            catch
                            {
                                try
                                {
                                    field.SetValue(obj, Convert.ToInt32(value));
                                }
                                catch
                                {
                                    field.SetValue(obj, Convert.ToDecimal(value));
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public static void SetFormReadOnly(Ext.Net.Panel form, bool isreadonly)
    {
        //<Ext.Net.Observable>
        List<Field> fields = Ext.Net.Utilities.ControlUtils.FindControls<Field>(form);

        foreach (Field field in fields)
        {
            field.ReadOnly = isreadonly;
        }
    }

    public static void SetFormReadOnly(Ext.Net.FormPanel form, bool isreadonly)
    {
        //<Ext.Net.Observable>
        List<Field> fields = Ext.Net.Utilities.ControlUtils.FindControls<Field>(form);

        foreach (Field field in fields)
        {
            field.ReadOnly = isreadonly;
        }
    }

    //convert: DD/MM/YYYY to YYYYMMDD
    public static string FormatDate2(string date)
    {
        string temp = "";
        if (date != null && date != "")
        {
            try
            {
                temp = date.Substring(6, 4) + date.Substring(3, 2) + date.Substring(0, 2);
            }
            catch (Exception ex)
            {
                temp = "";
            }
        }

        return temp;
    }

    public static string FormatDate(string date)
    {
        string temp = "";
        if (date != null && date != "")
        {
            try
            {
                temp = date.Substring(4, 2) + date.Substring(6, 2) + date.Substring(0, 4);
            }
            catch (Exception ex)
            {
                temp = "";
            }
        }

        return temp;
    }

    public static bool IsDate(string date)
    {
        string regex = "[0-9]{2}/[0-9]{2}/[0-9]{4}";
        Regex r = new Regex(regex, RegexOptions.IgnoreCase);

        // Match the regular expression pattern against a text string.
        Match m = r.Match(date);

        return m.Success;
    }

    public static void SetTheme(Page pPage, int Theme)
    {
        var rm = ResourceManager.GetInstance(pPage);
        switch (Theme)
        {
            case 1:
                rm.SetTheme(Ext.Net.Theme.Default);
                break;
            case 2:
                rm.SetTheme(Ext.Net.Theme.Gray);
                break;
            case 3:
                rm.SetTheme(Ext.Net.Theme.Slate);
                break;
            case 4:
                rm.SetTheme(Ext.Net.Theme.Access);
                break;
        }
    }

    public static string GetAccessRightByModuleId(string RawString, string ModuleId)
    {
        return RawString.Substring(RawString.IndexOf(ModuleId) + ModuleId.Length + 1, 6);
    }

    public static void SetBtnAccessRight(string AccessString, Ext.Net.Button BtnAddId, Ext.Net.Button BtnEditId, Ext.Net.Button BtnDeleteId)
    {
        char[] arr = AccessString.ToCharArray();
        bool IsAdd = (arr[1] == '1' ? true : false);
        bool IsEdit = (arr[2] == '1' ? true : false);
        bool IsDelete = (arr[3] == '1' ? true : false);

        if (BtnAddId != null) BtnAddId.Disabled = !IsAdd;
        if (BtnEditId != null) BtnEditId.Disabled = !IsEdit;
        if (BtnDeleteId != null) BtnDeleteId.Disabled = !IsDelete;
    }

    public static bool IsAdd(string AccessString)
    {
        char[] arr = AccessString.ToCharArray();
        return (arr[1] == '1' ? true : false);
    }

    public static bool IsEdit(string AccessString)
    {
        char[] arr = AccessString.ToCharArray();
        return (arr[2] == '1' ? true : false);
    }

    public static bool IsDelete(string AccessString)
    {
        char[] arr = AccessString.ToCharArray();
        return (arr[3] == '1' ? true : false);
    }

    public static string Decode(string input)
    {
        input = input.Replace("ấ", "a");
        input = input.Replace("ầ", "a");
        input = input.Replace("ẩ", "a");
        input = input.Replace("ẫ", "a");
        input = input.Replace("ậ", "a");
        //---------------------------------A^
        input = input.Replace("Ấ", "A");
        input = input.Replace("Ầ", "A");
        input = input.Replace("Ẩ", "A");
        input = input.Replace("Ẫ", "A");
        input = input.Replace("Ậ", "A");
        //---------------------------------a(
        input = input.Replace("ắ", "a");
        input = input.Replace("ằ", "a");
        input = input.Replace("ẳ", "a");
        input = input.Replace("ẵ", "a");
        input = input.Replace("ặ", "a");
        //---------------------------------A(
        input = input.Replace("Ắ", "A");
        input = input.Replace("Ằ", "A");
        input = input.Replace("Ẳ", "A");
        input = input.Replace("Ẵ", "A");
        input = input.Replace("Ặ", "A");
        //---------------------------------a
        input = input.Replace("á", "a");
        input = input.Replace("à", "a");
        input = input.Replace("ả", "a");
        input = input.Replace("ã", "a");
        input = input.Replace("ạ", "a");
        input = input.Replace("â", "a");
        input = input.Replace("ă", "a");
        //---------------------------------A
        input = input.Replace("Á", "A");
        input = input.Replace("À", "A");
        input = input.Replace("Ả", "A");
        input = input.Replace("Ã", "A");
        input = input.Replace("Ạ", "A");
        input = input.Replace("Â", "A");
        input = input.Replace("Ă", "A");
        //---------------------------------e^
        input = input.Replace("ế", "e");
        input = input.Replace("ề", "e");
        input = input.Replace("ể", "e");
        input = input.Replace("ễ", "e");
        input = input.Replace("ệ", "e");
        //---------------------------------E^
        input = input.Replace("Ế", "E");
        input = input.Replace("Ề", "E");
        input = input.Replace("Ể", "E");
        input = input.Replace("Ễ", "E");
        input = input.Replace("Ệ", "E");
        //---------------------------------e
        input = input.Replace("é", "e");
        input = input.Replace("è", "e");
        input = input.Replace("ẻ", "e");
        input = input.Replace("ẽ", "e");
        input = input.Replace("ẹ", "e");
        input = input.Replace("ê", "e");
        //---------------------------------E
        input = input.Replace("É", "E");
        input = input.Replace("È", "E");
        input = input.Replace("Ẻ", "E");
        input = input.Replace("Ẽ", "E");
        input = input.Replace("Ẹ", "E");
        input = input.Replace("Ê", "E");
        //---------------------------------i
        input = input.Replace("í", "i");
        input = input.Replace("ì", "i");
        input = input.Replace("ỉ", "i");
        input = input.Replace("ĩ", "i");
        input = input.Replace("ị", "i");
        //---------------------------------I
        input = input.Replace("Í", "I");
        input = input.Replace("Ì", "I");
        input = input.Replace("Ỉ", "I");
        input = input.Replace("Ĩ", "I");
        input = input.Replace("Ị", "I");
        //---------------------------------o^
        input = input.Replace("ố", "o");
        input = input.Replace("ồ", "o");
        input = input.Replace("ổ", "o");
        input = input.Replace("ỗ", "o");
        input = input.Replace("ộ", "o");
        //---------------------------------O^
        input = input.Replace("Ố", "O");
        input = input.Replace("Ồ", "O");
        input = input.Replace("Ổ", "O");
        input = input.Replace("Ô", "O");
        input = input.Replace("Ộ", "O");
        //---------------------------------o*
        input = input.Replace("ớ", "o");
        input = input.Replace("ờ", "o");
        input = input.Replace("ở", "o");
        input = input.Replace("ỡ", "o");
        input = input.Replace("ợ", "o");
        //---------------------------------O*
        input = input.Replace("Ớ", "O");
        input = input.Replace("Ờ", "O");
        input = input.Replace("Ở", "O");
        input = input.Replace("Ỡ", "O");
        input = input.Replace("Ợ", "O");
        //---------------------------------u*
        input = input.Replace("ứ", "u");
        input = input.Replace("ừ", "u");
        input = input.Replace("ử", "u");
        input = input.Replace("ữ", "u");
        input = input.Replace("ự", "u");
        //---------------------------------U*
        input = input.Replace("Ứ", "U");
        input = input.Replace("Ừ", "U");
        input = input.Replace("Ử", "U");
        input = input.Replace("Ữ", "U");
        input = input.Replace("Ự", "U");
        //---------------------------------y
        input = input.Replace("ý", "y");
        input = input.Replace("ỳ", "y");
        input = input.Replace("ỷ", "y");
        input = input.Replace("ỹ", "y");
        input = input.Replace("ỵ", "y");
        //---------------------------------Y
        input = input.Replace("Ý", "Y");
        input = input.Replace("Ỳ", "Y");
        input = input.Replace("Ỷ", "Y");
        input = input.Replace("Ỹ", "Y");
        input = input.Replace("Ỵ", "Y");
        //---------------------------------DD
        input = input.Replace("Đ", "D");
        input = input.Replace("Đ", "D");
        input = input.Replace("đ", "d");
        //---------------------------------o
        input = input.Replace("ó", "o");
        input = input.Replace("ò", "o");
        input = input.Replace("ỏ", "o");
        input = input.Replace("õ", "o");
        input = input.Replace("ọ", "o");
        input = input.Replace("ô", "o");
        input = input.Replace("ơ", "o");
        //---------------------------------O
        input = input.Replace("Ó", "O");
        input = input.Replace("Ò", "O");
        input = input.Replace("Ỏ", "O");
        input = input.Replace("Õ", "O");
        input = input.Replace("Ọ", "O");
        input = input.Replace("Ô", "O");
        input = input.Replace("Ơ", "O");
        //---------------------------------u
        input = input.Replace("ú", "u");
        input = input.Replace("ù", "u");
        input = input.Replace("ủ", "u");
        input = input.Replace("ũ", "u");
        input = input.Replace("ụ", "u");
        input = input.Replace("ư", "u");
        //---------------------------------U
        input = input.Replace("Ú", "U");
        input = input.Replace("Ù", "U");
        input = input.Replace("Ủ", "U");
        input = input.Replace("Ũ", "U");
        input = input.Replace("Ụ", "U");
        input = input.Replace("Ư", "U");
        //---------------------------------
        return input;
    }
    public static void BindData(DataTable _rptData, GridPanel _gp, Store _store)
    {
        
        // remove old data and record set

        _store.Reader.Clear();

        _gp.SelectionModel.Clear();

        _gp.ColumnModel.Columns.Clear();

        if (_rptData == null)
        {
            _gp.Render();
            return;
        }
        //_store.Model.Clear();

        var _jsonReader = new Ext.Net.JsonReader();

        foreach (DataColumn _dataColumn in _rptData.Columns)
        {

            // create field

            _jsonReader.Fields.Add(new RecordField(_dataColumn.ColumnName));

            // create the column

            var _column = new Column
            {

                Header = _dataColumn.ColumnName,

                DataIndex = _dataColumn.ColumnName,

            };

            _gp.ColumnModel.Columns.Add(_column);

        }

        _store.Reader.Add(_jsonReader);

        _store.DataSource = _rptData.DefaultView;

        _store.DataBind();

        // redraw [] must call

        _gp.Render();

    }

}