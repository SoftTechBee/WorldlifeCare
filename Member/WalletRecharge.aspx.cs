using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
public partial class User_WalletRecharge : System.Web.UI.Page
{
    clsTimeZone objtime = new clsTimeZone();
    clsConnection objcon = new clsConnection();
    clsValidation objValidation = new clsValidation();
    clsAMD objamd = new clsAMD();
    clsList objlist = new clsList();
    string Tid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.Get<string>("Newuser") == null && SessionData.Get<string>("Newuser") == "")
        {
            Response.Redirect("Logout.aspx");
        }
        else
        {
            if (!IsPostBack)
            {

                //ReffStatuscheked();
                //checkAccountStatus();
                product();
                myInput.Value = UPIID.Text;
                lbusername.Text = SessionData.Get<string>("newuser");
            }
            if (IsPostBack && FileUpload1.PostedFile != null)
            {

                if (FileUpload1.PostedFile.FileName.Length > 0)

                {
                    if (FileUpload1.HasFile)
                    {
                        if (!objValidation.IsExtenstion(FileUpload1, "Image"))
                        {
                            string UploadedImageType = FileUpload1.PostedFile.ContentType.ToString().ToLower();
                            string UploadedImageFileName = FileUpload1.PostedFile.FileName;

                            //Create an image object from the uploaded file
                            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);

                            string ThumbnailImage = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                            string extenion = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                            string imgurl = SessionData.Get<string>("Newuser") + "DRBReceiptAmount" + txtAmount.Text;
                            imgurl += ThumbnailImage;
                            string imgPath = "../SoftImg/Wallet/" + imgurl;
                            FileUpload1.SaveAs(Server.MapPath(imgPath.Trim()));
                            Image1.ImageUrl = imgPath;

                            hndurl.Value = imgPath;


                        }
                    }
                }
            }
        }
    }
    void product()
    {
        DataTable pro = objlist.CompanyBankMaster(0, "", "", "", "", "", "", "", "", "L");


        drpPaymentMode.DataSource = pro;


        drpPaymentMode.DataBind();
        drpPaymentMode.Items.Insert(0, "--Select--");
    }
    private void ReffStatuscheked()
    {
        try
        {
            string sql = "select reffstatus from register where username='" + SessionData.Get<string>("Newuser") + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {

                string reffstatus = dt.Rows[0][0].ToString();
                if (reffstatus == "Pending")
                {
                    lbdanger.Text = "Your account has not been confimed by the Sponsor !!! Please Contact to your Sponsor";
                    danger.Visible = true;
                    bntsubmit.Visible = false;

                }
                else
                {
                    bntsubmit.Visible = true;
                }
            }

        }
        catch (Exception ex)
        { }
    }

    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (hndurl.Value != "")
            {
                int a = objamd.RepuchaseRequest(0, SessionData.Get<string>("Newuser"), txtAmount.Text, hndurl.Value, "Pending", objtime.returnCurrentSurverTimeHHMM(), "", "", "", drpPaymentMode.SelectedItem.Text, txtremark.Text, "Repurchase", "N");
                if (a > 0)
                {
                    lbsuccess.Text = "Fund Request sent successfully !!!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick(); ", true);
                    success.Visible = true;
                    danger.Visible = false;

                    txtAmount.Text = "";
                    txtremark.Text = "";
                    drpPaymentMode.Text = "";

                }
                else if (a == -1)
                {
                    lbdanger.Text = "Fund Request already Sent !!!";
                    danger.Visible = true;
                    success.Visible = false;
                }
                else
                {
                    lbdanger.Text = "Unable to send Fund Request !!! Please Try Again";
                    danger.Visible = true;
                    success.Visible = false;
                }
            }
            else
            {
                lbdanger.Text = "Please Upload Transaction Reciept !!!";
                danger.Visible = true;
                success.Visible = false;
                return;

            }





        }
        catch (Exception ex)
        {
            //Response.Redirect("../error.aspx?error=" + ex.Message);
        }



    }
    protected void drpbankname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            DataTable pro = objlist.CompanyBankMaster(0, drpPaymentMode.SelectedItem.Text, "", "", "", "", "", "", "", "S");

            if (pro.Rows.Count > 0)
            {

                if (drpPaymentMode.SelectedItem.Text == "UPI")
                {
                    divbank.Visible = false;
                    divupi.Visible = true;
                    div1.Visible = true;

                    UPIID.Text = pro.Rows[0]["UPI"].ToString();
                    myInput.Value = UPIID.Text;
                    hndqr.Value = pro.Rows[0]["QRCode"].ToString();
                    ImgQR.Src = hndqr.Value;
                }
                else
                {

                    divbank.Visible = true;
                    divupi.Visible = false;
                    div1.Visible = false;

                    txtbankname.Text = pro.Rows[0]["Bankname"].ToString();
                    txtaccountnumber.Text = pro.Rows[0]["accountnumber"].ToString();
                    txtbranch.Text = pro.Rows[0]["branch"].ToString();
                    txtifsc.Text = pro.Rows[0]["ifsc"].ToString();
                    txtholdername.Text = pro.Rows[0]["holdername"].ToString();


                }
            }
            else
            {
                lbdanger.Text = "No Payment Mode Available !!! Please Contact Admin";
                danger.Visible = true;
            }





        }
        catch (Exception ex)
        {

        }

    }


    protected void btncencel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    public int checkAccountStatus()
    {
        int status = 0;
        try
        {
            string sql = "select status from tblkycmain where username='" + SessionData.Get<string>("Newuser") + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                string kycstatus = dt.Rows[0]["status"].ToString();
                if (kycstatus == "Approved")
                {
                    //  lbkyc.Text = "Your KYC has approved";
                    divkyc.Visible = false;
                }
                else
                {
                    //lbkyc.Text = "Your KYC has not approved ,please approved your kyc first";


                    divkyc.Visible = true;
                    lbdanger.Text = "Your KYC has not been Approved !";
                    danger.Visible = true;
                    success.Visible = false;
                    bntsubmit.Focus();
                    txtAmount.ReadOnly = true;




                }
                //genrateOTP();
                //string SMS = "For Member Active OTP is:" + OTP + " .Do not share it";
                //  objsms.sendsms(mobile, SMS);
            }
            else
            {
                divkyc.Visible = true;

            }


        }
        catch (Exception ex)
        { }
        return status;

    }
}