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
public partial class Admin_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    static string Password = "", id = "", dateofjoining = "", Profilepic="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            info.Visible = false;
            //LoadCity();
            //String UserName = "380689";
            //loadlist(UserName);
        
        }
    }
    private void LoadCity()
    {
        try
        {
        //    DataTable dt = objcon.ReturnDataTableSql("select distinct state from tblcity order by state asc");
        //    drpstate.DataSource = dt;
        //    drpstate.DataBind();
        //    drpstate.Items.Insert(0, "Select State");
        //    DataTable dt1 = objcon.ReturnDataTableSql("select  city from tblcity where state='" + drpstate.SelectedItem.Text + "' ");
        //    drpCity.DataSource = dt1;
        //    drpCity.DataBind();
        //    drpCity.Items.Insert(0, "Select City");


        }
        catch (Exception ex)
        { }
    }
    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            //DataTable dt1 = objcon.ReturnDataTableSql("select  city from tblcity where state='" + drpstate.SelectedItem.Text + "' ");
            //drpCity.DataSource = dt1;
            //drpCity.DataBind();
            //drpCity.Items.Insert(0, "Select City");


        }
        catch (Exception ex) { }
    }
    private void loadlist(string UserName)
    {
        try
        {

            string sql = "select id,reffid,reffname,name,username,[password],fname,onside,dateofJoin,[address],city,[state],country,email,mobile,[status],nomineename,relation,pan,aadhar,nage,sex,pin,dob,rtime,ftime,cardno,nomineemobile,dateofjoining,DOA,MarriageStatus,Profilepic,Upline,UplineName from register where UserName='" + UserName + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["id"].ToString();
                lbSponser.Text = dt.Rows[0]["reffid"].ToString();
                lbSponserName.Text = dt.Rows[0]["reffname"].ToString();
                txtName.Text = dt.Rows[0]["name"].ToString();
                lbUserName.Text = dt.Rows[0]["username"].ToString();
                Password = dt.Rows[0]["password"].ToString();
               // txtFName.Text = dt.Rows[0]["fname"].ToString();
lbside.Text = dt.Rows[0]["onside"].ToString();
                lbDOJ.Text = dt.Rows[0]["dateofJoin"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();
              //  drpstate.SelectedItem.Text = dt.Rows[0]["state"].ToString();
              //  drpCity.SelectedItem.Text = dt.Rows[0]["city"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                txtMobile.Text = dt.Rows[0]["mobile"].ToString();
                lbStatus.Text = dt.Rows[0]["status"].ToString();
              //  txtNName.Text = dt.Rows[0]["nomineename"].ToString();
             //   txtNRelation.Text = dt.Rows[0]["relation"].ToString();
              //  txtpan.Text = dt.Rows[0]["pan"].ToString();
              //  txtaadhar.Text = dt.Rows[0]["aadhar"].ToString();
              //  txtNAge.Text = dt.Rows[0]["nage"].ToString();
                rdSex.Text = dt.Rows[0]["sex"].ToString();
              //  txtpincode.Text = dt.Rows[0]["pin"].ToString();
               // txtDOB.Text = dt.Rows[0]["dob"].ToString();
               // txtNMobile.Text = dt.Rows[0]["nomineemobile"].ToString();
                dateofjoining = dt.Rows[0]["dateofjoining"].ToString();
              //  txtDOA.Text = dt.Rows[0]["DOA"].ToString();
               // rdMaritalStatus.Text = dt.Rows[0]["MarriageStatus"].ToString();
                Profilepic = dt.Rows[0]["Profilepic"].ToString();
               // lbUpline.Text = dt.Rows[0]["Upline"].ToString();
                //lbuplineName.Text = dt.Rows[0]["UplineName"].ToString();
            }



        }
        catch (Exception ex) { }
    }
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {

            string side = "";
            try { side = ""; }
            catch (Exception ee) { side = ""; };
            string DOJ = objtime.returnStringServerMachTime();
            string DOB = "";// txtDOB.Text == "" ? "" : Convert.ToDateTime(txtDOB.Text).ToString("yyyy-MM-dd");
            string DOA = "";// txtDOA.Text == "" ? "" : Convert.ToDateTime(txtDOA.Text).ToString("yyyy-MM-dd");
            int a = objamd.Register(0, lbSponser.Text, lbSponserName.Text, txtName.Text, lbUserName.Text, Password, "", lbUserName.Text, side, DOJ, txtAddress.Text, "Select", "Select", "India", txtEmail.Text, txtMobile.Text, lbStatus.Text, "", "", "", "", "", "", rdSex.SelectedItem.Text, DOB, "", "", "", "", "", "", DOJ, "", DOA, "", "../dist/img/user2-160x160.jpg", "", "", "A");
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
        Password = "";
        // txtaadhar.Text = "";
        txtAddress.Text = "";
        // txtDOB.Text = "";
        txtEmail.Text = "";
        //txtFName.Text = "";
        txtMobile.Text = "";
        txtName.Text = "";
        //txtpan.Text = "";
        // txtpincode.Text = "";
        lbUserName.Text = "";
        lbSponserName.Text = "";
       // lbUpline.Text = "";
       // lbmsg.Text = "";

    }
    protected void btncencel_Click(object sender, EventArgs e)
    {
        Clear();

    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadlist(txtsearchuname.Text);
    }
}