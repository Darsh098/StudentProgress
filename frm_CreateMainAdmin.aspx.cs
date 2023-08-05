using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frm_CreateMainAdmin : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int AdminId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminId"] != null)
        {
            AdminId = int.Parse(Session["AdminId"].ToString());
            txtusername.Visible = true;
            txtpassword.Visible = true;
        }
    }
    protected void Btn_Create_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_LoginDetails VALUES (";
        QRY += "(SELECT MAX(User_Id) + 1 FROM Tbl_LoginDetails), ";
        QRY += "'"+txtusername.Text+"', ";
        QRY += "'" + txtpassword.Text + "', ";
        QRY += "4, (SELECT MAX(P_Id) + 1 FROM Tbl_LoginDetails WHERE Des_Id=4), 'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtusername.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtusername.Focus();
    }
}