using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
public partial class Admin_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
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
            string sql = "select * from register ";
            if (Drpstatus.SelectedValue != "0")
            {
                sql += "where packtype='" + Drpstatus.SelectedItem.Text + "' and status='Active'";
            }
            sql += " order by dateofjoining desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                decimal total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string amount = dt.Rows[i]["JoinAmount"].ToString() == "" ? "0" : dt.Rows[i]["JoinAmount"].ToString();
                    total += Convert.ToDecimal(amount);


                }
                lbtotal.Text = total.ToString();
                danger.Visible = false;
               
            }
            else
            {
                lbdanger.Text = "Opps! NO Data Found";
                danger.Visible = true;
                lbtotal.Text = "0";
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
        loadinactivememberlist();
    }
}