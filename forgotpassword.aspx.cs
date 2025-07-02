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
            lbmsg.Visible = false;
            //objclosing.closing();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        DataTable dt = objcon.ReturnDataTableSql("select name,username,TransPassword,Password from register where email='" + txtmail.Text + "' and username='" + txtUserName.Text + "'");
        if (dt.Rows.Count > 0)
        {
            string UserName = dt.Rows[0]["username"].ToString();
            string Name = dt.Rows[0]["name"].ToString();
            string Password = dt.Rows[0]["Password"].ToString();
            string TransPassword = dt.Rows[0]["TransPassword"].ToString();
            objmail.ForgotPassword(Name, UserName, Password, TransPassword, txtmail.Text);
            lbmsg.Text = "Password has been send successfully on your '" + txtmail.Text + "' EMAIL.";
            lbmsg.Visible = true;
            txtmail.Text = "";
            txtUserName.Text = "";

        }
        else
        {

            lbmsg.Text = "Invalid Username or Email Add,Please enter register Email Add.";
            txtmail.Text = "";
            txtUserName.Text = "";
            //Response.Write("<script>alert('Invalid Username or Password')</script>");
        }




    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtmail.Text = objdashboard.ReturnEmail(txtUserName.Text);
            if (txtmail.Text != "")
            {
                lbmsg.Visible = false;

            }
            else
            {
                lbmsg.Text = "Invalid Username.";
                lbmsg.Visible = true;
            }


        }
        catch (Exception ex)
        {

        }

    }
}