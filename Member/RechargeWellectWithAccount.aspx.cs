using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;

public partial class User_wallectRecharge111 : System.Web.UI.Page
{
    clsfunction objfun = new clsfunction();
    clsAMD objamd = new clsAMD();
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsDashboard objDash = new clsDashboard();
    clsfunction objFun = new clsfunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.Get<string>("Newuser") == null && SessionData.Get<string>("Newuser") == "")
        {
            Response.Redirect("Logout.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                 lbIncome.Text = objDash.TotalBlance(SessionData.Get<string>("Newuser"));
                string today = objtime.returnCurrentSurverTimeHHMM();
               
               
            }
        }
    }
    public void BlockStatus()
    {
        try
        {
            string sql = "select loginstatus from register where username='" + SessionData.Get<string>("Newuser") + "' and loginstatus='0'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                danger.Visible = false;
                txtAmt.ReadOnly = false;

            }
            else
            {
                txtAmt.ReadOnly = true;

                lbdanger.Text = "You have no right to Transfer, contact to admin";
                danger.Visible = true;


            }


        }
        catch (Exception ex)
        { }
    }
    public void loadclean()
    {
        txtAmt.Text = "";
        //txtTDS.Text = "";
       // lbIncome.Text = "";
        txtTotal.Text = "";
        //txtfinal.Text = "";
       // txttds.Text = "";
       // txtadmincharge.Text = "";

    }

    public void checkrequest()
    {
        int status = 0;
        try
        {
            //string sql = "select username from TblRWithdraw where  [status]= 'Pending' and username ='" + SessionData.Get<string>("newuser") + "'";
            string sql = "SELECT (SUM(CONVERT(FLOAT,ISNULL(CREDIT,0)))-SUM(CONVERT(FLOAT,ISNULL(debit,0)))) FROM account WHERE  username='" + SessionData.Get<string>("Newuser") + "' AND [DATE] between '2019-5-1' and  '"+objtime.returnStringServerMachTime()+"' and valu in ('SM','capping','Direct','Working')";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                lbIncome.Text = dt.Rows[0][0].ToString();
                
               
            }
            else
            {
                lbIncome.Text = "0";

            }


        }
        catch (Exception ex)
        { }
       

    }

    protected void butsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //int Flag = objFun.GetTransPaswwordCheck(SessionData.Get<string>("newuser"), txttransPassword.Text);
            //if (Flag == 1)
            //{

                decimal widamount = 0;
                string date = objtime.returnStringServerMachTime();


                string id = SessionData.Get<string>("newuser");
                decimal finalamount = Convert.ToDecimal(objDash.TotalBlance(SessionData.Get<string>("newuser")));
                //  int wamount = (finalamount / 2);
                widamount = Convert.ToDecimal(txtAmt.Text.Trim());

                if (finalamount >= widamount && widamount > 0)
                {

                    int a = objamd.WalletRecharge(0, SessionData.Get<string>("Newuser"), widamount,"Fund",txttransPassword.Text, "R");
                    if (a > 0)
                    {
                        lbIncome.Text = objDash.TotalBlance(SessionData.Get<string>("Newuser"));

                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        sccess.Visible = true;
                        lbsuccess.Text = "Income transfer in fund wallet successfull";
                        loadclean();

                    }
                    else if (a == -1)
                    {
                        loadclean();
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        info.Visible = true;
                        lbinfo.Text = "You have already recharge wallet or may be your id has been blocked ,contact to admin";

                    }



                }
                else
                {

                    loadclean();
                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    warning.Visible = true;
                    lbwarning.Text = "Balance is less then  recharge wallet amount .";

                }

            //}
            //else if (Flag == 0)
            //{
            //    lbdanger.Text = "Invaild Password ...... Try again";
            //    txttransPassword.Text = "";
            //    txttransPassword.Focus();

            //    danger.Visible = true;

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
            txtAmt.Text = "";
            txtAmt.Focus();
            //  Response.Redirect("error.aspx?error=" + ex);



        }
            
    }


    protected void txtAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal finalamount = Convert.ToDecimal(objDash.TotalBlance(SessionData.Get<string>("newuser")));

            decimal reqAmt = Convert.ToDecimal(txtAmt.Text);
          
                if (reqAmt > 0)
            {
                decimal AdminCharge = (reqAmt * 10 / 100);
                //decimal tds = (reqAmt * 5 / 100);
                decimal amount = reqAmt- AdminCharge;
                txtTotal.Text = amount.ToString();
               // txtTDS.Text = tds.ToString();
             txtadmincharge.Text = AdminCharge.ToString();

                warning.Visible = false;
                danger.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
                sccess.Visible = false;
            }
            else
            {
                warning.Visible = false;
                danger.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
                lbwarning.Text = "Enter valid amount";
                warning.Visible = true;
                txtAmt.Text = "";
                txtAmt.Focus();
            }

           
        }
        catch (Exception ex)
        { }
    }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //int Flag = objFun.GetTransPaswwordCheck(SessionData.Get<string>("newuser"), txttransPassword.Text);
            //if (Flag == 1)
            //{
            //    danger.Visible = false;

            //}
            //else if (Flag == 0)
            //{
            //    lbdanger.Text = "Invaild Password ...... Try again";
            //    txttransPassword.Text = "";
            //    txttransPassword.Focus();

            //    danger.Visible = true;

            
        }
    
}