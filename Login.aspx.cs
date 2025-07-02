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
            objclosing.MasterClosing();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt = objlist.LoginCheck(txtUserName.Text.Trim(), txtPassword.Text.Trim(), "U");
            if (dt.Rows.Count > 0)
            {
                string status = dt.Rows[0]["LoginStatus"].ToString();
                if (status == "False")
                {
                    SessionData.Put("newuser", dt.Rows[0]["username"].ToString());
                    SessionData.Put("name", dt.Rows[0]["name"].ToString());
                    SessionData.Put("profilepic", dt.Rows[0]["profilepic"].ToString());
                    SessionData.Put("status", dt.Rows[0]["status"].ToString());
                    SessionData.Put("UserType", "User");

                    Response.Redirect("~/Member/Home.aspx", false);
                }
                else
                {
                    lbmsg.Visible = true;
                    lbmsg.Text = "your income limit exceeded,please contact to admin";
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    Response.Write("<script>alert('your income limit exceeded, please contact to admin')</script>");
                }
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