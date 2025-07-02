﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
using Newtonsoft.Json;
using System.Drawing;
public partial class User_withdrrawPlan1 : System.Web.UI.Page
{
    clsfunction objfun = new clsfunction();
    clsAMD objamd = new clsAMD();
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsDashboard objDash = new clsDashboard();
    clsSMS objsms = new clsSMS();
    CoinPayments objcoin = new CoinPayments();
    clsmail objmail = new clsmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.Get<string>("Newuser") == null && SessionData.Get<string>("Newuser") == "")
        {
            Response.Redirect("Logout.aspx");
        }
        else
        {
            danger.Visible = false;
           // paymenttype_TextChanged(sender, e);
            lbIncome.Text = objDash.IncomeBalance(SessionData.Get<string>("Newuser"));

            int day = Convert.ToInt32(objtime.returnStringServerMachTime1());


            //string dayname = objtime.returnCurrentDay();
            if (day == 10 && day == 16)
            {





                int flag = checkrequest();
                if (flag == 0)
                {
                    warning.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    lbdanger.Text = "Your withdrawal has been disabled. Please Contact Admin.";
                    danger.Visible = true;
                    txtAmt.ReadOnly = true;
                    btnaction.Visible = false;


                }
                else
                {



                }

            }

            else
            {
                btnaction.Visible = false;
                warning.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
                lbdanger.Text = "You can applied for withdraw only 1st and 16th Date Of Month";

                danger.Visible = true;
                txtAmt.ReadOnly = true;

            }
        }
    }
    

    public void loadclean()
    {
        txtAmt.Text = "";
        // txtremark.Text = "";
        // lbIncome.Text = "";
        txtTotal.Text = "";
        //txtfinal.Text = "";
        // txttds.Text = "";
        // txtadmincharge.Text = "";

    }
    public int checkrequest()
    {
        int status = 0;
        try
        {
            string sql = "select username from register where  [loginstatus]= '1' and username ='" + SessionData.Get<string>("Newuser") + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                status = 0;
            }
            else
            {
                status = 1;
            }
        }
        catch (Exception ex)
        { }
        return status;
    }

  

    protected void butsubmit_Click(object sender, EventArgs e)
    {
        try
        {

            decimal widamount = 0 ;
            string date = objtime.returnStringServerMachTime();

            string id = SessionData.Get<string>("Newuser");
            decimal finalamount = Convert.ToDecimal(lbIncome.Text.Trim());
           string TransPass = objDash.ReturnTransPass(SessionData.Get<string>("Newuser"));
            widamount = Convert.ToDecimal(txtAmt.Text.Trim());
            if (TransPass == txtpassword.Text)
            {
                //if (paymenttype.SelectedValue != "0")
                //{
                //    if (lbWallet.Text != "") //&& txtotp.Text != "")
                //    {
                //if (TransPass == txttransPassword.Text)
                //{
                if (finalamount >= widamount && widamount >= 500  )
                        {
                           

                            int a = objamd.WithdrawRequest(0, SessionData.Get<string>("Newuser"), widamount, "",  "INCOME",  "INR",  "P");
                            if (a > 0)
                            {
                                lbIncome.Text = objDash.IncomeBalance(SessionData.Get<string>("Newuser"));
                     
                                //string email = objDash.ReturnEmail(SessionData.Get<string>("Newuser"));
                                // objmail.WithdrawFund(SessionData.Get<string>("Newuser"), widamount.ToString(), paymenttype.SelectedValue, address, email);

                        warning.Visible = false;
                                danger.Visible = false;
                                sccess.Visible = false;
                                info.Visible = false;
                                sccess.Visible = true;
                                lbsuccess.Text = "Congratulations!!! Your Withdrawal successfully transfered in your wallet.";
                                loadclean();
                                btnaction.Visible = false;

                            }
                            else if (a == -1)
                            {
                                loadclean();
                                warning.Visible = false;
                                danger.Visible = false;
                                sccess.Visible = false;
                                info.Visible = false;
                                info.Visible = true;
                                lbinfo.Text = "Your previous Withdrawal Under Process ";
                            }

                            else
                            {
                                loadclean();
                                warning.Visible = false;
                                danger.Visible = false;
                                sccess.Visible = false;
                                info.Visible = false;
                                info.Visible = true;
                                lbinfo.Text = "Something went to wrong! Try Again?.";

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
                            lbwarning.Text = "Insufficient Amount (or) Minimum Withdrawal 100 and Reamining Capping Check Limit Please";

                        }
                //}

                //else
                //{
                //    lbdanger.Text = "Your Transaction Password is wrong ...... Try again";
                //    txttransPassword.Text = "";
                //    txttransPassword.Focus();
                //    danger.Visible = true;
                //}
                //    }
                //    else
                //    {
                //        lbdanger.Text = "Invaild Wallet Address !!! Try again";
                //        //txttransPassword.Text = "";
                //        //txttransPassword.Focus();
                //        danger.Visible = true;
                //    }
                //}
                //else
                //{
                //    lbdanger.Text = "Select Payment Mode Like - TRX ...... Try again";
                //    //  paymenttype.Focus();
                //    //txttransPassword.Text = "";
                //    //txttransPassword.Focus();

                //    danger.Visible = true;

                //}
            }

            else
            {
                lbdanger.Text = "Your Transaction Password is wrong ...... Try again";
                txtpassword.Text = "";
                txtpassword.Focus();
                danger.Visible = true;
            }

        }
        catch (Exception ex)
        {
            warning.Visible = false;
            danger.Visible = false;
            sccess.Visible = false;
            info.Visible = false;
            lbwarning.Text = "Enter valid Amount";
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
            //if (drpIncomeType.SelectedValue != "0")
            //{
            decimal finalamount = Convert.ToDecimal(lbIncome.Text.Trim());
                decimal reqAmt = Convert.ToDecimal(txtAmt.Text);
                if (finalamount >= reqAmt && reqAmt >= 500)
                {
                   
                        decimal AdminCharge = (reqAmt * 5 / 100);
                     //   decimal tds = (reqAmt * 5 / 100);
                      //  decimal wallet = (reqAmt * 10 / 100);
						
                        decimal amount = reqAmt - AdminCharge;
                        txtTotal.Text = amount.ToString();
                        txtadmincharge.Text = AdminCharge.ToString();
                         //txtFund.Text = wallet.ToString();
                        //     lbBario.Text = (amount / 2).ToString();
                       //  txtTDS.Text = tds.ToString();
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        sccess.Visible = false;
                        Label1.Visible = false;
                   
               
                }
                else
                {
                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    Label1.Visible = true;
                    txtAmt.Text = "";
                    txtAmt.Focus();
                    Label1.Text = "Don't have enough Fund, “Amount should be greater than 500”";
                    warning.Visible = false;
                    btnaction.Focus();
                }

            //}
            //else
            //{
            //    Label1.Text = "Select Income Type !!!";
            //    drpIncomeType.Focus();
            //    //txttransPassword.Text = "";
            //    //txttransPassword.Focus();

            //    Label1.Visible = true;

            //}
        }
        catch (Exception ex)
        { }
    }
    

  

 

   
}