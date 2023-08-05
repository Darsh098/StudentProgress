using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_StaffApproval : System.Web.UI.Page
{
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int Sem_Id,InstId=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());
        if (!IsPostBack)
        {
            bindmydata();
        }
    }
    void bindmydata()
    {
        QRY = "SELECT SA.Staff_Id, SP.Staff_Name, SA.Div_Id, SM.Sem_Id, CM.Inst_Id, SMM.Cour_Id  FROM Tbl_CourseMaster CM, Tbl_SemMaster SMM, Tbl_SubjectMaster SM, Tbl_SubjectAllocationMaster SA, Tbl_StaffPersonalDetails SP WHERE SA.Div_Id=0 AND SA.Sa_IsActive='TRUE' AND SP.Staff_Id= SA.Staff_Id AND SM.Sub_Id=SA.Sub_Id AND SMM.Sem_Id=SM.Sem_Id AND CM.Cour_Id=SMM.Cour_Id And CM.Inst_Id="+InstId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        DataTable DT = new DataTable();
        DT.Columns.Add("Staff_Id");
        DT.Columns.Add("Staff_Name");
        DT.Columns.Add("Div_Id");
        while (DR.Read())
        {
            DataRow DR1 = DT.NewRow();
            DR1["Staff_Id"] = DR["Staff_Id"];
            DR1["Staff_Name"] = DR["Staff_Name"];
            DR1["Div_Id"] = DR["Div_Id"];
            Sem_Id = int.Parse(DR["Sem_Id"].ToString());
            DT.Rows.Add(DR1);
        }
        dt_approval.DataSource = DT;
        dt_approval.DataBind();  
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
    }

    protected void dt_approval_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        QRY = "UPDATE Tbl_SubjectAllocationMaster SET Div_Id=" + ((DropDownList)(dt_approval.Rows[e.RowIndex].Cells[2].FindControl("ddl_division"))).SelectedValue + " WHERE Staff_Id=" + dt_approval.Rows[e.RowIndex].Cells[0].Text;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        QRY = "INSERT INTO Tbl_StaffJoinMaster VALUES (";
        QRY += "(SELECT MAX(Sj_Id) + 1 FROM Tbl_StaffJoinMaster), ";
        QRY += "" + dt_approval.Rows[e.RowIndex].Cells[0].Text + ", ";
        QRY += "2, ";
        QRY += "'" + System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.AddDays(7).Day + "', ";
        QRY += "'" + System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.AddDays(7).Day + "', NULL, 'TRUE'";
        QRY += ")";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        dt_approval.EditIndex = -1;
        bindmydata();
    }
        
    protected void dt_approval_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dt_approval.EditIndex = e.NewEditIndex;
        bindmydata();
        QRY = "SELECT Div_Id,Div_Name FROM Tbl_DivisionMaster WHERE Sem_Id=" + Sem_Id + "AND Div_IsActive='TRUE'";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        ((DropDownList)(dt_approval.Rows[e.NewEditIndex].Cells[2].FindControl("ddl_division"))).DataTextField = "Div_Name";
        ((DropDownList)(dt_approval.Rows[e.NewEditIndex].Cells[2].FindControl("ddl_division"))).DataValueField = "Div_Id";
        ((DropDownList)(dt_approval.Rows[e.NewEditIndex].Cells[2].FindControl("ddl_division"))).DataSource = DS.Tables[0];
        ((DropDownList)(dt_approval.Rows[e.NewEditIndex].Cells[2].FindControl("ddl_division"))).DataBind();
        CMD.Dispose();  

    }
    protected void dt_approval_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dt_approval.EditIndex = -1;
        bindmydata();
    }
    protected void dt_approval_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "display")
        {
            Session["StaffId"]=e.CommandArgument;
            Response.Redirect("frmDisplayStaffDetails.aspx");
        }
    }
}