using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_DisplayStudents_Inst : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId;
    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());
        if (!IsPostBack)
            bindmyStudents();
    }
    void bindmyStudents()
    {
        QRY = "SELECT SD.Stud_Id, SD.Stud_Name, CM.Cour_Name, SM.Sem_Name FROM Tbl_StudentPersonalDetails SD, Tbl_SemMaster SM, Tbl_CourseMaster CM,Tbl_StudClassMaster SCM,Tbl_InstituteMaster IM,Tbl_DivisionMaster DM WHERE ";
        QRY += "SD.Stud_Id=SCM.Stud_Id AND SM.Cour_Id=CM.Cour_Id AND DM.Div_Id=SCM.Div_Id AND DM.Sem_Id=SM.Sem_Id AND CM.Inst_Id=IM.Inst_Id AND SCM.Sc_IsActive='TRUE'";
            QRY += " AND IM.Inst_Id=" + InstId+" ORDER BY SD.Stud_Id";

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        rpt_studentdisplay.DataSource = DS.Tables[0];
        rpt_studentdisplay.DataBind();
        CMD.Dispose();
    }
    protected void rpt_studentdisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Session["StudId"] = e.CommandArgument.ToString();
            Response.Redirect("frm_StudentDetailsUpdate.aspx");
        }
        else if (e.CommandName == "Delete")
        {
            Session["StudId"] = e.CommandArgument.ToString();
            Response.Redirect("frm_AccountDeleteStudent.aspx");
        }
    }
}