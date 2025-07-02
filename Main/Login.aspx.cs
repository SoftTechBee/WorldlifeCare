using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITConnection;
using TripleITTransaction;

public partial class Login : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsAMD objamd = new clsAMD();
    clsList objlist = new clsList();
    clsclosing objclosing = new clsclosing();
    clsTimeZone objtime = new clsTimeZone();
    clsSMS objsms = new clsSMS();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            lbmsg.Visible = false;
            
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt = objlist.LoginCheck(txtUserName.Text.Trim(), txtPassword.Text.Trim(), "A");
            if (dt.Rows.Count > 0)
            {
                SessionData.Put("Admin", dt.Rows[0]["username"].ToString());
                SessionData.Put("newuser", dt.Rows[0]["username"].ToString());
                SessionData.Put("name", dt.Rows[0]["name"].ToString());
                SessionData.Put("UserType", "Admin");

                Response.Redirect("~/Admin/Home.aspx", false);

            }
            else
            {
                lbmsg.Visible = true;
                lbmsg.Text = "Invalid Username or Password";
                txtPassword.Text = "";
                txtUserName.Text = "";
                //Response.Write("<script>alert('Invalid Username or Password')</script>");
            }

        }
        catch (Exception ex)
        {
            lbmsg.Visible = true;
            lbmsg.Text = "Invalid Username or Password";
            txtPassword.Text = "";
            txtUserName.Text = "";
        }
    }
}