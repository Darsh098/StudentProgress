using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string QRY;
    string CNS = System.Configuration.ConfigurationManager.ConnectionStrings["cnStr"].ToString();
    SqlCommand CMD;
    SqlConnection CNN;
    int DesId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["DesId"] != null)
        {
            DesId = int.Parse(Session["DesId"].ToString());
            if (DesId == 1)
                mnuStud.Visible = true;
            else if (DesId == 2)
                mnuStaff.Visible = true;
            else if (DesId == 3)
            {
                mnuInstitute.Visible = true;
                if (Session["IsAdmin"] != null)
                {
                    adminhome.Visible = true;
                    insthome.Visible = false;
                    Session["DesId"] = 4;
                }
            }
            else if (DesId == 4)
                mnuMainAdmin.Visible = true;
        }
    }
}
