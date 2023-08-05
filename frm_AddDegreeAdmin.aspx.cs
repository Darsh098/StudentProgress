using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_AddDegreeAdmin : System.Web.UI.Page
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
    void BindMyGrid()
    {
        QRY = "SELECT deg_Id,deg_Name FROM Tbl_DegreeMaster WHERE deg_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        Grd_Degree.DataSource = DS.Tables[0];
        Grd_Degree.DataBind();
    }

    protected void Grd_Degree_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grd_Degree.EditIndex = -1;
        BindMyGrid();
    }
    protected void Grd_Degree_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        QRY = "UPDATE Tbl_DegreeMaster SET deg_Name='" + e.NewValues["deg_Name"] + "' WHERE deg_Id=" + Grd_Degree.Rows[e.RowIndex].Cells[0].Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        Grd_Degree.EditIndex = -1;
        BindMyGrid();
    }
    protected void Grd_Degree_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        QRY = "DELETE Tbl_DegreeMaster WHERE deg_Id=" + Grd_Degree.Rows[e.RowIndex].Cells[0].Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        BindMyGrid();
    }
    protected void Grd_Degree_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grd_Degree.EditIndex = e.NewEditIndex;
        BindMyGrid();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_DegreeMaster VALUES (";
        QRY += "(SELECT MAX(deg_Id) + 1 FROM Tbl_DegreeMaster), ";
        QRY += "'" + txtdegname.Text + "', ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        BindMyGrid();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtdegname.Text = string.Empty;
        txtdegname.Focus();
    }
}