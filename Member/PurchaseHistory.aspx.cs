using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class User_TopUpWallet : System.Web.UI.Page
{
    clsDashboard objdashboard = new clsDashboard();
    clsfunction objfun = new clsfunction();
    clsAMD objamd = new clsAMD();
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsDashboard objDash = new clsDashboard();
    clsSMS objsms = new clsSMS();
    clsmail objmail = new clsmail();
   
    public List<clsaccount> objacclist = new List<clsaccount>();
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
                loadTotal(SessionData.Get<string>("Newuser"));
                loadaccount(SessionData.Get<string>("Newuser"));
                txtbalance.Text = objDash.TotalWallectBlance(SessionData.Get<string>("Newuser"));
            }
        }

    }
    //for account
    public void loadaccount(string username)
    {
        try
        {
            string sql = "select * from [tblproductsale] where username='" + username + "' and status='Pending'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                //lbdanger.Text = "Opps! NO Data Found";
                //danger.Visible = true;
            }


        }
        catch (Exception ex)
        {

        }


    }


    public void loadTotal(string username)
    {
        try
        {
            string sql = "select sum(mrp) as MRP,count(qty) as qty,sum(price) as DP,sum(bv) as BV,sum(discount) as Discount from [tblproductsale] where username='" + username + "' and status='Pending'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
              
                lbqty.Text = dt.Rows[0]["qty"].ToString();
                totalbv.Text = dt.Rows[0]["BV"].ToString();
                lbtotalBV.Text = dt.Rows[0]["BV"].ToString();
                totaldiscount.Text = dt.Rows[0]["Discount"].ToString();
                totaldp.Text = dt.Rows[0]["DP"].ToString();
                totalmrp.Text = dt.Rows[0]["MRP"].ToString();
                Decimal TotalBV = Convert.ToDecimal(lbtotalBV.Text);
                if (TotalBV >= 1 && TotalBV <= 500)
                {
                    lbgrandtotal.Text = totaldp.Text;
                    lbshipping.Text = "Free";
                    lbtotalpayout.Text = (Convert.ToDecimal(totaldp.Text) + 0).ToString();
                }
                else if (TotalBV >= 501 && TotalBV <= 999)
                {
                    lbgrandtotal.Text = totaldp.Text;
                    lbshipping.Text = "Free";
                    lbtotalpayout.Text = (Convert.ToDecimal(totaldp.Text) + 0).ToString();
                }
                else
                {
                    lbshipping.Text = "Free";
                    lbtotalpayout.Text = Convert.ToDecimal(totaldp.Text).ToString();
                    lbgrandtotal.Text = totaldp.Text;
                }
            }
            else
            {
                //lbdanger.Text = "Opps! NO Data Found";
                //danger.Visible = true;
            }


        }
        catch (Exception ex)
        {

        }


    }





    protected void btncheckout_Click(object sender, EventArgs e)
    {
        try

        {

            decimal widamount = 0, Price = 0, BV = 0, Qty = 0, Discount = 0;
            string date = objtime.returnStringServerMachTime();
            string PackType = "";
            string id = SessionData.Get<string>("Newuser");
            decimal finalamount = Convert.ToDecimal(txtbalance.Text.Trim());
            string PaidStatus = objdashboard.PaidStatus(id);

            Price = (Convert.ToDecimal(totaldp.Text.Trim()));
            BV = (Convert.ToDecimal(totalbv.Text.Trim()));
            Qty = (Convert.ToDecimal(lbqty.Text.Trim()));
            Discount = (Convert.ToDecimal(totaldiscount.Text.Trim()));
            BV = (Convert.ToDecimal(totalbv.Text.Trim()));

            if (PaidStatus == "True")
            {




                if (finalamount >= Price)
                {


                    int a = objamd.ActiveMember(id, Price, BV,  "PRODUCTS PURCHASE",  SessionData.Get<string>("Newuser"), "R");
                    if (a > 0)
                    {

                        int b = objamd.PRODUCTBILL(0, "", SessionData.Get<string>("Newuser"), "", "", Qty, Convert.ToDecimal(totalmrp.Text), Discount, Price, BV, Price, 0, 0, 0, "", "C");
                        if (b > 0)
                        {
                            danger.Visible = false;
                            warning.Visible = false;
                            danger.Visible = false;
                            sccess.Visible = true;
                            info.Visible = false;
                            lbsuccess.Text = "Your Payment Has Been Succesully .! Please Check Out In Invoice List";
                            //string Username = SessionData.Get<string>("newuser");
                            //Response.Redirect("Billview.aspx?username=" + Username);

                            loadTotal(SessionData.Get<string>("Newuser"));
                            loadaccount(SessionData.Get<string>("Newuser"));
                            txtbalance.Text = objDash.TotalWallectBlance(SessionData.Get<string>("Newuser"));
                                   SessionData.Put("StatusCSS", "text-success");


                        }
                        else if (b == -1)
                        {


                            danger.Visible = true;

                            lbdanger.Text = "You have already insert Member...!";
                        }
                        else
                        {

                            lbdanger.Text = "Data is not insert successfully";
                            danger.Visible = true;


                        }


                    }
                    else if (a == -1)
                    {

                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;

                        info.Visible = true;
                        lbinfo.Text = "You have already Payment ";
                    }
                }
                else
                {

                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    info.Visible = true;
                    lbinfo.Text = "Less Then Balance! ";
                }
            }
            else
            {

                warning.Visible = false;
                danger.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
                info.Visible = true;
                lbinfo.Text = "First You have to Buy Starter Kit For Buying Product ";
            }
        }





        catch (Exception ex)
        {



        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "remove")
        {
            string id = e.CommandArgument.ToString();
            objcon.ExecuteSqlQuery("delete from [tblproductsale] where pid='" + id + "'");

            lbinfo.Text = "Product remove Successfully";
            info.Visible = true;
            loadTotal(SessionData.Get<string>("Newuser"));
            loadaccount(SessionData.Get<string>("Newuser"));
            txtbalance.Text = objDash.TotalWallectBlance(SessionData.Get<string>("Newuser"));




        }
    }
}