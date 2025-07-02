using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TripleITTransaction;
using TripleITConnection;
/// <summary>
/// Summary description for clsAccount
/// </summary>
public class clsAccount
{// clsConnection objcon = new clsConnection();
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    public List<clspinused> objpinlist = new List<clspinused>();
    public List<clspinunused> objpinunlist = new List<clspinunused>();
    public List<clsuser> objuserlist = new List<clsuser>();
    public List<clsaccount> objacclist = new List<clsaccount>();
    public clsAccount()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Debitspid(string spid)
    {
        int amount = 0;
        try
        {
          
            string query = " SELECT SUM(CONVERT(int , Amount)) as amount FROM TblAccount WHERE  satus!='Pending' and AcountStatus = 'Debit' and SponserId = '"+spid+"'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                string a = dt.Rows[0]["amount"].ToString();
                if (a == "")
                {
                    amount = 0;

                }
                amount += Convert.ToInt32(a);
            }
        }
        catch (Exception ex)
        {


        }
        return amount;
    }
    public int Creditspid(string spid)
    {
        int amount = 0;
        try
        {

            string query = "SELECT SUM(CONVERT(int , Amount)) as amount FROM TblAccount WHERE  satus!='Pending' and AcountStatus = 'Credit' and SponserId ='" + spid+"' ";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {
                string a = dt.Rows[0]["amount"].ToString();
                if (a == "")
                {
                    amount = 0;

                }
                amount += Convert.ToInt32(a);
            }
        }
        catch (Exception ex)
        {


        }
        return amount;
    }

    public int FinalAmount(string spid)
    {
        int amount = (Creditspid(spid) - Debitspid(spid));


        return amount;
    }


 


}