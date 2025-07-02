using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class Admin_UnBlockMember : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadinactivememberlist();
        }
    }

    private void loadinactivememberlist()
    {
        try
        {
            string sql = "select * from register where loginstatus='0' ";
            if(txtsearch.Text != "")
            {
                sql += " and username='" + txtsearch.Text + "'";
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

   
    protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
           
            string id = e.CommandArgument.ToString();
           
            try
            {
                string date = objtime.returnStringServerMachTime();
                //active member
                string sql1 = "update register set loginstatus='1'  where username='" + id + "'";
                int status3 = objcon.ExecuteSqlQuery(sql1);
                if (status3 > 0)
                    {
                        loadinactivememberlist();
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        sccess.Visible = true;
                        lbsuccess.Text = " User Blocked!";

                    }
                    else
                    {
                        loadinactivememberlist();
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        info.Visible = true;
                        lbinfo.Text = "User is not Blocked successfully";
                    }

                }


           

            catch (Exception ex)
            {

            }


        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadinactivememberlist();
    }
}