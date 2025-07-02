using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TripleITConnection;
/// <summary>
/// Summary description for clspayment
/// </summary>
public class clspayment
{
    BussinessLayer ob = new BussinessLayer();
    clsConnection objcon = new clsConnection();
	public clspayment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void transaction(string username, string particular, string debit, string credit)
    {

        try
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string query = "insert into tbtransaction(username,particular,debit,credit,date) values('" + username + "','" + particular + "','" + debit + "','" + credit + "','" + date + "')";
             int a=objcon.ExecuteSqlQuery(query);
        }
        catch (Exception ex)
        { }

    }
    public void UpdateWallet(string username, string currentamount)
    {

        try
        {
            string query = "update account  set total='" + currentamount + "' where username='" + username + "'";
             int a=objcon.ExecuteSqlQuery(query);
        }
        catch (Exception ex)
        { }

    }
    public double checkwallet(string username)
    {
        double amt = 0;
        try
        {

            string query = "select total from account where username='" + username + "'";
            DataTable dt = objcon.ReturnDataTableSql(query);
            if (dt.Rows.Count > 0)
            {

                amt = Convert.ToDouble(dt.Rows[0]["total"].ToString());
            }
            else
            { amt = 0; }


        }
        catch (Exception ex)
        { }
        return amt;

    }
}