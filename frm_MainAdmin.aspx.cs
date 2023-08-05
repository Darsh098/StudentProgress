using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_MainAdmin : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            myInstitutes();
            LoadImages();
        }
    }
    void myInstitutes()
    {
        QRY = "SELECT Inst_Name, Inst_Id FROM Tbl_InstituteMaster WHERE Inst_IsActive='TRUE' AND Inst_Id>0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        rpt_institues.DataSource = DS.Tables[0];
        rpt_institues.DataBind();
    }
    void LoadImages()
    {
        foreach (RepeaterItem row in rpt_institues.Items)
        {
            ((ImageButton)rpt_institues.Items[row.ItemIndex].FindControl("imginstitutelogo")).ImageUrl = "frm_Inst_Logo.ashx?myId="+((Label)rpt_institues.Items[row.ItemIndex].FindControl("lblintituteid")).Text;
        }
    }
    protected void rpt_institues_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int DesId = 3;
        if (e.CommandName == "InstituteUrl")
        {
            Session.Add("InstId",e.CommandArgument);
            Session.Add("DesId",DesId);
            Session.Add("IsAdmin", "Admin");
            Response.Redirect("frm_MainInstituteAdmin.aspx");
        }
    }
}