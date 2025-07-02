using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class User_rptLevelIncome : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    clsAccount objacc = new clsAccount();
    public List<clsaccount> objacclist = new List<clsaccount>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.Get<string>("Newuser") != null || SessionData.Get<string>("Newuser") == "")
        {
            if (!IsPostBack)
            {

                loadaccount();
            }
        }
        else
        {

            Response.Redirect("logout.aspx");
        }

    }
    //for account
    public void loadaccount()
    {
        try
        {
            string sql = "select * from tblsalary ";
            if (txtsearch.Text != "")
            {
                sql += " Where username= '" + txtsearch.Text + "'";
               
            }
            sql += "order by DOA desc";
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
    public string remark(object IsType)
    {
        string Status = "";
        if (IsType.ToString() == "False")
        {
            Status = "Continue";
        }

        else
        {
            Status = "Stoped";
        }
        return Status;

    }

    protected void btnSeach_Click(object sender, EventArgs e)
    {
        loadaccount();
    }

}