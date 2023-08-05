using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_StudentList : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int Max_DivId, Min_DivId,Sem_Id=0,TestId,SubId;

    protected void Page_Load(object sender, EventArgs e)
    {
        Sem_Id = int.Parse(Session["SemesterId"].ToString());
        SubId = int.Parse(Session["Sub_Id"].ToString());
        TestId = int.Parse(Session["TestId"].ToString());
            GeneratePassingYear();
        if (!IsPostBack)
        {
            bindmyStudents();
            bindmyGrid();
        }
    }
    void GeneratePassingYear()
    {
        for (int i = 0; i < 20; i++)
        {
            ddlPassingYear.Items.Add((System.DateTime.Now.Year - i).ToString());
        }
    }
    void bindmyStudents()
    {
        dt_studentlist.DataSource = null;
        dt_studentlist.DataBind();

        QRY = "SELECT MAX(Div_Id), MIN(Div_Id) FROM Tbl_DivisionMaster WHERE Sem_Id="+Sem_Id;
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

        QRY = "SELECT SD.Stud_Name, SC.Sc_RollNo, DM.Div_Name FROM Tbl_StudClassMaster SC, Tbl_DivisionMaster DM, Tbl_StudentPersonalDetails SD Where SC.Div_Id<=" + Max_DivId + " AND SC.Div_Id>=" + Min_DivId + " AND SC.Stud_Id = SD.Stud_Id AND SC.Sc_IsActive='TRUE' AND DM.Div_Id = SC.Div_Id AND SD.Stud_Id NOT IN (SELECT Stud_Id from Tbl_ExamMaster WHERE Tt_Id="+TestId+" AND Sub_Id="+SubId+")"; 
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        dt_studentlist.DataSource = DS.Tables[0];
        dt_studentlist.DataBind();
        CMD.Dispose();
    }
    void bindmyGrid()
    {
        QRY = "SELECT UM.Em_Id, SD.Stud_Name,TT.Tt_Name, UM.Em_ObtainedMarks, UM.Em_TotalMarks FROM Tbl_StudentPersonalDetails SD, Tbl_ExamMaster UM, Tbl_TestTypeMaster TT ";
        QRY += "WHERE Sub_Id=" + SubId + " AND SD.Stud_Id=UM.Stud_Id AND TT.Tt_Id=UM.Tt_Id AND UM.Em_IsActive='TRUE' AND UM.Tt_Id=" + TestId + " AND UM.Em_date>='" + int.Parse(ddlPassingYear.SelectedItem.ToString()) + "-03-01' AND UM.Em_date<='" + (int.Parse(ddlPassingYear.SelectedItem.ToString())+1).ToString() + "-04-30'";

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        Grd_StudentsMarksUpdate.DataSource = DS.Tables[0];
        Grd_StudentsMarksUpdate.DataBind();
        CMD.Dispose();
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {            
        foreach (GridViewRow row in dt_studentlist.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk_studselect");
            if (cb.Checked)
            {
                lblerror.Visible = false;
                QRY = "INSERT INTO Tbl_ExamMaster VALUES (";
                QRY += "(SELECT MAX(Em_Id) + 1 FROM Tbl_ExamMaster), ";
                QRY += "(SELECT Stud_Id From Tbl_StudentPersonalDetails WHERE Stud_Name='" + dt_studentlist.Rows[row.RowIndex].Cells[2].Text + "'), ";
                QRY += ""+SubId+", ";
                QRY += ""+TestId+", ";
                QRY += "'" + int.Parse(ddlPassingYear.SelectedItem.ToString()) + "-09-10', ";
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
        bindmyGrid();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txt_totalmarks.Text = string.Empty;
        txt_totalmarksobt.Text = string.Empty;
        txtremarks.Text = string.Empty;
    }
    private void ToggleCheckState(bool checkState)
    {
        foreach (GridViewRow row in dt_studentlist.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chk_studselect");
            if (cb != null)
                cb.Checked = checkState;
        }
    }
    protected void Btn_CheckAll_Click(object sender, EventArgs e)
    {
        if(Btn_CheckAll.Text=="Check All")
        {

            ToggleCheckState(true);
            Btn_CheckAll.Text = "Uncheck All";
        }
        else
        {
            ToggleCheckState(false);
            Btn_CheckAll.Text = "Check All";
        }
    }
    protected void Grd_StudentsMarksUpdate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grd_StudentsMarksUpdate.EditIndex = e.NewEditIndex;
        bindmyGrid();
    }
    protected void Grd_StudentsMarksUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        QRY = "UPDATE Tbl_ExamMaster SET Em_ObtainedMarks=" + e.NewValues["Em_ObtainedMarks"] + " WHERE Em_Id=" + ((Label)Grd_StudentsMarksUpdate.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();
        Grd_StudentsMarksUpdate.EditIndex = -1;
        bindmyGrid();
    }
    protected void Grd_StudentsMarksUpdate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grd_StudentsMarksUpdate.EditIndex = -1;
        bindmyGrid();
    }
    protected void ddlPassingYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindmyGrid();
    }
}