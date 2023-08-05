using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_StaffAllocation : System.Web.UI.Page
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
            LoadStaff();
        }
    }
    public void LoadStaff()
    {
        QRY = "SELECT SPD.Staff_Name,SPD.Staff_Id FROM Tbl_SubjectAllocationMaster SAM, Tbl_StaffPersonalDetails SPD WHERE SAM.Sub_Id IN ";
        QRY += "(SELECT SM.Sub_Id FROM Tbl_SubjectMaster SM, Tbl_SemMaster SEM, Tbl_CourseMaster CM ";
        QRY += "WHERE SM.Sem_Id=SEM.Sem_Id AND CM.Cour_Id=SEM.Cour_Id AND CM.Inst_Id="+InstId+" AND SM.Sub_IsActive='TRUE')";
        QRY += "AND SAM.Staff_Id=SPD.Staff_Id AND SAM.Sa_Id IN (SELECT MAX(Sa_Id) FROM Tbl_SubjectAllocationMaster GROUP BY Staff_Id) ORDER BY SPD.Staff_Id";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlStaff.DataTextField = "Staff_Name";
        ddlStaff.DataValueField = "Staff_Id";
        ddlStaff.DataSource = DS.Tables[0];
        ddlStaff.DataBind();
        CMD.Dispose();

        ddlStaff.Items.Insert(0,"-- Select Staff --");
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

    void LoadSubjects()
    {
        QRY = "SELECT Sub_Id,Sub_Name FROM Tbl_SubjectMaster WHERE Sub_IsActive='TRUE' AND Sem_Id=" + ddlSem.SelectedValue + "OR Sem_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddlsubject.DataTextField = "Sub_Name";
        ddlsubject.DataValueField = "Sub_Id";
        ddlsubject.DataSource = DS.Tables[0];
        ddlsubject.DataBind();
        CMD.Dispose();
    }

    void BindMyGrid()
    {
        QRY = "SELECT SAM.Sa_Id, SPD.Staff_Name, SM.Sub_Name, SEM.Sem_Name, DM.Div_Name FROM Tbl_StaffPersonalDetails SPD, Tbl_SemMaster SEM, Tbl_DivisionMaster DM, Tbl_SubjectAllocationMaster SAM, Tbl_SubjectMaster SM ";
        QRY += "WHERE SPD.Staff_Id=SAM.Staff_Id AND SAM.Sub_Id=SM.Sub_Id AND SAM.Staff_Id="+ddlStaff.SelectedValue+" AND SAM.Div_Id=DM.Div_Id AND SM.Sem_Id=SEM.Sem_Id AND SAM.Sa_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        Grd_Staff.DataSource = DS.Tables[0];
        Grd_Staff.DataBind();
        CMD.Dispose();
    }

    void LoadDivisions()
    {
        QRY = "SELECT Div_Id,Div_Name FROM Tbl_DivisionMaster WHERE Sem_Id=" + ddlSem.SelectedValue + "AND Div_IsActive='TRUE' OR Sem_Id=0";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ddldivision.DataTextField = "Div_Name";
        ddldivision.DataValueField = "Div_Id";
        ddldivision.DataSource = DS.Tables[0];
        ddldivision.DataBind();
        CMD.Dispose();
    }

    protected void ddlStaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStaff.SelectedIndex == 0)
        {
            Grd_Staff.Visible = false;
        }
        else
        {
                Grd_Staff.Visible = true;
                BindMyGrid();
        }
    }
    protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCourses();
        LoadSemesters();
        LoadDivisions();
        LoadSubjects();
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSemesters();
        LoadDivisions();
        LoadSubjects();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDivisions();
        LoadSubjects();
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        if (btn_insert.Text == "Allocate New Subject")
        {
            btn_insert.Text = "Add Subject";
            spn_course.Visible = true;
            spn_sem.Visible = true;
            spn_stream.Visible = true;
            spn_div.Visible = true;
            spn_sub.Visible = true;
            btn_cancel.Visible = true;

            LoadStreams();
        }
        else if (btn_insert.Text == "Add Subject")
        {
            btn_insert.Text = "Allocate New Subject";
            spn_course.Visible = false;
            spn_sub.Visible = false;
            spn_sem.Visible = false;
            spn_div.Visible = false;
            spn_stream.Visible = false;
            btn_cancel.Visible = false;

            QRY = "INSERT INTO Tbl_SubjectAllocationMaster VALUES (";
            QRY += "(SELECT MAX(Sa_Id) + 1 FROM Tbl_SubjectAllocationMaster), ";
            QRY += "'"+System.DateTime.Now.Year.ToString()+"', ";
            QRY += ""+ddlsubject.SelectedValue+", ";
            QRY += ""+ddlStaff.SelectedValue+", ";
            QRY += ""+ddldivision.SelectedValue+", NULL, 'TRUE')";

            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();
            BindMyGrid();

            ddlCourse.SelectedIndex = 0;
            ddldivision.SelectedIndex = 0;
            ddlSem.SelectedIndex = 0;
            ddlStream.SelectedIndex = 0;
            ddlsubject.SelectedIndex = 0;
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        if (ddlCourse.Items.Count > 0)
        {
            ddlCourse.SelectedIndex = 0;
            ddldivision.SelectedIndex = 0;
            ddlSem.SelectedIndex = 0;
            ddlsubject.SelectedIndex = 0;
        }
        ddlStream.SelectedIndex = 0;
        btn_insert.Text = "Allocate New Subject";
        btn_cancel.Visible = false;
        spn_course.Visible = false;
        spn_sub.Visible = false;
        spn_sem.Visible = false;
        spn_div.Visible = false;
        spn_stream.Visible = false;
    }
    protected void Grd_Staff_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        QRY = "UPDATE Tbl_SubjectAllocationMaster SET Sa_IsActive='FALSE' WHERE Sa_Id=" + ((Label)Grd_Staff.Rows[e.RowIndex].Cells[0].FindControl("lbl_Sa_Id")).Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();
        BindMyGrid();
    }
    protected void Grd_Staff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grd_Staff.EditIndex = -1;
    }
}