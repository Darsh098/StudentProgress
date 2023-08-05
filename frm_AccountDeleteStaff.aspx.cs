using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_AccountDeleteStaff : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StaffId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());
        DeleteMyAccounts();
        if (Session["DesId"].ToString().Equals("3"))
        {
            Session.Remove("StaffId");
            Response.Redirect("frm_DisplayStaff_Inst.aspx");
        }
        else if (Session["DesId"].ToString().Equals("4"))
        {
            Session.Remove("StaffId");
            Response.Redirect("frm_DisplayStaff.aspx");
        }
        else if (!(Session["DesId"].ToString().Equals("3") && Session["DesId"].ToString().Equals("4")))
        {
            Response.Redirect("frm_Logout.aspx");
        }

    }
    void DeleteMyAccounts()
    {
        CNN = new SqlConnection(CNS);
        CNN.Open();
        QRY = "DELETE FROM Tbl_SubjectAllocationMaster WHERE Staff_Id=" + StaffId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_StaffPersonalDetails WHERE Staff_Id=" + StaffId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_StaffQualificationDetails WHERE Staff_Id=" + StaffId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_LoginDetails WHERE P_Id=" + StaffId  + " AND Des_Id=2";
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_StaffExperienceDetails WHERE Staff_Id=" + StaffId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_StaffJoinMaster WHERE Staff_Id=" + StaffId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
    }
}