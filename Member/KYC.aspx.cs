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

public partial class Member_Default2 : System.Web.UI.Page
{
    clsList objList = new clsList();
    clsAMD objAMD = new clsAMD();
    clsDashboard objDash = new clsDashboard();
    string Sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["newuser"] == null)
            {
                Response.Redirect("../logout.aspx");
            }

            if (!IsPostBack) { FillFormKYC(); }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    public void FillFormKYC()
    {
        Sql = "Select * From TblKYC Where UserName ='" + Session["newuser"].ToString() + "'";
        DataTable Rs = objList.RetrunSqlDataList(Sql);
        if (Rs.Rows.Count != 0)
        {
            AccountType.Value = Rs.Rows[0]["AccountType"].ToString();
            txtBankName.Value = Rs.Rows[0]["BankName"].ToString();
            txtBranchName.Value = Rs.Rows[0]["BranchName"].ToString();
            txtAccountHolderName.Value = Rs.Rows[0]["AccountHolderName"].ToString();
            txtAccountNumber.Value = Rs.Rows[0]["AccountNumber"].ToString();
            txtIFSC.Value = Rs.Rows[0]["IFSC"].ToString();
            //txtPaytm.Value = Rs.Rows[0]["Paytm"].ToString();
            //txtPhonePay.Value = Rs.Rows[0]["phonepay"].ToString();
            //txtGpay.Value = Rs.Rows[0]["Bhim"].ToString();

            txtAdhaarNumber.Value = Rs.Rows[0]["AdhaarCardNumber"].ToString();
           txtPanCardNumber.Value = Rs.Rows[0]["PanNumber"].ToString();
            // Images
            if (Rs.Rows[0]["ImagePassbook"].ToString() != "") { imgPassbook.Src = "../SoftImg/KYC/" + Rs.Rows[0]["ImagePassbook"].ToString(); }
            
            
            if (Rs.Rows[0]["AdhaarFront"].ToString() != "") { imgadharfront.Src = "../SoftImg/KYC/" + Rs.Rows[0]["AdhaarFront"].ToString(); }

            if (Rs.Rows[0]["AdhaarBack"].ToString() != "") { imgadharback.Src = "../SoftImg/KYC/" + Rs.Rows[0]["AdhaarBack"].ToString(); }
           
                if (Rs.Rows[0]["PanImage"].ToString() != "") { imgPancard.Src = "../SoftImg/KYC/" + Rs.Rows[0]["PanImage"].ToString(); }

            if (Rs.Rows[0]["IsStatus"].ToString() == "1")
            {
                IsVerified.Visible = true;

                ActionBank.Visible = false;
                ActionAdhaar.Visible = false;
                ActionPan.Visible = false;
            }  
            else
            {
                if (Rs.Rows[0]["BankStatus"].ToString() == "Approved") { ActionBank.Visible = false; }
                if (Rs.Rows[0]["AdhaarFrontStatus"].ToString() == "Approved") { ActionAdhaar.Visible = false; }
              if (Rs.Rows[0]["PanStatus"].ToString() == "Approved") { ActionPan.Visible = false; }

                // Reject
                if (Rs.Rows[0]["BankStatus"].ToString() == "Reject") { BankReject.Visible = true; }
                if (Rs.Rows[0]["AdhaarFrontStatus"].ToString() == "Reject") { AdhaarReject.Visible = true; }
               if (Rs.Rows[0]["PanStatus"].ToString() == "Reject") { PanReject.Visible = true; }
            }
        }
    }

    protected void bntBank_Click(object sender, EventArgs e)
    {
        try
        {
            string Passbook = "";

            if (FilePassbook.HasFile)
            {
                string UploadedImageType = FilePassbook.PostedFile.ContentType.ToString().ToLower();
                string UploadedImageFileName = FilePassbook.PostedFile.FileName;

                //Create an image object from the uploaded file
                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FilePassbook.PostedFile.InputStream);

                Passbook = SessionData.Get<string>("Newuser") + "-Pass-Book-" + System.IO.Path.GetFileName(FilePassbook.PostedFile.FileName);
                string imgPath = "../SoftImg/KYC/" + Passbook;

                FilePassbook.SaveAs(Server.MapPath(imgPath.Trim()));
            }

            int status = objAMD.KYCBank(Session["newuser"].ToString(),
                                        AccountType.Value,
                                        txtBankName.Value,
                                        txtBranchName.Value,
                                        txtAccountNumber.Value,
                                        txtIFSC.Value,
                                        txtAccountHolderName.Value,
                                      
                                        Passbook, "N");
            if (status >0)
            {
                FillFormKYC();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Bank details has been submited'); ", true);

            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    protected void bntAdhaar_Click(object sender, EventArgs e)
    {
        try
        {
            string FrontImage = "";
            string BackImage = "";

            if (FileFrontAdhaar.HasFile)
            {
                string UploadedImageType = FileFrontAdhaar.PostedFile.ContentType.ToString().ToLower();
                string UploadedImageFileName = FileFrontAdhaar.PostedFile.FileName;

                //Create an image object from the uploaded file
                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileFrontAdhaar.PostedFile.InputStream);

                FrontImage = SessionData.Get<string>("Newuser") + "-Front-Adhaar-Card-" + System.IO.Path.GetFileName(FileFrontAdhaar.PostedFile.FileName);
                string imgPath = "../SoftImg/KYC/" + FrontImage;

                FileFrontAdhaar.SaveAs(Server.MapPath(imgPath.Trim()));
            }

            if (FileBackAdhaar.HasFile)
            {
                string UploadedImageType = FileBackAdhaar.PostedFile.ContentType.ToString().ToLower();
                string UploadedImageFileName = FileBackAdhaar.PostedFile.FileName;

                //Create an image object from the uploaded file
                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileBackAdhaar.PostedFile.InputStream);

                BackImage = SessionData.Get<string>("Newuser") + "-Back-Adhaar-Card-" + System.IO.Path.GetFileName(FileBackAdhaar.PostedFile.FileName);
                string imgPath = "../SoftImg/KYC/" + BackImage;

                FileBackAdhaar.SaveAs(Server.MapPath(imgPath.Trim()));
            }

            int status = objAMD.KYCAdhaar(Session["newuser"].ToString(), txtAdhaarNumber.Value, FrontImage, BackImage, "N");
            if (status == 1) {
                FillFormKYC(); 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Adhaar details has been submited'); ", true);
                
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    protected void bntPan_Click(object sender, EventArgs e)
    {
        try
        {
            string PanImage = "";

            if (FilePanCard.HasFile)
            {
                string UploadedImageType = FilePanCard.PostedFile.ContentType.ToString().ToLower();
                string UploadedImageFileName = FilePanCard.PostedFile.FileName;

                //Create an image object from the uploaded file
                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FilePanCard.PostedFile.InputStream);

                PanImage = SessionData.Get<string>("Newuser") + "-Pan-Card-" + System.IO.Path.GetFileName(FilePanCard.PostedFile.FileName);
                string imgPath = "../SoftImg/KYC/" + PanImage;

                FilePanCard.SaveAs(Server.MapPath(imgPath.Trim()));
            }
            int SamePan = Convert.ToInt32(objDash.SamePancard(txtPanCardNumber.Value));
            if (SamePan <= 3)
            {
                int status = objAMD.KYCPAN(Session["newuser"].ToString(), txtPanCardNumber.Value, PanImage, "N");
                if (status == 1)
                {
                    FillFormKYC();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Pan details has been submited'); ", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('this PanNumber Already used for 6 times..! try Another Pan Number'); ", true);

            }


        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }





    //   protected void btnVoter_Click(object sender, EventArgs e)
    //  {
    //    try
    //    {
    //        string VoterFront = "";
    //        string VoterBack = "";

    //        if (FileVoter.HasFile)
    //        {
    //            string UploadedImageType = FileVoter.PostedFile.ContentType.ToString().ToLower();
    //            string UploadedImageFileName = FileVoter.PostedFile.FileName;

    //            //Create an image object from the uploaded file
    //            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileVoter.PostedFile.InputStream);

    //            VoterFront = SessionData.Get<string>("Newuser") + "-Voter-Card-front-" + System.IO.Path.GetFileName(FileVoter.PostedFile.FileName);
    //            string imgPath = "../SoftImg/KYC/" + VoterFront;

    //            FileVoter.SaveAs(Server.MapPath(imgPath.Trim()));
    //        }
    //        if (FileVoterBack.HasFile)
    //        {
    //            string UploadedImageType = FileVoterBack.PostedFile.ContentType.ToString().ToLower();
    //            string UploadedImageFileName = FileVoterBack.PostedFile.FileName;

    //            //Create an image object from the uploaded file
    //            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileVoterBack.PostedFile.InputStream);

    //            VoterBack = SessionData.Get<string>("Newuser") + "voter-Back-Card-" + System.IO.Path.GetFileName(FileVoterBack.PostedFile.FileName);
    //            string imgPath = "../SoftImg/KYC/" + VoterBack;

    //            FileVoterBack.SaveAs(Server.MapPath(imgPath.Trim()));
    //        }
    //        int SamePan = Convert.ToInt32(objDash.SameVotercard(txtVoterNumber.Value));
    //        if (SamePan <= 3)
    //        {
    //            int status = objAMD.KYCVOTER(Session["newuser"].ToString(), txtVoterNumber.Value, VoterBack,VoterFront, "N");
    //            if (status == 1)
    //            {
    //                FillFormKYC();
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Voter details has been submited'); ", true);
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('this Voter Already used for 6 times..! try Another Voter Number'); ", true);

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.WriteLine(ex.Message);
    //    }
    //}

    //protected void btndriving_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string DrivingFront = "";
    //        string DrivingBack = "";

    //        if (FileDriving.HasFile)
    //        {
    //            string UploadedImageType = FileDriving.PostedFile.ContentType.ToString().ToLower();
    //            string UploadedImageFileName = FileDriving.PostedFile.FileName;

    //            //Create an image object from the uploaded file
    //            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileDriving.PostedFile.InputStream);

    //            DrivingFront = SessionData.Get<string>("Newuser") + "-Driving-front-Card-" + System.IO.Path.GetFileName(FileDriving.PostedFile.FileName);
    //            string imgPath = "../SoftImg/KYC/" + DrivingFront;

    //            FileDriving.SaveAs(Server.MapPath(imgPath.Trim()));
    //        }

    //        if (FileDrivingBack.HasFile)
    //        {
    //            string UploadedImageType = FileDrivingBack.PostedFile.ContentType.ToString().ToLower();
    //            string UploadedImageFileName = FileDrivingBack.PostedFile.FileName;

    //            //Create an image object from the uploaded file
    //            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FileDrivingBack.PostedFile.InputStream);

    //            DrivingBack = SessionData.Get<string>("Newuser") + "Driving-Back-Card-" + System.IO.Path.GetFileName(FileDrivingBack.PostedFile.FileName);
    //            string imgPath = "../SoftImg/KYC/" + DrivingBack;

    //            FileDrivingBack.SaveAs(Server.MapPath(imgPath.Trim()));
    //        }
    //        int SamePan = Convert.ToInt32(objDash.SameDrivingcard(txtDrivingNumber.Value));
    //        if (SamePan <= 3)
    //        {
    //            int status = objAMD.KYCDRIVING(Session["newuser"].ToString(), txtDrivingNumber.Value, DrivingBack, DrivingFront, "N");
    //            if (status == 1)
    //            {
    //                FillFormKYC();
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Driving License details has been submited'); ", true);
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('this Driving License Already used for 6 times..! try Another Driving License'); ", true);

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.WriteLine(ex.Message);
    //    }
    //}


    //protected void btnPassport_Click(object sender, EventArgs e)


    //{
    //    try
    //    {
    //        string PassportFront = "";
    //        string PassportBack = "";

    //        if (FilePassport.HasFile)
    //        {
    //            string UploadedImageType = FilePassport.PostedFile.ContentType.ToString().ToLower();
    //            string UploadedImageFileName = FilePassport.PostedFile.FileName;

    //            //Create an image object from the uploaded file
    //            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FilePassport.PostedFile.InputStream);

    //            PassportFront = SessionData.Get<string>("Newuser") + "-Passport-front-Card-" + System.IO.Path.GetFileName(FilePassport.PostedFile.FileName);
    //            string imgPath = "../SoftImg/KYC/" + PassportFront;

    //            FilePassport.SaveAs(Server.MapPath(imgPath.Trim()));
    //        }
    //        if (FilePassportBack.HasFile)
    //        {
    //            string UploadedImageType = FilePassportBack.PostedFile.ContentType.ToString().ToLower();
    //            string UploadedImageFileName = FilePassportBack.PostedFile.FileName;

    //            //Create an image object from the uploaded file
    //            System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(FilePassportBack.PostedFile.InputStream);

    //            PassportBack = SessionData.Get<string>("Newuser") + "Passport-Back-Card-" + System.IO.Path.GetFileName(FilePassportBack.PostedFile.FileName);
    //            string imgPath = "../SoftImg/KYC/" + PassportBack;

    //            FilePassportBack.SaveAs(Server.MapPath(imgPath.Trim()));
    //        }
    //        int SamePan = Convert.ToInt32(objDash.SamePancard(txtVoterNumber.Value));
    //        if (SamePan <= 3)
    //        {
    //            int status = objAMD.KYCPASSPORT(Session["newuser"].ToString(), txtPassportNumber.Value, PassportFront,PassportBack, "N");
    //            if (status == 1)
    //            {
    //                FillFormKYC();
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Passport details has been submited'); ", true);
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('this Passport Already used for 6 times..! try Another Passport Number'); ", true);

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.WriteLine(ex.Message);
    //    }

    //}
}