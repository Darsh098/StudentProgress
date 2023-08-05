using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class frm_UniversityMarksEntry : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int StudId,Sem_Id,SubId,Max_DivId,Min_DivId;
    protected void Page_Load(object sender, EventArgs e)
    {
        Sem_Id = int.Parse(Session["SemesterId"].ToString());
        SubId = int.Parse(Session["Sub_Id"].ToString());
        GeneratePassingYear();
        if (!IsPostBack)
        {
            bindmyStudents();
            bindmyGrid();
        }
    }
    void bindmyGrid()
    {
        QRY = "SELECT UM.Uni_Id, SD.Stud_Name, UM.Uni_ExamYear, UM.Uni_ObtainedMarks, UM.Uni_TotalMarks FROM Tbl_StudentPersonalDetails SD, Tbl_UniversityMarks UM WHERE ";
        QRY += "UM.Sub_Id="+SubId+" AND UM.Sem_Id="+Sem_Id+" AND SD.Stud_Id=UM.Stud_Id AND UM.Uni_ExamYear="+ddlPassingYear.SelectedItem;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        grd_studentlistupdate.DataSource = DS.Tables[0];
        grd_studentlistupdate.DataBind();
        CMD.Dispose();
    }
    void bindmyStudents()
    {
        dt_studentlist.DataSource = null;
        dt_studentlist.DataBind();

        QRY = "SELECT MAX(Div_Id), MIN(Div_Id) FROM Tbl_DivisionMaster WHERE Sem_Id=" + Sem_Id;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            Max_DivId = int.Parse(DR[0].ToString());
            Min_DivId = int.Parse(DR[1].ToString());
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();

        QRY = "SELECT SD.Stud_Name, SC.Sc_RollNo, DM.Div_Name FROM Tbl_StudClassMaster SC, Tbl_DivisionMaster DM, Tbl_StudentPersonalDetails SD Where SC.Div_Id<=" + Max_DivId + " AND SC.Div_Id>=" + Min_DivId + " AND SC.Stud_Id = SD.Stud_Id AND DM.Div_Id = SC.Div_Id AND SD.Stud_Id NOT IN (SELECT Stud_Id from Tbl_UniversityMarks WHERE Sem_Id="+Sem_Id+")";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        dt_studentlist.DataSource = DS.Tables[0];
        dt_studentlist.DataBind();
        CMD.Dispose();
    }
    void GeneratePassingYear()
    {
        for (int i = 0; i < 20; i++)
        {
            ddlPassingYear.Items.Add((System.DateTime.Now.Year - i).ToString());
        }
    }

    public void ClearControls()
    {
        txtremarks.Text = string.Empty;
        txt_totalmarks.Text = string.Empty;
        txt_totalmarksobt.Text = string.Empty;
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in dt_studentlist.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk_studselect");
            if (cb.Checked)
            {
                QRY = "INSERT INTO Tbl_UniversityMarks VALUES (";
                QRY += "(SELECT MAX(Uni_Id) + 1 FROM Tbl_UniversityMarks), ";
                QRY += "(SELECT Stud_Id From Tbl_StudentPersonalDetails WHERE Stud_Name='" + dt_studentlist.Rows[row.RowIndex].Cells[2].Text + "'), ";
                QRY += "(SELECT MAX(Uni_SeatNo) + 1 FROM Tbl_UniversityMarks), ";
                QRY += "" + Sem_Id + ", ";
                QRY += "" + SubId + ", ";
                QRY += "" + ddlPassingYear.SelectedValue.ToString() + ", ";
                QRY += "" + txt_totalmarks.Text + ", ";
                QRY += "" + txt_totalmarksobt.Text + ", ";
                QRY += "'" + txtremarks.Text + "', ";
                QRY += "'TRUE')";
                CNN = new SqlConnection(CNS);
                CMD = new SqlCommand(QRY, CNN);
                CNN.Open();
                CMD.ExecuteNonQuery();
                CNN.Close();
                CMD.Dispose();
            }
        }
        bindmyStudents();
        ClearControls();
    }
    protected void grd_studentlistupdate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grd_studentlistupdate.EditIndex = e.NewEditIndex;
        bindmyGrid();
    }
    protected void grd_studentlistupdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //QRY = "UPDATE Tbl_UniversityMarks SET Uni_ObtainedMarks=" + e.NewValues["Uni_ObtainedMarks"]+" WHERE Stud_Id="+((Label)grd_studentlistupdate.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text;
        QRY = "UPDATE Tbl_UniversityMarks SET Uni_ObtainedMarks=" + e.NewValues["Uni_ObtainedMarks"] + " WHERE Uni_Id=" + ((Label)grd_studentlistupdate.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        grd_studentlistupdate.EditIndex = -1;
        bindmyGrid();
    }
    protected void grd_studentlistupdate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grd_studentlistupdate.EditIndex = -1;
        bindmyGrid();
    }
    protected void ddlPassingYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindmyGrid();
    }
}