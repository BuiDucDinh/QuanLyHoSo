<%@ WebService Language="C#" Class="UpdateFile" %>
using System;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Collections.Generic;
using QLHS_Logic;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]

public class UpdateFile : WebService
{
    [WebMethod]
    public string UpImages(string arrImg)
    {
        DataTable dt = QLHS_Logic.Sys_Common.NV_Image.GetbyListID("," + arrImg + ",");
        StringBuilder sb = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow item in dt.Rows)
            {
                sb.Append("[");

                sb.Append(string.Format("\"{0}\",\"{1}\"", item["ImageID"], item["TenAnh"]));

                sb.Append("],");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
        }
        string s = sb.ToString();
        return sb.ToString();
    }

    //load lại ảnh sau khi cập nhật
    [WebMethod]
    public string LoadImages(string danhmuc, int index, int count)
    {
        string sql = "";
        if (!string.IsNullOrEmpty(danhmuc) && danhmuc != "0")
        {
            sql = "select top " + count + " * from (select ROW_NUMBER() over(order by ImageID) as rowindex,* from Image where DanhMuc=" + danhmuc + ") as tb where rowindex>" + (index - 1) * count;
        }
        else
        {
            sql = "select top " + count + " * from (select ROW_NUMBER() over(order by ImageID) as rowindex,* from Image) as tb where rowindex>" + (index - 1) * count;
        }
        DataTable dt = Sys_Common.getDataByQuery(sql);
        StringBuilder sb = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow item in dt.Rows)
            {
                sb.Append("[");

                sb.Append(string.Format("\"{0}\",\"{1}\"", item["ImageID"], item["TenAnh"]));

                sb.Append("],");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
        }
        string s = sb.ToString();
        return sb.ToString();
    }

    [WebMethod]
    public string LoadImagesCount(string danhmuc)
    {
        string sql = "";
        if (!string.IsNullOrEmpty(danhmuc) && danhmuc != "0")
        {
            sql = "select count(ImageID) as Count from Image where DanhMuc=" + danhmuc;
        }
        else
        {
            sql = "select count(ImageID) as Count from Image";
        }
        DataTable dt = Sys_Common.getDataByQuery(sql);

        return dt.Rows[0]["Count"].ToString();
    }
    [WebMethod]
    public string LoadDocument(string arrDoc)
    {
        DataTable dt = QLHS_Logic.Sys_Common.NV_Document.GetbyListID("," + arrDoc + ",");
        StringBuilder sb = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow item in dt.Rows)
            {
                sb.Append("[");

                sb.Append(string.Format("\"{0}\",\"{1}\",\"{2}\"", item["DocumentID"], item["TenTaiLieu"], item["File"]));

                sb.Append("],");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
        }
        string s = sb.ToString();
        return sb.ToString();
    }
    [WebMethod]
    public string LoadVideo(string arr)
    {
        DataTable dt = QLHS_Logic.Sys_Common.NV_Video.GetbyListID("," + arr + ",");
        StringBuilder sb = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow item in dt.Rows)
            {
                sb.Append("[");

                sb.Append(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", item["VideoID"], item["TenVideo"], item["FileUpload"], item["AnhMoTa"]));

                sb.Append("],");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
        }
        string s = sb.ToString();
        return sb.ToString();
    }
    [WebMethod]
    public string LoadVideoByDanhMuc(string danhmuc)
    {
        int idDanhmuc;
        try
        {
            idDanhmuc = int.Parse(danhmuc);
        }
        catch { idDanhmuc = 0; }
        DataTable dt = Sys_Common.NV_Video.GetByParent(idDanhmuc);
        StringBuilder sb = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow item in dt.Rows)
            {
                sb.Append("[");

                sb.Append(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", item["VideoID"], item["TenVideo"], item["FileUpload"], item["AnhMoTa"]));

                sb.Append("],");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
        }
        string s = sb.ToString();
        return sb.ToString();
    }
}