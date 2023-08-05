using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_StaffDetailsUpdate : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int StaffId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId =int.Parse(Session["StaffId"].ToString());
        if (Session["DesId"].ToString().Equals("3") || Session["DesId"].ToString().Equals("4"))
        {
            btn_back.Visible = true;
        }
        if (!IsPostBack)
        {
            BindMyPersonalDetails();
            BindMyQualification();
            BindMyExperienceDetails();
            
        }
    }
    void VisibleTextBox()
    {
        lblname.Visible = false;
        lblgender.Visible = false;
        lblcontno.Visible = false;
        lblbdate.Visible = false;

        txtname.Visible = true;
        txtname.Text = lblname.Text;
        txtcontno.Visible = true;
        txtcontno.Text = lblcontno.Text;
        txtgender.Visible = true;
        txtgender.Text = lblgender.Text;
        txtbdate.Visible = true;
        txtbdate.Value = lblbdate.Text;

        btn_edit.Text = "Update";
        btn_cancel.Visible = true;
    }
    void VisibleLabel()
    {
        lblname.Visible = true;
        lblgender.Visible = true;
        lblcontno.Visible = true;
        lblbdate.Visible = true;

        txtname.Visible = false;
        txtcontno.Visible = false;
        txtgender.Visible = false;
        txtbdate.Visible = false;

        btn_edit.Text = "Edit";
        btn_cancel.Visible = false;
    }
    void BindMyQualification()
    {
        QRY = "SELECT * FROM Tbl_StaffQualificationDetails WHERE Staff_Id=" + StaffId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        grd_educat.DataSource = DS.Tables[0];
        grd_educat.DataBind();
        CMD.Dispose();
        CNN.Close();
    }
    void BindMyExperienceDetails()
    {
        QRY = "SELECT * FROM Tbl_StaffExperienceDetails WHERE Staff_Id=" + StaffId;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        dt_staffexp.DataSource = DS.Tables[0];
        dt_staffexp.DataBind();
        CMD.Dispose();
        CNN.Close();
    }
    void BindMyPersonalDetails()
    {
        QRY = "SELECT * FROM Tbl_StaffPersonalDetails WHERE Staff_Id=" + StaffId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        SqlDataReader DR = CMD.ExecuteReader();
        while (DR.Read())
        {
            lblname.Text = DR["Staff_Name"].ToString();
            lblgender.Text = DR["Staff_Gender"].ToString();
            lblemail.Text = DR["Staff_Email"].ToString();
            lblbdate.Text = ((DateTime)DR["Staff_Bdate"]).ToString("yyyy-MM-dd");
            lblcontno.Text = DR["Staff_ContNo"].ToString();
        }
        DR.Dispose();
        CMD.Dispose();
        CNN.Close();
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        if (btn_edit.Text == "Edit")
        {
            VisibleTextBox();
        }
        else if (btn_edit.Text == "Update")
        {
            QRY = "UPDATE Tbl_StaffPersonalDetails SET Staff_Name='" + txtname.Text + "', ";
            QRY += "Staff_Gender='" + txtgender.Text + "', ";
            QRY += "Staff_Bdate='" + txtbdate.Value + "', ";
            QRY += "Staff_ContNo=" + txtcontno.Text + " ";
            QRY += "WHERE Staff_Id=" + StaffId;
            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();
            VisibleLabel();
            BindMyPersonalDetails();
            if (Session["DesId"].ToString().Equals("3"))
            {
                Response.Redirect("frm_DisplayStaff_Inst.aspx");
            }
            else if (Session["DesId"].ToString().Equals("4"))
            {
                Response.Redirect("frm_DisplayStaff.aspx");
            }
        }      
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        VisibleLabel();
    }
}