using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using TripleITTransaction;
using TripleITConnection;
using System.Data;
using System.Configuration;
public partial class Admin_ChangeMemberTransPassword : System.Web.UI.Page
{
    clsAMD objAMD = new clsAMD();
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hndusername.Value = Request.QueryString["username"].ToString();
        
        }
    }

    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtnewpass.Text == txtconpass.Text)
            {

                string sql = "update register set transpassword='" + txtnewpass.Text + "' where username='" + hndusername.Value + "' ";

                int a = objcon.ExecuteSqlQuery(sql);
                if (a == -1)
                {

                    sccess.Visible = false;
                    danger.Visible = true;
                }
                else if (a == 1)
                {
                    danger.Visible = false;
                    sccess.Visible = true;

                }
            }
            else
            {
                danger.Visible = false;
                info.Visible = false;
                warning.Visible = false;
                sccess.Visible = false;
                danger.Visible = true;
                lbdanger.Text = "Transaction Password is not match";
                txtnewpass.Text = "";
                txtconpass.Text = "";
                txtnewpass.Focus();
            }
        }
        catch (Exception ex)
        {

            Response.Redirect("../error.aspx?error=" + ex.Message);

        }

    }
}