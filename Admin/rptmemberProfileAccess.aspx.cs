using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using TripleITTransaction;
using TripleITConnection;
public partial class Admin_rptmemberProfileAccess : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsDashboard objdash = new clsDashboard();
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
            string sql = "select * from  register a where 1=1";
             if (txtsearch.Text != "" && txtfromdate.Text != "" && txttodate.Text != "")
            {
                sql += "and a.username='" + txtsearch.Text + "'  and  a.dateofjoining between '" + txtfromdate.Text + "' and '" + txttodate.Text + "'";

            }
           else if (txtsearch.Text == "" && txtfromdate.Text != "" && txttodate.Text != "")
            {
                sql += "  and  a.dateofjoining between '" + txtfromdate.Text + "' and '" + txttodate.Text + "'";

            }
            else if (txtsearch.Text != "" && txtfromdate.Text == "" && txttodate.Text == "")
            {
                sql += "and a.username='" + txtsearch.Text + "'";
            }
             else if (drpstatus.SelectedItem.Text != "All User")
            {
                sql += " and a.status='" + drpstatus.SelectedItem.Text + "' ";

            }


            sql += " order by a.id desc";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
               
                
            }
            else
            {
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
            Response.Redirect("../Member/AdminAccess.aspx?username=" + username);
        }
    
        if (e.CommandName == "Pass")
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("ChangeMemberPassword.aspx?username=" + username);
        }
        if (e.CommandName == "Transpass")
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("ChangeMemberTransPassword.aspx?username=" + username);
        }
        if (e.CommandName == "Investment")
        {
          
            string id = e.CommandArgument.ToString();
            Response.Redirect("SelfActive.aspx?Id=" + id);// + "&sponserid=" + sponserid.Text);

           


        }
        if (e.CommandName == "Block")
        {
            string username = e.CommandArgument.ToString();
            Button Loginstatus = e.Item.FindControl("Button21") as Button;

            if (Loginstatus.Text == "UnBlock")
            {

                objcon.ExecuteSqlQuery("update register set loginstatus=1 where username='" + username + "'");

                lbinfo.Text = username+"'s account has been blocked";
                info.Visible = true;
                loadlist();
            }
            else
            {
                objcon.ExecuteSqlQuery("update register set loginstatus=0 where username='" + username + "'");

                lbinfo.Text = username + "'s account has been un-blocked";
                info.Visible = true;
                loadlist();
            }

        }
    }
    public string remark(object IsType)
    {
        string Status = "";
        if (IsType.ToString() == "True")
        {
            Status = "Block";
        }
       
        else
        {
            Status = "UnBlock";
        }
        return Status;

    }





    protected void drpstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadlist();
    }
}