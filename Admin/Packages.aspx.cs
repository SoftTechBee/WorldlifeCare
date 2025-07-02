using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITConnection;
using TripleITTransaction;

public partial class Member_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsDashboard objdashboard = new clsDashboard();
    clsList objlist = new clsList();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    CoinPayments objcoin = new CoinPayments();
    clsDashboard objDash = new clsDashboard();


    protected void Page_Load(object sender, EventArgs e)
    {
      
            try
            {
                if (!IsPostBack)
                {
                    string reqUser = Request.QueryString["Id"].ToString();
                    lbActiveMember.Text = reqUser ;
                txtcurrentpack.Text = objdashboard.ReturnLastPackName(lbActiveMember.Text);
                txtcurrentamt.Text = objdashboard.ReturnLastPackAmt(lbActiveMember.Text);
                loadPack();
                SessionData.Put("ActiveUser", lbActiveMember.Text);




            }
        }
            catch (Exception ex)
            { }
      
    }


    private void loadPack()
    {
        try
        {
            string sql = "select Pid,Product,Descrption,MRP,DOI,PackID,cast(PV as int) as PV,cast(BV as int) as BV,Matching,Capping from tblproduct";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
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



    protected void repPack_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
            int packid = Convert.ToInt32(e.CommandArgument.ToString());
            Label lbamount = e.Item.FindControl("lbamount") as Label;
            Label lbpack = e.Item.FindControl("lbpack") as Label;
          

            try
            {
                
                    //btnaction.Visible = false;
                    decimal widamount = 0, Min = 0, Max = 0;
                    string date = objtime.returnStringServerMachTime();
                    string PackType = lbpack.Text;

                    string Username = SessionData.Get<string>("newuser");
                    decimal finalamount = Convert.ToDecimal(1000000000);

                    widamount = Convert.ToDecimal(lbamount.Text);

                    if (finalamount >= widamount && widamount >= 100)
                    {


                        int a = objamd.ActiveMember(lbActiveMember.Text.Trim(), widamount, widamount, PackType, "Admin", "N");
                        if (a > 0)
                        {


                          
                            txtcurrentpack.Text = objdashboard.ReturnLastPackName(lbActiveMember.Text);
                            txtcurrentamt.Text = objdashboard.ReturnLastPackAmt(lbActiveMember.Text);
                            warning.Visible = false;
                            danger.Visible = false;
                            sccess.Visible = false;
                            info.Visible = false;
                            sccess.Visible = true;
                            lbsuccess.Text = "Congratulations! ID: "+ lbActiveMember.Text + " packages " + lbpack.Text + "  has been buy successfully.";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick(); ", true);
                        }
                        else if (a == -1)
                        {

                            warning.Visible = false;
                            danger.Visible = false;
                            sccess.Visible = false;
                            info.Visible = false;
                            info.Visible = true;

                            lbinfo.Text = "You have already buy this  " + lbpack.Text + " ! try another buy a pack!";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "warningclick(); ", true);
                           
                        }
                        else
                        {
                            warning.Visible = false;
                            danger.Visible = false;
                            sccess.Visible = false;
                            info.Visible = false;
                            warning.Visible = true;
                            lbwarning.Text = "Account active Not successfully";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "dangerlick(); ", true);
                          
                        }

                    }
                    else
                    {


                        warning.Visible = false;
                        danger.Visible = false;
                        sccess.Visible = false;
                        info.Visible = false;
                        warning.Visible = true;
                        lbwarning.Text = "Balance is less then to require amount  ";
                        lbfund.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "fundlick(); ", true);
                       
                    }
                  
            }
            catch (Exception ex)
            {
                warning.Visible = false;
                danger.Visible = false;
                sccess.Visible = false;
                info.Visible = false;
                lbwarning.Text = "Enter valid amount";
                warning.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "dangerlick(); ", true);
               
            }
            

        }
    }



    
}