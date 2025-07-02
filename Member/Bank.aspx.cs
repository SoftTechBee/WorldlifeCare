using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using TripleITConnection;
using TripleITTransaction;
using Newtonsoft.Json;
public partial class User_Bank : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    clsValidation objValidation = new clsValidation();
    static string Password = "", id = "", dateofjoining = "", Profilepic = "";
    ClsDoopme objdoop = new ClsDoopme();
      protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Get<string>("Newuser") == null)
            {
                Response.Redirect("logout.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadBank();
                    String UserName = SessionData.Get<string>("Newuser");
                    loadlist(UserName);

                }
                //if (IsPostBack && FileUploadChaque.PostedFile != null)
                //{
                //    if (FileUploadChaque.PostedFile.ContentLength > 1000000)
                //    {
                //        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.')", true);
                //    }

                //    else if (FileUploadChaque.PostedFile.FileName.Length < 1000000)
                //    {
                //        if (FileUploadChaque.HasFile)
                //        {
                //            if (!objValidation.IsExtenstion(FileUploadChaque, "Image"))
                //            {
                //                string UploadedImageType = FileUploadChaque.PostedFile.ContentType.ToString().ToLower();
                //                string UploadedImageFileName = FileUploadChaque.PostedFile.FileName;

                //                //Create an image object from the uploaded file
                //                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileUploadChaque.PostedFile.InputStream);

                //                string ThumbnailImage = System.IO.Path.GetFileName(FileUploadChaque.PostedFile.FileName);
                //                string extenion = System.IO.Path.GetExtension(FileUploadChaque.PostedFile.FileName);
                //                string imgurl = SessionData.Get<string>("Newuser") + "AccAddImg";
                //                imgurl += ThumbnailImage;
                //                string imgPath = "../SoftImg/Bank/" + imgurl;
                //                FileUploadChaque.SaveAs(Server.MapPath(imgPath.Trim()));
                //                ImgChaque.Src = imgPath;
                //                hndcheque.Value = imgPath;


                //            }
                //        }
                //    }
                //}
            }
        }
        private void loadlist(string UserName)
        {
            try
            {

                string sql = "select b.*,r.mobile from bankdetail b inner join register r on b.username=r.username where b.username='" + UserName + "'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    txtAccNo.Text = dt.Rows[0]["accno"].ToString();
                    txtAHName.Text = dt.Rows[0]["holdername"].ToString();
                txtbank.Text = dt.Rows[0]["bankname"].ToString();
                    txtBranch.Text = dt.Rows[0]["branchname"].ToString();
                    txtIFSC.Text = dt.Rows[0]["ifsc"].ToString();
                    hndMobile.Value = dt.Rows[0]["mobile"].ToString();
                    string AccType = dt.Rows[0]["acctype"].ToString();
                    if (AccType == "Saving")
                    {
                        rdAccType.Items[0].Selected = true;
                    }
                    else
                    { rdAccType.Items[1].Selected = true; }

                  //  txtbitcoin.Text = dt.Rows[0]["AccountLink"].ToString();
                 //   hndcheque.Value = dt.Rows[0]["AccountImg"].ToString();
                    //lbstatus.Text = dt.Rows[0]["Status"].ToString();
                 //   ImgChaque.Src = hndcheque.Value;
                }



            }
            catch (Exception ex) { }
        }
        private void LoadBank()
        {
            //try
            //{
                
            //    string result = objdoop.GETBankList();
            //    var parentData = JsonConvert.DeserializeObject<RootBank>(result);

            //    drpBank.DataSource = parentData.NTDRESP.BANKLIST;
            //    drpBank.Items.Insert(0, "Select Bank");
            //    drpBank.DataBind();


            //}
            //catch (Exception ex)
            //{ }
        } 


        protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {


            int a = objamd.ModifyBankDetail(0, SessionData.Get<string>("Newuser"), txtAccNo.Text.Trim(), txtbank.Text, txtIFSC.Text.Trim(), txtBranch.Text.Trim(), txtAHName.Text.Trim(), rdAccType.SelectedItem.Text, "", "", "", "", "", "","", "U");

            if (a > 0)
            {
                

                lbinfo.Text = "Record Update successfully";
                info.Visible = true;


            }
            else if (a == -1)
            {

                lbinfo.Text = "Record already Update inserted";
                info.Visible = true;
            }
            else
            {

                lbinfo.Text = "Record has not Update successfully";
                info.Visible = true;
            }
        
    }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
        txtAccNo.Text = "";
        txtAHName.Text = "";
       // txtBank.Text = "";
        txtBranch.Text = "";
        txtIFSC.Text = "";
        //txtBitcoin.Text = "";
        //txtbhim.Text = "";
        //txtpaytm.Text = "";
        //txtPhonePay.Text = "";


    }
    protected void btncencel_Click(object sender, EventArgs e)
    {
        Clear();

    }
    
}

public class BANKLIST
{
    public string BANKID { get; set; }
    public string BANKCODE { get; set; }
    public string BANKNAME { get; set; }
    public string MIFSCCODE { get; set; }
    public string IMPS { get; set; }
    public string NEFT { get; set; }
    public string ACVERIFYAVAIL { get; set; }
    public string DISORDER { get; set; }
    public string STATUS { get; set; }
}

public class NTDRESP
{
    public string STATUSCODE { get; set; }
    public string STATUSMSG { get; set; }
    public List<BANKLIST> BANKLIST { get; set; }
}

public class RootBank
{
    public NTDRESP NTDRESP { get; set; }
}

public class NTDRESPAddCustomer
{
    public string STATUSCODE { get; set; }
    public string STATUSMSG { get; set; }
    public string OTPREQ { get; set; }
}

public class RootAddCustomer
{
    public NTDRESPAddCustomer NTDRESP { get; set; }
}

public class NTDRESPBeni
{
    public string STATUSCODE { get; set; }
    public string STATUSMSG { get; set; }
    public string BENEID { get; set; }
    public string OTPREQ { get; set; }
}

public class RootBeni
{
    public NTDRESPBeni NTDRESP { get; set; }
}

