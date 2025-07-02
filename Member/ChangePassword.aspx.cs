using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;

public partial class User_ChangePassword : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            { 
            
            }
        }
        catch (Exception ex)
        { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtnew.Text == txtconfirm.Text)
            {
                string sql = "update register set password='" + txtnew.Text + "' where username='" + SessionData.Get<string>("newuser") + "'";
                objcon.ExecuteSqlQuery(sql);
                lbsuccess.Text = "Password Change Successfully";
                sccess.Visible = true;
            }
            else
            {
                lbinfo.Text = "New Password And Confirm Password Not Match";
                info.Visible = true;
            }
        }
        catch (Exception ex)
        { }
    }
}