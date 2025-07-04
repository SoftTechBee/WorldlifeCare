using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class Admin_WalletRechargeRequest : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    clsConnection objcon = new clsConnection();
    public List<clsuser> objuserlist = new List<clsuser>();
    clsDashboard objdash = new clsDashboard();
    clsmail objmail = new clsmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        loaddirect();
        }
    }
    public void loaddirect()
    {
        try
        {
            //DOI between '" + txtfromdate.Text + "' and '" + txttodate.Text + "' and
            string sql = "select * from [TblRepurchaseRequest] where status='Pending'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
               // danger.Visible = false;
              

            }
            else
            {
                lbdanger.Text = "Opps! NO Data Found";
                danger.Visible = true;
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }
        catch (Exception ex)
        {

        }

    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Approved")
        {
            Label lbAmount = e.Item.FindControl("lbamount") as Label;
            Label lbutr = e.Item.FindControl("lbutr") as Label;
            Label lbtcx = e.Item.FindControl("lbtcx") as Label;
            Label lbUserName = e.Item.FindControl("lbname") as Label;
            Label lbpaymentmode = e.Item.FindControl("lbpaymentmode") as Label;
            string wid = e.CommandArgument.ToString();
            int a = objamd.RepuchaseRequest(Convert.ToInt32(wid),lbUserName.Text, lbAmount.Text, "", "Pending", objtime.returnCurrentSurverTimeHHMM(), "", "", "", "", lbutr.Text, "Recharge", "A");
            if (a > 0)
            {
                loaddirect();
                danger.Visible = false;
                lbinfo.Text = "Request Approved successfully";
                info.Visible = true;
                string email = objdash.ReturnEmail(lbUserName.Text);
                string msg = "Your Fund Request is completed successfully.<br /> UserName :-" + lbUserName.Text + "<br />Wallet Address:-  " + lbpaymentmode.Text + "<br />UTR (Txn ID):-  " + lbutr.Text + "<br />Amount ($) : " + lbAmount.Text + "<br />";

                objmail.DepositeFund(lbUserName.Text, msg, email);
                
            }
            else if (a == -1)
            {
                loaddirect();
                info.Visible = false;
                lbdanger.Text = "Request already Approved ";
                danger.Visible = true;
                
            }
            else
            {
                loaddirect();
                info.Visible = false;
                lbdanger.Text = "Request has not Approved successfully";
                danger.Visible = true;
            }
        }
        if (e.CommandName == "Reject")
        {
            Label lbpaymentmode = e.Item.FindControl("lbpaymentmode") as Label;

            Label lbAmount = e.Item.FindControl("lbamount") as Label;
            Label lbtcx = e.Item.FindControl("lbtcx") as Label;
            Label lbUserName = e.Item.FindControl("lbname") as Label;
            Label lbutr = e.Item.FindControl("lbutr") as Label;
            string wid = e.CommandArgument.ToString();
            int a = objamd.RepuchaseRequest(Convert.ToInt32(wid), lbUserName.Text, lbAmount.Text, "", "Pending", objtime.returnCurrentSurverTimeHHMM(), "","", "", "", "", "Repurchase", "R");
            if (a > 0)
            {
                loaddirect();
                string email = objdash.ReturnEmail(lbUserName.Text);
                string msg = "Your Fund Request is Reject : Something Went to wrong... try again.<br /> UserName :-" + lbUserName.Text + "<br />Wallet Address:-  " + lbpaymentmode.Text + "<br />UTR (Txn ID):-  " + lbutr.Text + "<br />Amount ($) : " + lbAmount.Text + "<br />";

                objmail.DepositeFund(lbUserName.Text, msg, email);
               
             
                danger.Visible = false;
                lbinfo.Text = "Request Reject successfully";
                info.Visible = true;


            }
            else if (a == -1)
            {
                loaddirect();
                info.Visible = false;
                lbdanger.Text = "Request already Reject ";
                danger.Visible = true;
            }
            else
            {
                loaddirect();
                info.Visible = false;
                lbdanger.Text = "Request has not Reject successfully";
                danger.Visible = true;
            }
        }
    }
}