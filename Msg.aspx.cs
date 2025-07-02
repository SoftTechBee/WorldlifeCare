using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITConnection;
using TripleITTransaction;

public partial class forgotpassword : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsAMD objamd = new clsAMD();
    clsList objlist = new clsList();
    clsclosing objclosing = new clsclosing();
    clsTimeZone objtime = new clsTimeZone();
    clsSMS objsms = new clsSMS();
    clsmail objmail = new clsmail();
    clsDashboard objdashboard = new clsDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                string username = Request.QueryString["username"].ToString();
                string Pass = Request.QueryString["Pass"].ToString();
                string Tpass = Request.QueryString["Tp"].ToString();
                DataTable dt = objcon.ReturnDataTableSql("select name,Password,username,TransPassword from register where username='" + username + "' and transpassword='"+ Tpass + "' ");
                if (dt.Rows.Count > 0)
                {
                    lbname.Text = dt.Rows[0]["name"].ToString();
                    lbpassword.Text = Pass;
                    lbusername.Text = username;
                   lbtranspassword.Text = Tpass;

                }
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}