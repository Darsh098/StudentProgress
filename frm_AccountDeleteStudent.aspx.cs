using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class frm_AccountDeleteStudent : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StudId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudId = int.Parse(Session["StudId"].ToString());
        DeleteMyAccounts();
        if (Session["DesId"].ToString().Equals("3"))
        {
            Session.Remove("StudId");
            Response.Redirect("frm_DisplayStudents_Inst.aspx");
        }
        else if (Session["DesId"].ToString().Equals("4"))
        {
            Session.Remove("StudId");
            Response.Redirect("frm_DisplayStudents.aspx");
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
        QRY = "DELETE FROM Tbl_StudentEducationalDetails WHERE Stud_Id=" + StudId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_StudClassMaster WHERE Stud_Id=" + StudId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_ExamMaster WHERE Stud_Id=" + StudId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_AttendanceMaster WHERE Stud_Id=" + StudId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_UniversityMarks WHERE Stud_Id=" + StudId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_StudentPersonalDetails WHERE Stud_Id=" + StudId;
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CMD.Dispose();

        QRY = "DELETE FROM Tbl_LoginDetails WHERE P_Id=" + StudId + " AND Des_Id=1";
        CMD = new SqlCommand(QRY, CNN);
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

    }
}