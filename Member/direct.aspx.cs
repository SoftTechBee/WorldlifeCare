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
        { loaddirect(); }
       
    }
    public void loaddirect()
    {
        try
        {
            string username = SessionData.Get<string>("newuser");
              string sql = "";
            if (username != "Admin")
            {
                sql = " select * from register where reffid ='" + SessionData.Get<string>("newuser") + "'";

            }
            else
            {

                sql = " select * from register";

            }
            //sql = " select username, name, mobile, city, reffname, reffid, dateofjoining from register";
            DataTable dt = objcon.ReturnDataTableSql(sql);
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

        loaddirect();
    }

}

