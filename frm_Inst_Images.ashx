<%@ WebHandler Language="C#" Class="frm_Inst_Images" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class frm_Inst_Images : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request.QueryString["InstGId1"] != null)
        {
            string QRY = "SELECT InstG_Image1 FROM Tbl_InstituteGallery WHERE InstG_Id=" + context.Request.QueryString["InstGId1"];
            string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
            SqlConnection CNN = new SqlConnection(CNS);
            SqlCommand CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                context.Response.BinaryWrite((byte[])DR["InstG_Image1"]);
            }
            DR.Close();
            CNN.Close();
            context.Response.Flush();
            context.Response.End();
        }
        else if (context.Request.QueryString["InstGId2"] != null)
        {
            string QRY = "SELECT InstG_Image2 FROM Tbl_InstituteGallery WHERE InstG_Id=" + context.Request.QueryString["InstGId2"];
            string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
            SqlConnection CNN = new SqlConnection(CNS);
            SqlCommand CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                context.Response.BinaryWrite((byte[])DR["InstG_Image2"]);
            }
            DR.Close();
            CNN.Close();
            context.Response.Flush();
            context.Response.End();
        }
        else if (context.Request.QueryString["InstGId3"] != null)
        {
            string QRY = "SELECT InstG_Image3 FROM Tbl_InstituteGallery WHERE InstG_Id=" + context.Request.QueryString["InstGId3"];
            string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
            SqlConnection CNN = new SqlConnection(CNS);
            SqlCommand CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                context.Response.BinaryWrite((byte[])DR["InstG_Image3"]);
            }
            DR.Close();
            CNN.Close();
            context.Response.Flush();
            context.Response.End();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}