using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using TripleITTransaction;
using TripleITConnection;
using System.Collections.Generic;
using System;

public partial class Admin_Default : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    clsAccount objacc = new clsAccount();
    public List<clsaccount> objacclist = new List<clsaccount>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            loadlist();
        }

    }
    private void loadlist()
    {
        try
        {
            string sql = "select * from tblctofund ";
            //if (txtfromdate.Text != "" && txttodate.Text != "")
            //{
            //    sql += "  and Date between '" + txtfromdate.Text + "' and '" + txttodate.Text + "'";

            //}
            //else if ( txtfromdate.Text != "" && txttodate.Text != "")
            //{
            //    sql += "  and  Date between '" + txtfromdate.Text + "' and '" + txttodate.Text + "'";

            //}
            //else if ( txtfromdate.Text == "" && txttodate.Text == "")
            //{
            //    sql += "and Date='" + txtsearch.Text + "'";
            //}


            //sql += "select * from tblctofund ";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                //decimal total = 0;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    total += Convert.ToDecimal(dt.Rows[i]["totalincome"].ToString());


                //}
                ////lbtotal.Text = total.ToString();
                danger.Visible = false;

            }
            else
            {
                //lbtotal.Text = "0";
                lbdanger.Text = "Opps! NO Data Found";
                danger.Visible = true;
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadlist();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("rptViewIncome.aspx?username=" + username + "&type=ROYALTY");
        }
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=rptIncome.xls");
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