using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITTransaction;
using TripleITConnection;
using System.Data;
public partial class Admin_Default2 : System.Web.UI.Page
{
    public static string pass = "";
    clsAMD objAMD = new clsAMD();
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    public static int Sid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loaddata();
            danger.Visible = false;
            info.Visible = false;
            warning.Visible = false;
            sccess.Visible = false;

        }
    }

    private void loaddata()
    {
        try
        {
            // int id = Convert.ToInt32(Session["Sid"]);
            DataTable dt = objcon.ReturnDataTableSql("select Username,Name,Mobile,Email from TblAdmin");
            if (dt.Rows.Count == 1)
            {
              
               
                txtuname.Text = dt.Rows[0]["UserName"].ToString();
                txtname.Text = dt.Rows[0]["Name"].ToString();
                txtmail.Text = dt.Rows[0]["Email"].ToString();
                txtmob.Text = dt.Rows[0]["Mobile"].ToString();
               
               // pass = dt.Rows[0]["Pass"].ToString();
                
               
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../error.aspx?error=" + ex.Message);

        }


    }


    protected void bntSearch_Click(object sender, EventArgs e)
    {

        


    }

    protected void bntchange_Click(object sender, EventArgs e)
    {
        try
        {


            int a = objcon.ExecuteSqlQuery("update tbladmin set UserName='"+txtuname.Text+"' , Name='" + txtname.Text + "',Mobile='" + txtmob.Text + "' ,Email='" + txtmail.Text + "' where Aid='1'"); 
                if (a == 1)
            {
                danger.Visible = false;
                info.Visible = false;
                warning.Visible = false;
                sccess.Visible = false;
                sccess.Visible = true;
                


            }
            else
            {

                danger.Visible = false;
                info.Visible = false;
                warning.Visible = false;
                sccess.Visible = false;
                danger.Visible = true;
            }

        }

        catch (Exception ex)
        {

            Response.Redirect("../error.aspx?error=" + ex.Message);

        }


    }
}