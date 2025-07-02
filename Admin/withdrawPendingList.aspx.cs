using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class Admin_withdrawPendingList : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsmail objmail = new clsmail();
    clsDashboard objDash = new clsDashboard();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { loadlist(); }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadlist();
    }
    public void loadlist()
    {
        try {
            string sql = "select r.tds,r.PackType,r.IncomeType,LEFT(r.PackType, 4) AS CoinType,r.Rid, r.username,r.Amount,r.DOR,r.DOA,r.remark,r.status,b.*,r.Payout,r.AdminCharge,r.Wallet,r.TDS,r.WalletFund from TblRWithdraw  r Left Join bankdetail b on r.Username=b.Username where r.status='Pending'";
            if (txtsearch.Text.Trim() != "")
            {
                sql += "and r.username='" + txtsearch.Text.Trim() + "'";
            }

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                
                
            }

            else
            {
                //lbdanger.Text = "Opps! NO Data Found";
                //danger.Visible = true;
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
        if (e.CommandName == "delete")
        {
            Label username = e.Item.FindControl("lbuname") as Label;
            Label lbIncomeType = e.Item.FindControl("lbIncomeType") as Label;

            string id = e.CommandArgument.ToString();
            Label lbType = e.Item.FindControl("lbType") as Label;
            int a = objamd.WithdrawRequest(Convert.ToInt32(id), username.Text, 0, lbIncomeType.Text, "", "", "M");
            if(a > 0)
            {

                warning.Visible = false;
                danger.Visible = true;
                sccess.Visible = false;
                info.Visible = false;
                sccess.Visible = false;
                lbdanger.Text = "Request Reject Successfully";
                loadlist();

            }
           
        }
            if (e.CommandName == "Click")
        {
            Label username = e.Item.FindControl("lbuname") as Label;
            Label lbamt = e.Item.FindControl("lbamt") as Label;
            Label lbpayout = e.Item.FindControl("Label1") as Label;
            Label lbadminchrg = e.Item.FindControl("Label2") as Label;
            Label lbIncomeType = e.Item.FindControl("lbIncomeType") as Label;
            Label lbwallet = e.Item.FindControl("lbwallet") as Label;
            Label lbPayout = e.Item.FindControl("lbPayout") as Label;
            Label lbType = e.Item.FindControl("lbType") as Label;
            decimal amt = Convert.ToDecimal(lbamt.Text);
            string id = e.CommandArgument.ToString();
            //check pancard

            int a = objamd.WithdrawRequest(Convert.ToInt32(id), username.Text, amt, lbIncomeType.Text, "", "","A");
           
           
                if (a> 0)
                {
                           
                            warning.Visible = false;
                                danger.Visible = false;
                                sccess.Visible = false;
                                info.Visible = false;
                                sccess.Visible = true;
                                lbsuccess.Text = "Request Approved Successfully";
                               

                            //string email = objDash.ReturnEmail(username.Text);
                            //string msge = "Your Crypto Withdrawal has been completed successfully<br /> UserName :-" + username.Text + "<br />CryptoCurrency:-  " + lbIncomeType.Text + "<br />Withdrawal Address :- "+ lbwallet .Text+ "<br />Amount (USDT) : "+ lbPayout.Text+ "";
                            //objmail.Notification(username.Text, msge, email);
                loadlist();
            }

                else if (a == -1)
                {
                    loadlist();
                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    info.Visible = true;
                    lbinfo.Text = "Request Already Approved Successfully ";
                }
                else if (a == -1)
                {
                    loadlist();
                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    info.Visible = true;
                    lbinfo.Text = "Try Again .. Something went to wrong! ";
                }

            
        }



        }
 
   

    

    }

   
