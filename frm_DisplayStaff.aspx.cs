using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_DisplayStaff : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadInstitutes();
            bindmystaff();
        }
    }
    void bindmystaff()
    {

        


        QRY = "SELECT DISTINCT IM.Inst_Name, SPD.Staff_Name, SPD.Staff_Id FROM Tbl_SubjectAllocationMaster SAM, Tbl_StaffPersonalDetails SPD, Tbl_InstituteMaster IM, Tbl_CourseMaster CM, Tbl_SemMaster SEM, Tbl_DivisionMaster DM ";
        QRY += "WHERE SAM.Staff_Id=SPD.Staff_Id AND SAM.Div_Id=DM.Div_Id AND DM.Sem_Id=SEM.Sem_Id AND SEM.Cour_Id=CM.Cour_Id AND CM.Inst_Id = IM.Inst_Id ";
        QRY += "AND SAM.Staff_Id=SPD.Staff_Id AND SPD.Staff_Id>0";
        if (ddlInst.SelectedIndex > 0)
            QRY += " AND IM.Inst_Id=" + ddlInst.SelectedValue;

      CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        rpt_staffdisplay.DataSource=DS.Tables[0];
        rpt_staffdisplay.DataBind();
        CMD.Dispose();

    }
    void LoadInstitutes()
    {
        QRY = "SELECT Inst_Id, Inst_Name FROM Tbl_InstituteMaster WHERE Inst_IsActive='TRUE' AND Inst_Id > 0 ORDER BY Inst_Id";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlInst.DataTextField = "Inst_Name";
        ddlInst.DataValueField = "Inst_Id";
        ddlInst.DataSource = DS.Tables[0];
        ddlInst.DataBind();
        CMD.Dispose();
        ddlInst.Items.Insert(0, "All Institutes");
    }
    protected void ddlInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindmystaff();
    }
    protected void rpt_staffdisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Session["StaffId"] = e.CommandArgument.ToString();
            Response.Redirect("frm_StaffDetailsUpdate.aspx");
        }
        else if (e.CommandName == "Delete")
        {
            Session["StaffId"] = e.CommandArgument.ToString();
            Response.Redirect("frm_AccountDeleteStaff.aspx");
        }
    }
}