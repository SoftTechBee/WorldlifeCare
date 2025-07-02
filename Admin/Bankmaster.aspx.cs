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
public partial class Admin_Default2 : System.Web.UI.Page
{
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    clsSMS objsms = new clsSMS();
    clsValidation objValidation = new clsValidation();
    static string Password = "", id = "", dateofjoining = "", Profilepic = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessionData.Get<string>("newuser") == null)
            {
                Response.Redirect("logout.aspx");
            }
            else
            {
                String UserName = SessionData.Get<string>("newuser");
                loadlist();

            }
        }
        if (IsPostBack && FileUploadChaque.PostedFile != null)
        {
            if (FileUploadChaque.PostedFile.ContentLength > 1000000)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too Uniq.')", true);
            }

            else if (FileUploadChaque.PostedFile.FileName.Length < 1000000)
            {
                if (FileUploadChaque.HasFile)
                {
                    if (!objValidation.IsExtenstion(FileUploadChaque, "Image"))
                    {
                        string UploadedImageType = FileUploadChaque.PostedFile.ContentType.ToString().ToLower();
                        string UploadedImageFileName = FileUploadChaque.PostedFile.FileName;

                        //Create an image object from the uploaded file
                        System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileUploadChaque.PostedFile.InputStream);

                        string ThumbnailImage = System.IO.Path.GetFileName(FileUploadChaque.PostedFile.FileName);
                        string extenion = System.IO.Path.GetExtension(FileUploadChaque.PostedFile.FileName);
                        string imgurl = SessionData.Get<string>("Newuser") + "Img";
                        imgurl += ThumbnailImage;
                        string imgPath = "../SoftImg/Wallet/" + imgurl;
                        FileUploadChaque.SaveAs(Server.MapPath(imgPath.Trim()));
                        ImgQR.Src = imgPath;
                        hndqr.Value = imgPath;


                    }
                }
            }
        }


    }
   

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            string id = e.CommandArgument.ToString();
            objcon.ExecuteSqlQuery("delete from [TblBankMaster] where Bid='" + id + "'");

            lbinfo.Text = "Delete Successfully";
            info.Visible = true;
            loadlist();
        }

    }
    private void loadlist()
    {
        try
        {
            string sql = "select * from [TblBankMaster]";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }
        catch (Exception ex)
        { }
    }
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (drpBank.SelectedValue != "-1" )
           {
                int a = objamd.CompanyBankMaster(0, drpBank.SelectedItem.Text.Trim(), txtbankname.Text, txtbranch.Text, txtifsc.Text, txtaccountnumber.Text, txtholdername.Text, hndqr.Value, txtaddress.Text, "N");
                if (a > 0)
                {

                    lbinfo.Text = "Record Insert successfully";
                    info.Visible = true;
                    loadlist();

                }
                else if (a == -1)
                {

                    lbinfo.Text = "Record already Insert inserted";
                    info.Visible = true;
                    loadlist();
                }
                else
                {

                    lbinfo.Text = "Record has not Insert successfully";
                    info.Visible = true;
                    loadlist();
                }
            }
            else
            {
                lbinfo.Text = "Fill Correct Data!";
                info.Visible = true;
                loadlist();
            }

            
        }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
        txtaddress.Text = "";
        txtaccountnumber.Text = "";
        txtbranch.Text = "";
        txtifsc.Text = "";
        txtbranch.Text = "";
        txtholdername.Text = "";
        hndqr.Value = "";
        hndqr.Value = "";
        ImgQR.Src = "";
        info.Visible = false;

    }
    protected void btncencel_Click(object sender, EventArgs e)
    {
        Clear();

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
      
       // loadlist();
    }

    protected void drpBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        if (drpBank.SelectedValue == "0")
        {
            divbank.Visible = false;
            divupi.Visible = true;
        }
        else if (drpBank.SelectedValue == "1")
        {
            divbank.Visible = true;
            divupi.Visible = false;
        }
        if (drpBank.SelectedValue == "2")
        {
            divbank.Visible = false;
            divupi.Visible = true;
        }

    }
}