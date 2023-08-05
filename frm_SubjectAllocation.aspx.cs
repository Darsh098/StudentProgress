using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frm_SubjectAllocation : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlCommand CMD;
    SqlConnection CNN;
    int StaffId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());
        if (!IsPostBack)
        {
            LoadInstitutes();
            GeneratePassingYear(ddl_year);
        }
    }
    void LoadInstitutes()
    {
        QRY = "SELECT Inst_Id, Inst_Name FROM Tbl_InstituteMaster WHERE Inst_IsActive='TRUE'";
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
        QRY = "SELECT Cour_Id, Cour_Name FROM Tbl_CourseMaster WHERE Cour_IsActive='TRUE' AND Stream_Id=" + ddlStream.SelectedValue + " AND Inst_Id=" + ddlInst.SelectedValue + " OR Inst_Id=0 OR Stream_Id=0";
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
    void LoadSubjects()
    {
        QRY = "SELECT Sub_Name,Sub_Id FROM Tbl_SubjectMaster WHERE Sub_IsActive='TRUE' AND Sem_Id=" + ddlSem.SelectedValue + " OR Sub_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl_subject.DataTextField = "Sub_Name";
        ddl_subject.DataValueField = "Sub_Id";
        ddl_subject.DataSource = DS.Tables[0];
        ddl_subject.DataBind();
        CMD.Dispose();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_SubjectAllocationMaster VALUES (";
        QRY += "(SELECT MAX(Sa_Id) + 1 FROM Tbl_SubjectAllocationMaster), ";
        QRY += ""+ddl_year.SelectedItem.Text+", ";
        QRY += "" + ddl_subject.SelectedValue +", ";
        QRY += ""+StaffId+", ";
        QRY += "0, ";
        QRY += "'"+txtremarks.Text+"', ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        Response.Redirect("frm_StaffLogin.aspx");
    }
    void GeneratePassingYear(DropDownList DDL)
    {
        for (int i = 0; i < 20; i++)
        {
            DDL.Items.Add((System.DateTime.Now.Year - i).ToString());
        }
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
        LoadSubjects();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemesters();
        LoadSubjects();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSubjects();
    }
    protected void ddlInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInst.SelectedIndex == 0)
        {
            ddlStream.SelectedIndex = 0;
        }
        else
        {
            LoadStreams();
        }
        LoadCourses();
        LoadSemesters();
        LoadSubjects();
    }
}