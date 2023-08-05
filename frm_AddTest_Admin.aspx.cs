using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_AddTest_Institute : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindMyGrid();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_TestTypeMaster VALUES (";
        QRY += "(SELECT MAX(Tt_Id) + 1 FROM Tbl_TestTypeMaster), ";
        QRY += "'"+txttestname.Text+"', ";
        QRY+="'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        BindMyGrid();
    }
    void BindMyGrid()
    {
        QRY = "SELECT Tt_Id,Tt_Name FROM Tbl_TestTypeMaster WHERE Tt_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        Grd_Test.DataSource = DS;
        Grd_Test.DataBind();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txttestname.Text = string.Empty;
        txttestname.Focus();
    }
    protected void Grd_Test_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        QRY = "UPDATE Tbl_TestTypeMaster SET Tt_Name='" + e.NewValues["Tt_Name"] + "' WHERE Tt_Id=" + Grd_Test.Rows[e.RowIndex].Cells[0].Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        Grd_Test.EditIndex = -1;
        BindMyGrid();
    }
    protected void Grd_Test_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grd_Test.EditIndex = -1;
        BindMyGrid();
    }
    protected void Grd_Test_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        QRY = "DELETE Tbl_TestTypeMaster WHERE Tt_Id=" + Grd_Test.Rows[e.RowIndex].Cells[0].Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        BindMyGrid();
    }
    protected void Grd_Test_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grd_Test.EditIndex = e.NewEditIndex;
        BindMyGrid();
    }
}