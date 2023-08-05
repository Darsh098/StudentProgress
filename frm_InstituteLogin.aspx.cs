using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_InstituteLogin : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId, User_Id,DesId;

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        QRY = "SELECT * FROM Tbl_LoginDetails WHERE User_Name='" + txtusername.Text + "' AND User_Password='" + txtpassword.Text + "' AND Des_Id=(SELECT Des_Id FROM Tbl_DesignationMaster WHERE Des_Name='Institute Admin')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            InstId = int.Parse(DR["P_Id"].ToString());
            User_Id = int.Parse(DR["User_Id"].ToString());
            DesId = int.Parse(DR["Des_Id"].ToString());
            DR.Close();
            CNN.Close();
            CMD.Dispose();
            Session.Add("InstId", InstId);
            Session.Add("UserId", User_Id);
            Session.Add("DesId", DesId);
            Response.Redirect("frm_MainInstituteAdmin.aspx");
        }
        else
        {
            DR.Close();
            CNN.Close();
            CMD.Dispose();
            lberror.Visible = true;
        }
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtusername.Text = string.Empty;
        txtpassword.Text = string.Empty;
    }
}