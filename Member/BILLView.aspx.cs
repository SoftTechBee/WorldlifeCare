using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using TripleITConnection;
using TripleITTransaction;
public partial class User_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    clsList objlist = new clsList();
    clsAccount objacc = new clsAccount();
    public List<clsaccount> objacclist = new List<clsaccount>();


    protected void Page_Load(object sender, EventArgs e)
    {
        string Username = Request.QueryString["username"].ToString();
        string InvoiceNo = Request.QueryString["invoiceNo"].ToString();
        lbinvoice.Text = InvoiceNo;
        LoadList(Username,InvoiceNo);
            LoadData(Username);
            GrandTotal(Username, InvoiceNo);



    }
    private void LoadList(string Username,string InvoiceNo)
    {
        try
        {
            string sql = "select * from tblproductsale  where username='" + Username + "' and status='success' and InvoiceNo='"+ InvoiceNo + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {

              //  lbdelivertype.Text = "By Courier";

                Repeater1.DataSource = dt;
                Repeater1.DataBind();

            }
            else
            {

            }

        }
        catch (Exception ex)
        {

        }
    } 
    private void LoadData(string Username)
    {
        try
        {
            string InvoiceNo = Request.QueryString["invoiceNo"].ToString();

            string sql = "select b.*,r.* from tblsalebill b inner join register r on b.username=r.username  where b.username='" + Username + "' and b.InvoiceNo='" + InvoiceNo + "'   ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {


                lbdelivertype.Text = dt.Rows[0]["DeliveryType"].ToString();
                lbshipping.Text = dt.Rows[0]["GSTAmt"].ToString();
                lbpaystatus.Text = dt.Rows[0]["paid"].ToString();
                lbusername.Text = dt.Rows[0]["username"].ToString();
                lbshipname.Text = dt.Rows[0]["name"].ToString();
                lbshiusername.Text = dt.Rows[0]["username"].ToString();
                lbname.Text = dt.Rows[0]["name"].ToString();
                lbaddress.Text = dt.Rows[0]["address"].ToString();
                lbaddress2.Text = dt.Rows[0]["address"].ToString();
                lbmobile.Text = dt.Rows[0]["mobile"].ToString();
                lbmobille2.Text = dt.Rows[0]["mobile"].ToString();
                lbdated.Text = Convert.ToDateTime(dt.Rows[0]["DOI"].ToString()).ToShortDateString();

            }
            else
            {

            }

        }
        catch (Exception ex)
        {

        }
        
    }
    private void GrandTotal(string Username, string InvoiceNo)
    {
        try
        {
            string sql = "select  sum(mrp) as MRP,Count(qty) as qty,sum(price) as DP,sum(bv) as BV,sum(discount) as Discount from [tblproductsale] where username='" + Username + "'  and InvoiceNo='" + InvoiceNo + "'";
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
                Decimal TotalDP = Convert.ToDecimal(totaldp.Text);
                //if(TotalBV  >= 1 && TotalBV <= 500)
                //{
                //    lbgrandtotal.Text = TotalDP;
                //    lbshipping.Text = "free";
                //    lbtotalpayout.Text = (Convert.ToDecimal(TotalDP)).ToString();
                //}
                //else if (TotalBV >= 501 && TotalBV <= 999)
                //{
                //    lbgrandtotal.Text = TotalDP;
                //    lbshipping.Text = "free";
                //    lbtotalpayout.Text = (Convert.ToDecimal(TotalDP)).ToString();
                //}
                //else
                //{
                    decimal Ship = Convert.ToDecimal(lbshipping.Text);

                lbtotalpayout.Text = (TotalDP+ Ship).ToString();
                    lbgrandtotal.Text = TotalDP.ToString();
               // }
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

    

    protected void btnview_Click(object sender, EventArgs e)
    {
        
        string Username = lbusername.Text;
        string InvoiceId = lbinvoice.Text;
        Response.Redirect("BillPrint.aspx?Username=" + Username + "&invoiceNo=" + InvoiceId);
    }



    protected void btnpay_Click(object sender, EventArgs e)
    {
        string TotalDP = lbgrandtotal.Text;
        string Username = lbusername.Text;
        string InvoiceId = lbinvoice.Text;
        Response.Redirect("PayNow.aspx?Username=" + Username + "&invoiceNo=" + InvoiceId + "&Total=" + TotalDP);
    }
}