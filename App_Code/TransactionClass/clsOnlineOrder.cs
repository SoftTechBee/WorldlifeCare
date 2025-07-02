using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.IO;
using TripleITConnection;
using System.Globalization;
/// <summary>
/// Summary description for clsOnlineOrder
/// </summary>
namespace TripleITTransaction
{

    public class clsOnlineOrder
    {
        string Sql = "";
        clsConnection ObjConnection = new clsConnection();
        clsValidation ObjValid = new clsValidation();
        clsTimeZone objtime = new clsTimeZone();

        public clsOnlineOrder()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string ConnectionString()
        {
            try
            {
                return ObjConnection.ConnectString;
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

        #region Related to OnlineOrder
        public int OnlineOrder(int Oid, string UserName, string ProductCode, int Qty, string InvoiceNo, string OrderNo
              , string OrderRemark, string Remark, string Status, string Transaction)
        {
            SqlParameter ptmOid = new SqlParameter("@Oid", Oid);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmProductCode = new SqlParameter("@ProductCode", ProductCode);
            SqlParameter ptmQty = new SqlParameter("@Qty", Qty);
            SqlParameter ptmInvoiceNo = new SqlParameter("@InvoiceNo", InvoiceNo);
            SqlParameter ptmOrderNo = new SqlParameter("@OrderNo", OrderNo);
            SqlParameter ptmOrderRemark = new SqlParameter("@OrderRemark", OrderRemark);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmStatus = new SqlParameter("@Status", Status);
            SqlParameter ptmTransaction = new SqlParameter("@Transaction", Transaction);
            int status = ObjConnection.ExecuteProcedure("[OnlineOrder]", ptmOid, ptmUserName, ptmProductCode,
                ptmQty, ptmInvoiceNo, ptmOrderNo, ptmOrderRemark, ptmRemark, ptmStatus, ptmTransaction);
            return status;
        }
        #endregion
        #region Related to OnlineOrderCheckOut
        public int CheckOut(int BID, string UserName, string PaymentMethod, string OrderNo, string InvoiceNo,
            decimal TotalBill,decimal TotalBV, string OrderRemark, string Remark, string ShippingStatus, string Transaction)
        {
            SqlParameter ptmBID = new SqlParameter("@BID", BID);
            SqlParameter ptmUserName = new SqlParameter("@UserName", UserName);
            SqlParameter ptmPaymentMethod = new SqlParameter("@PaymentMethod", PaymentMethod);
            SqlParameter ptmOrderNo = new SqlParameter("@OrderNo", OrderNo);
            SqlParameter ptmInvoiceNo = new SqlParameter("@InvoiceNo", InvoiceNo);            
            SqlParameter ptmTotalBill = new SqlParameter("@TotalBill", TotalBill);
            SqlParameter ptmTotalBV = new SqlParameter("@TotalBV ", TotalBV);
            SqlParameter ptmRemark = new SqlParameter("@Remark", Remark);
            SqlParameter ptmShippingStatus = new SqlParameter("@ShippingStatus", ShippingStatus);
            SqlParameter ptmTransaction = new SqlParameter("@Trsancation", Transaction);
            int status = ObjConnection.ExecuteProcedure("[OnlineOrderCheckout]", ptmBID, ptmUserName, ptmPaymentMethod,
                ptmInvoiceNo, ptmOrderNo, ptmTotalBill, ptmTotalBV, ptmRemark, ptmShippingStatus, ptmTransaction);
            return status;
        }
        #endregion
        #region Related to OnlineNO
        public string GETOrderNO()
        {
            string OrderNo = "";
            try {
                string sql = "select OrderCount,InvoiceCount from dbo.TblOnlinecount ";
                DataTable dt = ObjConnection.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    int Count = Convert.ToInt32(dt.Rows[0]["OrderCount"].ToString());
                    Count += 1;
                    OrderNo = "OO21/" + Count.ToString();
                }


            }
            catch (Exception ex)
            { }


            return OrderNo;

        }
        #endregion
        #region Related to InvoiceNo
        public string GETInvoiceNo()
        {
            string OrderNo = "";
            try
            {
                string sql = "select OrderCount,InvoiceCount from dbo.TblOnlinecount ";
                DataTable dt = ObjConnection.ReturnDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    int Count = Convert.ToInt32(dt.Rows[0]["InvoiceCount"].ToString());
                    Count += 1;
                    OrderNo = "OO21/" + Count.ToString();
                }


            }
            catch (Exception ex)
            { throw ex; }


            return OrderNo;
    
        }
        #endregion
    }
}