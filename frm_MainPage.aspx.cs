using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_MainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgadmin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frm_MainAdminLogin.aspx");
    }
    protected void imgstaff_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frm_StaffLogin.aspx");
    }
    protected void imginstadmin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frm_InstituteLogin.aspx");
    }
    protected void imgstudent_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frm_StudentLogin.aspx");
    }
}