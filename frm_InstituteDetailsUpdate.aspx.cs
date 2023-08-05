using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class frm_InstituteDetailsUpdate : System.Web.UI.Page
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
            BindmyInstitute();
            BindmyInstituteImages();
        }
    }
    void BindmyInstituteImages()
    {
        QRY = "SELECT InstG_Id FROM Tbl_InstituteGallery WHERE Inst_Id="+InstId;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        grd_instgallery.DataSource = DS.Tables[0];
        grd_instgallery.DataBind();
        CMD.Dispose();
    }
    public void BindmyInstitute()
    {
        QRY = "SELECT * FROM Tbl_InstituteDetails WHERE InstD_IsActive='TRUE' AND Inst_Id=" + InstId;
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        SqlDataAdapter DA = new SqlDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        dt_inst.DataSource = DS.Tables[0];
        dt_inst.DataBind();
        CMD.Dispose();
    }
    //protected void dt_inst_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    QRY = "UPDATE Tbl_InstituteDetails SET InstD_IsActive='FALSE' WHERE Inst_Id="+InstId;
    //    CNN = new SqlConnection(CNS);
    //    CMD = new SqlCommand(QRY, CNN);
    //    CNN.Open();
    //    CMD.ExecuteNonQuery();
    //    CMD.Dispose();
    //    CNN.Close();
    //    BindmyInstitute();
    //}
    protected void dt_inst_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dt_inst.EditIndex = -1;
        BindmyInstitute();
    }
    protected void dt_inst_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dt_inst.EditIndex = e.NewEditIndex;
        BindmyInstitute();
    }
    protected void dt_inst_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        byte[] imgByte = null;
        FileUpload fld = (FileUpload)dt_inst.Rows[e.RowIndex].Cells[1].FindControl("fldImgGrid");


        if (fld.PostedFile.ContentLength > 0)
        {
            imgByte = new byte[fld.PostedFile.ContentLength];
            fld.PostedFile.InputStream.Read(imgByte, 0, imgByte.Length);
        }
        QRY = "UPDATE Tbl_InstituteDetails SET ";
        QRY += "InstD_Details='"+e.NewValues["InstD_Details"]+"', ";
        if (fld.PostedFile.ContentLength > 0)
        {
            QRY += "InstD_Logo = @img, ";
        }
        QRY += "InstD_ContactNo=" + e.NewValues["InstD_ContactNo"] + ", ";
        QRY += "InstD_AltContactNo=" + e.NewValues["InstD_AltContactNo"] + ", ";
        QRY += "InstD_Email='" + e.NewValues["InstD_Email"] + "' ";
        QRY += "WHERE Inst_Id="+InstId;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        if (fld.PostedFile.ContentLength > 0)
            CMD.Parameters.AddWithValue("@img", imgByte);

        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();
        dt_inst.EditIndex = -1;
        BindmyInstitute();
    }

    protected void grd_instgallery_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        byte[] imgByte1 = null;
        FileUpload fld1 = (FileUpload)grd_instgallery.Rows[e.RowIndex].Cells[1].FindControl("fld_img1");


        if (fld1.PostedFile.ContentLength > 0)
        {
            imgByte1 = new byte[fld1.PostedFile.ContentLength];
            fld1.PostedFile.InputStream.Read(imgByte1, 0, imgByte1.Length);
        }
       
        byte[] imgByte2 = null;
        FileUpload fld2 = (FileUpload)grd_instgallery.Rows[e.RowIndex].Cells[2].FindControl("fld_img2");

        if (fld2.PostedFile.ContentLength > 0)
        {
            imgByte2 = new byte[fld2.PostedFile.ContentLength];
            fld2.PostedFile.InputStream.Read(imgByte2, 0, imgByte2.Length);
        }
        byte[] imgByte3 = null;
        FileUpload fld3 = (FileUpload)grd_instgallery.Rows[e.RowIndex].Cells[3].FindControl("fld_img3");


        if (fld3.PostedFile.ContentLength > 0)
        {
            imgByte3 = new byte[fld3.PostedFile.ContentLength];
            fld3.PostedFile.InputStream.Read(imgByte3, 0, imgByte3.Length);
        }
        QRY = "UPDATE Tbl_InstituteGallery SET ";
        if (fld1.PostedFile.ContentLength > 0 && fld2.PostedFile.ContentLength>0 && fld3.PostedFile.ContentLength>0)
        {
            QRY += "InstG_Image1 = @img1, InstG_Image2=@img2, InstG_Image3=@img3";
        }
        else if (fld1.PostedFile.ContentLength > 0 && fld2.PostedFile.ContentLength > 0)
        {
            QRY += "InstG_Image1 = @img1, InstG_Image2=@img2";
        }
        else if (fld2.PostedFile.ContentLength > 0 && fld3.PostedFile.ContentLength > 0)
        {
            QRY += "InstG_Image2 = @img2, InstG_Image3=@img3";
        }
        else if (fld1.PostedFile.ContentLength > 0 && fld3.PostedFile.ContentLength > 0)
        {
            QRY += "InstG_Image1 = @img1, InstG_Image3=@img3";
        }
        else if (fld1.PostedFile.ContentLength > 0)
        {
            QRY += "InstG_Image1 = @img1";
        }
        else if (fld2.PostedFile.ContentLength > 0)
        {
            QRY += "InstG_Image2 = @img2";
        }
        else if (fld3.PostedFile.ContentLength > 0)
        {
            QRY += "InstG_Image3 = @img3";
        }
        QRY += " WHERE InstG_Id="+((Label)grd_instgallery.Rows[e.RowIndex].Cells[0].FindControl("Label1")).Text;

        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
       

        if (fld1.PostedFile.ContentLength > 0)
        {
            CMD.Parameters.AddWithValue("@img1", imgByte1);
        }
        if (fld2.PostedFile.ContentLength > 0)
        {
            CMD.Parameters.AddWithValue("@img2", imgByte2);
        }
        if (fld3.PostedFile.ContentLength > 0)
        {
            CMD.Parameters.AddWithValue("@img3", imgByte3);
        }

        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();

        grd_instgallery.EditIndex = -1;
        BindmyInstituteImages();
    }
    protected void grd_instgallery_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grd_instgallery.EditIndex = e.NewEditIndex;
        BindmyInstituteImages();
    }
    protected void grd_instgallery_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grd_instgallery.EditIndex = -1;
        BindmyInstituteImages();
    }
}