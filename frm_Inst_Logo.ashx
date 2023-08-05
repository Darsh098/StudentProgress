<%@ WebHandler Language="C#" Class="frm_Inst_Logo" %>

using System;
using System.Web;
using System.Data.SqlClient;


public class frm_Inst_Logo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request.QueryString["myId"] != null)
        {
            string QRY = "SELECT InstD_Logo FROM Tbl_InstituteDetails WHERE InstD_Id=" + context.Request.QueryString["myId"];
            string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
            SqlConnection CNN = new SqlConnection(CNS);
            SqlCommand CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                context.Response.BinaryWrite((byte[])DR["InstD_Logo"]);
            }
            DR.Close();
            CNN.Close();
            context.Response.Flush();
            context.Response.End();
        }
        //else throw new ArgumentException("Invalid Image Data");

        if (context.Request.QueryString["myInstId"] != null)
        {
            string QRY = "SELECT ";
            if (context.Request.QueryString["IgId"] == "1")
                QRY += "InstG_Image1";
            else if (context.Request.QueryString["IgId"] == "2")
                QRY += "InstG_Image2";
            else if (context.Request.QueryString["IgId"] == "3")
                QRY += "InstG_Image3";
                QRY += " FROM Tbl_InstituteGallery WHERE Inst_Id=" + context.Request.QueryString["myInstId"];
            string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
            SqlConnection CNN = new SqlConnection(CNS);
            SqlCommand CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                context.Response.BinaryWrite((byte[])DR[0]);
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