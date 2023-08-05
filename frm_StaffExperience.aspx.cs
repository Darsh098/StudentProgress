using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_StaffExperience : System.Web.UI.Page
{
    static DataTable dt_Grd = new DataTable();
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StaffId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = int.Parse(Session["StaffId"].ToString());
        if (!IsPostBack)
        {
            dtGrd_Test.DataSource = null;
            dt_Grd.Rows.Clear();
            GenerateGrid();
        }
    }
    void GenerateGrid()
    {
        GenerateTab();
        DataRow DR = dt_Grd.NewRow();
        DR[0] = dt_Grd.Rows.Count + 1;
        dt_Grd.Rows.Add(DR);

        dtGrd_Test.DataSource = dt_Grd;
        dtGrd_Test.DataBind();
    }

    void GenerateTab()
    {
        if (dt_Grd.Columns.Count == 0)
        {
            dt_Grd.Columns.Add(new DataColumn("SrNo", typeof(int)));
            dt_Grd.Columns.Add(new DataColumn("Organization", typeof(string)));
            dt_Grd.Columns.Add(new DataColumn("Designation", typeof(string)));
            dt_Grd.Columns.Add(new DataColumn("JoinDate", typeof(string)));
            dt_Grd.Columns.Add(new DataColumn("LeaveDate", typeof(string)));
        }
    }
    void FillToDataTable(int RowCount)
    {
        try
        {
            for (int i = 0; i <= RowCount; i++)
            {
                dt_Grd.Rows[i][0] = i + 1;
                dt_Grd.Rows[i][1] = ((HtmlInputText)dtGrd_Test.Rows[i].Cells[1].FindControl("txtOrganization")).Value;
                dt_Grd.Rows[i][2] = ((HtmlInputText)dtGrd_Test.Rows[i].Cells[2].FindControl("txtDesignation")).Value;
                dt_Grd.Rows[i][3] = ((HtmlInputControl)dtGrd_Test.Rows[i].Cells[3].FindControl("txtJoin")).Value.ToString();
                dt_Grd.Rows[i][4] = ((HtmlInputControl)dtGrd_Test.Rows[i].Cells[4].FindControl("txtLeave")).Value.ToString();
            }
        }
        catch { }
    }
    protected void btn_addnewrecord_Click(object sender, EventArgs e)
    {
        dtGrd_Test.DataSource = null;
        FillToDataTable(dtGrd_Test.Rows.Count - 1);
        GenerateGrid();
    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dtGrd_Test.Rows.Count; i++)
        {
            QRY = "INSERT INTO Tbl_StaffExperienceDetails VALUES (";
            QRY += "(SELECT MAX(Se_Id) + 1 FROM Tbl_StaffExperienceDetails), ";
            QRY += "" + StaffId + ", ";
            QRY += "'" + ((HtmlInputText)dtGrd_Test.Rows[i].Cells[1].FindControl("txtOrganization")).Value + "', ";
            QRY += "'" + ((HtmlInputText)dtGrd_Test.Rows[i].Cells[2].FindControl("txtDesignation")).Value + "', ";
            QRY += "'" + ((HtmlInputControl)dtGrd_Test.Rows[i].Cells[3].FindControl("txtJoin")).Value.ToString() + "', ";
            QRY += "'" + ((HtmlInputControl)dtGrd_Test.Rows[i].Cells[4].FindControl("txtLeave")).Value.ToString() + "', ";
            QRY += "'TRUE')";
            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();
            Response.Redirect("frm_SubjectAllocation.aspx");
        }
    }
}