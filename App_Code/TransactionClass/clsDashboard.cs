using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripleITTransaction;
using TripleITConnection;
using System.Data;
/// <summary>
/// Summary description for clsDashboard
/// </summary>
public class clsDashboard
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    public clsDashboard()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string TotalIncome(string username )
    {
        string total = "0";
        try {
            string sql = "select sum(ISNULL(credit,0)) as amount from account where username='" + username + "' and status='0' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }
         
        
        }
        catch (Exception ex)
        { }

        return total;
    }

    public string WithdrawType(string username, string Status,string Type)
    {
        string total = "0";
        try
        {
            string sql = "select sum(CONVERT(decimal(18,2),ISNULL(amount,0))) as amount from TblRWithdraw where status='"+ Status + "' and  username='" + username + "' and PackType='" + Type + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }

    public string TotalWithdrawPending(string username)
    {
        string total = "0";
        try
        {
            string sql = "select sum(CONVERT(decimal(18,2),ISNULL(amount,0))) as amount from TblRWithdraw where status='pending' and  username='" + username + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalWithdrawApprove(string username)
    {
        string total = "0";
        try
        {
            string sql = "select sum(CONVERT(decimal(18,2),ISNULL(amount,0))) as amount from TblRWithdraw where status='approved' and username='" + username + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string WIthdrawRequest(string username, string status)
    {
        string total = "0";
        try
        {
            if (username == "Admin")
            {
                string sql = "select count(payout) as amount from TblRWithdraw where    status='" + status + "'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }
            }
            else
            {
                string sql = "select count(payout) as amount from TblRWithdraw where     username='" + username + "' and status='" + status + "'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    

    public string IncomeType(string username,string incomeType)
    {
        string total = "0";
        try
        {
            if (username == "Admin")
            {
                string sql = "select sum(CONVERT(decimal(18,2),ISNULL(credit,0))) as amount from account where    valu ='" + incomeType + "' and status='0'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }
            }
            else
            {
                string sql = "select sum(CONVERT(decimal(18,2),ISNULL(credit,0))) as amount from account where username='" + username + "' and  valu like'" + incomeType + "' and status='0'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
 

    public string TotalBlance(string username)
    {
        string total = "0";
        try
        {
            string sql = "select (sum(CONVERT(decimal(18,2),ISNULL(credit,0)))-sum(CONVERT(decimal(18,2),ISNULL(debit,0)))) as amount from account where username='" + username + "' and status='0' ";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TodayIncome(string username)
    {
        string total = "0";
        try
        {
            string sql = "select sum(credit) from account where username='" + username + "' and date='" + objtime.returnStringServerMachTime() + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }

    public  string ReturnMobile(string  UserName)
    {
        string Mobile = "";
        try {
            string sql = "select Mobile from register where username='" + UserName + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                Mobile = dt.Rows[0][0].ToString();
            }

        }
        catch (Exception ex)
        { }
        return Mobile;
    }
    
    public string ReturnEmail(string UserName)
    {
        string Mobile = "";
        try
        {
            string sql = "select email from register where username='" + UserName + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                Mobile = dt.Rows[0][0].ToString();
            }

        }
        catch (Exception ex)
        { }
        return Mobile;
    }
    public string TotalIncomeBlance(string username,string IncomeType)
    {
        string total = "0";
        try
        {
            string sql = "select (sum(CONVERT(decimal(18,2),ISNULL(credit,0)))-sum(CONVERT(decimal(18,2),ISNULL(debit,0)))) as amount from account where username='" + username + "' and status='0' ";
            if (IncomeType == "1")
            {
                sql += "and valu !='ROI'";
            }
            else if (IncomeType == "2")
            {
                sql += "and valu in ('ROI','ROIWithdraw')";

            }
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string DepositCredit(string username ,string type)
    {
        string total = "0";
        try
        {
            string sql = "select sum(credit) as amount from [tblwallet] where username='" + username + "'  and type='" + type + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
  public string DepositDebit(string username,string type)
    {
        string total = "0";
        try
        {
            string sql = "select sum(debit) as amount from [tblwallet] where username='" + username + "' and type='"+ type + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }

    public string TotalWallectBlance(string username)
    {
        string total = "0";
        try
        {
            string sql = "select (sum(credit)-sum(debit)) as amount from [tblwallet] where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalIncometoFundTransfer(string username)
    {
        string total = "0";
        try
        {
            string sql = "select (sum(debit)) as amount from account where username='" + username + "' and remark='Income transfer in fund wallet'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string CompanyTurnOver()
    {
        string total = "0";
        try
        {
            string sql = "select sum(credit) from tblwallet where type='Payment'";
            //if (Plantype == "Plan1")
            //{
            //    sql += " and PackType!='PORTFOLIO SERVICE'";
            //}
            //else if (Plantype == "Plan2")
            //{
            //    sql += " and PackType='PORTFOLIO SERVICE'";
            //}
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string totapurchasing()
    {
        string total = "0";
        try
        {
            string sql = "select sum(Amount) from tblretopup where 1=1" ;
            //if (Plantype == "Plan1")
            //{
            //    sql += " and PackType!='PORTFOLIO SERVICE'";
            //}
            //else if (Plantype == "Plan2")
            //{
            //    sql += " and PackType='PORTFOLIO SERVICE'";
            //}
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string Totalwithdraw()
    {
        string total = "0";
        try
        {
            string sql = "select sum(cast(isnull(Payout,0) as decimal(18,2))) As Withdraw from TblRWithdraw where status='Approved'";

          

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string Pendingwithdraw()
    {
        string total = "0";
        try
        {
            string sql = "select sum(cast(isnull(Payout,0) as decimal(18,2))) As Withdraw from TblRWithdraw where status='Pending'";

          

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
  
  
    public string TotalActiveDirect(string username)
    {
        string total = "0";
        try
        {
            string sql = "select count(username) as Member from register where  reffid='" + username + "' and status='Active'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalINActiveDirect(string username)
    {
        string total = "0";
        try
        {
            string sql = "select count(username) as Member from register where  reffid='" + username + "' and status='Not Active'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string SelfBusiness(string username)
    {
        string total = "0";
        try
        {

            string sql = "select  isnull(sum(amount),0) from tblretopup where  username='" + username + "'";
            //if (PackType == "Plan1")
            //{
            //    sql += " and Packtype in('Crypto Online Education Platform','Crypto+Forex Online Education Platform','Forex Online Education Platform') ";
            //}
            //else
            //{

            //    sql += " and PackType='" + PackType + "'";
            //}
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalDirect(string username)
    {
        string total = "0";
        try
        {
            string sql = "select count(username) as Member from register where  reffid='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalActiveTeam(string username)
    {
        string total = "0";
        try
        {
            string sql = "select CAST(rightcount AS int) from total_binarycount where  username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalInActiveTeam(string username)
    {
        string total = "0";
        try
        {
            string sql = "select CAST(leftcount AS int)-CAST(rightcount AS int) from total_binarycount where  username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalDirectBusiness(string username)
    {
        string total = "0";
        try
        {
            string sql = "select isnull(sum(t.amount),0)  from tblretopup t inner join register r on t.username=r.username where r.reffid='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    
    public string TotalDownline(string username)
    {
        string total = "0";
        try
        {
            
            DataTable dt = objlist.GetDownline(username,"C");
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }

   
   
   
    public string RetrunName(string username)
    {
        string TotalTeamBusness = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select Name from register where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                TotalTeamBusness = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return TotalTeamBusness;

    }
    public string RetrunMobile(string username)
    {
        string TotalTeamBusness = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select mobile from register where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                TotalTeamBusness = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return TotalTeamBusness;

    }
    
  public string ReturnTransPass(string username)
    {
        string TotalTeamBusness = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select transpassword from register where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                TotalTeamBusness = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return TotalTeamBusness;

    }
    
    public string TotalTeam(string username)
    {
        string TotalTeamBusness = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select convert(int,leftcount) from total_binarycount  where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                TotalTeamBusness = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return TotalTeamBusness;

    }
   

  
    public string ReturnLastPackName(string username)
    {
        string packtype = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select top 1 isnull(packtype,0) from tblretopup where username='" + username + "' order by rid desc";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                packtype = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return packtype;

    }
    public string ReturnLastPackAmt(string username)
    {
        string packtype = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select top 1 isnull(amount,0) from tblretopup where username='" + username + "' order by rid desc";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                packtype = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return packtype;

    }
  
    public string ReturnPackID(string username)
    {
        string Id = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "SELECT top 1 packid FROM tblretopup where username='" + username + "' order by rid desc ";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                Id = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return Id;

    }
    public string TotalTeamBusnessleg(string username, string Type)
    {
        string TotalTeamBusness = "0";
        try
        {

            clsConnection objcon1 = new clsConnection();
            string sql = "EXEC [dbo].[GetLegBusiness] @UserName ='" + username + "',@Type='" + Type + "'";

            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                TotalTeamBusness = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return TotalTeamBusness;

    }
    public string IncomeBalance(string username)
    {
        string total = "0";
        try
        {
            if (username == "Admin")
            {
                string sql = "select (sum(ISNULL(credit,0))-sum(ISNULL(debit,0))) as amount from account ";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }
            }
            else
            {
                string sql = "select (sum(ISNULL(credit,0))-sum(ISNULL(debit,0))) as amount from account where username='" + username + "' ";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string IncomeTypeBalance(string username, string incomeType)
    {
        string total = "0";
        try
        {
            if (username == "Admin")
            {
                string sql = "select (sum(ISNULL(credit,0))-sum(ISNULL(debit,0))) as amount from account where planType in ('" + incomeType + "')";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }
            }
            else
            {
                string sql = "select (sum(ISNULL(credit,0))-sum(ISNULL(debit,0))) as amount from account where username='" + username + "' and  planType in ('" + incomeType + "')";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                    total = total == "" ? "0" : total;
                }

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string IdActiveDays(string username,string rid)
    {
        string day = "0";
        try
        {

            clsConnection objcon1 = new clsConnection();
            string sql = "SELECT [dbo].[IdActiveDays] ('"+ username + "','"+ rid + "')";

            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                day = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return day;

    }
    public string Capping(string username)
    {
        string status = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select Capping from register where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                status = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return status;

    }
    public string CappingWithdraw(string username)
    {
        string status = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select isnull(sum(amount),0) from tblrwithdraw where username='" + username + "' and Status in ('Pending','Approved')";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                status = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return status;

    }
    public string AccountStatus(string username)
    {
        string status = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select status from register where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                status = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return status;

    }
    public string CappingBalance(string username)
    {
        string total = "0";
        try
        {
            string sql = "select [dbo].[Capping]('" + username + "')   ";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();
                total = total == "" ? "0" : total;
            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string SamePancard(string PanNo)
    {
        string total = "0";
        try
        {
            string sql = "select count(username) as Total from tblkyc where pannumber='" + PanNo + "' ";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }

    public string PaidStatus(string username)
    {
        string TotalTeamBusness = "0";
        try
        {
            clsConnection objcon1 = new clsConnection();
            string sql = "select PaidStatus from register where username='" + username + "'";
            DataTable dt = objcon1.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                TotalTeamBusness = dt.Rows[0][0].ToString();


            }


        }
        catch (Exception ex)
        { }
        return TotalTeamBusness;

    }
    public string SameUPI(string UPI)
    {
        string total = "0";
        try
        {
            string sql = "select count(username) as Total from tblkyc where UPI='" + UPI + "' ";

            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                total = dt.Rows[0][0].ToString();

            }


        }
        catch (Exception ex)
        { }

        return total;
    }
}