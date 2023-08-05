using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_StudentLogin : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StudId, DesId;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtusername.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtusername.Focus();
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        QRY = "SELECT * FROM Tbl_LoginDetails WHERE User_Name='" + txtusername.Text + "' AND User_Password='" + txtpassword.Text + "' AND Des_Id=(SELECT Des_Id FROM Tbl_DesignationMaster WHERE Des_Name='Student')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            StudId = int.Parse(DR["P_Id"].ToString());
            DesId = int.Parse(DR["Des_Id"].ToString());
            DR.Close();
            CNN.Close();
            CMD.Dispose();
            Session.Add("StudId", StudId);
            Session.Add("DesId", DesId);
            Response.Redirect("frm_StudentDetailsUpdate.aspx");
        }
        else
        {
            DR.Close();
            CNN.Close();
            CMD.Dispose();
            lberror.Visible = true;
        }
    }
}