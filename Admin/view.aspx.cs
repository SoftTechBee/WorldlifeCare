using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TripleITConnection;
using TripleITTransaction;

public partial class Admin_Default2 : System.Web.UI.Page
{
    clsList objList = new clsList();
    clsAMD objAMD = new clsAMD();
    public  string Sql = "";
    public string UserName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Count == 0) { Response.Redirect("logout.aspx"); }
            UserName = Request.QueryString["id"].ToString();

            if (!IsPostBack)
            {
                
                FillFormKYC();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    private void FillFormKYC()
    {
        Sql = "SELECT TblKYC.*, register.Name";
        Sql += " FROM TblKYC INNER JOIN register ON TblKYC.UserName = register.Username";
        Sql += " Where TblKYC.UserName='" + UserName + "'";
        DataTable Rs = objList.RetrunSqlDataList(Sql);
        if (Rs.Rows.Count != 0)
        {

            lblUserName.InnerHtml = Rs.Rows[0]["UserName"].ToString();
            lblFullName.InnerHtml = Rs.Rows[0]["Name"].ToString();
            lblAccountType.InnerHtml = Rs.Rows[0]["AccountType"].ToString();
            lblAccountHolderName.InnerHtml = Rs.Rows[0]["AccountHolderName"].ToString();
            lblBankName.InnerHtml = Rs.Rows[0]["BankName"].ToString();
            lblBranch.InnerHtml = Rs.Rows[0]["BranchName"].ToString();
            lblAccountNumber.InnerHtml = Rs.Rows[0]["AccountNumber"].ToString();
            lblIFSC.InnerHtml = Rs.Rows[0]["IFSC"].ToString();

            if (Rs.Rows[0]["BankStatus"].ToString() == "Approved")
            {
                lblBankStatus.InnerHtml = "<span class='label label-success font-weight-100'>Verified</span>";
            }
            else if (Rs.Rows[0]["BankStatus"].ToString() == "Pending")
            {
                lblBankStatus.InnerHtml = "<span class='label label-default font-weight-100'>Pending</span>";
            }
            else
            {
                lblBankStatus.InnerHtml = "<span class='label label-danger font-weight-100'>Rejected</span>";
            }

            if (Rs.Rows[0]["BankStatus"].ToString() == "Approved")
            {
                lblisapproved.Visible = false;
                btnBankApproved.Visible = false;
                btnBankReject.Visible = false;
            }
            if (Rs.Rows[0]["ImagePassbook"].ToString() != "")
            {
                imgpasbook.Src = "../SoftImg/KYC/" + Rs.Rows[0]["ImagePassbook"].ToString();
                ViewPassbook.HRef = "../SoftImg/KYC/" + Rs.Rows[0]["ImagePassbook"].ToString();
            }
            /////ADHaar Card

            lblAdharFront.InnerHtml = Rs.Rows[0]["AdhaarCardNumber"].ToString();
            if (Rs.Rows[0]["AdhaarFront"].ToString() != "")
            {
                imgAdhaarFront.Src = "../SoftImg/KYC/" + Rs.Rows[0]["AdhaarFront"].ToString();
                ViewAdhaarFront.HRef = "../SoftImg/KYC/" + Rs.Rows[0]["AdhaarFront"].ToString();
            }

            if (Rs.Rows[0]["AdhaarFrontStatus"].ToString() == "Approved")
            {
                lblAdharFrontStatus.InnerHtml = "<span class='label label-success font-weight-100'>Verified</span>";
                lblAdharBackStatus.InnerHtml = "<span class='label label-success font-weight-100'>Verified</span>";
            }
            else if (Rs.Rows[0]["AdhaarFrontStatus"].ToString() == "Pending")
            {
                lblAdharFrontStatus.InnerHtml = "<span class='label label-default font-weight-100'>Pending</span>";
                lblAdharBackStatus.InnerHtml = "<span class='label label-default font-weight-100'>Pending</span>";
            }
            else
            {
                lblAdharFrontStatus.InnerHtml = "<span class='label label-danger font-weight-100'>Rejected</span>";
                lblAdharBackStatus.InnerHtml = "<span class='label label-danger font-weight-100'>Rejected</span>";
            }

            if (Rs.Rows[0]["AdhaarFrontStatus"].ToString() == "Approved")
            {
                btnFrontApproved.Visible = false;
                btnFrontReject.Visible = false;
            }

            if (Rs.Rows[0]["AdhaarBack"].ToString() != "")
            {
                imgAdhaarBack.Src = "../SoftImg/KYC/" + Rs.Rows[0]["AdhaarBack"].ToString();
                ViewAdhaarBack.HRef = "../SoftImg/KYC/" + Rs.Rows[0]["AdhaarBack"].ToString();
            }



            ///------------============= PenCardNo card details-----===========

            lblPenCardNo.InnerHtml = Rs.Rows[0]["PanNumber"].ToString();
            if (Rs.Rows[0]["PanImage"].ToString() != "")
            {
                imgPencard.Src = "../SoftImg/KYC/" + Rs.Rows[0]["PanImage"].ToString();
                ViewPan.HRef = "../SoftImg/KYC/" + Rs.Rows[0]["PanImage"].ToString();
            }


            if (Rs.Rows[0]["PanStatus"].ToString() == "Approved")
            {
                 lblPanStatus.InnerHtml = "<span class='label label-success font-weight-100'>Verified</span>";
            }
            else if (Rs.Rows[0]["PanStatus"].ToString() == "Pending")
            {
                 lblPanStatus.InnerHtml = "<span class='label label-default font-weight-100'>Pending</span>";
            }
            else
            {
                lblPanStatus.InnerHtml = "<span class='label label-danger font-weight-100'>Rejected</span>";
            }

            if (Rs.Rows[0]["PanStatus"].ToString() == "Approved")
            {

                btnPanApproved.Visible = false;
                btnPanReject.Visible = false;
            }
        }
    }

    protected void btnBankApproved_Click(object sender, EventArgs e)
    {
        try
        {
            Sql = "Update TblKYC Set BankStatus ='Approved' Where UserName ='" + UserName + "'";
            Sql += " Update TblKyc Set IsStatus = 1 ";
            Sql += " Where BankStatus ='Approved'"; 
            Sql += " And AdhaarFrontStatus ='Approved'";  
            Sql += " And PanStatus ='Approved'";
            Sql += " And UserName ='" + UserName + "'";
            objAMD.AMD(Sql);

            FillFormKYC();

            lbsuccess.Text = "Bank details has been verified";
            sccess.Visible = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Bank details has been verified'); ", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }


    protected void btnFrontApproved_Click(object sender, EventArgs e)
    {
        try
        {
            Sql = "Update TblKYC Set AdhaarFrontStatus ='Approved' ,AdhaarBackStatus ='Approved' Where UserName ='" + UserName + "'";
            Sql += " Update TblKyc Set IsStatus = 1 ";
            Sql += " Where BankStatus ='Approved'";
            Sql += " And AdhaarFrontStatus ='Approved'";
            Sql += " And PanStatus ='Approved'";
            Sql += " And UserName ='" + UserName + "'";
            objAMD.AMD(Sql);
            FillFormKYC();

            lbsuccess.Text = "Adhaar details has been verified";
            sccess.Visible = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Adhaar details has been verified'); ", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }


    protected void btnBackApproved_Click(object sender, EventArgs e)
    {
        try
        {
            Sql ="Update TblKYC Set AdhaarBackStatus ='Approved' Where UserName ='" +UserName + "'";
            Sql += " Update TblKyc Set IsStatus = 1 ";
            Sql += " Where BankStatus ='Approved'";
            Sql += " And AdhaarFrontStatus ='Approved'";
            Sql += " And PanStatus ='Approved'";
            Sql += " And UserName ='" + UserName + "'";
            objAMD.AMD(Sql);
            FillFormKYC();

            lbsuccess.Text = "Bank details has been verified";
            sccess.Visible = true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }


    protected void btnPanApproved_Click(object sender, EventArgs e)
    {
        try
        {
            Sql ="Update TblKYC Set PanStatus ='Approved' Where UserName ='" +UserName + "'";
            Sql += " Update TblKyc Set IsStatus = 1 ";
            Sql += " Where BankStatus ='Approved'";
            Sql += " And AdhaarFrontStatus ='Approved'";
            Sql += " And PanStatus ='Approved'";
            Sql += " And UserName ='" + UserName + "'";
            objAMD.AMD(Sql);

            FillFormKYC();

            lbsuccess.Text = "Pan details has been verified";
            sccess.Visible = true;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Pan details has been verified'); ", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }


    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            if (hndTitle.Value == "Bank Details")
            {
                Sql = "Update TblKYC Set  IsStatus = 3 , BankStatus ='Reject', BankRemarks ='" + txtremarks.InnerText + "' Where UserName ='" + UserName + "'";
            }
            else if (hndTitle.Value == "Adhaar Card")
            {
                Sql = "Update TblKYC Set  IsStatus = 3 , AdhaarFrontStatus ='Reject',AdhaarBackStatus ='Reject' , AdhaarFrontRemarks ='" + txtremarks.InnerText + "' Where UserName ='" + UserName + "'";
            }
            else if (hndTitle.Value == "Voter Card")
            {
                Sql = "Update TblKYC Set  IsStatus = 3 , VoterFrontStatus ='Reject',VoterBackStatus ='Reject' , VoterFrontRemarks ='" + txtremarks.InnerText + "' Where UserName ='" + UserName + "'";
            }
            else if (hndTitle.Value == "Driving License")
            {
                Sql = "Update TblKYC Set  IsStatus = 3 , DrivingFrontStatus ='Reject',DrivingBackStatus ='Reject' , DrivingFrontRemarks ='" + txtremarks.InnerText + "' Where UserName ='" + UserName + "'";
            }
            else if (hndTitle.Value == "Passport Card")
            {
                Sql = "Update TblKYC Set  IsStatus = 3 , PassportFrontStatus ='Reject',PassportBackStatus ='Reject' , PassportFrontRemarks ='" + txtremarks.InnerText + "' Where UserName ='" + UserName + "'";
            }
            else 
            {
                Sql = "Update TblKYC Set IsStatus = 3 , PanStatus ='Reject' , PanRemarks ='" + txtremarks.InnerText + "' Where UserName ='" + UserName + "'";
            }
            
            objAMD.AMD(Sql);
            FillFormKYC();

            if (hndTitle.Value == "Bank Details")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Bank details has been rejected'); ", true);
            }
            else if (hndTitle.Value == "Adhaar Card")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Adhaar details has been rejected'); ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "Successclick('Pan details has been rejected'); ", true);
            }
            
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }


}