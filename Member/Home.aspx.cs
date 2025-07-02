using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using TripleITConnection;
using TripleITTransaction;
public partial class Member_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsDashboard objdashboard = new clsDashboard();
    clsList objlist = new clsList();
    //clsListNew objlistnew = new clsListNew();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    CoinPayments objcoin = new CoinPayments();
    clsmail objmail = new clsmail();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (SessionData.Get<string>("Newuser") != null)
        {
            try
            {




                loadlist();
                loadDownLineBusniess();
                loadBuiness();
                loadlist();
                loadTeam();
                string username = SessionData.Get<string>("Newuser");
               
                myInput.Value = "https://worldlifecareenterprises.com/register.aspx?Sponsor=" + username + "&Side=Left";
                myInputRight.Value = "https://worldlifecareenterprises.com/register.aspx?Sponsor=" + username + "&Side=Right";
                lbreffsidLeft.Text = "https://worldlifecareenterprises.com/register.aspx?Sponsor=" + username + "&Side=Left";
                lbreffsidRight.Text = "https://worldlifecareenterprises.com/register.aspx?Sponsor=" + username + "&Side=Right";
               
                
               // lbTotalIncome.Text = objdashboard.TotalIncome(username);
                lbbalance.Text = objdashboard.TotalBlance(username);
                //lbdirect.Text = objdashboard.TotalDirect(username);
                int Team = Convert.ToInt32(objdashboard.TotalTeam(username));
               // lbteam.Text = Team.ToString();
               // lbTodayincome.Text = objdashboard.TodayIncome(username);
                lbwithdrawapprove.Text = objdashboard.TotalWithdrawApprove(username);
                lbwithdrawpending.Text = objdashboard.TotalWithdrawPending(username);
                lbwalletbal.Text = objdashboard.TotalWallectBlance(username);

                


                lbdirectIncome.Text = objdashboard.IncomeType(username, "Direct");
                lbmatchingIncome.Text = objdashboard.IncomeType(username, "Matching");
               // lbretailIncome.Text = objdashboard.IncomeType(username, "Retail");
                lbRewardIncome.Text = objdashboard.IncomeType(username, "Reward");
                lbroyaltyIncome.Text = objdashboard.IncomeType(username, "Royalty");
              //  lblvlIncome.Text = objdashboard.IncomeType(username, "Level");

            }
            catch (Exception ex)
            { }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }

    }

    private void loadDownLineBusniess()
    {
        try
        {
            string sql = "select Pv,capping,doa,reward,rankname,mobile,status,username,email,dateofjoin,name,rankname,joinAmount,country,PackType from register  where username='" + SessionData.Get<string>("Newuser") + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);

            if (dt.Rows.Count > 0)
            {

                lbDOJ.Text = Convert.ToDateTime(dt.Rows[0]["dateofjoin"].ToString()).ToShortDateString();
              //  lbDOA.Text = Convert.ToDateTime(dt.Rows[0]["doa"].ToString()).ToShortDateString();
               // lbname.Text = dt.Rows[0]["name"].ToString();
               
                lbmobile.Text = dt.Rows[0]["mobile"].ToString();
               // lbusername.Text = dt.Rows[0]["username"].ToString();
                lbemail.Text = dt.Rows[0]["email"].ToString();

                lbReward.Text = dt.Rows[0]["reward"].ToString();
                lvSB.Text = dt.Rows[0]["Pv"].ToString();
                   lbpack.Text = dt.Rows[0]["capping"].ToString();
                   //lbpack.Text = dt.Rows[0]["PackType"].ToString();
                lbtotalrepurchase.Text = dt.Rows[0]["joinAmount"].ToString();

                lbstatus.Text = dt.Rows[0]["status"].ToString();




            }

        }
        catch (Exception ex)
        { }
    }
    private void loadTeam()
    {
        try
        {


            string sql = "EXEC [dbo].[BinaryTeam]@UserName ='" + SessionData.Get<string>("Newuser") + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                lbTotalLeftDirect.Text = dt.Rows[0]["LeftDirect"].ToString();
                lbTotalRightDirect.Text = dt.Rows[0]["RightDirect"].ToString();

                lbActiveDirectLeft.Text = dt.Rows[0]["LeftActiveDirect"].ToString();
                lbActiveDirectRight.Text = dt.Rows[0]["RightActiveDirect"].ToString();

                lbinActiveDirectLeft.Text = dt.Rows[0]["LeftInActiveDirect"].ToString();
                lbinActiveDirectRight.Text = dt.Rows[0]["RightInActiveDirect"].ToString();

                lbLeftTeam.Text = dt.Rows[0]["LeftTeam"].ToString();
                lbRightTeam.Text = dt.Rows[0]["RightTeam"].ToString();

                lbActiveleftteam.Text = dt.Rows[0]["LeftActiveTeam"].ToString();
                lbActiveRightteam.Text = dt.Rows[0]["RightActiveTeam"].ToString();

                lbInActiveLeftteam.Text = dt.Rows[0]["LeftInactiveTeam"].ToString();
                lbInActiveRightteam.Text = dt.Rows[0]["RightInactiveTeam"].ToString();


            }

        }
        catch (Exception ex)
        { }
    }
    private void loadBuiness()
    {
        try
        {


            string sql = "EXEC [dbo].[BinaryBusiness]@UserName ='" + SessionData.Get<string>("Newuser") + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                lbtotalbusiness.Text = dt.Rows[0]["BusinessTotal"].ToString();
                leftbusiness.Text = dt.Rows[0]["BusinessLeft"].ToString();
                rightbusiness.Text = dt.Rows[0]["BusinessRight"].ToString();
                AvailableleftBV.Text = dt.Rows[0]["BVLeftBalance"].ToString();
                leftBV.Text = dt.Rows[0]["BVLeftTotal"].ToString();
                AvailablerightBV.Text = dt.Rows[0]["BVRightBalance"].ToString();
                rightBV.Text = dt.Rows[0]["BVRightTotal"].ToString();
                Availableleftpv.Text = dt.Rows[0]["PVLeftBalance"].ToString();
                leftpv.Text = dt.Rows[0]["PVLeftTotal"].ToString();
                rightpv.Text = dt.Rows[0]["PVRightTotal"].ToString();
                Availablerightpv.Text = dt.Rows[0]["PVRightBalance"].ToString();

            }

        }
        catch (Exception ex)
        { }
    }


    private void loadlist()
    {
        try
        {


            string sql = "select news,tittle from tblnews order by id desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            lbnews.Text = dt.Rows[0]["news"].ToString();
            lbhead.Text = dt.Rows[0]["tittle"].ToString();


        }
        catch (Exception ex)
        { }
    }
}