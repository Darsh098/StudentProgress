using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_SignUP : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StaffId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadCountries();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    void LoadCountries()
    {
        QRY = "SELECT Country_Id,Country_Name FROM Tbl_CountryMaster WHERE Country_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl_Country.DataTextField = "Country_Name";
        ddl_Country.DataValueField = "Country_Id";
        ddl_Country.DataSource = DS.Tables[0];
        ddl_Country.DataBind();
        CMD.Dispose();
    }
    void LoadStates(DropDownList ddl)
    {
        QRY = "SELECT State_Id,State_Name FROM Tbl_StateMaster WHERE State_IsActive='TRUE' AND Country_Id=0 OR Country_Id=" + ddl.SelectedValue;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl_State.DataTextField = "State_Name";
        ddl_State.DataValueField = "State_Id";
        ddl_State.DataSource = DS.Tables[0];
        ddl_State.DataBind();
        CMD.Dispose();
        ddl_State.SelectedIndex = 0;

    }
    void ClearControls()
    {
        txtname.Text = string.Empty;
        txtemail.Text = string.Empty;
        txtcontno.Text = string.Empty;
        txtaddress.Text = string.Empty;
        txtconfpassword.Text = string.Empty;
        txtpassword.Text = string.Empty;
        ddl_Country.SelectedIndex = 0;
        txtname.Focus();
    }
   
    void LoadCities(DropDownList ddl)
    {
        QRY = "SELECT City_Id,City_Name FROM Tbl_CityMaster WHERE City_IsActive='TRUE' AND State_Id=0 OR State_Id=" + ddl.SelectedValue;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl_City.DataTextField = "City_Name";
        ddl_City.DataValueField = "City_Id";
        ddl_City.DataSource = DS.Tables[0];
        ddl_City.DataBind();
        CMD.Dispose();
        ddl_City.SelectedIndex = 0;
    }
   
    protected void ddl_Country_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadStates(ddl_Country);
        LoadCities(ddl_State);
    }
    protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCities(ddl_State);
    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        QRY = "SELECT MAX(Staff_Id) + 1 FROM Tbl_StaffPersonalDetails";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            StaffId = int.Parse(DR[0].ToString());
        }
        DR.Close();
        CNN.Close();
        CMD.Dispose();

        QRY = "INSERT INTO Tbl_StaffPersonalDetails VALUES (";
        QRY += "" + StaffId + ", ";
        QRY += "'" + txtname.Text + "', ";
        QRY += "'" + rd_gender.SelectedItem.Text + "', ";
        QRY += "'" + txtbdate.Text + "', ";
        QRY += "'" + txtemail.Text + "', ";
        QRY += "'" + txtaddress.Text + "', ";
        QRY += "" + txtcontno.Text + ", ";
        QRY += "" + ddl_City.SelectedValue + ", ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        QRY = "INSERT INTO Tbl_LoginDetails VALUES (";
        QRY += "(SELECT MAX(User_ID) +1 FROM Tbl_LoginDetails), ";
        QRY += "'" + txtemail.Text + "', ";
        QRY += "'" + txtpassword.Text + "', ";
        QRY += "2, " + StaffId + ", 'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        ClearControls();

        Session["StaffId"] = StaffId;
        Response.Redirect("frm_StaffQualification.aspx");
        //Response.Redirect("frm_StaffExperience.aspx");
        //Response.Redirect("frm_SubjectAllocation.aspx");
    }
}