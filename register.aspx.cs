using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using TripleITConnection;
using TripleITTransaction;
using System.Drawing;
using System.Threading.Tasks;

public partial class Signup : System.Web.UI.Page
{
    clsmail objmail = new clsmail();
    clsfunction objfun = new clsfunction();

    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    clsDashboard objdash = new clsDashboard();
    string Password = "", UserName = "", Sponserid = "", SponserName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCountry();
            drpcode.Text = "+1";

            lbsponserid.Text = Request.QueryString["Sponsor"].ToString();
            drpside.Text = Request.QueryString["Side"].ToString();
            DataTable dt2 = objcon.ReturnDataTableSql("select username,name from register where username='" + lbsponserid.Text + "' order by username asc");
            if (dt2.Rows.Count > 0)
            {
                lbSponsermsg.Text = dt2.Rows[0]["name"].ToString();

                btnRegister.Visible = true;

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Oops!', 'Invaild Sponsor.!'); ", true);

                lbsponserid.Text = "";
                lbSponsermsg.Text = "";
                lbsponserid.Focus();
                btnRegister.Visible = false;
            }

        }
    }

    protected void drpcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable dt2 = objcon.ReturnDataTableSql("select Country,code from tblcountry  where cid='" + drpcountry.SelectedValue + "' ");
            if (dt2.Rows.Count > 0)
            {
                drpcode.Text = "+" + dt2.Rows[0]["code"].ToString();
                Visible = true;
            }
            else
            {
                //code = "Invaild Sponser Name";
                //Visible = true;
            }
        }
        catch (Exception ex)
        { }
    }
    public void loadCountry()
    {

        DataTable dt1 = objcon.ReturnDataTableSql("select cid,Country,code from tblcountry  order by Country asc");
        drpcountry.DataSource = dt1;
        drpcountry.DataBind();
        drpcountry.Items.Insert(0, "Select Country");
        
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
            newuser = "WLC" + capta;
            DataTable dt1 = objcon.ReturnDataTableSql("select username from register where username='" + newuser + "'");
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



    
    private string genratepassword1()
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
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            if (drpside.Text != "Choose Position")
            {


                if (txtPassword.Text == txtConfirmPassword.Text)
                {

                    string side = drpside.Text;
                    UserName = loaduseridsixdigit();
                    string TransactionPassword = genratepassword1();

                    string DOJ = objtime.returnStringServerMachTime();
                    string DOB = "";


                    int a = objamd.Register(0, lbsponserid.Text, lbSponsermsg.Text, txtName.Text, UserName, txtPassword.Text, "", txtName.Text, side, DOJ, "", "", "", drpcountry.SelectedItem.Text, txtemail.Text, txtMobile.Text, "Not Active", "", "", "", "", "", "", "", DOB, "", "", "", "", "", "", DOJ, "", DOJ, TransactionPassword, "../SoftImg/NoImage.jpeg", lbsponserid.Text, lbSponsermsg.Text, "N");
                    if (a > 0)
                    {
                        objmail.sendpass(txtName.Text, UserName, txtPassword.Text, TransactionPassword, txtemail.Text.Trim());

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Success!', 'Registeration successfully! Please wait.............'); ", true);

                        Response.Redirect("msg.aspx?username=" + UserName + "&Tp=" + TransactionPassword + "&Pass=" + txtPassword.Text + "&Name=" + txtName.Text);



                    }
                    else if (a == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Oops!', 'Record already inserted Like- Email,Mobile?'); ", true);



                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Oops!', 'Record has not insert successfully? Try Again?'); ", true);


                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Oops!', 'Password does not match'); ", true);


                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Oops!', 'Select One Side Side Please!'); ", true);


            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Oops!', 'Try AGain!'); ", true);


        }
    }

    protected void txtMobile_TextChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable dt2 = objcon.ReturnDataTableSql("select mobile from register where mobile='" + txtMobile.Text + "'");
            if (dt2.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Already!', 'Mobile No. Already Exsits !!! Try Again With Another Number'); ", true);

               
                txtMobile.Text = "";
                txtMobile.Focus();
            }
            else
            {
            }

        }
        catch (Exception ex)
        { }
    }

    protected void txtemail_TextChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable dt2 = objcon.ReturnDataTableSql("select email from register where email='" + txtemail.Text + "'");
            if (dt2.Rows.Count > 3)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "showAlert('Already!', 'Email Already Exsits !!! Try Again With Another Email'); ", true);

                 txtemail.Text = "";
                txtemail.Focus();
            }
            else
            {
               
            }

        }
        catch (Exception ex)
        { }
    }
}