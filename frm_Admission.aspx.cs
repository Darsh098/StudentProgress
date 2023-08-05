using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_Admission : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlCommand CMD;
    SqlConnection CNN;
    int StudId,DivId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudId = int.Parse(Session["StudId"].ToString());
        if (!IsPostBack)
        {
            LoadInstitutes();
        }
    }
    void bindDivision()
    {
        QRY = "SELECT Div_Id, Div_Name FROM Tbl_DivisionMaster WHERE Div_IsActive='TRUE' AND Sem_Id="+ddlSem.SelectedValue+"OR Div_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl_div.DataTextField = "Div_Name";
        ddl_div.DataValueField = "Div_Id";
        ddl_div.DataSource = DS.Tables[0];
        ddl_div.DataBind();
        CMD.Dispose();
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
        QRY = "SELECT Cour_Id, Cour_Name FROM Tbl_CourseMaster WHERE Cour_IsActive='TRUE' AND Stream_Id="+ddlStream.SelectedValue+" AND Inst_Id="+ddlInst.SelectedValue+" OR Inst_Id=0 OR Stream_Id=0";
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
            bindDivision();
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
        bindDivision();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemesters();
        bindDivision();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_StudClassMaster VALUES (";
        QRY += "(SELECT MAX(Sc_Id) + 1 FROM Tbl_StudClassMaster), ";
        QRY += "" + StudId + ", ";
        QRY += ""+ddl_div.SelectedValue+", ";
        QRY += "(SELECT MAX(Sc_RollNo) + 1 FROM Tbl_StudClassMaster), ";
        QRY += "'" + System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "', NULL, NULL, ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        Response.Redirect("frm_StudentLogin.aspx");
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDivision();
    }
}