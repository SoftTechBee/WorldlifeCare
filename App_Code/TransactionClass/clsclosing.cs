using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TripleITConnection;
using TripleITTransaction;
/// <summary>
/// Summary description for clsclosing
/// </summary>
public class clsclosing
{
    clsfunction objfun = new clsfunction();
    clsAMD objamd = new clsAMD();
    clsConnection objcon = new clsConnection();
    clsTimeZone objtime = new clsTimeZone();
    public string reffid = "";
    public clsclosing()
    {

       

    }

  

    public void closing()
    {
        try
        {
            string closingdate = DateTime.Now.AddHours(5.30).ToString("yyyy-MM-dd");
            string newbackdate = Convert.ToDateTime(closingdate).AddDays(-1).ToString("yyyy-MM-dd");

            string sql = "select count from closingdate where dateto ='" + newbackdate + "' ";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
               
            }
            
            else                  
            {
                string query = "insert into closingdate(dateto,count)values('" + newbackdate + "','1')";
                 int status = objcon.ExecuteSqlQuery(query);
                        if (status > 0)
                        {
                    
                           int aaa = objamd.SetRoiWeekly();
                         
                         //  int xx = objamd.SetDirectROI();
                           //int xcheckx = objamd.CheckIncome300();
                           //int sala = objamd.SalaryDistribution();
                }
              }
        }
        catch (Exception ex)
        {
           

        }

    }

   
    public void MasterClosing()
    {
     
        try
        {
            //check first time binary or secoand time piar
            string sql11 = "exec [dbo].[MachingDateMaster]";
            int aa = objcon.ExecuteSqlQuery(sql11);
            

        }
        catch (Exception ex)
        {


        }
        

    }

    private void setbinaryzero(string username, int left, int right)
    {
        try
        {

            string query = "update daily_binarycount set leftcount='" + left + "',rightcount='" + right + "' where username='" + username + "'";
            int status = objcon.ExecuteSqlQuery(query);


        }
        catch (Exception ex)
        {

        }
    }

    private void Paidbinarycount(string username, int left, int right)
    {
        try
        {

            string query = "update daily_counttable set leftcount='" + left + "',rightcount='" + right + "' where username='" + username + "'";
            int status = objcon.ExecuteSqlQuery(query);


        }
        catch (Exception ex)
        {

        }
    }

   
    }


