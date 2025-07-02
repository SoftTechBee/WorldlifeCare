using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
public partial class Admin_Account : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    clsAccount objacc = new clsAccount();
    public List<clsaccount> objacclist = new List<clsaccount>();
    protected void Page_Load(object sender, EventArgs e)
    {if (!IsPostBack)
        {

            loadaccount(SessionData.Get<string>("newuser"));
        }
        
    }
    //for account
    public void loadaccount(string username)
    {
        try
        {
            string sql = "select username,credit,debit,date,remark from account where username='" + username + "' and valu !='Admin' order by id desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                grdData.DataSource = dt;
                grdData.DataBind();
                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Credit"));
                decimal Debit = dt.AsEnumerable().Sum(row => row.Field<decimal>("Debit"));
                grdData.FooterRow.Cells[3].Text = "Total";
                grdData.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                grdData.FooterRow.Cells[3].Font.Bold = true;
                grdData.FooterRow.Cells[4].Font.Bold = true;
                grdData.FooterRow.Cells[5].Font.Bold = true;
                grdData.FooterRow.Cells[4].Text = total.ToString("N2");
                grdData.FooterRow.Cells[5].Text = Debit.ToString("N2");
            }
        }
        catch (Exception ex)
        {

        }


    }

    protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdData.PageIndex = e.NewPageIndex;
     //   this.BindGrid();
        loadaccount(SessionData.Get<string>("newuser"));
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
       
    }

   
            
}