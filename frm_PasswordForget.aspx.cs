using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_PasswordForget : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int UserId;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtpasswordold.Text = "";
        txtpassword.Text = "";
        txtconfpassword.Text = "";
        txtpasswordold.Focus();
    }
    protected void btn_Change_Click(object sender, EventArgs e)
    {
        QRY = "SELECT User_Id FROM Tbl_LoginDetails WHERE User_Password='"+txtpasswordold.Text+"'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            UserId = int.Parse(DR["User_Id"].ToString());
            CMD.Dispose();
            DR.Close();
            QRY = "UPDATE Tbl_LoginDetails SET User_Password='"+txtpassword.Text+"' WHERE User_Id="+UserId;
            CMD = new SqlCommand(QRY, CNN);
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();
            lblsuc.Visible = true;
            lberr.Visible = false;
        }
        else
        {
            DR.Close();
            CNN.Close();
            CMD.Dispose();
            lberr.Visible = true;
        }
    }
}