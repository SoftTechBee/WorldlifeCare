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

public partial class Admin_SupportLIst : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    CoinPayments objcoin = new CoinPayments();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { loadlist(); }
        
    }
    public void loadlist()
    {
        try {
            string sql = "select * from tblsupport  order by DOI desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();


        }
        catch (Exception ex)
        {

        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if (e.CommandName == "Click")
        {

            TextBox lbresponsce = e.Item.FindControl("txtResposnce") as TextBox;
            //check pancard           

            string sql = "update  TblSupport set status='Approved',response='"+ lbresponsce.Text + "' where sid='"+e.CommandArgument.ToString()+"'";
            int a = objcon.ExecuteSqlQuery(sql);
            if (a > 0)
            {
                loadlist();
                lbsuccess.Text = "Your response sent successfull";
                sccess.Visible = true;
                danger.Visible = false;
            }
            else
            {
                loadlist();
                lbdanger.Text = "Try Again";
                sccess.Visible = false;
                danger.Visible = true;
            }

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


