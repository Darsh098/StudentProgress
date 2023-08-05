using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_AddSubject : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlCommand CMD;
    SqlConnection CNN;
    int InstId;

    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());
        if (!IsPostBack)
            LoadStreams();

    }
    public void BindmySubjects()
    {
        QRY = "SELECT * FROM Tbl_SubjectMaster WHERE Sub_IsActive='TRUE' AND Sem_Id=" + ddlSem.SelectedValue;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        dt_subject.DataSource = DS.Tables[0];
        dt_subject.DataBind();
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
        QRY = "SELECT Cour_Id, Cour_Name FROM Tbl_CourseMaster WHERE Cour_IsActive='TRUE' AND Stream_Id=" + ddlStream.SelectedValue + " AND Inst_Id="+InstId+" OR Stream_Id=0";
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

    void LoadDivisions()
    {
        QRY = "SELECT Div_Id,Div_Name FROM Tbl_DivisionMaster WHERE Sem_Id=" + ddlSem.SelectedValue + "AND Div_IsActive='TRUE' OR Sem_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlSem.DataTextField = "Div_Name";
        ddlSem.DataValueField = "Div_Id";
        ddlSem.DataSource = DS.Tables[0];
        ddlSem.DataBind();
        CMD.Dispose();
    }

    protected void btn_insert_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_SubjectMaster VALUES (";
        QRY += "(SELECT MAX(Sub_Id) + 1 FROM Tbl_SubjectMaster), ";
        QRY += "" + ddlSem.SelectedValue + ", ";
        QRY += "'" + txtsubjectname.Text + "', ";
        QRY += "'" + txtsubjectcode.Text + "', ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        BindmySubjects();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        LoadSemesters();
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        ddlSem.SelectedIndex = 0;
        ddlCourse.SelectedIndex = 0;
        ddlStream.SelectedIndex = 0;
        txtsubjectcode.Text = string.Empty;
        txtsubjectname.Text = string.Empty;
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindmySubjects();
    }
    protected void dt_subject_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        QRY = "UPDATE Tbl_SubjectMaster SET ";
        QRY += "Sub_Name='" + e.NewValues["Sub_Name"] + "', ";
        QRY += "Sub_Code='" + e.NewValues["Sub_Code"] + "' ";
        QRY += "WHERE Sub_Id=" +dt_subject.Rows[e.RowIndex].Cells[0].Text.ToString();
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();
        dt_subject.EditIndex = -1;
        BindmySubjects();
    }
    protected void dt_subject_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dt_subject.EditIndex = e.NewEditIndex;
        BindmySubjects();
    }
    protected void dt_subject_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        QRY = "UPDATE Tbl_SubjectMaster SET Sub_IsActive='FALSE' WHERE Sub_Id=" + dt_subject.Rows[e.RowIndex].Cells[0].Text.ToString();
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();
        BindmySubjects();
    }
    protected void dt_subject_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dt_subject.EditIndex = -1;
        BindmySubjects();
    }
}