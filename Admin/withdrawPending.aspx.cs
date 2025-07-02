using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
using Newtonsoft.Json;

public partial class Admin_WREquest : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    ClsDoopme objdoopme = new ClsDoopme();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { loadlist(); }
        
    }
    public void loadlist()
    {
        try
        {
            string sql = "select r.*,rr.name,rr.mobile from TblRWithdraw  r  inner join register rr on r.username=rr.username  where r.status='Pending' order by r.DOR desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();


        }
        catch (Exception ex)
        {

        }
    }
    private string RequestID()
    {
        string RequestID = "";
        try
        {
            for (int i = 1; i <= 100; i++)
            {
                var chars = "0123456789";
                var stringChars = new char[10];
                var random = new Random();

                for (int ik = 0; ik < stringChars.Length; ik++)
                {
                    stringChars[ik] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                RequestID = Convert.ToString(finalString);
                DataTable dt1 = objcon.ReturnDataTableSql("select transactionid from TblRWithdraw where transactionid='" + RequestID + "'");
                if (dt1.Rows.Count > 0)
                {

                }
                else
                {
                    i = 120;
                }
            }
            return RequestID;

        }
        catch (Exception ex) { }
        return RequestID;
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            string id = e.CommandArgument.ToString();
            Label lbpacktype = e.Item.FindControl("lbpacktype") as Label;
            Label lbIncomeType = e.Item.FindControl("lbIncomeType") as Label;
            int a = objamd.WithdrawRequest(Convert.ToInt32(id), "", 0, "", lbpacktype.Text,"", "C");
            loadlist();
        }
        
        if (e.CommandName == "Click")
        {
            Label username = e.Item.FindControl("lbuname") as Label;
            Label lbamt = e.Item.FindControl("lbamt") as Label;
            Label lbpayout = e.Item.FindControl("lbpayout") as Label;
            Label lbadminchrg = e.Item.FindControl("Label2") as Label;          
            Label lbbid = e.Item.FindControl("lbbid") as Label;
            Label lbmobile = e.Item.FindControl("lbmobile") as Label;
            Label lbpacktype = e.Item.FindControl("lbpacktype") as Label;
           
            decimal amt = Convert.ToDecimal(lbpayout.Text);
            int roudup = Convert.ToInt32(amt);
            string id = e.CommandArgument.ToString();
            string Transaction = RequestID();
           
                int a = objamd.WithdrawRequest(Convert.ToInt32(id), username.Text, amt, Transaction, lbpacktype.Text, "","A");


                if (a > 0)
                {
                    loadlist();
                    warning.Visible = false;
                    danger.Visible = false;
                    sccess.Visible = false;
                    info.Visible = false;
                    sccess.Visible = true;
                    lbsuccess.Text = "Request Approved Successfully";
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
                    lbinfo.Text = "Request Approved Successfully ";
                }
            }
            else
            {
                loadlist();
                warning.Visible = false;
                danger.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
               

            }
     



    }
 
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PendingWithdrawlist.xls");
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
//public class NTDRESPSendMoney
//{
//    public string STATUSCODE { get; set; }
//    public string STATUSMSG { get; set; }
//}

//public class RootSendMoney
//{
//    public NTDRESPSendMoney NTDRESP { get; set; }
//}


