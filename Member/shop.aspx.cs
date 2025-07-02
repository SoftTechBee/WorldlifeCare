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
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (SessionData.Get<string>("Newuser") == null && SessionData.Get<string>("Newuser") == "")
            {
                Response.Redirect("Logout.aspx");
            }
            else
            {
                if (!IsPostBack)
                { 
                    loadlist();
                    CartCount();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Logout.aspx");
        }
    }
    public void loadlist()
    {
        try
        {
            string sql = "select * from TblProductMaster ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
               
            }
            else
            {
                //lbdanger.Text = "Opps! NO Data Found";
                //danger.Visible = true;
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    public void CartCount()
    {
        try
        {
            string sql = "select count(qty) as qty from [tblproductsale] where username='" + SessionData.Get<string>("Newuser") + "' and status='Pending'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                lbcart.InnerText = dt.Rows[0]["qty"].ToString();
            }
           
        }
        catch (Exception ex)
        {

        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
            string id = e.CommandArgument.ToString();
            Label lbproduct = e.Item.FindControl("lbproduct") as Label;
            Label lbmrp = e.Item.FindControl("lbmrp") as Label;
            Label lbDP = e.Item.FindControl("lbDP") as Label;
            Label lbbv = e.Item.FindControl("lbbv") as Label;


            int b = objamd.PRODUCTBILL(0, lbproduct.Text, SessionData.Get<string>("Newuser"), "By Courier", "", 1, Convert.ToDecimal(lbmrp.Text), 0, Convert.ToDecimal(lbDP.Text), Convert.ToDecimal(lbbv.Text), Convert.ToDecimal(lbDP.Text), 0, 0, 0, "", "N");
            if (b > 0)
            {

                sccess.Visible = true;
                lbsuccess.Text = "Product Add to cart Successfully";


                loadlist();
                CartCount();

            }









            
          
           // Response.Redirect("SelfActive.aspx?pId=" + id);



        }
    }
}