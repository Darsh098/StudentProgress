using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class frm_MarksChart : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StudId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudId = int.Parse(Session["StudId"].ToString());
        PopulateChart();
        if (!IsPostBack)
        {
            LoadSemesters();
        }
    }
    void LoadSemesters()
    {
        QRY = "SELECT SM.Sem_Name, SM.Sem_Id FROM Tbl_DivisionMaster DM, Tbl_SemMaster SM WHERE SM.Sem_Id=DM.Sem_Id AND DM.Div_Id IN (SELECT Div_Id From Tbl_StudClassMaster WHERE Stud_Id="+StudId+")";
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
        
        ListItem i = new ListItem();
        i.Text = "All Sem";
        i.Value = "0";
        ddlSem.Items.Add(i);

        ddlSem.Items.Insert(0,"-- Select Semester --");
    }
    void PopulateChart()
    {
        QRY = "SELECT (SELECT AVG(Uni_ObtainedMarks) FROM Tbl_UniversityMarks WHERE Sem_Id=SM.Sem_Id AND Stud_Id="+StudId+") AS 'Sem_Marks', SM.Sem_Name ";
        QRY += "FROM Tbl_DivisionMaster DM, Tbl_SemMaster SM WHERE SM.Sem_Id=DM.Sem_Id AND DM.Div_Id IN (SELECT Div_Id From Tbl_StudClassMaster WHERE Stud_Id="+StudId+")";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        chrtMarks.DataSource = DS.Tables[0];
        chrtMarks.DataBind();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSem.SelectedIndex != 0)
            link_rprt.NavigateUrl = "frm_ViewReportMarks.aspx?SemId=" + ddlSem.SelectedValue;
        else
            link_rprt.NavigateUrl = string.Empty;
    }
}