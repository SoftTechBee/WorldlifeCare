using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TripleITTransaction;
using TripleITConnection;
using System.Configuration;
public partial class Admin_Accountmaster : System.Web.UI.Page
{
    clsDashboard objdash = new clsDashboard();
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["newuser"] == null && Session["newuser"].ToString() == "")
            {
                Response.Redirect("Logout.aspx");
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Logout.aspx");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdlist.SelectedItem.Text=="Debit")
            {
                string sql = "insert into tblwallet(username,debit,DOI,type,remark)values('"+txtusername.Text+"','"+txtAmount.Text+"','"+ objtime.returnStringServerMachTime()+ "','Admin','" + txtremarks.Text+"')";
                int a=objcon.ExecuteSqlQuery(sql);
                if (a > 0)
                {
                    lbsuccess.Text = "Transaction  Successed";
                    sccess.Visible = true;
                    txtremarks.Text = "";
                    txtAmount.Text = "";
                    txtusername.Text = "";
                    lbname.Text = "";
                    txtusername.Focus();
                }
                else
                {
                    lbsuccess.Text = "Transaction has not  Successed";
                    sccess.Visible = true;
                    txtremarks.Text = "";
                    txtAmount.Text = "";
                    txtusername.Text = "";
                    lbname.Text = "";
                    txtusername.Focus();
                }
            }
            else if (rdlist.SelectedItem.Text == "Credit")
            {
                string sql = "insert into tblwallet(username,Credit,DOI,type,remark)values('" + txtusername.Text + "','" + txtAmount.Text + "','" + objtime.returnStringServerMachTime() + "','Admin','" + txtremarks.Text + "')";
                int a = objcon.ExecuteSqlQuery(sql);
                if (a > 0)
                {
                    lbsuccess.Text = "Transaction  Successed";
                    sccess.Visible = true;
                    txtremarks.Text = "";
                    txtAmount.Text = "";
                    txtusername.Text = "";
                    lbname.Text = "";
                    txtusername.Focus();
                }
                else
                {
                    lbsuccess.Text = "Transaction has not  Successed";
                    sccess.Visible = true;
                }
            }

        }
        catch (Exception ex)
        { }
    }

    protected void txtusername_TextChanged(object sender, EventArgs e)
    {
        string name = objdash.RetrunName(txtusername.Text);
        if (name != "0")
        {

            lbname.Text = name;
        }
        else
        {
            lbname.Text = "Invaild ID";
            txtusername.Text = "";
            txtusername.Focus();

        }
    }
}