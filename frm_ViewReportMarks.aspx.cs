using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class frm_ViewReportMarks : System.Web.UI.Page
{
    string QRY;
    string CNS = ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int SemId,StudId;
    protected void Page_Load(object sender, EventArgs e)
    {

        StudId = int.Parse(Session["StudId"].ToString());
        //if (Request.QueryString["SemId"].ToString() != null)
        try
        {
            SemId = int.Parse(Request.QueryString["SemId"].ToString());
        }
        catch
        {
            Response.Redirect("frm_MarksReporting.aspx");
        }
        LoadmyReport();
    }
    void LoadmyReport()
    {
        QRY = "SELECT SM.Sub_Name, SD.Stud_Name, UM.Uni_ObtainedMarks, SEM.Sem_Name, UM.Uni_TotalMarks, ";
        QRY += "(SELECT SUM(Uni_ObtainedMarks) FROM Tbl_UniversityMarks WHERE Stud_Id="+StudId+"";
        if (SemId != 0)
            QRY += " AND Sem_Id=" + SemId;
        QRY+=") AS 'Total', ";
        QRY += "(SELECT AVG(Uni_ObtainedMarks) FROM Tbl_UniversityMarks WHERE Stud_Id="+StudId+"";
        if (SemId != 0)
            QRY += " AND Sem_Id=" + SemId;
        QRY+=") AS 'Percentage' ";
        QRY += "FROM Tbl_SubjectMaster SM, Tbl_UniversityMarks UM, Tbl_SemMaster SEM, Tbl_StudentPersonalDetails SD ";
        QRY += "WHERE UM.Stud_Id = "+StudId+" AND SM.Sub_Id=UM.Sub_Id ";
        QRY += "AND SD.Stud_Id=UM.Stud_Id AND SEM.Sem_Id=UM.Sem_Id ";
        if (SemId != 0)
            QRY += "AND UM.Sem_Id="+SemId;
        QRY += "ORDER BY SM.Sem_Id, SM.Sub_Id";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        
        
        DS_Marks DM = new DS_Marks();
        DA.Fill(DM,"DT_Marks");
        
        
        ReportDocument r = new ReportDocument();
        r.Load(Server.MapPath("CR_Marks.rpt"));
        r.SetDataSource(DM.Tables["DT_Marks"]);
        CRV_StudentMarks.ReportSource=r;
        CRV_StudentMarks.DataBind();
        r.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Student Progress Report");
    }
}