using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class frmDisplayStaffDetails : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int StaffId;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());
        if (!IsPostBack)
        {
            BindMyPersonalDetails();
            BindMyQualification();
            BindMyExperience();
        }
    }
    void BindMyPersonalDetails()
    {
        QRY = "SELECT * FROM Tbl_StaffPersonalDetails WHERE Staff_Id="+StaffId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        while (DR.Read())
        {
            lblname.Text = DR["Staff_Name"].ToString();
            lblgender.Text = DR["Staff_Gender"].ToString();
            lblemail.Text = DR["Staff_Email"].ToString();
            lblbdate.Text = DR["Staff_Bdate"].ToString();
            lblcontno.Text = DR["Staff_ContNo"].ToString();
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
    }
    void BindMyQualification()
    {
        QRY = "SELECT * FROM Tbl_StaffQualificationDetails WHERE Staff_Id=" + StaffId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        grd_quali.DataSource = DS.Tables[0];
        grd_quali.DataBind();
        CMD.Dispose();
        CNN.Close();
    }
    void BindMyExperience()
    {
        QRY = "SELECT * FROM Tbl_StaffExperienceDetails WHERE Staff_Id=" + StaffId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        grd_exp.DataSource = DS.Tables[0];
        grd_exp.DataBind();
        CMD.Dispose();
        CNN.Close();
    }
    protected void btn_pdf_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}