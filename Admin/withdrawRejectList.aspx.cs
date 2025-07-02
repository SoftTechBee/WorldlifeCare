using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class Admin_withdrawRejectList : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { loadlist(""); }
        
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadlist(txtsearch.Text.Trim());
    }
    public void loadlist(string username)
    {
        try {
            string sql = "select r.Packtype,r.TDS,r.Rid,LEFT(r.PackType, 4) AS CoinType, r.username,r.Amount,r.DOR,r.DOA,r.remark,r.status,b.*," +
                "r.Payout,r.AdminCharge,r.Wallet,r.TDS,r.WalletFund from TblRWithdraw  r Left Join bankdetail b on " +
                "r.Username=b.Username where r.status='Reject'";
            if (username != "")
            {
                sql += "and r.username='" + username + "'";
            }
           
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                danger.Visible = false;
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

   
    public void panchradcheck()
    {
        /// string query = "select pan from  register where username='" + username.Text + "' ";
        //  DataTable dt1 = objcon.ReturnDataTableSql(query);
        //  string cardno = dt1.Rows[0]["pan"].ToString();
        // if (cardno != "")
        //{  //if have pan card

        //  string tds = (amt * 10 / 100).ToString();
        //  int newamount = (amt - Convert.ToInt32(tds));
        //   string sql2 = "insert into passbook1(username,debit,date,remark,type)values('" + username.Text + "','" + newamount.ToString() + "','" + date + "','Withdraw Request Approved','Withdraw')";
        //  int status2 = objcon.ExecuteSqlQuery(sql2);
        // string sql1 = "insert into passbook1(username,debit,date,remark,type)values('" + username.Text + "','" + tds + "','" + date + "','TDS+Service Debit','TDS+Service')";
        // int status1 = objcon.ExecuteSqlQuery(sql1);
        // if (status1 > 0)
        //{
        //  loadlist();
        //  }
        //  }
        //else
        // {  //not have pan card
        // string tds = (amt * 25 / 100).ToString();
        // int newamount = (amt - Convert.ToInt32(tds));
        // string sql2 = "insert into passbook1(username,debit,date,remark,type)values('" + username.Text + "','" + newamount.ToString() + "','" + date + "','Withdraw Request Approved ','Withdraw')";
        // int status2 = objcon.ExecuteSqlQuery(sql2);
        //  string sql1 = "insert into passbook1(username,debit,date,remark,type)values('" + username.Text + "','" + tds + "','" + date + "','TDS+Service Debit','TDS+Service')";
        //  int a = objcon.ExecuteSqlQuery(sql1);



        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {


                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=RejectWithdrawlist.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                //     Your Repeater Name Mine is "Rep"
                Repeater1.RenderControl(htmlWrite);
                Response.Write("<table>");
                Response.Write(stringWrite.ToString());
                Response.Write("</table>");
                Response.End();

            }
            catch (Exception ex)
            { }
        }

    

    }

   
