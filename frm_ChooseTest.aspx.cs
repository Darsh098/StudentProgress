using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_ChooseTest : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId,Max_DivId,Min_DivId,StaffId,SubID;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());

        GetInstId();
        if (!IsPostBack)
        {
            LoadStreams();
        }
       LoadTestButtons();
    }
    void GetInstId()
    {
        QRY="SELECT IM.Inst_Id FROM Tbl_SubjectAllocationMaster SAM, ";
        QRY+="Tbl_DivisionMaster DM, ";
        QRY+="Tbl_CourseMaster CM, ";
        QRY+="Tbl_SemMaster SM, ";
        QRY+="Tbl_InstituteMaster IM ";
        QRY += "WHERE SAM.Staff_Id="+StaffId+" AND SAM.Div_Id=DM.Div_Id AND DM.Sem_Id=SM.Sem_Id AND SM.Cour_Id=CM.Cour_Id AND CM.Inst_Id = IM.Inst_Id";
         CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            InstId = int.Parse(DR["Inst_Id"].ToString());
        }
        DR.Close();
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();

    }
    void LoadTestButtons()
    {
        QRY = "SELECT * FROM Tbl_TestTypeMaster WHERE Tt_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        while(DR.Read())
        {
            Button btn = new Button();
            btn.ID = DR["Tt_Id"].ToString();
            btn.Text = DR["Tt_Name"].ToString();

            lblbtn.Controls.Add(btn);
            lblbtn.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
            btn.Click += abc_OnClick;
        }
        DR.Close();
        CNN.Close();
        CMD.Dispose();
    }
    protected void abc_OnClick(object sender, EventArgs e)
    {
        Button b = ((Button)(sender));
        Session["TestId"] = b.ID.ToString();
        Session["SemesterId"] = ddlSem.SelectedValue.ToString();
        Response.Redirect("frm_StudentList.aspx");
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
    void LoadSemesters()
    {
        QRY = "SELECT Sem_Id, Sem_Name FROM Tbl_SemMaster WHERE Sem_IsActive='TRUE' AND Cour_Id=" + ddlCourse.SelectedValue + " OR Cour_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlSem.DataTextField = "Sem_Name";
        ddlSem.DataValueField = "Sem_Id";
        ddlSem.DataSource = DS.Tables[0];
        ddlSem.DataBind();
        CMD.Dispose();
    }

    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemesters();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        QRY = "SELECT MAX(Div_Id), MIN(Div_Id) FROM Tbl_DivisionMaster WHERE Sem_Id="+ddlSem.SelectedValue.ToString();
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

        QRY = "SELECT DISTINCT Sub_Id FROM Tbl_SubjectAllocationMaster WHERE Staff_Id="+StaffId+" AND Div_Id <="+Max_DivId+" AND Div_Id >="+Min_DivId+" AND Sa_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
         DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            SubID = int.Parse(DR["Sub_Id"].ToString());
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
        Session["Sub_Id"] = SubID;
    }
    protected void btn_unimarks_Click(object sender, EventArgs e)
    {
        Session["SemesterId"] = ddlSem.SelectedValue.ToString();
        Response.Redirect("frm_UniversityMarksEntry.aspx");
    }
}