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
    clsList objlist = new clsList();
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = SessionData.Get<string>("newuser");
        if (!IsPostBack)
        {
             
            try
            {
                DataTable dt = objlist.GetDownline(username, "P");
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }

    

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
            Label sponserid = e.Item.FindControl("lbsponser") as Label;
            string id = e.CommandArgument.ToString();
           // Response.Redirect("action.aspx?username=" + id + "&sponserid=" + sponserid.Text);
           Response.Redirect("Packages.aspx?Id=" + id );



        }
    }
    protected void btnsearch_Click1(object sender, EventArgs e)
    {
        try
        {
            string sql = "select * from register   where register.status='Not Active'  and register.username='" + txtsearch.Text + "'";
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


    
    
}