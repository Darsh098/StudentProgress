using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_AddCourse : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId;
    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());
        if (!IsPostBack)
        {
            BindmyStream(ddl_stream);
            BindMyGrid();
        }
     
    }
    public void BindmyStream(DropDownList ddl)
    {
        QRY = "SELECT Stream_Id,Stream_Name FROM Tbl_StreamMaster WHERE Stream_IsActive='TRUE' OR Stream_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl.DataTextField = "Stream_Name";
        ddl.DataValueField = "Stream_Id";
        ddl.DataSource = DS.Tables[0];
        ddl.DataBind();
        CMD.Dispose();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        ddl_stream.SelectedIndex = 0;
        txtcourse.Text = string.Empty;
        txtcourseduration.Text = string.Empty;
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        int CourId=0;

        QRY = "SELECT MAX(Cour_Id)+1 FROM Tbl_CourseMaster WHERE Cour_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            CourId = int.Parse(DR[0].ToString());
        }
        DR.Close();
        CNN.Close();
        CMD.Dispose();


        QRY = "INSERT INTO Tbl_CourseMaster VALUES (";
        QRY += ""+CourId+", ";
        QRY += ""+InstId+", ";
        QRY += ""+ddl_stream.SelectedValue+", ";
        QRY += "'"+txtcourse.Text+"', ";
        QRY += "'"+txtcourseduration.Text+"', ";
        QRY+="'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        for (int i = 1; i <= int.Parse(txtcourseduration.Text.ToString()) * 2; i++)
        {
            QRY = "INSERT INTO Tbl_SemMaster VALUES (";
            QRY += "(SELECT MAX(Sem_Id)+1 FROM Tbl_SemMaster), ";
            QRY += "" + CourId + ", ";
            QRY += "'SEM - " + i + "', ";
            QRY += "'TRUE')";
            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();
        }
    }
    void BindMyGrid()
    {
            QRY = "SELECT CM.Cour_Id, SM.Stream_Name, CM.Cour_Name FROM Tbl_StreamMaster SM, Tbl_CourseMaster CM ";
            QRY+="WHERE SM.Stream_Id=CM.Stream_Id AND CM.Inst_Id="+InstId;
            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            Grd_Course.DataSource = DS;
            Grd_Course.DataBind();
            CMD.Dispose();
    }
    protected void Grd_Course_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        QRY = "UPDATE Tbl_CourseMaster SET Cour_Name = '" + e.NewValues["Cour_Name"] + "'";
        if (((DropDownList)Grd_Course.Rows[e.RowIndex].Cells[1].FindControl("ddlStream")).SelectedIndex>0)
            QRY += ", Stream_Id="+((DropDownList)Grd_Course.Rows[e.RowIndex].Cells[1].FindControl("ddlStream")).SelectedValue;
        QRY += "WHERE Cour_Id=" + ((Label)Grd_Course.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text.ToString();
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        Grd_Course.EditIndex = -1;
        BindMyGrid();
    }
    protected void Grd_Course_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grd_Course.EditIndex = e.NewEditIndex;
        BindMyGrid();
        //Response.Write(((DropDownList)Grd_Course.Rows[Grd_Course.EditIndex].Cells[1].FindControl("ddlStream")).ID);
        BindmyStream((DropDownList)Grd_Course.Rows[Grd_Course.EditIndex].Cells[1].FindControl("ddlStream"));
    }
    protected void Grd_Course_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grd_Course.EditIndex = -1;
        BindMyGrid();
    }
}