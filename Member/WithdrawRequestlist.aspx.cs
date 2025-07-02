using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class User_Default : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();  
    public List<clsuser> objuserlist = new List<clsuser>();   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string username = SessionData.Get<string>("newuser");
            loaddirect(username);
        }
       
    }
    protected void btnSeach_Click(object sender, EventArgs e)
    {
        loaddirect(SessionData.Get<string>("newuser"));
    }
    public void loaddirect(string username)
    {
        try
        {
            
            string sql = " select r.tds,r.PackType,r.IncomeType,LEFT(r.PackType, 4) AS CoinType,r.Rid, r.username,r.Amount,r.DOR,r.DOA,r.remark,r.status,b.*,r.Payout,r.AdminCharge,r.Wallet from TblRWithdraw  r Left Join bankdetail b on r.Username=b.Username where  r.username='" + username+"'";
            if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                sql += "and r.dor between '" + txtfromdate.Text + "' and '" + txttodate.Text + "'";

            }
            sql += "order by r.dor asc";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                grdData.DataSource = dt;
                grdData.DataBind();

            }
            else
            {
                lbdanger.Text = "Oops! No Data Found...";
                danger.Visible = true;
            }

        }
        catch (Exception ex)
        {

        }


    }
    public string Color(object IsType)
    {
        string Status = "";
        if (IsType.ToString() == "Deposit")
        {
            Status = "From: ";
        }
        else if (IsType.ToString() == "Withdraw")
        {
            Status = "To: ";
        }
        else
        {
            Status = " ";
        }
        return Status;

    }
    protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdData.PageIndex = e.NewPageIndex;

        loaddirect(SessionData.Get<string>("newuser"));
    }

}

