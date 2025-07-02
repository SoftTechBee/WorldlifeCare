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
using System.Drawing;
using System.Drawing.Drawing2D;
public partial class Admin_Popup : System.Web.UI.Page
{
    clsList objlist = new clsList();
    clsAMD objamd = new clsAMD();
    clsTimeZone objtime = new clsTimeZone();
    clsConnection objcon = new clsConnection();
    public List<clsuser> objuserlist = new List<clsuser>();
    clsDashboard objdash = new clsDashboard();
    clsmail objmail = new clsmail();
    clsValidation objValidation = new clsValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
         
            
        loadList();
        }
        if (IsPostBack && FileUploadPan.PostedFile != null)
        {
            if (FileUploadPan.PostedFile.FileName.Length > 0)

            {
                if (FileUploadPan.HasFile)
                {
                    //if (!objValidation.IsExtenstion(FileUploadPan, "Image"))
                    {

                        Stream strm = FileUploadPan.PostedFile.InputStream;
                        using (var image = System.Drawing.Image.FromStream(strm))
                        {
                            // Print Original Size of file (Height or Width)   
                            string ss = image.Size.ToString();
                            int newWidth = 600; // New Width of Image in Pixel  
                            int newHeight = 300; // New Height of Image in Pixel  
                            var thumbImg = new Bitmap(newWidth, newHeight);
                            var thumbGraph = Graphics.FromImage(thumbImg);
                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            thumbGraph.DrawImage(image, imgRectangle);
                            string imgurl = SessionData.Get<string>("Newuser") + "IMG" + FileUploadPan.FileName;

                            // Save the file  
                            string targetPath = Server.MapPath(@"../SoftImg/PopUp/") + imgurl;
                            thumbImg.Save(targetPath, image.RawFormat);
                            // Print new Size of file (height or Width)  
                            string newsize = thumbImg.Size.ToString();
                            //Show Image  
                            // Image1.ImageUrl = @"~\Images\" + FileUpload1.FileName;

                            ImgPan.Src = "../SoftImg/PopUp/" + imgurl;
                            hndPan.Value = "../SoftImg/PopUp/" + imgurl;
                        }








                    }
                }
            }
        }
        //if (IsPostBack && FileUploadPan.PostedFile != null)
        //{

        //    if (FileUploadPan.PostedFile.FileName.Length > 0)

        //    {
        //        if (FileUploadPan.HasFile)
        //        {
        //            if (!objValidation.IsExtenstion(FileUploadPan, "Image"))
        //            {
        //                string UploadedImageType = FileUploadPan.PostedFile.ContentType.ToString().ToLower();
        //                string UploadedImageFileName = FileUploadPan.PostedFile.FileName;

        //                //Create an image object from the uploaded file
        //                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileUploadPan.PostedFile.InputStream);

        //                string ThumbnailImage = System.IO.Path.GetFileName(FileUploadPan.PostedFile.FileName);
        //                string extenion = System.IO.Path.GetExtension(FileUploadPan.PostedFile.FileName);

        //                string imgurl = "AdminIMG" + ThumbnailImage;
        //                string imgPath = "../SoftImg/PopUp/" + imgurl;
        //                FileUploadPan.SaveAs(Server.MapPath(imgPath.Trim()));
        //                ImgPan.Src = imgPath;
        //                hndPan.Value = imgPath;


        //            }
        //        }
        //    }
        //}
    }

  
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int a = objamd.Slider(0, txttitle.Text, "", hndPan.Value, 0, "","", "", "A");
            if (a > 0)
            {
                loadList();
                lbinfo.Text = "Image insert successfully";
                info.Visible = true;
               
                bntsubmit.Text = "Save";
                //txtname.Text = "";
                hndPan.Value = "";
                txttitle.Text = "";
            }
            else if (a == -1)
            {
                lbinfo.Text = "Image Already Inserted";
                info.Visible = true;
                
            }
            else
            { 
                lbinfo.Text = "Image is not insert successfully";
                info.Visible = true;
                

            }
            loadList();
        }
        catch (Exception ex)
        { }
    }
    public void loadList()
    {
        try
        {
            string sql = "select * from tblpopup  order by pid desc";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                
            }
            else
            {
                
            }
            grdData.DataSource = dt;
            grdData.DataBind();




        }
        catch (Exception ex)
        {

        }


    }

    protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdData.PageIndex = e.NewPageIndex;
        //   this.BindGrid();
        loadList();
    }


    protected void grdData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            info.Visible = false;

            string sql = "Delete from tblpopup where pid='" + e.CommandArgument.ToString() + "'";
            int a = objcon.ExecuteSqlQuery(sql);
            if (a > 0)
            {
                lbinfo.Text = "Image Remove successfully";
                info.Visible = true;
                loadList();
            }
            else
            {
                lbinfo.Text = "Image has not remove successfully";
                info.Visible = true;
                loadList();
            }
        }

    }

    
}