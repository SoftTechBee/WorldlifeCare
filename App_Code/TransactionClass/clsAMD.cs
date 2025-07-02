using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.IO;
using TripleITConnection;
using System.Globalization;
//Lalit Kumar Verma 16-02-09

namespace TripleITTransaction
{
    public class clsAMD
    {
        clsConnection ObjConnection = new clsConnection();
        clsValidation ObjValid = new clsValidation();
        clsTimeZone objtime = new clsTimeZone();

        public int AMDSql(string Sql)
        {
            try
            {
                int status;
                status = ObjConnection.ExecuteSqlQuery(Sql);
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetRecord(string Sql)
        {
            return ObjConnection.ReturnDataTableSql(Sql);
        }

        public void AMD(string Sql)
        {
            try
            {
                ObjConnection.ExecuteSqlQuery(Sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //updatetotalrecordbinary count Function
        public int increasedailybinarycount(string username, string Amount, string Type)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            SqlParameter ptrAmount = new SqlParameter("@AMOUNTT", Amount);
            SqlParameter ptrType = new SqlParameter("@Type", Type);
            int a = ObjConnection.ExecuteProcedure("increasedailybinarycount", ptrusername, ptrAmount, ptrType);

            return a;


        }
        public int SetOffer(string username, string Amount)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            SqlParameter ptrAmount = new SqlParameter("@AMOUNTT", Amount);           
            int a = ObjConnection.ExecuteProcedure("SETOFFERMONTHLY", ptrusername, ptrAmount);

            return a;


        }
        public int totalcount(string username)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);

            int a = ObjConnection.ExecuteProcedure("Companybusiness", ptrusername);

            return a;


        }
        public int regi(string username)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);

            int a = ObjConnection.ExecuteProcedure("regi", ptrusername);

            return a;


        }
        public int DirectTransfer(string username)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            int a = ObjConnection.ExecuteProcedure("DirectTransfer", ptrusername);
            return a;


        }
        public int BINARYTransfer(string fromdate ,string todate)
        {

            SqlParameter ptmfromdate = new SqlParameter("@Fromdate", fromdate);
            SqlParameter ptmtodate = new SqlParameter("@Todate", todate);
            int a = ObjConnection.ExecuteProcedure("BinaryTransfer", ptmfromdate,ptmtodate);
            return a;


        }
        public int AMDPageContent(int PageCode, string PageData, string Images, string SeoTitle,
                                   string seoKeyword, string SeoDescription)
        {
            try
            {
                int status;
                SqlParameter prmPageCode = new SqlParameter("@PageCode", PageCode);
                SqlParameter prmPageData = new SqlParameter("@PageData", PageData);
                SqlParameter prmImage = new SqlParameter("@Image", Images);
                SqlParameter prmSeoTitle = new SqlParameter("@SeoTitle", SeoTitle);
                SqlParameter prmSeoKeyword = new SqlParameter("@SeoKeyword", seoKeyword);
                SqlParameter prmSeoDescription = new SqlParameter("@SeoDescription", SeoDescription);
                status = ObjConnection.ExecuteProcedure("PageContent", prmPageCode, prmPageData, prmImage, prmSeoTitle, prmSeoKeyword, prmSeoDescription);
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
       
        //updatetotalrecordbinary count Function
        public int updatetotalrecordbinary(string username)
        {
           
            SqlParameter ptrusername = new SqlParameter("@USERNAME",username);
            
            int a = ObjConnection.ExecuteProcedure("updatetotalbinarycount",ptrusername);

            return a;
        

        }
        //TRANSFER TO PASSBOOK all income
        public int transfertopassbook10day()
        {
            string backdate = DateTime.Now.AddHours(-253).ToString("yyyy-MM-dd");
           // DateTime TDATE = Convert.ToDateTime(backdate);
            SqlParameter ptrtdate = new SqlParameter("@tdate",backdate);

            int a = ObjConnection.ExecuteProcedure("passbook", ptrtdate);

            return a;


        }
        
        //TRANSFER TO PASSBOOK only first income
        public int transfertopassbookclube()
        {
            string backdate = DateTime.Now.AddHours(0).ToString("yyyy-MM-dd");
            //DateTime TDATE = Convert.ToDateTime(backdate);
            SqlParameter ptrtdate = new SqlParameter("@tdate", backdate);
            int a = ObjConnection.ExecuteProcedure(" clubPassbook", ptrtdate);
            return a;
        }
        //TRANSFER TO PASSBOOK Direct income
        public int transfertopassbook(string fromdate ,string todate)
        {
           
            SqlParameter ptmtodate = new SqlParameter("@Todate", todate);
            SqlParameter ptmfromdate = new SqlParameter("@Fromdate", fromdate);
            int a = ObjConnection.ExecuteProcedure("TransPassbook", ptmfromdate,ptmtodate);
            return a;
        }

        //TRANSFER TO Account All type income
        public int Account(string username,string income,string incometype,string cid)
        {
            string backdate = DateTime.Now.AddHours(0).ToString("yyyy-MM-dd");
            SqlParameter ptmusername = new SqlParameter("@Username", username);
            SqlParameter ptmincome = new SqlParameter("@Income",income);
            SqlParameter ptmincometype = new SqlParameter("@IncomeType",incometype);
            SqlParameter ptrtdate = new SqlParameter("@DOI", backdate);
            SqlParameter ptrCid = new SqlParameter("@Cid", cid);
            int a = ObjConnection.ExecuteProcedure("AccountP", ptmusername,ptmincome,ptmincometype, ptrtdate,ptrCid);
            return a;
        }
        public int DOCupload(int mid, string UserName, string imagename, string url, string Status, string Remark,
           DateTime DOU, string Transaction)
        {

            SqlParameter ptrmid = new SqlParameter("Kid", mid);
            SqlParameter ptrusername = new SqlParameter("UserName", UserName);
            SqlParameter ptrimagename = new SqlParameter("DocName", imagename);
            SqlParameter ptrurl = new SqlParameter("DocLink", url);
            SqlParameter ptrStatus = new SqlParameter("DocStatus", Status);
            SqlParameter ptrRemark = new SqlParameter("Remark", Remark);
            SqlParameter ptrDOU = new SqlParameter("DOU", DOU);
            SqlParameter ptrTransaction = new SqlParameter("Transaction", Transaction);
            int a = ObjConnection.ExecuteProcedure("KYC", ptrmid, ptrusername, ptrimagename, ptrurl, ptrStatus, ptrRemark, ptrDOU, ptrTransaction);

            return a;

        }
        //TRANSFER TO Account Pin Income income
        public int setPinIncome(string userName, int pinAmount,int totalPin)
        {


            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            SqlParameter ptmPinAmount = new SqlParameter("@PinAmount", pinAmount);
            SqlParameter ptmTotalPin = new SqlParameter("@TotalPin", totalPin);
            int a = ObjConnection.ExecuteProcedure("setFranchiseIncentive", ptmUserName, ptmPinAmount, ptmTotalPin);
            return a;
        }
        //Vender Income 
        //updatetotalrecordbinary count Function
        public int VenderIncomeIncome(string username, string Amount)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            SqlParameter ptrAmount = new SqlParameter("@AMOUNTT", Amount);
            int a = ObjConnection.ExecuteProcedure("setVenderIncomeIncome", ptrusername, ptrAmount);

            return a;


        }
        public int WekklyClosing(int CID)
        {
            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);
            SqlParameter ptrCid = new SqlParameter("@CID", CID);
            int a = ObjConnection.ExecuteProcedure("Maching2_1", ptmtime, ptrCid);

            return a;


        }
        public int WekklyClosingCTB()
        {
            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);            
            int a = ObjConnection.ExecuteProcedure("[SetRoi]", ptmtime);
            return a;


        }
        public int SetRoiWeekly()
        {
            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);          
            int a = ObjConnection.ExecuteProcedure("SetRoiWeekly", ptmtime);
            return a;


        }
        public int SalaryDistribution()
        {
            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);
            int a = ObjConnection.ExecuteProcedure("SetSalary", ptmtime);
            return a;


        }
        public int CheckIncome300()
        {
           
          
            int a = ObjConnection.ExecuteProcedure("CheackIncome");
            return a;


        }
        public int SetDirectROI()
        {
            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);
            int a = ObjConnection.ExecuteProcedure("SetBonusWeekly", ptmtime);
            return a;


        }
        public DataTable Prefix()
        {
            string d = DateTime.Now.Day.ToString();
            string m = DateTime.Now.Month.ToString();
            string y = DateTime.Now.Year.ToString();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string prefix = d + m + y;
            string dDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            SqlParameter ptmPrefix = new SqlParameter("@Prefix", prefix);
            SqlParameter ptmDate = new SqlParameter("@Date", dDate);
            DataTable dt = ObjConnection.ReturnDataTable("CreateUserName", ptmPrefix,ptmDate);

            return dt;


        }
        public int DeleteUsername(string username)
        {

            SqlParameter ptmUsername = new SqlParameter("@UserName", username);
            int status = ObjConnection.ExecuteProcedure("DeleteInactiveID", ptmUsername);

            return status;


        }

        #region Related WeeklyROIDistribute
        public int WeeklyROIDistribute()
        {

            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);
            int status = ObjConnection.ExecuteProcedure("SetRoiWeekly", ptmtime);
            return status;
         }
        #endregion
        #region Related Booster Income DISTRIBUTION
        public int SetCTBWeekly()
        {

            string todaydate = objtime.returnStringServerMachTime();
            SqlParameter ptmtime = new SqlParameter("@TodayDate", todaydate);
            int status = ObjConnection.ExecuteProcedure("SetBoosterIncome", ptmtime);
            return status;
        }
        #endregion
        //related to treeview
        //related to treeeview
        public int treeview()
        {

            int a = ObjConnection.ExecuteProcedure("activ");
            return a;


        }

        #region Related to set auto position of new user
        public int SETUserInDownLine(string sponser,string userName,string side)
        {
            SqlParameter ptmSponser = new SqlParameter("@Sponser", sponser);
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            SqlParameter ptmSide = new SqlParameter("@Side", side);
            int status = ObjConnection.ExecuteProcedure("[SetUserInDownline]", ptmSponser, ptmUserName, ptmSide);
            return status;
        }
        #endregion
        #region Related to SET REWARD
        public int SETREWARD(string userName)
        {
           
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            int status = ObjConnection.ExecuteProcedure("[SetReward]", ptmUserName);
            return status;
        }
        #endregion

        #region Add New Agent
        public int Register(int Id,string ReffId,string ReffName,string Name,string UserName,string Password,string FName,string userName,string OnSide,
            string DateOfJoin,string Address,string City,string State,string Country,string Email,string Mobile,
            string Status,string NomineeName,string Relation,string Pan,string Aadhar,string NAge,
            string NDOB,string Sex,string DOB,string Pin,string RTime,string FDate,string FTime,
            string CardNo,string NomineeMobile,string DateOfJoining,string BranchStatus,string DOA,string MarriageStaus,
            string Profilepic, string Upline, string UplineName, string Transaction)
        {
            int status = 0;
            try {
                SqlParameter ptmId = new SqlParameter("@Id", Id);
                SqlParameter ptmReffId = new SqlParameter("@ReffId", ReffId);
                SqlParameter ptmReffName = new SqlParameter("@ReffName", ReffName);
                SqlParameter ptmName = new SqlParameter("@Name", Name);                
                SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
                SqlParameter ptmPassword = new SqlParameter("@Password", Password);
                SqlParameter ptmFName = new SqlParameter("@FName", FName);
                SqlParameter ptmOnSide = new SqlParameter("@OnSide", OnSide);
                SqlParameter ptmDateOfJoin = new SqlParameter("@DateOfJoin", DateOfJoin);
                SqlParameter ptmAddress = new SqlParameter("@Address", Address);
                SqlParameter ptmCity = new SqlParameter("@City", City);
                SqlParameter ptmState = new SqlParameter("@State", State);
                SqlParameter ptmCountry = new SqlParameter("@Country", Country);
                SqlParameter ptmEmail = new SqlParameter("@Email", Email);
                SqlParameter ptmMobile = new SqlParameter("@Mobile", Mobile);
                SqlParameter ptmStatus = new SqlParameter("@Status", Status);
                SqlParameter ptmNomineeName = new SqlParameter("@NomineeName", NomineeName);
                SqlParameter ptmRelation = new SqlParameter("@Relation", Relation);
                SqlParameter ptmPan = new SqlParameter("@Pan", Pan);
                SqlParameter ptmAadhar = new SqlParameter("@Aadhar", Aadhar);
                SqlParameter ptmNAge = new SqlParameter("@NAge", NAge);
                SqlParameter ptmNDOB = new SqlParameter("@NDOB", NDOB);
                SqlParameter ptmSex = new SqlParameter("@Sex", Sex);
                SqlParameter ptmPin = new SqlParameter("@Pin", Pin);
                SqlParameter ptmDOB = new SqlParameter("@DOB", DOB);
                SqlParameter ptmRTime = new SqlParameter("@RTime", RTime);
                SqlParameter ptmFDate = new SqlParameter("@FDate", FDate);
                SqlParameter ptmFTime = new SqlParameter("@FTime", FTime);
                SqlParameter ptmCardNo = new SqlParameter("@CardNo", CardNo);
                SqlParameter ptmNomineeMobile = new SqlParameter("@NomineeMobile", NomineeMobile);
                SqlParameter ptmDateOfJoining = new SqlParameter("@DateOfJoining", DateOfJoining);
                SqlParameter ptmBranchStatus = new SqlParameter("@BranchStatus", BranchStatus);
                SqlParameter ptmDOA = new SqlParameter("@DOA", DOA);
                SqlParameter ptmMarriageStaus = new SqlParameter("@MarriageStaus", MarriageStaus);
                SqlParameter ptmProfilepic = new SqlParameter("@Profilepic", Profilepic);
                SqlParameter ptmUpline = new SqlParameter("@Upline", Upline);
                SqlParameter ptmUplineName = new SqlParameter("@UplineName", UplineName);
                SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
                status = ObjConnection.ExecuteProcedure("RegisterUser", ptmId, ptmReffId, ptmReffName, ptmName, ptmUserName, ptmPassword
                     ,ptmFName,ptmOnSide,ptmDateOfJoin,ptmAddress,ptmCity,ptmState,ptmCountry,ptmEmail,ptmMobile,ptmStatus,ptmNomineeName,
                     ptmRelation,ptmPan,ptmAadhar,ptmNAge,ptmNDOB,ptmSex,ptmPin,ptmDOB,ptmRTime,ptmFDate,ptmFTime,ptmCardNo,
                     ptmNomineeMobile, ptmDateOfJoining, ptmBranchStatus, ptmDOA, ptmMarriageStaus, ptmProfilepic, ptmUpline, ptmUplineName, ptmTransaction);
                return status;
            }
            catch (Exception ex)
            {
                throw; 
            }
            
        }
        #endregion
        #region Related to Modify Bank Detail
        public int ModifyBankDetail(int Int, string UserName, string AccountNo, string BankName, string IFSC,
            string BranchName, string HolderName, string AccountType, string AccountImg, string BHIM,
            string AccountLink, string PhonePay, string PayTM, string GooglePay,string ChequeUrl, string Transaction)
        {

            SqlParameter ptmInt = new SqlParameter("@Int", Int);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAccountNo = new SqlParameter("@AccountNo", AccountNo);
            SqlParameter ptmBankName = new SqlParameter("@BankName", BankName);
            SqlParameter ptmIFSC = new SqlParameter("@IFSC", IFSC);
            SqlParameter ptmBranchName = new SqlParameter("@BranchName", BranchName);
            SqlParameter ptmHolderName = new SqlParameter("@HolderName", HolderName);
            SqlParameter ptmAccountType = new SqlParameter("@AccountType", AccountType);
            SqlParameter ptmAccountImg = new SqlParameter("@AccountImg", AccountImg);
            SqlParameter ptmAccountLink = new SqlParameter("@AccountLink", AccountLink);
            SqlParameter ptmPhonePay = new SqlParameter("@PhonePay", PhonePay);
            SqlParameter ptmPayTM = new SqlParameter("@PayTM", PayTM);
            SqlParameter ptmBHIM = new SqlParameter("@BHIM", BHIM);
            SqlParameter ptmGooglePay = new SqlParameter("@GooglePay", GooglePay);
            SqlParameter ptmChaqueUrl = new SqlParameter("@ChequeUrl", ChequeUrl);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);


            int status = ObjConnection.ExecuteProcedure("[Bank]", ptmInt, ptmUserName, ptmAccountNo, ptmBankName, ptmIFSC,
                ptmBranchName, ptmHolderName, ptmAccountType, ptmAccountImg, ptmAccountLink, ptmPhonePay, ptmPayTM, ptmBHIM, ptmGooglePay, ptmChaqueUrl, ptmTransaction);
            return status;
        }
        #endregion

        #region Related to Approved Activate Account Link
        public int ActivateAccountLink(int Rid, string UserName, string Amount, string Receipt, string Status,
            string DOR, string DOD, string Remark, string @ReffId, string Paymentmode, string ClientRemark, string Transaction)
        {
            SqlParameter ptmRid = new SqlParameter("@Rid", Rid);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmReceipt = new SqlParameter("@Receipt", Receipt);
            SqlParameter ptmStatus = new SqlParameter("@Status", Status);
            SqlParameter ptmDOR = new SqlParameter("@DOR", DOR);
            SqlParameter ptmDOD = new SqlParameter("@DOD", DOD);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmReffId = new SqlParameter("@ReffId", ReffId);
            SqlParameter ptmPaymentmode = new SqlParameter("@Paymentmode", Paymentmode);
            SqlParameter ptmClientRemark = new SqlParameter("@ClientRemark", ClientRemark);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[RequestForActivation]", ptmRid, ptmUserName, ptmAmount, ptmReceipt, ptmStatus,
                ptmDOR, ptmDOD, ptmRemark, ptmReffId, ptmPaymentmode, ptmClientRemark, ptmTransaction);
            return status;
        }
        #endregion

        #region Related to Fund Transafer
        public int FundTransfer( string UserName, string Amount, string DOT, string Transaction)
        {
           
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);           
            SqlParameter ptmDOR = new SqlParameter("@DOT", DOT);           
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[FUND]", ptmUserName, ptmAmount, 
                ptmDOR,  ptmTransaction);
            return status;
        }
        #endregion

        public int RepuchaseRequest(int Rid, string UserName, string Amount, string Receipt, string Status,
           string DOR, string DOD, string Remark, string @ReffId, string Paymentmode, string ClientRemark, string PurchaseType, string Transaction)
        {
            SqlParameter ptmRid = new SqlParameter("@Rid", Rid);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmReceipt = new SqlParameter("@Receipt", Receipt);
            SqlParameter ptmStatus = new SqlParameter("@Status", Status);
            SqlParameter ptmDOR = new SqlParameter("@DOR", DOR);
            SqlParameter ptmDOD = new SqlParameter("@DOD", DOD);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmReffId = new SqlParameter("@ReffId", ReffId);
            SqlParameter ptmPaymentmode = new SqlParameter("@Paymentmode", Paymentmode);
            SqlParameter ptmClientRemark = new SqlParameter("@ClientRemark", ClientRemark);
            SqlParameter ptmPurchaseType = new SqlParameter("@PurchaseType", PurchaseType);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("RequestRepurchase", ptmRid, ptmUserName, ptmAmount, ptmReceipt, ptmStatus,
                ptmDOR, ptmDOD, ptmRemark, ptmReffId, ptmPaymentmode, ptmClientRemark, ptmPurchaseType, ptmTransaction);
            return status;
        }


        public int BankTransfer(int Tid, string FromDate, string ToDate)
        {
            string Today = objtime.returnStringServerMachTime();
            //string Fdate = Convert.ToDateTime(FromDate).ToString("yyyy-MM-dd");
            //string Tdate = Convert.ToDateTime(ToDate).ToString("yyyy-MM-dd");
            SqlParameter ptmTID = new SqlParameter("@TID", Tid);
            SqlParameter ptmFromDate = new SqlParameter("@FromDate", FromDate);
            SqlParameter ptmToDate = new SqlParameter("@ToDate", ToDate);
            SqlParameter ptmToday = new SqlParameter("@TodayDate", Today);
            int a = ObjConnection.ExecuteProcedure("GenratePayOut", ptmFromDate, ptmToDate, ptmToday, ptmTID);

            return a;
        }
        #region Related to KYC
        public int KYC(string UserName, string Pan, string PanStatus, string AadharFront, string AadharBack, string AadharStatus,string Status,string Remark,string UserSign,string UserPhoto, string Transaction)
        {
           
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmPan = new SqlParameter("@Pan", Pan);
            SqlParameter ptmPanStatus = new SqlParameter("@PanStatus", PanStatus);
            SqlParameter ptmAadharFront = new SqlParameter("@AadharFront", AadharFront);
            SqlParameter ptmAadharBack = new SqlParameter("@AadharBack", AadharBack);            
            SqlParameter ptmAadharStatus = new SqlParameter("@AadharStatus", AadharStatus);
            SqlParameter ptmStatus = new SqlParameter("@Status", Status);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmUserSign = new SqlParameter("@UserSign", UserSign);
            SqlParameter ptmUserPhoto = new SqlParameter("@UserPhoto", UserPhoto);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[KYCMAIN]", ptmUserName, ptmPan,
                ptmPanStatus,ptmAadharFront,ptmAadharBack,ptmAadharStatus,ptmStatus,ptmRemark, ptmUserSign, ptmUserPhoto, ptmTransaction);
            return status;
        }
        #endregion
        public int ActiveMember(string username, decimal Amount, decimal PackAmount, string packtype, string ActiveBy, string Transaction)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            SqlParameter ptrAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptrPackAmount = new SqlParameter("@PackAmount", PackAmount);
            SqlParameter ptrActiveby = new SqlParameter("@ActiveBy", ActiveBy);
            SqlParameter ptrpacktype = new SqlParameter("@PackType", packtype);
            //SqlParameter ptrROI = new SqlParameter("@ROI", ROI);
            SqlParameter ptrTransactiom = new SqlParameter("@Transaction", Transaction);
            int a = ObjConnection.ExecuteProcedure("ActiveMember", ptrusername, ptrActiveby, ptrAmount, ptrPackAmount, ptrpacktype,  ptrTransactiom);

            return a;


        }
        #region Related WithdrawRequest
        public int WithdrawRequest(int RID, string Username, decimal Amount, string Remark,string IncomeType,string TranstionPass, string Transaction)
        {


            SqlParameter ptmrid = new SqlParameter("@RID", RID);
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmIncomeType = new SqlParameter("@IncomeType", IncomeType);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            SqlParameter ptmTranstionPass = new SqlParameter("@TranstionPass", TranstionPass);
            int status = ObjConnection.ExecuteProcedure("WithdrawRequest", ptmrid, ptmUsername, ptmAmount, ptmRemark, ptmIncomeType, ptmTranstionPass, ptmTransaction);
            return status;
        }
        #endregion
        #region Related WithdrawRequest
        public int WalletRecharge(int RID, string Username, decimal Amount, string Remark,string TranstionPass, string Transaction)
        {
            SqlParameter ptmrid = new SqlParameter("@RID", RID);
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmTranstionPass = new SqlParameter("@TranstionPass", TranstionPass);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("WalletRecharge", ptmrid, ptmUsername, ptmAmount, ptmTranstionPass, ptmRemark, ptmTransaction);
            return status;
        }
        #endregion
        #region Related WalletLoantRecharge
        public int WalletLoanRecharge(int RID, string Username, decimal Amount, string Remark, string TranstionPass, string Transaction)
        {
            SqlParameter ptmrid = new SqlParameter("@RID", RID);
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmTranstionPass = new SqlParameter("@TranstionPass", TranstionPass);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("WalletLoanRecharge", ptmrid, ptmUsername, ptmAmount, ptmTranstionPass, ptmRemark, ptmTransaction);
            return status;
        }
        #endregion

        public int RoolBackAccount(string username, decimal Amount, string packtype, string DOJ)
        {
            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            SqlParameter ptrAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptrpacktype = new SqlParameter("@PackType", packtype);
            SqlParameter ptrDOJ = new SqlParameter("@TodayDate", DOJ);           
            int a = ObjConnection.ExecuteProcedure("ActiveIDRollBack", ptrusername, ptrAmount, ptrpacktype, ptrDOJ);
            return a;
        }
        public int SalaryMaster(string username)
        {
            SqlParameter ptrusername = new SqlParameter("@UserName", username);          
            int a = ObjConnection.ExecuteProcedure("SetSalaryMaster", ptrusername);
            return a;
        }
        public int PoolUpgrade(string username, decimal Amount, string PoolName, int LevelNumber,string Transaction)
        {

            SqlParameter ptrusername = new SqlParameter("@UserName", username);
            SqlParameter ptrAmount = new SqlParameter("@PoolAmount", Amount);
            SqlParameter ptrPackAmount = new SqlParameter("@PoolName", PoolName);
            SqlParameter ptrLevelNumber = new SqlParameter("@LevelNumber", LevelNumber);
            SqlParameter ptrTransactiom = new SqlParameter("@Transaction", Transaction);
            int a = ObjConnection.ExecuteProcedure("[stayglobaldb].[PoolUpgrade]", ptrusername, ptrAmount, ptrPackAmount, ptrLevelNumber, ptrTransactiom);

            return a;


        }
        #region Related to BTCAPI
        public int BTCAPI(int FID, string UserName, decimal AmountUSD, double AMountBTC, string txn_id, string Address, string Confirms_Needed, string TimeOut, string Checkout_url, string Status_url, string QRCode_url, string Status, string Transaction)
        {
            SqlParameter ptmFID = new SqlParameter("@FID", FID);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAmountUSD = new SqlParameter("@AmountUSD", AmountUSD);
            SqlParameter ptmAMountBTC = new SqlParameter("@AMountBTC", AMountBTC);
            SqlParameter ptmtxn_id = new SqlParameter("@txn_id", txn_id);
            SqlParameter ptmAddress = new SqlParameter("@Address", Address);
            SqlParameter ptmConfirms_Needed = new SqlParameter("@Confirms_Needed", Confirms_Needed);
            SqlParameter ptmTimeOut = new SqlParameter("@TimeOut", TimeOut);
            SqlParameter ptmCheckout_url = new SqlParameter("@Checkout_url", Checkout_url);
            SqlParameter ptmStatus_url = new SqlParameter("@Status_url", Status_url);
            SqlParameter ptmQRCode_url = new SqlParameter("@QRCode_url", QRCode_url);
            SqlParameter ptmStatus = new SqlParameter("@Status", Status);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ExecuteProcedure("[BTCAPIFundRequest]", ptmFID, ptmUserName, ptmAmountUSD, ptmAMountBTC, ptmtxn_id, ptmAddress, ptmConfirms_Needed, ptmTimeOut, ptmCheckout_url, ptmStatus_url, ptmQRCode_url, ptmStatus, ptmTransaction);



        }
        #endregion
        #region RELATED WITH REPURCHASE
        public int Repurchase(string username, decimal Amount, decimal PackAmount, string packtype, string ActiveBy, string Transaction)
        {

            SqlParameter ptrusername = new SqlParameter("@USERNAME", username);
            SqlParameter ptrAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptrPackAmount = new SqlParameter("@PackAmount", PackAmount);
            SqlParameter ptrActiveby = new SqlParameter("@ActiveBy", ActiveBy);
            SqlParameter ptrpacktype = new SqlParameter("@PackType", packtype);
            SqlParameter ptrTransactiom = new SqlParameter("@Transaction", Transaction);
            int a = ObjConnection.ExecuteProcedure("Repurchase", ptrusername, ptrActiveby, ptrAmount, ptrPackAmount, ptrpacktype, ptrTransactiom);

            return a;


        }
        #endregion
        #region Related to IMPSWithraw
        public int IMPSWithraw(int RID, string UserName, string Amount, string Remark, string IncomeType,
            string OrderID, string ReportID, string ClientID, int StatusID, string Transaction)
        {

            SqlParameter ptmRID = new SqlParameter("@RID", RID);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmIncomeType = new SqlParameter("@IncomeType", IncomeType);
            SqlParameter ptmOrderID = new SqlParameter("@OrderID", OrderID);
            SqlParameter ptmReportID = new SqlParameter("@ReportID", ReportID);
            SqlParameter ptmClientID = new SqlParameter("@ClientID", ClientID);
            SqlParameter ptmStatusID = new SqlParameter("@StatusID", StatusID);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[WithdrawRequest]", ptmRID, ptmUserName, ptmAmount,
                ptmRemark, ptmIncomeType, ptmOrderID, ptmReportID, ptmClientID, ptmStatusID, ptmTransaction);
            return status;
        }
        #endregion
        #region Related to IMPSWithraw
        public int Recharge(int RID, string UserName, string Amount, string RechargeMobile, string Coupon,
            string Fund, string Operator, string RequestID, int StatusID, string Transaction)
        {
       

            SqlParameter ptmRID = new SqlParameter("@RID", RID);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmRechargeMobile = new SqlParameter("@RechargeMobile", RechargeMobile);
            SqlParameter ptmIncomeType = new SqlParameter("@Coupon", Coupon);
            SqlParameter ptmFund = new SqlParameter("@Fund", Fund);
            SqlParameter ptmOperator = new SqlParameter("@Operator", Operator);
            SqlParameter ptmRequestID = new SqlParameter("@RequestID", RequestID);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("Recharge", ptmRID, ptmUserName, ptmAmount,
                ptmRechargeMobile, ptmIncomeType, ptmFund, ptmOperator, ptmRequestID, ptmTransaction);
            return status;
        }
        #endregion
        #region Related to GETPoo1
        public int GETPoo1(string userName)
        {
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            int status = ObjConnection.ExecuteProcedure("[GETPool1]", ptmUserName);
            return status;
        }
        #endregion
        #region Related to GETPoo2A
        public int GETPoo2(string userName)
        {
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            int status = ObjConnection.ExecuteProcedure("[GETPool2]", ptmUserName);
            return status;
        }
        #endregion
        #region Related to GETPoo1
        public int GETPoo3(string userName)
        {
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            int status = ObjConnection.ExecuteProcedure("[GETPool2B]", ptmUserName);
            return status;
        }
        #endregion
        #region Related to GETPoo1
        public int GETPoo4(string userName)
        {
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);

            int status = ObjConnection.ExecuteProcedure("[GETPool3A]", ptmUserName);
            return status;
        }
        #endregion
        #region Related to GETPoo1
        public int GETPoo5(string userName)
        {
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            int status = ObjConnection.ExecuteProcedure("[GETPool3B]", ptmUserName);
            return status;
        }
        #endregion
        #region Related to GETPoo1
        public DataTable GETPoolStatus(string userName, string PoolName)
        {
            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            SqlParameter ptmPoolName = new SqlParameter("@PoolName", PoolName);
            DataTable dt = ObjConnection.ReturnDataTable("[GETPoolTeamStatus]", ptmUserName, ptmPoolName);

            return dt;

        }
        #endregion
        #region Related to GETPoo1
        public DataTable GETPoolTree(string Sponser, int PoolNo)
        {
            SqlParameter ptmUserName = new SqlParameter("@Sponser", Sponser);
            SqlParameter ptmPoolName = new SqlParameter("@PoolNo", PoolNo);
            DataTable dt = ObjConnection.ReturnDataTable("[PoolTreeView]", ptmUserName, ptmPoolName);

            return dt;

        }
        #endregion
        #region Related to FundTransfer
        public int FundTransfer(string Fromuser, string Touser,decimal Amount,string TranstionPass)
        {
            SqlParameter ptmFromuser = new SqlParameter("@FromUser", Fromuser);
            SqlParameter ptmTouser = new SqlParameter("@ToUser", Touser);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmTranstionPass = new SqlParameter("@TranstionPass", TranstionPass);
            return  ObjConnection.ExecuteProcedure("[WalletTransfer]", ptmFromuser,ptmTouser, ptmAmount, ptmTranstionPass);

          

        }
        #endregion
        #region Related to Admid FundTransfer
        public int AdminFundTransfer(string Username, decimal Amount,string Mode, string Remark,string Transaction)
        {
          

            SqlParameter ptmUsername = new SqlParameter("@Username", Username);        
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmMode = new SqlParameter("@Mode", Mode);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ExecuteProcedure("[AdminPower]", ptmUsername, ptmAmount, ptmMode, ptmRemark, ptmTransaction);



        }
        #endregion
        #region Related to Admid FundTransfer
        public int CryptoWallet(string Username, string BTCWallet, string ETHWallet,string TRXWallet,string USDTWallet,string LTCWallet, string DOGEallet, string Transaction)
        {

            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmBTCWallet = new SqlParameter("@BTCWallet", BTCWallet);
            SqlParameter ptmETHWallet = new SqlParameter("@ETHWallet", ETHWallet);
            SqlParameter ptmTRXWallet = new SqlParameter("@TRXWallet", TRXWallet);
            SqlParameter ptmLTCWallet = new SqlParameter("@LTCWallet", LTCWallet);
            SqlParameter ptmUSDTWallet = new SqlParameter("@USDTWallet", USDTWallet);
            SqlParameter ptmDOGEallet = new SqlParameter("@DOGEallet", DOGEallet);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ExecuteProcedure("[CryptoWallet]", ptmUsername, ptmBTCWallet, ptmETHWallet, ptmTRXWallet, ptmLTCWallet, ptmUSDTWallet, ptmDOGEallet, ptmTransaction);



        }
        #endregion
        #region Related to SET GameBid
        public int GameBid(string userName,decimal BidAmt,string ColorName)
        {

            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            SqlParameter ptmBidAmt = new SqlParameter("@BidAmt", BidAmt);
            SqlParameter ptmColorName = new SqlParameter("@ColorName", ColorName);
            int status = ObjConnection.ExecuteProcedure("[GameBid]", ptmUserName, ptmBidAmt,ptmColorName);
            return status;
        }
        #endregion
       
         #region Related to SET Slider
        public int Slider(int Sid, string Title,string Username,string Image, decimal Amount, string Day, string Status, string Remark, string Transaction)
        {

            SqlParameter ptmSid = new SqlParameter("@Sid", Sid);
            SqlParameter ptmTitle = new SqlParameter("@Title", Title);
            SqlParameter ptmUsername = new SqlParameter("@Username", Username);
            SqlParameter ptmImage = new SqlParameter("@Image", Image);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmDay = new SqlParameter("@Day", Day);
            SqlParameter ptmStatus = new SqlParameter("@Status", Status);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[SliderMaster]", ptmSid, ptmTitle, ptmUsername, ptmImage, ptmAmount, ptmDay, ptmStatus, ptmRemark, ptmTransaction);
            return status;
        }
        #endregion
        public int ProductMaster(int PID, string ProductName, decimal ProductAmt, decimal ProductBV, string ProductDesc, string ProductImg, string Transaction)
        {
            SqlParameter ptrPID = new SqlParameter("@PID", PID);
            SqlParameter ptrProductName = new SqlParameter("@ProductName", ProductName);
            SqlParameter ptrProductAmt = new SqlParameter("@ProductAmt", ProductAmt);
            SqlParameter ptrProductBV = new SqlParameter("@ProductBV", ProductBV);
            SqlParameter ptrProductDesc = new SqlParameter("@ProductDesc", ProductDesc);
            SqlParameter ptrProductImg = new SqlParameter("@ProductImg", ProductImg);
            SqlParameter ptrTransaction = new SqlParameter("@Transaction", Transaction);
            int a = ObjConnection.ExecuteProcedure("ProductMaster", ptrPID, ptrProductName, ptrProductAmt, ptrProductBV, ptrProductDesc, ptrProductImg, ptrTransaction);
            return a;
        }
        #region Related to SET CompanyBankMaster
        public int CompanyBankMaster(int Bid, string PaymentMode, string BankName, string Branch, string IFSC, string AccountNumber, string HolderName, string QRCode, string UPI, string Transaction)
        {

            SqlParameter ptmBid = new SqlParameter("@Bid", Bid);
            SqlParameter ptmPaymentMode = new SqlParameter("@PaymentMode", PaymentMode);
            SqlParameter ptmBankName = new SqlParameter("@BankName", BankName);
            SqlParameter ptmBranch = new SqlParameter("@Branch", Branch);
            SqlParameter ptmIFSC = new SqlParameter("@IFSC", IFSC);
            SqlParameter ptmAccountNumber = new SqlParameter("@AccountNumber", AccountNumber);
            SqlParameter ptmHolderName = new SqlParameter("@HolderName", HolderName);
            SqlParameter ptmQRCode = new SqlParameter("@QRCode", QRCode);
            SqlParameter ptmUPI = new SqlParameter("@UPI", UPI);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[dbo].[BankMaster]", ptmBid, ptmPaymentMode, ptmBankName, ptmBranch, ptmIFSC, ptmAccountNumber, ptmHolderName, ptmQRCode, ptmUPI, ptmTransaction);
            return status;
        }
        #endregion
        public int ROIMaster(string IDX, string Package, decimal ROI, string Remark, string Transaction)
        {

            SqlParameter ptmIDX = new SqlParameter("@IDX", IDX);
            SqlParameter ptmPackage = new SqlParameter("@Package", Package);
            SqlParameter ptmROI = new SqlParameter("@ROI", ROI);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("ROIMaster", ptmIDX, ptmPackage, ptmROI, ptmRemark, ptmTransaction);
            return status;
        }

        public int AutoWalletRecharge(string username, string HashCode, string Amount, string Transaction)
        {


            SqlParameter ptrusername = new SqlParameter("@UserName", username);
            SqlParameter ptrHashCode = new SqlParameter("@HashCode", HashCode);
            SqlParameter ptrAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptrTransaction = new SqlParameter("@Transaction", Transaction);

            int a = ObjConnection.ExecuteProcedure("AutoWalletRecharge", ptrusername, ptrHashCode, ptrAmount, ptrTransaction);

            return a;


        }
        #region Related to SET GameBid
        public int GETFundBySmartContract(string userName, decimal Amount, string TransactionNo, string WalletAddress, string Transaction)
        {

            SqlParameter ptmUserName = new SqlParameter("@UserName", userName);
            SqlParameter ptmAmount = new SqlParameter("@Amount", Amount);
            SqlParameter ptmTransactionNo = new SqlParameter("@TransactionNo", TransactionNo);
            SqlParameter ptmWalletAddress = new SqlParameter("@WalletAddress", WalletAddress);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("GETFundBySmartContract", ptmUserName, ptmAmount, ptmTransactionNo, ptmWalletAddress, ptmTransaction);
            return status;
        }
        #endregion
        public int KYCBank(string Username,
                     string AccountType, string BankName, string BranchName,
                     string AccountNumber, string IFSC, string AccountHolderName, string ImagePassbook,
                     string Transaction)
        {
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);

            SqlParameter ptmAccountType = new SqlParameter("@AccountType", AccountType);
            SqlParameter ptmBankName = new SqlParameter("@BankName", BankName);
            SqlParameter ptmBranchName = new SqlParameter("@BranchName", BranchName);

            SqlParameter ptmAccountNumber = new SqlParameter("@AccountNumber", AccountNumber);
            SqlParameter ptmIFSC = new SqlParameter("@IFSC", IFSC);
            SqlParameter ptmAccountHolderName = new SqlParameter("@AccountHolderName", AccountHolderName);
            SqlParameter ptmImagePassbook = new SqlParameter("@ImagePassbook", ImagePassbook);

            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("KycBank", ptmUsername,
                                                        ptmAccountType, ptmBankName, ptmBranchName,
                                                        ptmAccountNumber, ptmIFSC, ptmAccountHolderName, ptmImagePassbook,
                                                        ptmTransaction);
            return status;
        }

        public int KYCAdhaar(string Username, string AdhaarCardNumber, string AdhaarFront, string AdhaarBack, string Transaction)
        {
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmAdhaarCardNumber = new SqlParameter("@AdhaarCardNumber", AdhaarCardNumber);
            SqlParameter ptmAdhaarFront = new SqlParameter("@AdhaarFront", AdhaarFront);
            SqlParameter ptmAdhaarBack = new SqlParameter("@AdhaarBack", AdhaarBack);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("KycAdhaar", ptmUsername, ptmAdhaarCardNumber, ptmAdhaarFront, ptmAdhaarBack, ptmTransaction);
            return status;
        }

        public int KYCPAN(string Username, string PanNumber, string PanImage, string Transaction)
        {
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmPanNumber = new SqlParameter("@PanNumber", PanNumber);
            SqlParameter ptmPanImage = new SqlParameter("@PanImage", PanImage);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("KycPan", ptmUsername, ptmPanNumber, ptmPanImage, ptmTransaction);
            return status;
        }
        public int KYCVOTER(string Username, string VoterNumber, string VoterFront, string VoterBack, string Transaction)
        {
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmVoterNumber = new SqlParameter("@voterNumber", VoterNumber);
            SqlParameter ptmVoterFront = new SqlParameter("@VoterFront", VoterFront);
            SqlParameter ptmVoterBack = new SqlParameter("@VoterBack", VoterBack);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("KycVoter", ptmUsername, ptmVoterNumber, ptmVoterFront, ptmVoterBack, ptmTransaction);
            return status;
        }
        public int ProductMaster(int PID, string ProductName, decimal ProductAmt, decimal ProductMRP, decimal DISCOUNT, decimal ProductBV, decimal DirectCommision, string ProductDesc, string ProductImg, string Transaction)
        {
            SqlParameter ptrPID = new SqlParameter("@PID", PID);
            SqlParameter ptrProductName = new SqlParameter("@ProductName", ProductName);
            SqlParameter ptrProductAmt = new SqlParameter("@ProductAmt", ProductAmt);
            SqlParameter ptrProductMRP = new SqlParameter("@ProductMRP", ProductMRP);
            SqlParameter ptrDISCOUNT = new SqlParameter("@DISCOUNT", DISCOUNT);
            SqlParameter ptrProductBV = new SqlParameter("@ProductBV", ProductBV);
            SqlParameter ptrDirectCommision = new SqlParameter("@DirectCommision", DirectCommision);
            SqlParameter ptrProductDesc = new SqlParameter("@ProductDesc", ProductDesc);
            SqlParameter ptrProductImg = new SqlParameter("@ProductImg", ProductImg);
            SqlParameter ptrTransaction = new SqlParameter("@Transaction", Transaction);
            int a = ObjConnection.ExecuteProcedure("ProductMaster", ptrPID, ptrProductName, ptrProductAmt, ptrProductMRP, ptrDISCOUNT, ptrProductBV, ptrDirectCommision, ptrProductDesc, ptrProductImg, ptrTransaction);
            return a;
        }

        public int PRODUCTBILL(int PID, string Product, string UserName, string HSNCode, string ProductCode, decimal Qty, decimal MRP, decimal Discount, decimal Price, decimal BV, decimal GrandToatal, decimal CGST, decimal IGST, decimal SGST, string InvoiceNo, string Transaction)
        {

            SqlParameter ptmPID = new SqlParameter("@PID", PID);
            SqlParameter ptmProduct = new SqlParameter("@Product", Product);
            SqlParameter ptmUsername = new SqlParameter("@UserName", UserName);
            SqlParameter ptmHSNCode = new SqlParameter("@HSNCode", HSNCode);
            SqlParameter ptmProductCode = new SqlParameter("@ProductCode", ProductCode);
            SqlParameter ptmQty = new SqlParameter("@Qty", Qty);
            SqlParameter ptmMRP = new SqlParameter("@MRP", MRP);
            SqlParameter ptmDiscount = new SqlParameter("@Discount", Discount);
            SqlParameter ptmPrice = new SqlParameter("@Price", Price);
            SqlParameter ptmBV = new SqlParameter("@BV", BV);
            SqlParameter ptmGrandToatal = new SqlParameter("@GrandToatal", GrandToatal);
            SqlParameter ptmCGST = new SqlParameter("@CGST", CGST);
            SqlParameter ptmIGST = new SqlParameter("@IGST", IGST);
            SqlParameter ptmSGST = new SqlParameter("@SGST", SGST);
            SqlParameter ptmInvoiceNo = new SqlParameter("@InvoiceNo", InvoiceNo);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ExecuteProcedure("[dbo].[ProductSale]", ptmPID, ptmProduct, ptmUsername, ptmHSNCode, ptmProductCode, ptmQty, ptmMRP, ptmDiscount, ptmPrice, ptmBV, ptmGrandToatal, ptmCGST, ptmIGST, ptmSGST, ptmInvoiceNo, ptmTransaction);



        }

        public int KYCUPI(string Username, string UPI, string QRCode, string Transaction)
        {
            SqlParameter ptmUsername = new SqlParameter("@UserName", Username);
            SqlParameter ptmUPI = new SqlParameter("@UPI", UPI);
            SqlParameter ptmQRCode = new SqlParameter("@QRCode", QRCode);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);

            int status = ObjConnection.ExecuteProcedure("KycUPI", ptmUsername, ptmUPI, ptmQRCode, ptmTransaction);
            return status;
        }
    }
}
