using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;

public partial class User_Support1 : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.Get<string>("Newuser") == null)
        {
            Response.Redirect("logout.aspx");
        }
        else
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            
                string sql = "insert into TblSupport(username,subject,message,DOI)values('" + SessionData.Get<string>("Newuser") + "','"+txtSubject.Text.Trim()+"','"+txtmsg.Text.Trim()+"','"+ objtime.returnStringServerMachTime() + "')";
                int a= objcon.ExecuteSqlQuery(sql);
            if (a > 0)
            {

                lbsuccess.Text = "Your request sent successfull";
                sccess.Visible = true;
                danger.Visible = false;
            }
            else
            {
                lbdanger.Text = "Try Again";
                sccess.Visible = false;
                danger.Visible = true;
            }


        }
        catch (Exception ex)
        { }
    }
}