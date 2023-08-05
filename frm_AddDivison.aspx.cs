using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class frm_AddDivison : System.Web.UI.Page
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
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_DivisionMaster VALUES (";
        QRY += "(SELECT MAX(Div_Id) + 1 FROM Tbl_DivisionMaster), ";
        QRY += ""+ddlSem.SelectedValue+", ";
        QRY += "'"+txtdivison.Text+"', ";
        QRY+="'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtdivison.Text = string.Empty;
        ddlCourse.SelectedIndex = 0;
        ddlSem.SelectedIndex = 0;
        ddlStream.SelectedIndex = 0;
    }
}