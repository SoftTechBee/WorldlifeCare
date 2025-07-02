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
public partial class User_ProfilePic : System.Web.UI.Page
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
            if (SessionData.Get<string>("Newuser") == null)
            {
                Response.Redirect("logout.aspx");
            }
            else
            {
                String UserName = SessionData.Get<string>("Newuser");
                loadlist(UserName);

            }
        }
            if (IsPostBack && FileUploadChaque.PostedFile != null)
            {
                if (FileUploadChaque.PostedFile.ContentLength > 100000000000)
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.')", true);
                }

                else if (FileUploadChaque.PostedFile.FileName.Length < 100000000000)
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
                            string imgPath = "../SoftImg/Profile/" + imgurl;
                            FileUploadChaque.SaveAs(Server.MapPath(imgPath.Trim()));
                            ImgChaque.Src = imgPath;
                            hndcheque.Value = imgPath;


                        }
                    }
                }
            }

        
    }
    private void loadlist(string UserName)
    {
        try
        {

            string sql = "select profilepic from register where username='" + UserName + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {

                hndcheque.Value = dt.Rows[0]["profilepic"].ToString();
          
                ImgChaque.Src = hndcheque.Value;
            }



        }
        catch (Exception ex) { }
    }
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "update register set profilepic='" + hndcheque.Value + "' where username='" + SessionData.Get<string>("Newuser") + "' ";
            int a = objcon.ExecuteSqlQuery(sql);
             
             if (a > 0)
            {
                SessionData.Put("profilepic", hndcheque.Value);
                lbinfo.Text = "Profile Image Updated successfully";
                info.Visible = true;
                Clear();

            }
            else if (a == -1)
            {

                lbinfo.Text = "Profile Image already Updated successfully";
                info.Visible = true;
            }
            else
            {

                lbinfo.Text = "Profile Image has not Updated successfully";
                info.Visible = true;
            }
        }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
       


    }
    protected void btncencel_Click(object sender, EventArgs e)
    {
        Clear();

    }
   
}