using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LogOut();
    }
    void LogOut()
    {
        Session.RemoveAll();
        Response.Redirect("frm_MainPage.aspx");
    }
}