using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
/// <summary>
/// Summary description for clsfunction
/// </summary>
public class clsfunction
{ clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    clsAMD objamd = new clsAMD();
    public clsfunction()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //FIND TOTAL CREDIT
    public string totalcredit(string username)
    {
        string amount = "";
        try
        {
            string query = "select sum(cast(credit as real)) as credit from passbook1 where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {

                string credit = dt.Rows[0]["credit"].ToString();
                if (credit != "")
                {

                    double creditno = Convert.ToDouble(credit);
                    amount = creditno.ToString();

                }

                else
                { amount = "0"; }
            }
            else
            { amount = "0"; }
        }
        catch (Exception ex)
        {

        }
        return amount;

    }
    public string ReturnName(string username)
    {
        string Name = "";
        try
        {
            string query = "select Name from register where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            { Name = dt.Rows[0]["Name"].ToString(); }
        }
        catch (Exception ex)
        { }

        return Name;
    }
    public int Returnside(string username)
    {
        int side = 0;
        try
        {
            string query = "select count(Name) as side from register where upline='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                int aa = Convert.ToInt32(dt.Rows[0]["side"].ToString());
                side = (aa + 1);
            }
            else
            { side = 1; }
        }
        catch (Exception ex)
        { }

        return side;
    }
    //FIND TOTAL INCOME INCOMETYPEWISE
    public string totalincometype(string username, string type)
    {
        string amount = "";
        try
        {
            string query = "select sum(cast(credit as real)) as credit from dbo.account where username='" + username + "' and valu='" + type + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {

                string credit = dt.Rows[0]["credit"].ToString();
                if (credit != "")
                {

                    double creditno = Convert.ToDouble(credit);
                    amount = creditno.ToString();

                }

                else
                { amount = "0"; }
            }
            else
            { amount = "0"; }
        }
        catch (Exception ex)
        {

        }
        return amount;

    }
    //FIND TOTAL DEBIT
    public string totaldebit(string username)
    {
        string amount = "0";
        try
        {
            string query = "select sum(cast(debit as real)) as debit  from passbook1 where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                string debit = dt.Rows[0]["debit"].ToString();

                if (debit != "")
                {
                    double debitno = Convert.ToDouble(debit);

                    amount = debitno.ToString();

                }

                else
                { amount = "0"; }
            }
            else
            { amount = "0"; }
        }
        catch (Exception ex)
        {

        }
        return amount;

    }
    //user wallet
    public string ewallet(string username)
    {
        string amount = "";
        try {
            string query = "select sum(cast(debit as real)) as debit ,sum(cast(credit as real)) as credit from dbo.account where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                string debit = dt.Rows[0]["debit"].ToString();
                string credit = dt.Rows[0]["credit"].ToString();
                if (debit != "" && credit != "")
                {
                    double debitno = Convert.ToDouble(debit);
                    double creditno = Convert.ToDouble(credit);
                    amount = (creditno - debitno).ToString();

                }
                else if (debit == "" && credit != "")
                {
                    double debitno = 0;
                    double creditno = Convert.ToDouble(credit);
                    amount = (creditno - debitno).ToString();

                }
                else if (debit != "" && credit == "")
                {
                    double debitno = Convert.ToDouble(debit);
                    double creditno =0;
                    amount = (creditno - debitno).ToString();
                }
                else
                { amount = "0"; }
            }
            else
            { amount = "0"; }
        }
        catch (Exception ex)
        {

        }
        return amount;

    }
    public string epassbookwallet(string username)
    {
        string amount = "";
        try
        {
            string query = "select sum(cast(debit as real)) as debit ,sum(cast(credit as real)) as credit from passbook1 where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                string debit = dt.Rows[0]["debit"].ToString();
                string credit = dt.Rows[0]["credit"].ToString();
                if (debit != "" && credit != "")
                {
                    double debitno = Convert.ToDouble(debit);
                    double creditno = Convert.ToDouble(credit);
                    amount = (creditno - debitno).ToString();

                }
                else if (debit == "" && credit != "")
                {
                    double debitno = 0;
                    double creditno = Convert.ToDouble(credit);
                    amount = (creditno - debitno).ToString();

                }
                else if (debit != "" && credit == "")
                {
                    double debitno = Convert.ToDouble(debit);
                    double creditno = 0;
                    amount = (creditno - debitno).ToString();
                }
                else
                { amount = "0"; }
            }
            else
            { amount = "0"; }
        }
        catch (Exception ex)
        {

        }
        return amount;

    }
    //FOR FINAL  COMPANY BUSNISS  AFTER USER JOIN
    public int clubeincome(string username)
    {
        int clubeamount =0;
        try
        {
            int clubeincome = 0;
            int totaluser = 0;
            //string query = "select max(leftcount) as countuser  FROM total_binarycount ";//where username='" + username + "'";
            string query ="select count(username) from register where reffid='"+username+"'";
            //string query = "select sum(cast(leftcount as real)) as countuser  FROM total_binarycount ";//where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                string countuser = dt.Rows[0]["countuser"].ToString();
                if (countuser != "")
                {
                    totaluser = Convert.ToInt32(countuser);
                    int limit = loaduserobver(username);
                    clubeincome = (totaluser - limit);
                    clubeamount = (clubeincome * 2000);
                }

            }
            else
            {
                int limit = loaduserobver(username);
                clubeincome = (limit);
                clubeamount = (clubeincome * 2000);
            }
          
            }
        catch (Exception ex)
        {

        }
        return clubeamount;

    }
    //FOR COMPANY BUSNISS BEFORE USER JOIN
    public int loaduserobver(string username)
    {
        int limit = 0,income;
        try
        {
            string query1 = "SELECT companylimit FROM total_binarycount  where username='" + username+"'";
            DataTable dtd = objcon.ReturnDataTableSql(query1);
            int id = Convert.ToInt32(dtd.Rows[0]["companylimit"].ToString());
          //  string query2 = "select count(username) from register where status='Active' and id>"+id+"";
           string query2 = "SELECT count(username) as total FROM total_binarycount where leftcount!='0'";// where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query2);
            if (dt.Rows.Count > 0)
            {
                string countuser = dt.Rows[0]["total"].ToString();
                if (countuser != "")
                {
                    limit = Convert.ToInt32(countuser)-id;

                }


            }
        }
        catch (Exception ex)
        {


        }
        income = limit * 2000;
        return income;
    }
    public int checkDirect(string username)
    {

        int totalspn = 0;
        try
        {


            string query1 = "select count(username) as total from sponser where sponser='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query1);
            if (dt.Rows.Count > 0)
            {
                string countuser = dt.Rows[0]["total"].ToString();
                if (countuser != "")
                {
                    totalspn = Convert.ToInt32(countuser);

                }


            }

        }
        catch (Exception ex)
        {


        }
        return totalspn;
    }
    // check clube income
    public void checkINCOME(string username)
    {
        try
        {

            int income = loaduserobver(username);
            //   int income = count * 2000;
            int totaldirect = checkDirect(username);
            if (totaldirect == 2 && income == 300000) //|| totaldirect > 2 && income < 800000)
            {
                int a=  objamd.Account(username, "3000","Clube","0");

            }
            else if (totaldirect == 2 && income == 800000)// || totaldirect > 2 && income < 1000000)
            {
                int a=  objamd.Account(username, "5000","Clube","0");

            }
            else if (totaldirect == 2 && income == 1800000)// || totaldirect > 2 && income < 2500000)
            {
                int a=  objamd.Account(username, "10000","Clube","0");

            }
            else if (totaldirect == 2 && income == 4300000)// || totaldirect > 2 && income < 5000000)
            {
                int a=  objamd.Account(username, "25000","Clube","0");

            }
            else if (totaldirect == 4 && income == 93000000)// || totaldirect > 4 && income < 1000000)
            {
                int a=  objamd.Account(username, "12,500","Clube","0");

            }
            else if (totaldirect == 4 && income == 103000000)// || totaldirect > 4 && income < 2000000)
            {
                int a=  objamd.Account(username, "25000","Clube","0");

            }
            else if (totaldirect == 4 && income == 123000000)// || totaldirect > 4 && income < 5000000)
            {
                int a=  objamd.Account(username, "50000","Clube","0");

            }
            else if (totaldirect == 4 && income == 173000000)// || totaldirect > 4 && income < 10000000)
            {
                int a=  objamd.Account(username, "125000","Clube","0");

            }

            else if (totaldirect == 6 && income == 273000000)// || totaldirect > 6 && income < 15000000)
            {
                int a=  objamd.Account(username, "250000","Clube","0");

            }
            else if (totaldirect == 6 && income == 423000000)// || totaldirect > 6 && income < 20000000)
            {
                int a=  objamd.Account(username, "375000","Clube","0");

            }
            else if (totaldirect == 6 && income == 623000000)// || totaldirect > 6 && income < 25000000)
            {
                int a=  objamd.Account(username, "500000","Clube","0");

            }

            else if (totaldirect == 6 && income == 873000000)// || totaldirect > 6 && income < 30000000)
            {
                int a=  objamd.Account(username, "625000","Clube","0");

            }
            else if (totaldirect == 8 && income == 1173000000)// || totaldirect > 8 && income < 40000000)
            {
                int a=  objamd.Account(username, "750000","Clube","0");

            }
            else if (totaldirect == 8 && income == 1573000000)// || totaldirect > 8 && income < 50000000)
            {
                int a=  objamd.Account(username, "1000000","Clube","0");

            }
            else if (totaldirect == 8 && income == 2073000000)// || totaldirect > 8 && income < 80000000)
            {
                int a=  objamd.Account(username, "1250000","Clube","0");

            }
            //else if (totaldirect == 8 && income == 2873000000) 
            //{
            //    int a=  objamd.Account(username, "2000000","Clube","0");

            //}
            //else if (totaldirect == 8 && income == 2898947500)
            //{
            //    int a=  objamd.Account(username, "","Clube","0");

            //}
        }
        catch (Exception ex)
        {


        }


    }

    public string genratepassword()
    {


        var chars = "ABCDEFGHIJKLMTNOabcdefghijklmnopqrxrtwsa5678943210";
        var stringChars = new char[7];
        var random = new Random();

        for (int ik = 0; ik < stringChars.Length; ik++)
        {
            stringChars[ik] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        return Convert.ToString(finalString);

    }
    public int GetTransPaswwordCheck(string UserName,string TransPassword)
    {
        int status = 0;
        try
        {
            string sql = " select username from register where username='" + UserName + "' and transPassword='"+ TransPassword + "'";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {              
              status = 1;
            }
            else
            { status = 0; }


        }
        catch (Exception ex)
        { }
        return status;

    }

    public string UserStatus(string flag,string status)
    {
      
        string total = "0";
        try
        {
            if (flag == "1")
            {
                string sql = "select Count(name) from register where status='" + status + "' and Dateofjoin='" + objtime.returnStringServerMachTimeHHMM() + "'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }
            }
            else if (flag == "2")
            {
                string sql = "select count(name) from register  where status='Active'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }


            }

            else
            {
                string sql = "select count(name) from register where status='" + status + "' ";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }


            }


        }
        catch (Exception ex)
        { }

        return total;
    } public string AllUser(string flag)
    {
      
        string total = "0";
        try
        {
            if (flag == "1")
            {
                string sql = "select Count(name) from register";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }
            }
            else if (flag == "2")
            {
                string sql = "select count(name) from register  where status='Active'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }


            }

            else
            {
                string sql = "select count(name) from register where status='Not Active' ";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }


            }


        }
        catch (Exception ex)
        { }

        return total;
    }
    public string TotalGiveHelp(string flag, string status)
    {
        string total = "0";
        try
        {
            if (flag == "1")
            {
                string sql = "select count(inx) from TblGiveHelp where status='" + status + "' and DOR='" + objtime.returnStringServerMachTimeHHMM() + "'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }
            }
            else
            {
                string sql = "select count(inx) from TblGiveHelp where status='" + status + "' ";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }


            }



        }
        catch (Exception ex)
        { }

        return total;
    }

    public string TotalGetHelp(string flag, string status)
    {
        string total = "0";
        try
        {
            if (flag == "1")
            {
                string sql = "select count(inx) from TblGetHelp where status='" + status + "' and DOR='" + objtime.returnStringServerMachTimeHHMM() + "'";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }
            }
            else
            {
                string sql = "select count(inx) from TblGetHelp where status='" + status + "' ";
                DataTable dt = objcon.ReturnDataTableSql(sql);
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();

                }


            }



        }
        catch (Exception ex)
        { }

        return total;
    }
}