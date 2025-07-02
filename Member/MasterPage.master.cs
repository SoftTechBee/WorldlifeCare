using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.Get<string>("UserType") != "User")
        {
            Response.Redirect("logout.aspx");
            return;
        }
        if (SessionData.Get<string>("Newuser") == null)
        {
            Response.Redirect("logout.aspx");
        }
    }
}
