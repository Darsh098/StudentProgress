using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_PromoteStudents : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId, StaffId,Max_DivId,Min_DivId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());

        GetInstId();
        if (!IsPostBack)
        {
            LoadStreams();
        }
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
    void bindmyStudents()
    {
        dt_studentlist.DataSource = null;
        dt_studentlist.DataBind();

        QRY = "SELECT MAX(Div_Id), MIN(Div_Id) FROM Tbl_DivisionMaster WHERE Sem_Id=" + ddlSem.SelectedValue;
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

        QRY = "SELECT SD.Stud_Name, SC.Stud_Id, SC.Sc_RollNo, DM.Div_Name FROM Tbl_StudClassMaster SC, Tbl_DivisionMaster DM, Tbl_StudentPersonalDetails SD Where SC.Div_Id<=" + Max_DivId + " AND SC.Div_Id>=" + Min_DivId + " AND SC.Stud_Id = SD.Stud_Id AND DM.Div_Id = SC.Div_Id AND SC.Sc_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        dt_studentlist.DataSource = DS.Tables[0];
        dt_studentlist.DataBind();
        CMD.Dispose();
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemesters();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl.Visible = false;
        bindmyStudents();
    }
    protected void btn_Promote_Click(object sender, EventArgs e)
    {
        string str=string.Empty;
        foreach (GridViewRow row in dt_studentlist.Rows)
            str += ((Label)dt_studentlist.Rows[row.RowIndex].FindControl("lblStudId")).Text.ToString() + ",";
        str = str.Substring(0, str.Length - 1).ToString();

        QRY = "UPDATE Tbl_StudClassMaster Set ";
        QRY += "Sc_PassOutDate='"+System.DateTime.Now.Year+"-"+System.DateTime.Now.Month+"-"+System.DateTime.Now.Day+"', ";
        QRY += "Sc_IsActive='FALSE' WHERE Stud_Id IN ("+str+")";

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        QRY = "UPDATE Tbl_UniversityMarks Set ";
        QRY += "Uni_IsActive='FALSE' WHERE Stud_Id IN (" + str + ")";

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        QRY = "UPDATE Tbl_ExamMaster Set ";
        QRY += "Em_IsActive='FALSE' WHERE Stud_Id IN (" + str + ")";

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();


        if (ddlSem.Items.Count - 1 != ddlSem.SelectedIndex)
        {
            CNN = new SqlConnection(CNS);
            CNN.Open();
            foreach (GridViewRow row in dt_studentlist.Rows)
            {
                QRY = "INSERT INTO Tbl_StudClassMaster VALUES(";
                QRY += "(SELECT MAX(Sc_Id)+1 FROM Tbl_StudClassMaster), ";
                QRY += "" + ((Label)dt_studentlist.Rows[row.RowIndex].FindControl("lblStudId")).Text.ToString() + ", ";
                QRY += "(SELECT MAX(Div_Id) + 2 FROM Tbl_StudClassMaster WHERE Stud_Id=" + ((Label)dt_studentlist.Rows[row.RowIndex].FindControl("lblStudId")).Text.ToString() + "), ";
                QRY += "(SELECT Sc_RollNo FROM Tbl_StudClassMaster WHERE Stud_Id=" + ((Label)dt_studentlist.Rows[row.RowIndex].FindControl("lblStudId")).Text.ToString() + "), ";
                QRY += "'" + System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "', NULL, NULL, 'TRUE'";
                QRY += ")";

                CMD = new SqlCommand(QRY, CNN);
                CMD.ExecuteNonQuery();
                CMD.Dispose();
            }
            CNN.Close();
        }
        else
        {
            lbl.Visible = true;
        }
        bindmyStudents();
    }
}