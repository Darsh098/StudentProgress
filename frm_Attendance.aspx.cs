using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_Attendance : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId, StaffId, SubId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());
        GetInstId();
        if (!IsPostBack)
        {
            LoadStreams();
        }   
    }
   
    void GetSubId()
    {
        QRY = "SELECT Sub_Id FROM Tbl_SubjectAllocationMaster WHERE Staff_Id=" + StaffId + " AND Div_Id="+ddl_division.SelectedValue+ " AND Sa_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            SubId = int.Parse(DR["Sub_Id"].ToString());
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
        LoadDivision();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemesters();
        LoadDivision();
    }
  
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDivision(); 
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        GetSubId();
        
        foreach (RepeaterItem row in dt_studentstatus.Items )
        {
            CheckBox cb = (CheckBox)row.FindControl("chk_studselect");
            QRY = "INSERT INTO Tbl_AttendanceMaster VALUES (";
            QRY +="(SELECT MAX(Att_Id) + 1 FROM Tbl_AttendanceMaster), ";
            QRY += "" + ((Label)dt_studentstatus.Items[row.ItemIndex].FindControl("lblstudid")).Text + ", ";
            QRY += ""+SubId+", ";
            QRY += "'"+txtdate.Text+"', ";
            if (cb.Checked)
            {
                QRY += "" + rd_status.SelectedValue + ", ";
            }
            else
            {
                if (int.Parse(rd_status.SelectedValue) == 1)
                    QRY += "" + (int.Parse(rd_status.SelectedValue) + 1).ToString() + ", ";
                else
                    QRY += "" + (int.Parse(rd_status.SelectedValue) - 1).ToString() + ", ";

            }
            QRY += "NULL, ";
            QRY+=""+StaffId+", ";
            QRY += "'TRUE' )";
            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();
        }
        bindmyStudents();
        bindmystudentatt();
    }
    void bindmyStudents()
    {
        QRY = "SELECT SD.Stud_Name,SC.Sc_RollNo,SD.Stud_Id FROM Tbl_StudentPersonalDetails SD, Tbl_StudClassMaster SC WHERE SD.Stud_Id=SC.Stud_Id AND SC.Sc_IsActive='TRUE' AND SC.Div_Id=" + ddl_division.SelectedValue;
        QRY += " AND SC.Stud_Id NOT IN (SELECT Stud_Id From Tbl_AttendanceMaster WHERE Att_date='" + txtdate.Text + "' AND Staff_Id="+StaffId+")";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        if (DS.Tables[0].Rows.Count > 0)
        {
            dt_studentstatus.DataSource = DS.Tables[0];
            lblStatus.Visible = true;
            rd_status.Visible = true;
        }
        else
        {
            dt_studentstatus.DataSource = null;
            lblStatus.Visible = false;
            rd_status.Visible = false;
        }

        dt_studentstatus.DataBind();
        CMD.Dispose();
    }
    void LoadDivision()
    {
        QRY = "SELECT Div_Id,Div_Name FROM Tbl_DivisionMaster WHERE Sem_Id=" + ddlSem.SelectedValue + "AND Div_IsActive='TRUE' OR Sem_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddl_division.DataTextField = "Div_Name";
        ddl_division.DataValueField = "Div_Id";
        ddl_division.DataSource = DS.Tables[0];
        ddl_division.DataBind();
        CMD.Dispose();  
    }
    void GetInstId()
    {
        QRY = "SELECT IM.Inst_Id FROM Tbl_SubjectAllocationMaster SAM, ";
        QRY += "Tbl_DivisionMaster DM, ";
        QRY += "Tbl_CourseMaster CM, ";
        QRY += "Tbl_SemMaster SM, ";
        QRY += "Tbl_InstituteMaster IM ";
        QRY += "WHERE SAM.Staff_Id=" + StaffId + " AND SAM.Div_Id=DM.Div_Id AND DM.Sem_Id=SM.Sem_Id AND SM.Cour_Id=CM.Cour_Id AND CM.Inst_Id = IM.Inst_Id";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        if (DR.Read())
        {
            InstId = int.Parse(DR["Inst_Id"].ToString());
        }
        DR.Close();
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();

    }
    void LoadStreams()
    {
        QRY = "SELECT Stream_Id, Stream_Name FROM Tbl_StreamMaster WHERE Stream_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlStream.DataTextField = "Stream_Name";
        ddlStream.DataValueField = "Stream_Id";
        ddlStream.DataSource = DS.Tables[0];
        ddlStream.DataBind();
        CMD.Dispose();
    }   
    void LoadCourses()
    {
        QRY = "SELECT Cour_Id, Cour_Name FROM Tbl_CourseMaster WHERE Cour_IsActive='TRUE' AND Stream_Id=" + ddlStream.SelectedValue + " AND Inst_Id=" + InstId + " OR Stream_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlCourse.DataTextField = "Cour_Name";
        ddlCourse.DataValueField = "Cour_Id";
        ddlCourse.DataSource = DS.Tables[0];
        ddlCourse.DataBind();
        CMD.Dispose();
    }
    void LoadSemesters()
    {
        QRY = "SELECT Sem_Id, Sem_Name FROM Tbl_SemMaster WHERE Sem_IsActive='TRUE' AND Cour_Id=" + ddlCourse.SelectedValue + " OR Cour_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlSem.DataTextField = "Sem_Name";
        ddlSem.DataValueField = "Sem_Id";
        ddlSem.DataSource = DS.Tables[0];
        ddlSem.DataBind();
        CMD.Dispose();
    }

    protected void ddl_division_SelectedIndexChanged(object sender, EventArgs e)
    {

        bindmyStudents();    
    }
    protected void btndate_Click(object sender, ImageClickEventArgs e)
    {
        cldar.Visible = true;
        //txtdate.Visible = false;
    }
    protected void cldar_SelectionChanged(object sender, EventArgs e)
    {
        cldar.Visible = false;
        txtdate.Text = cldar.SelectedDate.ToString("yyyy-MM-dd");
        bindmyStudents();
        bindmystudentatt();
    }
    void bindmystudentatt()
    {
        GetSubId();
        QRY = "SELECT SD.Stud_Name, AM.Att_Id, SD.Stud_Id, STM.Status_Type FROM Tbl_StudentPersonalDetails SD, Tbl_AttendanceMaster AM, Tbl_StatusTypeMaster STM ";
        QRY+="WHERE SD.Stud_Id=AM.Stud_Id AND AM.Status_Id=STM.Status_Id AND AM.Att_Date='"+txtdate.Text+"' AND AM.Sub_Id="+SubId+" AND Staff_Id="+StaffId;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        grd_studentstatus.DataSource = DS.Tables[0];
        grd_studentstatus.DataBind();
        CNN.Close();
        CMD.Dispose();

    }
    protected void grd_studentstatus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grd_studentstatus.EditIndex = e.NewEditIndex;
        string str = ((Label)grd_studentstatus.Rows[grd_studentstatus.EditIndex].Cells[3].FindControl("lblstatus")).Text;
        bindmystudentatt();
        if(str.Equals("Present"))
            ((RadioButton)grd_studentstatus.Rows[grd_studentstatus.EditIndex].Cells[3].FindControl("grdrd_present")).Checked = true;
        else
        ((RadioButton)grd_studentstatus.Rows[grd_studentstatus.EditIndex].Cells[3].FindControl("grdrd_absent")).Checked = true;
    }
    protected void grd_studentstatus_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (((RadioButton)grd_studentstatus.Rows[e.RowIndex].Cells[2].FindControl("grdrd_present")).Checked)
            QRY = "UPDATE Tbl_AttendanceMaster SET Status_Id=" + ((RadioButton)grd_studentstatus.Rows[e.RowIndex].Cells[3].FindControl("grdrd_present")).ToolTip ;
        else
            QRY = "UPDATE Tbl_AttendanceMaster SET Status_Id=" + ((RadioButton)grd_studentstatus.Rows[e.RowIndex].Cells[3].FindControl("grdrd_absent")).ToolTip;
        QRY += " WHERE Att_Id=" + ((Label)grd_studentstatus.Rows[e.RowIndex].Cells[2].FindControl("lblattid")).Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        grd_studentstatus.EditIndex = -1;
        bindmystudentatt();
    }
    protected void grd_studentstatus_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grd_studentstatus.EditIndex = -1;
        bindmystudentatt();
    }
}