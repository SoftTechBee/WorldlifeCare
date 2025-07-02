using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TripleITConnection;
using TripleITTransaction;
public partial class Member_AdminAccess1 : System.Web.UI.Page
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
            string username = Request.QueryString["username"].ToString();
            login( username);
        }

    }

    public void login(string username)
    {
        try
        {

            DataTable dt = objcon.ReturnDataTableSql("select name ,username,profilepic,LoginStatus from register where username='" + username + "'");
            if (dt.Rows.Count > 0)
            {
                string status = dt.Rows[0]["LoginStatus"].ToString();
                SessionData.Put("UserType", "User");
                SessionData.Put("newuser", dt.Rows[0]["username"].ToString());
                SessionData.Put("name", dt.Rows[0]["name"].ToString());
                //if (status == "False")
                //{
               // Session["name"] = dt.Rows[0]["name"].ToString();
                string url = dt.Rows[0]["profilepic"].ToString();
                // Session["profilepic"] = url == "" ? "../dist/img/user3-128x128.jpg" : url;
               // Session["newuser"] = dt.Rows[0]["username"].ToString();

                Response.Redirect("Home.aspx", false);
               
            }
            else
            {

                          }

        }
        catch (Exception ex)
        {
          
        }


    }
}