using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class Admin_WalletSummary : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    clsAccount objacc = new clsAccount();
    public List<clsaccount> objacclist = new List<clsaccount>();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    //for account
    public void loadaccount(string username)
    {
        try
        {
             string   sql = "select username,credit,debit,DOI,remark from tblwallet where username='" + username + "' order by DOI asc";       
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                 Decimal debit = 0, credit = 0, tdebit = 0, tcredit = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    danger.Visible = false;
                    clsaccount objacc = new clsaccount();
                    objacc.username = dt.Rows[i]["username"].ToString();
                    
                    objacc.credit = dt.Rows[i]["debit"].ToString();
                    objacc.debit = dt.Rows[i]["credit"].ToString();                                                    
                    objacc.date = Convert.ToDateTime( dt.Rows[i]["DOI"].ToString()).ToString("dd/MM/yyyy");
                    objacc.remark = dt.Rows[i]["remark"].ToString();
                    objacclist.Add(objacc);
                    debit = dt.Rows[i]["debit"].ToString() !=""?Convert.ToDecimal(dt.Rows[i]["debit"].ToString()):0;
                    credit = dt.Rows[i]["credit"].ToString() != "" ? Convert.ToDecimal(dt.Rows[i]["credit"].ToString()) : 0;
                    tdebit += debit;
                    tcredit += credit;
                }
                lbcredit.Text = tcredit.ToString();
                lbdebit.Text = tdebit.ToString();

            }
            else
            { lbdanger.Text = "Opps! NO Data Found";
                danger.Visible = true;
            }
            Repeater1.DataSource = objacclist;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {

        }



    }



    protected void btnsearch_Click(object sender, EventArgs e)
    {
        loadaccount(txtsearch.Text);
    }

   
            
}