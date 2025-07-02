using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITConnection;
using TripleITTransaction;

public partial class Member_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsDashboard objdashboard = new clsDashboard();
    clsList objlist = new clsList();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    CoinPayments objcoin = new CoinPayments();
    clsDashboard objDash = new clsDashboard();
    clsmail objmail = new clsmail();

    protected void Page_Load(object sender, EventArgs e)
    {
      
            try
            {
                if (!IsPostBack)
                {
                    string reqUser = Request.QueryString["Id"].ToString();
                    lbActiveMember.Text = reqUser == "0" ? SessionData.Get<string>("newuser") : reqUser;
                txtbalance.Text = objDash.TotalWallectBlance(SessionData.Get<string>("newuser"));
                txtcurrentpack.Text = objdashboard.ReturnLastPackName(lbActiveMember.Text);
                txtcurrentamt.Text = objdashboard.ReturnLastPackAmt(lbActiveMember.Text);
                loadPack();
                SessionData.Put("ActiveUser", lbActiveMember.Text);



            }
        }
            catch (Exception ex)
            { }
      
    }


    private void loadPack()
    {
        try
        {
            string sql = "select product,descrption,PackID,CAST(mrp as int) as max,CAST(BV as int) as min,imgUrl from tblproduct where packid in (1)";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                lbdanger.Text = "Opps! NO Data Found";
                danger.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }



    protected void repPack_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
            int packid = Convert.ToInt32(e.CommandArgument.ToString());
            Label lbinvest = e.Item.FindControl("lbinvest") as Label;
            Label lbpv = e.Item.FindControl("lbpv") as Label;
            Label lbpack = e.Item.FindControl("lbpack") as Label;
            Label lbprofit = e.Item.FindControl("lbmonths") as Label;
            Label lbDuration = e.Item.FindControl("lbamountmin") as Label;
            //int ActiveDirect = Convert.ToInt32(objDash.TotalDirect(lbActiveMember.Text));
            //int CurrentPackid = Convert.ToInt32(objDash.ReturnPackID(lbActiveMember.Text));
            string PaidStatus = objdashboard.PaidStatus(lbActiveMember.Text);

            try
            {
                //if (ActiveDirect >= 2)
                //{


                //if ((CurrentPackid + 1) == packid)
                //{
                if (PaidStatus=="False")
                {


                    //btnaction.Visible = false;
                    decimal widamount = 0, Min = 0, Max = 0;
                    string date = objtime.returnStringServerMachTime();
                    string PackType = lbpack.Text;

                    string Username = SessionData.Get<string>("newuser");
                    decimal finalamount = Convert.ToDecimal(txtbalance.Text.Trim());

                string email = objDash.ReturnEmail(lbActiveMember.Text.Trim());
                    widamount = Convert.ToDecimal(lbinvest.Text);
                    int min = Convert.ToInt32(lbpv.Text);

                    if (finalamount >= widamount)
                    {


                    int a = objamd.ActiveMember(lbActiveMember.Text.Trim(), widamount, min, PackType, Username, "N");
                    if (a > 0)
                    {

                        //objmail.PackageActivate(lbActiveMember.Text.Trim(), widamount.ToString(), lbpack.Text, lbprofit.Text, lbDuration.Text, email);
                        txtbalance.Text = objDash.TotalWallectBlance(SessionData.Get<string>("newuser"));
                        txtcurrentpack.Text = objdashboard.ReturnLastPackName(lbActiveMember.Text);
                        txtcurrentamt.Text = objdashboard.ReturnLastPackAmt(lbActiveMember.Text);
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        sccess.Visible = true;
                        lbsuccess.Text = "Congratulations! Your packages " + lbpack.Text + "  has been buy successfully.";

                        string name = objDash.RetrunName(lbActiveMember.Text.Trim());

                        string title = "Congratulations : " + name +" !!!"; // Set your dynamic title here
                        string text = lbpack.Text + " (Amount : " + widamount + " ₹) Purchased successfully !!!"; // Set your dynamic text here

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('"+ title + "','"+ text + "'); ", true);

                    }
                    else if (a == -1)
                        {

                            warning.Visible = false;
                            danger.Visible = false;
                            sccess.Visible = false;
                            info.Visible = false;
                            info.Visible = true;

                            lbinfo.Text = "You have already buy this  " + lbpack.Text + " ! try another buy a pack!";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "warningclick(); ", true);
                            //  btnaction.Visible = true;
                        }
                        else
                        {
                            warning.Visible = false;
                            danger.Visible = false;
                            sccess.Visible = false;
                            info.Visible = false;
                            warning.Visible = true;
                            lbwarning.Text = "Account active Not successfully";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "dangerlick(); ", true);
                            // btnaction.Visible = true;
                        }

                    }
                    else
                    {


                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        warning.Visible = true;
                        lbwarning.Text = "Balance is less then to require amount  ";
                        lbfund.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "fundlick(); ", true);
                        // btnaction.Visible = true;
                    }
                }
                else
                {
                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    info.Visible = true;

                    lbinfo.Text = "Your Account Is Active ...! Please Upgrade Your Packages";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Active(); ", true);
                    //  btnaction.Visible = true;
                }
                //}
                //else
                //{
                //    warning.Visible = false;
                //    danger.Visible = false;
                //    sccess.Visible = false;
                //    info.Visible = false;
                //    lbwarning.Text = "you can't buy this packages! Required 2 Direct For Buy a Packages?";
                //    warning.Visible = true;
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Direct(); ", true);
                //    // btnaction.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                warning.Visible = false;
                danger.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
                lbwarning.Text = "Enter valid amount";
                warning.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "dangerlick(); ", true);
                // btnaction.Visible = true;
            }
            

        }
    }



    protected void btnaction_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    btnaction.Visible = false;
        //    decimal widamount = 0, Min = 0, Max = 0;
        //    string date = objtime.returnStringServerMachTime();
        //    string PackType = lbpack.Text;

        //    string Username = SessionData.Get<string>("newuser");
        //    decimal finalamount = Convert.ToDecimal(txtbalance.Text.Trim());

        //    widamount = Convert.ToDecimal(txtAmt.Text);
            
        //    if (finalamount >= widamount && widamount >= 100)
        //    {


        //        int a = objamd.ActiveMember(lbActiveMember.Text.Trim(), widamount, widamount, PackType, Username, "N");
        //        if (a > 0)
        //        {


        //            txtbalance.Text = objDash.TotalWallectBlance(SessionData.Get<string>("newuser"));
        //            txtcurrentpack.Text = objdashboard.ReturnLastPackName(lbActiveMember.Text);
        //            txtcurrentamt.Text = objdashboard.ReturnLastPackAmt(lbActiveMember.Text);
        //            warning.Visible = false;
        //            danger.Visible = false;
        //            sccess.Visible = false;
        //            info.Visible = false;
        //            sccess.Visible = true;
        //            lbsuccess.Text = "Congratulations! Your Amount " + txtAmt.Text + "  has been Invest successfully.";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick(); ", true);
        //        }
        //        else if (a == -1)
        //        {

        //            warning.Visible = false;
        //            danger.Visible = false;
        //            sccess.Visible = false;
        //            info.Visible = false;
        //            info.Visible = true;

        //            lbinfo.Text = "You have already Invest Amount " + txtAmt.Text + " ! try another buy a pack!";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "warningclick(); ", true);
        //            btnaction.Visible = true;
        //        }
        //        else
        //        {
        //            warning.Visible = false;
        //            danger.Visible = false;
        //            sccess.Visible = false;
        //            info.Visible = false;
        //            warning.Visible = true;
        //            lbwarning.Text = "Account active Not successfully";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "dangerlick(); ", true);
        //            btnaction.Visible = true;
        //        }

        //    }
        //    else
        //    {


        //        warning.Visible = false;
        //        danger.Visible = false;
        //        sccess.Visible = false;
        //        info.Visible = false;
        //        warning.Visible = true;
        //        lbwarning.Text = "Balance is less then to require amount or Please Enter Min Amt $100 and Max Amt $10000 ";
        //        lbfund.Visible = true;
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "fundlick(); ", true);
        //        btnaction.Visible = true;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    warning.Visible = false;
        //    danger.Visible = false;
        //    sccess.Visible = false;
        //    info.Visible = false;
        //    lbwarning.Text = "Enter valid amount";
        //    warning.Visible = true;
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "dangerlick(); ", true);
        //    btnaction.Visible = true;
        //}
    }
}