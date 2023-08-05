using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_MainInstituteAdmin : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId;
    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());
        bindmyInstituteImages();
        bindmyInstituteDetails();
    }
    void bindmyInstituteImages()
    {
        imglogo.ImageUrl = "frm_Inst_Logo.ashx?myId=" + InstId;
        instimg1.ImageUrl = "frm_Inst_Logo.ashx?myInstId=" + InstId + "&IgId=1";
        instimg2.ImageUrl = "frm_Inst_Logo.ashx?myInstId=" + InstId + "&IgId=2";
        instimg3.ImageUrl = "frm_Inst_Logo.ashx?myInstId=" + InstId + "&IgId=3";
    }
    void bindmyInstituteDetails()
    {
        QRY = "SELECT IM.Inst_Name,ID.InstD_Details FROM Tbl_InstituteMaster IM, Tbl_InstituteDetails ID WHERE IM.Inst_Id=ID.Inst_Id AND IM.Inst_Id="+InstId+" AND IM.Inst_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            lblinstname.InnerText = DR["Inst_Name"].ToString();
            instdescription.InnerText = DR["InstD_Details"].ToString();
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
    }
}