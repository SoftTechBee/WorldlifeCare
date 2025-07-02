using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class Admin_KYCPending : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
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
            string Sql = "SELECT  ROW_NUMBER() OVER (ORDER BY newId()) As serial, ";
            Sql += " CONVERT(varchar,TblKYC.AutoDate,106) As requestdate, ";
            Sql += " ('Pending') AS status, (TblKYC.UserName) as username, (register.Name) as fullname ";
            Sql += " FROM TblKYC INNER JOIN  register ON TblKYC.UserName = register.Username ";
            Sql += " Where TblKYC.IsStatus in (2,3) Order by TblKYC.AutoCode asc   ";
            if (txtsearch.Text.Length > 0)
            {
                Sql += "and username='" + txtsearch.Text + "'";
            }
            DataTable dt = objcon.ReturnDataTableSql(Sql);
            if (dt.Rows.Count > 0)
            {
                danger.Visible = false;
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }

            else
            {
                lbdanger.Text = "Opps! NO Data Found";
                danger.Visible = true;
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
           
            string id = e.CommandArgument.ToString();
           
            try
            {
                Response.Redirect("KYCShow.aspx?UserName=" + id);
                }


           

            catch (Exception ex)
            {

            }


        }
    }
    protected void btnSeach_Click(object sender, EventArgs e)
    {
        loadinactivememberlist();
    }
}