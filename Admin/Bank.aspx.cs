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
public partial class Admin_Default2 : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    static string Password = "", id = "", dateofjoining = "", Profilepic = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
   
    private void loadlist()
    {
        try
        {

            string sql = "select username,accno,bankname,ifsc,branchname,holdername,acctype,GooglePay,PhonePay,PayTm,BHIM from bankdetail where username='" + txtsearchuname.Text + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                txtAccNo.Text = dt.Rows[0]["accno"].ToString();
                txtAHName.Text = dt.Rows[0]["holdername"].ToString();
                txtBank.Text = dt.Rows[0]["bankname"].ToString();
                txtBranch.Text = dt.Rows[0]["branchname"].ToString();
                txtIFSC.Text = dt.Rows[0]["ifsc"].ToString();
                rdAccType.SelectedItem.Text = dt.Rows[0]["acctype"].ToString();
                //txtPhonePay.Text = dt.Rows[0]["PhonePay"].ToString();
                //txtpaytm.Text = dt.Rows[0]["PayTm"].ToString();
                //txtBitcoin.Text = dt.Rows[0]["GooglePay"].ToString();
                //txtbhim.Text = dt.Rows[0]["BHIM"].ToString();

            }




        }
        catch (Exception ex) { }
    }
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {


            int a = objamd.ModifyBankDetail(0, SessionData.Get<string>("newuser"), txtAccNo.Text.Trim(), txtBank.Text.Trim(), txtIFSC.Text.Trim(), txtBranch.Text.Trim(), txtAHName.Text.Trim(), rdAccType.SelectedItem.Text, "", "", "", "", "", "", "","A");
            if (a > 0)
            {

                lbinfo.Text = "Record Update successfully";
                info.Visible = true;
                Clear();

            }
            else if (a == -1)
            {

                lbinfo.Text = "Record already Update inserted";
                info.Visible = true;
            }
            else
            {

                lbinfo.Text = "Record has not Update successfully";
                info.Visible = true;
            }
        }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
        txtAccNo.Text = "";
        txtAHName.Text = "";
        txtBank.Text = "";
        txtBranch.Text = "";
        txtIFSC.Text = "";


    }
    protected void btncencel_Click(object sender, EventArgs e)
    {
        Clear();

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
      
        loadlist();
    }
}