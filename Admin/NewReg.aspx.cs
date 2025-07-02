using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TripleITConnection;
using TripleITTransaction;
using System.Data;
public partial class User_Default : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    clsDashboard objdash = new clsDashboard();
    string Password = "", UserName = "", Sponserid = "", SponserName = "";
    clsmail objmail = new clsmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (SessionData.Get<string>("Newuser") == null)
            {
                Response.Redirect("logout.aspx");
            }
            else
            {

                lbSponser.Text = "NG100001";
                lbUserName.Text = loaduseridsixdigit();
               try
                {

                    DataTable dt2 = objcon.ReturnDataTableSql("select username,name from register where username='" + lbSponser.Text + "' order by username asc");
                    if (dt2.Rows.Count > 0)
                    {
                        lbSponserName.Text = dt2.Rows[0]["name"].ToString();
                        Visible = true;
                    }
                    else
                    {
                        lbSponserName.Text = "Invaild Sponsor Name";
                        lbSponser.Text = "";
                        lbSponser.Focus();
                        Visible = true;
                    }

                }

                catch (Exception ex)
                { }
            }

        }
    }

    private string genratepassword()
    {
        string TransactionPassword = "";
        try
        {


            var chars = "5678943210";
            var stringChars = new char[4];
            var random = new Random();

            for (int ik = 0; ik < stringChars.Length; ik++)
            {
                stringChars[ik] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            TransactionPassword = Convert.ToString(finalString);

        }
        catch (Exception ex) { }
        return TransactionPassword;
    }


    public string loaduseridsixdigit()
    {
        string capta = "";
        string newuser = "";
        for (int i = 1; i <= 100; i++)
        {
            var chars = "0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int ik = 0; ik < stringChars.Length; ik++)
            {
                stringChars[ik] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            capta = Convert.ToString(finalString);
            newuser = "NG" + capta;
            DataTable dt1 = objcon.ReturnDataTableSql("select * from register where username='" + newuser + "'");
            if (dt1.Rows.Count > 0)
            {

            }
            else
            {
                i = 120;
            }
        }
        return newuser;

    }

    protected void drpSponser_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable dt2 = objcon.ReturnDataTableSql("select username,name from register where username='" + lbSponser.Text + "' order by username asc");
            if (dt2.Rows.Count > 0)
            {
                lbSponserName.Text = dt2.Rows[0]["name"].ToString();
                Visible = true;
            }
            else
            {
                lbSponserName.Text = "Invaild Sponsor Name";
                lbSponser.Text = "";
                lbSponser.Focus();
                Visible = true;
            }

        }
        catch (Exception ex)
        { }
    }

    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {
           
              
                    string TransactionPassword = genratepassword();
                  
                         UserName = loaduseridsixdigit();
                     string DOJ = objtime.returnStringServerMachTime();
            string DOB = "";
            string Side = drpside.SelectedValue;
                    string name = txtFirstName.Text ;
                    int a = objamd.Register(0, lbSponser.Text, lbSponserName.Text, name, UserName, txtPassword.Text, "", name, Side, DOJ, "","", "","", txtEmail.Text, txtMobile.Text, "Not Active", "", "", "", "", "", "","", DOB,"", "", "", "", "", "", DOJ, "", DOJ, TransactionPassword, "../dist/img/user2-160x160.jpg", "", "", "N");

                    if (a > 0)
                    {
                           
                           
                      
                        lbsuccess.Text = "Account Created : Username: "+ UserName + " & Password: "+ txtPassword.Text + "& Side: " + Side + " ";

                        sccess.Visible = true;

                    }
                    else if (a == -1)
                    {

                        lbinfo.Text = "Record already inserted";
                        info.Visible = true;
                    }
                    else
                    {

                        lbinfo.Text = "Record has not insert successfully";
                        info.Visible = true;
                    }

               
           
        }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
        Password = "";
       
        txtEmail.Text = "";
   
        txtMobile.Text = "";
       
       
        lbUserName.Text = "";
        lbSponserName.Text = "";
    
        lbSponser.Text = "";
        txtMobile.Text = "";
        

    }
   
}