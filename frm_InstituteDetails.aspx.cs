using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frm_InstituteDetails : System.Web.UI.Page
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlConnection CNN;
    SqlCommand CMD;
    int InstId;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        InstId = int.Parse(Session["InstId"].ToString());    
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        byte[] imginstlogo = new byte[fldinst_logo.PostedFile.ContentLength];
        fldinst_logo.PostedFile.InputStream.Read(imginstlogo, 0, imginstlogo.Length);

        QRY = "INSERT INTO Tbl_InstituteDetails VALUES(";
        QRY += "(SELECT MAX(InstD_Id) + 1 FROM Tbl_InstituteDetails), ";
        QRY += ""+InstId+", ";
        QRY += "'"+txtinstdetails.Text+"', ";
        QRY += "@img, ";
        QRY += "'"+txtinstcontno.Text+"', ";
        QRY += "'"+txtinstaltcontno.Text+"', ";
        QRY += "'"+txtinstemail.Text+"', ";
        QRY+="'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.Parameters.AddWithValue("@img", imginstlogo);
        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();
 
        byte[] imginstimage1 = new byte[fldinstimage1.PostedFile.ContentLength];
        fldinstimage1.PostedFile.InputStream.Read(imginstimage1, 0, imginstimage1.Length);

        byte[] imginstimage2 = new byte[fldinstimage2.PostedFile.ContentLength];
        fldinstimage2.PostedFile.InputStream.Read(imginstimage2, 0, imginstimage2.Length);

        byte[] imginstimage3 = new byte[fldinstimage3.PostedFile.ContentLength];
        fldinstimage3.PostedFile.InputStream.Read(imginstimage3, 0, imginstimage3.Length);



        QRY = "INSERT INTO Tbl_InstituteGallery VALUES (";
        QRY += "(SELECT MAX(InstG_Id) + 1 FROM Tbl_InstituteGallery), ";
        QRY += "" + InstId + ", ";
        QRY += "@img1, ";
        QRY += "@img2, ";
        QRY += "@img3, ";
        QRY += "'TRUE')";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.Parameters.AddWithValue("@img1", imginstimage1);
        CMD.Parameters.AddWithValue("@img2", imginstimage2);
        CMD.Parameters.AddWithValue("@img3", imginstimage3);
        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();

        QRY = "INSERT INTO Tbl_LoginDetails VALUES (";
        QRY += "(SELECT MAX(User_Id) + 1 FROM Tbl_LoginDetails), ";
        QRY += "'"+txtinstemail.Text+"', ";
        QRY += "'"+txtinstpassword.Text+"', ";
        QRY += "3, ";
        QRY += ""+InstId+", 'TRUE'";
        QRY+=")";
        CNN = new SqlConnection(CNS);
        CMD = new SqlCommand(QRY, CNN);
        CNN.Open();
        CMD.ExecuteNonQuery();
        CMD.Dispose();
        CNN.Close();
        Response.Redirect("frm_MainPage.aspx");
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txtinstaltcontno.Text = string.Empty;
        txtinstcontno.Text = string.Empty;
        txtinstdetails.Text = string.Empty;
        txtinstemail.Text = string.Empty;
        txtinstpassword.Text = string.Empty;
    }
}