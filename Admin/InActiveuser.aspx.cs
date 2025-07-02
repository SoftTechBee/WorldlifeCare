using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class User_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();    
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
        loadinactivememberlist("");
        }
    }

    private void loadinactivememberlist(string username)
    {
        try
        {
            string sql = "";
            sql = "select * from register where  status='Not Active' ";
            if (username != "")          
            { sql += "and username='" + username + "'"; }
            sql += " order by dateofjoin desc";


            DataTable dt = objcon.ReturnDataTableSql(sql);
            if(dt.Rows.Count>0)
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

  

    protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
            Label sponserid = e.Item.FindControl("lbsponser") as Label;
            string id = e.CommandArgument.ToString();
            Response.Redirect("Packages.aspx?Id=" + id);// + "&sponserid=" + sponserid.Text);

           


        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadinactivememberlist(txtsearch.Text.Trim());
    }
}