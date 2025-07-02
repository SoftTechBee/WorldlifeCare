using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class User_rptdwonline : System.Web.UI.Page
{
  
    clsList objlist = new clsList();   
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        if (!IsPostBack)
        {
            LoadData();
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
        }
       

    }

    public void LoadData()
    {
        try
        {
            string username = SessionData.Get<string>("newuser");
            DataTable dt = objlist.GetDownline(username, "A");
            grdData.DataSource = dt;
            grdData.DataBind();
            //decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("joinamount"));
   
            //grdData.FooterRow.Cells[3].Text = "Total";
            //grdData.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //grdData.FooterRow.Cells[3].Font.Bold=true; 
            //grdData.FooterRow.Cells[4].Font.Bold=true; 
            //grdData.FooterRow.Cells[5].Font.Bold=true; 
            //grdData.FooterRow.Cells[4].Text = total.ToString("N2");
            //grdData.FooterRow.Cells[5].Text = Debit.ToString("N2");
            
        }
        catch (Exception ex)
        {

        }


    }

    protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    grdData.PageIndex = e.NewPageIndex;
        //   this.BindGrid();
        LoadData();
}
  
}

