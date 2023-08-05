using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class frm_DisplayStaff_Inst : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId,Max_DivId,Min_DivId;

    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());
        if (!IsPostBack)
        {
            LoadStreams();
        }
    }
    void bindmystaff()
    {
        
        QRY = "SELECT MAX(Div_Id), MIN(Div_Id) FROM Tbl_DivisionMaster DM, Tbl_SemMaster SM,Tbl_CourseMaster CM,Tbl_InstituteMaster IM ";
        QRY += "WHERE DM.Sem_Id=SM.Sem_Id AND SM.Cour_Id=CM.Cour_Id AND CM.Inst_Id=IM.Inst_Id AND IM.Inst_Id=" + InstId + " AND CM.Cour_Id=" + ddlCourse.SelectedValue ;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            Max_DivId = int.Parse(DR[0].ToString());
            Min_DivId = int.Parse(DR[1].ToString());
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
 
        QRY = "SELECT DISTINCT SPD.Staff_Id, SPD.Staff_ContNo, SPD.Staff_Email, SPD.Staff_Name FROM Tbl_InstituteMaster IM, Tbl_DivisionMaster DM, Tbl_CourseMaster CM, Tbl_SemMaster SM, Tbl_StaffPersonalDetails SPD WHERE  ";
        QRY += "IM.Inst_Id="+InstId+" AND IM.Inst_Id=CM.Inst_Id AND CM.Cour_Id=SM.Cour_Id AND SM.Sem_Id=DM.Sem_Id AND ";
        QRY += "SPD.Staff_Id IN (SELECT Staff_Id FROM Tbl_SubjectAllocationMaster WHERE Div_Id IN (SELECT Div_Id FROM Tbl_SubjectAllocationMaster WHERE Div_Id<="+Max_DivId+" AND Div_Id>="+Min_DivId+")) ";
        QRY += "AND IM.Inst_Id>0 AND SPD.Staff_Id>0";

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        rpt_staffdisplay.DataSource = DS.Tables[0];
        rpt_staffdisplay.DataBind();
        CMD.Dispose();
    }
    void LoadCourses()
    {
        QRY = "SELECT Cour_Id, Cour_Name FROM Tbl_CourseMaster WHERE Cour_IsActive='TRUE' AND Stream_Id=" + ddlStream.SelectedValue + " AND Inst_Id=" + InstId + " OR Stream_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlCourse.DataTextField = "Cour_Name";
        ddlCourse.DataValueField = "Cour_Id";
        ddlCourse.DataSource = DS.Tables[0];
        ddlCourse.DataBind();
        CMD.Dispose();
    }
    void LoadStreams()
    {
        QRY = "SELECT Stream_Id, Stream_Name FROM Tbl_StreamMaster WHERE Stream_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlStream.DataTextField = "Stream_Name";
        ddlStream.DataValueField = "Stream_Id";
        ddlStream.DataSource = DS.Tables[0];
        ddlStream.DataBind();
        CMD.Dispose();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindmystaff();
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
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