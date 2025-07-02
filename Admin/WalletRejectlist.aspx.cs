using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class Admin_WalletRejectlist : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    clsConnection objcon = new clsConnection();
    public List<clsuser> objuserlist = new List<clsuser>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        loaddirect();
        }
    }
    public void loaddirect()
    {
        try
        {
            //DOI between '" + txtfromdate.Text + "' and '" + txttodate.Text + "' and
            string sql = "select * from [TblRepurchaseRequest] where status='Reject' ";
            if (txtsearch.Text != "")
            {
                sql += "and username='" + txtsearch.Text + "'";
            }
            sql += "order by DOD desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
               // danger.Visible = false;
              

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
    protected void btnSeach_Click(object sender, EventArgs e)
    {
        loaddirect();
    }

}