using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Diagnostics;
using TripleITConnection;
using System.Configuration;

namespace TripleITTransaction
{
    public class clsList  
    {
        clsConnection ObjConnection = new clsConnection();
        string Sql = "";

        public string ConnectionString()
        {
            try
            {
                return  ObjConnection.ConnectString; 
                            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RetrunSqlDataList(string Sql)
        {
            return ObjConnection.ReturnDataTableSql(Sql);
        }

      

        public string AutoCode(string TableName, string FieldName)
        {
            string gCode = "1";
            Sql = "Select Max(" + FieldName + ") as GetCode From " + TableName + " Group By " + FieldName + " Order By " + FieldName + " Desc";
            DataTable RsCode = RetrunSqlDataList(Sql);
            if (RsCode.Rows.Count == 0)
            {
                gCode = "1";
            }
            else
            {
                gCode = (Convert.ToInt32(RsCode.Rows[0]["GetCode"]) + 1).ToString();
            }
            return gCode;
        }

        public DataTable ListUser(int v1, string uname, DateTime now1, DateTime now2, string v2)
        {
            throw new NotImplementedException();
        }



        public DataTable GetBinaryDownline(string Sponser, string Accountstatus,string Transaction)
        {

            SqlParameter prmSponser = new SqlParameter("@Sponser", Sponser);
            SqlParameter prmAccountstatus = new SqlParameter("@AccountStatus", Accountstatus);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("[GetDownline]", prmSponser, prmAccountstatus, prmTransaction);
        }
        // User
        public DataTable GetDownline(string Sponser, string Transaction)
        {

            SqlParameter prmSponser = new SqlParameter("@Sponser", Sponser);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("[GetLEVELDownline]", prmSponser, prmTransaction);
        }
        public DataTable GetSuperDirectorlist(string Transaction)
        {          
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("[GetSuperDirectorList]", prmTransaction);
        }
        public DataTable GetTreeView(string Sponser)
        {
            

            SqlParameter prmSponser = new SqlParameter("@Sponser", Sponser);          
            return ObjConnection.ReturnDataTable("TreeView", prmSponser);
        }
        //Chanel List
        public DataTable ListChanel(Int32 Cid, string Keywords, string Transaction)
        {
            SqlParameter prmTicketCode = new SqlParameter("@Cid", Cid);
            SqlParameter prmKeywords = new SqlParameter("@Search", Keywords);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("ChanelList", prmTicketCode, prmKeywords, prmTransaction);
        }
        //for Mail List
        public DataTable ListMail(Int32 Mid, string keywords, string Transaction)
        {

            SqlParameter prmTicketCode = new SqlParameter("@Mid", Mid);
            SqlParameter prmKeywords = new SqlParameter("@Search",keywords);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("MailList", prmTicketCode, prmKeywords, prmTransaction);
        }
        //For Acoount
        //for Mail List
        public DataTable ListAccount(Int32 Aid, string AccountStaus,string Status, string Transaction)
        {

            SqlParameter prmTicketCode = new SqlParameter("@Aid", Aid);
            SqlParameter prmAccountStaus = new SqlParameter("@Search1", AccountStaus);
            SqlParameter prmStatus = new SqlParameter("@Search2", Status);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("AccountList", prmTicketCode, prmAccountStaus,prmStatus, prmTransaction);
        }

        public DataTable ListEmployee(int v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public DataTable ListPartyReg(int v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        //for Live Satus List
        public DataTable ListLiveStatus(Int32 Lid,string Search,DateTime Fdate,DateTime Tdate, string Transaction)
        {

            SqlParameter prmLid = new SqlParameter("@Lid", Lid);
            SqlParameter prmSearch = new SqlParameter("@Search", Search);
            SqlParameter prmFdate = new SqlParameter("@Fdate", Fdate);
            SqlParameter prmTdate = new SqlParameter("@Tdate", Tdate);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("LiveStatusLIst", prmLid, prmSearch, prmFdate, prmTdate, prmTransaction);
        }
        public DataTable visitlist(DateTime vdate)
        {

            SqlParameter prmvdate = new SqlParameter("@vdate", vdate);
            return ObjConnection.ReturnDataTable("visitlist", prmvdate);
        }
        public DataTable ListDOC(Int32 Mid, string Search, DateTime fdate, DateTime todate, string Transaction)
        {

            SqlParameter prmsid = new SqlParameter("@Kid", Mid);
            SqlParameter prmKeywords = new SqlParameter("@Search", Search);
            SqlParameter prmfdate = new SqlParameter("@fromdate", fdate);
            SqlParameter prmtodate = new SqlParameter("@todate", todate);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("KYCList", prmsid, prmKeywords, prmfdate, prmtodate, prmTransaction);
        }


        public DataTable ListGetBoardReport(string BoardName, string Username)
        {

            SqlParameter prmBoardName= new SqlParameter("@BoardName", BoardName);
            SqlParameter prmUsername = new SqlParameter("@Username", Username);

            return ObjConnection.ReturnDataTable("GetBoardReport", prmBoardName, prmUsername);
        }
        #region related with login
        public DataTable LoginCheck(string username, string Password, string Transaction)
        {
            SqlParameter ptrusername = new SqlParameter("@UserName", username);
            SqlParameter ptrPassword = new SqlParameter("@Password", Password);
            SqlParameter ptrTransaction = new SqlParameter("@Transaction", Transaction);
            return ObjConnection.ReturnDataTable("LoginCheck", ptrusername, ptrPassword, ptrTransaction);

        }
        #endregion
        public DataTable TDSReport(string FromDate, string ToDate, string Username, string Transaction)
        {

            SqlParameter prmFromDate = new SqlParameter("@FromDate", FromDate);            
            SqlParameter prmToDate = new SqlParameter("@ToDate", ToDate);
            SqlParameter prmUsername = new SqlParameter("@Username", Username);
            SqlParameter prmTransaction = new SqlParameter("@Transaction", Transaction);

            return ObjConnection.ReturnDataTable("GETNewTDSReport", prmFromDate, prmToDate, prmUsername, prmTransaction);
        }
        public DataTable CompanyBankMaster(int Bid, string PaymentMode, string BankName, string Branch, string IFSC, string AccountNumber, string HolderName, string QRCode, string UPI, string Transaction)
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
            return ObjConnection.ReturnDataTable("[dbo].[BankMaster]", ptmBid, ptmPaymentMode, ptmBankName, ptmBranch, ptmIFSC, ptmAccountNumber, ptmHolderName, ptmQRCode, ptmUPI, ptmTransaction);
        }
        public DataTable GetTreeView_(string Sponser)
        {


            SqlParameter prmSponser = new SqlParameter("@Sponser", Sponser);
            return ObjConnection.ReturnDataTable("TreeView_Tree", prmSponser);
        }
    }
}
