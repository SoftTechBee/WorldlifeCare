﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class Admin_BlockList : System.Web.UI.Page
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
            string sql = "select * from register where loginstatus='1' ";
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

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
                string sql1 = "update register set loginstatus='0'  where username='" + id + "'";
                int status3 = objcon.ExecuteSqlQuery(sql1);
                if (status3 > 0)
                    {
                        loadinactivememberlist();
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        sccess.Visible = true;
                        lbsuccess.Text = "Active User ";

                    }
                    else
                    {
                        loadinactivememberlist();
                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        info.Visible = true;
                        lbinfo.Text = "User is not active successfully";
                    }

                }


           

            catch (Exception ex)
            {

            }


        }
    }
}