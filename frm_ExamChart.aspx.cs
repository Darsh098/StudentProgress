using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_ExamChart : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StudId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudId = int.Parse(Session["StudId"].ToString());
        if (!IsPostBack)
            LoadTest();
    }
     void PopulateChart()
    {
        QRY = "SELECT (SELECT AVG(Em_ObtainedMarks) FROM Tbl_ExamMaster WHERE Stud_Id="+StudId+" AND Tt_Id="+ddltest.SelectedValue+" AND Sub_Id IN (SELECT Sub_Id FROM Tbl_SubjectMaster WHERE Sem_Id=SM.Sem_Id)) AS 'Sem_Marks', ";
        QRY += "SM.Sem_Name FROM Tbl_DivisionMaster DM, Tbl_SemMaster SM WHERE SM.Sem_Id=DM.Sem_Id AND DM.Div_Id IN (SELECT Div_Id From Tbl_StudClassMaster WHERE Stud_Id="+StudId+")";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        chrtMarks.DataSource = DS.Tables[0];
        chrtMarks.DataBind();
    }
     void LoadTest()
     { 
         QRY = "SELECT Tt_Id, Tt_Name FROM Tbl_TestTypeMaster WHERE Tt_IsActive='TRUE'";
         CNN = new SqlConnection(CNS);
         CMD = new SqlCommand(QRY, CNN);
         SqlDataAdapter DA = new SqlDataAdapter(CMD);
         DataSet DS = new DataSet();
         DA.Fill(DS);
         ddltest.DataValueField = "Tt_Id";
         ddltest.DataTextField = "Tt_Name";
         ddltest.DataSource = DS.Tables[0];
         ddltest.DataBind();
         ddltest.Items.Insert(0,"-- SELECT TEST --");
     }

     protected void ddltest_SelectedIndexChanged(object sender, EventArgs e)
     {
         PopulateChart();
     }
}