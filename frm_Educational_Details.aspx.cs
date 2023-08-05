using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class frm_Educational_Details : System.Web.UI.Page
{
    
    static DataTable dt_Grd = new DataTable();

    string CNS=ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    string QRY = string.Empty;
    SqlConnection CNN;
    SqlCommand CMD;
    int StudId,totalmarks,marksobt;
    float percent;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudId = int.Parse(Session["StudId"].ToString());
        if (!IsPostBack)
        {
            dtGrd_Test.DataSource = dt_Grd;
            dtGrd_Test.DataBind();
        }
    }
    void GeneratePassingYear(DropDownList DDL)
    {
        for (int i = 0; i < 20; i++)
        {
            DDL.Items.Add((System.DateTime.Now.Year - i).ToString());
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
        GeneratePassingYear(((DropDownList)dtGrd_Test.Rows[dtGrd_Test.Rows.Count - 1].Cells[3].FindControl("ddlYearGrid")));
    }

    void GenerateTab()
    {
        if (dt_Grd.Columns.Count == 0)
        {
            dt_Grd.Columns.Add(new DataColumn("SrNo", typeof(int)));
            dt_Grd.Columns.Add(new DataColumn("Grade", typeof(int)));
            dt_Grd.Columns.Add(new DataColumn("Board/Uni", typeof(int)));
            dt_Grd.Columns.Add(new DataColumn("PassingYear", typeof(string)));
            dt_Grd.Columns.Add(new DataColumn("TotalMarks", typeof(string)));
            dt_Grd.Columns.Add(new DataColumn("ObtMarks", typeof(string)));
        }
    }

    void FillToDataTable(int RowCount)
    {
        try
        {
            for (int i = 0; i <= RowCount; i++)
            {
                dt_Grd.Rows[i][0] = i + 1;
                dt_Grd.Rows[i][1] = ((DropDownList)dtGrd_Test.Rows[i].Cells[1].FindControl("ddlGradeGrid")).SelectedIndex;
                dt_Grd.Rows[i][2] = ((DropDownList)dtGrd_Test.Rows[i].Cells[2].FindControl("ddlUniGrid")).SelectedIndex;
                dt_Grd.Rows[i][3] = ((DropDownList)dtGrd_Test.Rows[i].Cells[3].FindControl("ddlYearGrid")).SelectedItem.Text;
                dt_Grd.Rows[i][4] = ((HtmlInputText)dtGrd_Test.Rows[i].Cells[4].FindControl("txtTotalMarks")).Value;
                dt_Grd.Rows[i][5] = ((HtmlInputText)dtGrd_Test.Rows[i].Cells[5].FindControl("txtObtMarks")).Value;
            }
        }
        catch { }
    }    
    
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    void ClearControls()
    {
        txt10_boardname.Text = string.Empty;
        txt10_passingyear.Text = string.Empty;
        txt10_totalmarks.Text = string.Empty;
        txt10_totalmarksobt.Text = string.Empty;
        txt12_boardname.Text = string.Empty;
        txt12_passingyear.Text = string.Empty;
        txt12_totalmarks.Text = string.Empty;
        txt12_totalmarksobt.Text = string.Empty;
        txt10_boardname.Focus();
    }
    protected void btn_newrow_Click(object sender, EventArgs e)
    {
        dtGrd_Test.DataSource = null;
        FillToDataTable(dtGrd_Test.Rows.Count - 1);
        GenerateGrid();
        if (dtGrd_Test.Rows.Count > 1)
        {
            for (int i = 0; i < dt_Grd.Rows.Count - 1; i++)
            {
                GeneratePassingYear(((DropDownList)dtGrd_Test.Rows[i].Cells[3].FindControl("ddlYearGrid")));
            }

            for (int i = 0; i < dt_Grd.Rows.Count - 1; i++)
            {
                ((DropDownList)dtGrd_Test.Rows[i].Cells[1].FindControl("ddlGradeGrid")).SelectedIndex = int.Parse(dt_Grd.Rows[i][1].ToString());
                ((DropDownList)dtGrd_Test.Rows[i].Cells[2].FindControl("ddlUniGrid")).SelectedIndex = int.Parse(dt_Grd.Rows[i][2].ToString());
                ((DropDownList)dtGrd_Test.Rows[i].Cells[3].FindControl("ddlYearGrid")).Text = dt_Grd.Rows[i][3].ToString();
            }
        }
        else
        {
            dtGrd_Test.DataSource = null;
            dt_Grd.Rows.Clear();
            GenerateGrid();
        }
    }
    public float CalcPercentage(int t1,int t2)
    {
        totalmarks = t1;
        marksobt = t2;
        percent = (float)(marksobt * 100) / (float)totalmarks;
        return percent;
    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        QRY = "INSERT INTO Tbl_StudentEducationalDetails VALUES (";
        QRY += "(SELECT MAX(Stq_Id) + 1 FROM Tbl_StudentEducationalDetails), ";
        QRY += ""+StudId+", ";
        QRY+="'10Th Details', ";
        QRY += ""+txt10_passingyear.Text+", ";
        QRY += ""+lblpercent.InnerHtml+", ";
        QRY += "'"+txt10_boardname.Text+"', ";
        QRY+="'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        QRY = "INSERT INTO Tbl_StudentEducationalDetails VALUES (";
        QRY += "(SELECT MAX(Stq_Id) + 1 FROM Tbl_StudentEducationalDetails), ";
        QRY += "" + StudId + ", ";
        QRY += "'12Th Details', ";
        QRY += "" + txt12_passingyear.Text + ", ";
        QRY += "" + lblpercent12.InnerHtml + ", ";
        QRY += "'" + txt12_boardname.Text + "', ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CNN.Close();
        CMD.Dispose();

        for (int i = 0; i < dtGrd_Test.Rows.Count; i++)
        {
            QRY = "INSERT INTO Tbl_StudentEducationalDetails VALUES (";
            QRY+="(SELECT MAX(Stq_Id) + 1 FROM Tbl_StudentEducationalDetails), ";
            QRY+=""+StudId+", ";
            QRY+="'"+((DropDownList)dtGrd_Test.Rows[i].Cells[1].FindControl("ddlGradeGrid")).SelectedItem.Text.ToString()+"', ";
            QRY+="'"+((DropDownList)dtGrd_Test.Rows[i].Cells[3].FindControl("ddlYearGrid")).SelectedItem.Text.ToString()+"', ";
            QRY += "" + CalcPercentage(int.Parse(((HtmlInputText)dtGrd_Test.Rows[i].Cells[4].FindControl("txtTotalMarks")).Value), int.Parse(((HtmlInputText)dtGrd_Test.Rows[i].Cells[5].FindControl("txtObtMarks")).Value))+", ";
            QRY += "'" + ((DropDownList)dtGrd_Test.Rows[i].Cells[2].FindControl("ddlUniGrid")).SelectedItem.Text.ToString() + "', ";
            QRY += "'TRUE')";

            
            CNN = new SqlConnection(CNS);
            CMD = new SqlCommand(QRY, CNN);
            CNN.Open();
            CMD.ExecuteNonQuery();
            CNN.Close();
            CMD.Dispose();

        }
        Response.Redirect("frm_Admission.aspx");
    }
    protected void txt10_totalmarksobt_TextChanged(object sender, EventArgs e)
    {
        if (txt10_totalmarksobt.Text != string.Empty && txt10_totalmarks.Text != string.Empty)
        {
            lblpercent.InnerHtml = CalcPercentage(int.Parse(txt10_totalmarks.Text), int.Parse(txt10_totalmarksobt.Text)).ToString();
            lblpercent.Visible = true;
        }
    }
    protected void txt12_totalmarks_TextChanged(object sender, EventArgs e)
    {
        if (txt12_totalmarksobt.Text != string.Empty && txt12_totalmarks.Text != string.Empty)
        {
            lblpercent12.InnerHtml = CalcPercentage(int.Parse(txt12_totalmarks.Text), int.Parse(txt12_totalmarksobt.Text)).ToString();
            lblpercent12.Visible = true;
        }        
    }
}
