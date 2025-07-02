using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using TripleITTransaction;
using TripleITConnection;
/// <summary>
/// Summary description for loadlist
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
[System.ComponentModel.ToolboxItem(false)]
[System.Web.Script.Services.ScriptService]
public class loadlist : System.Web.Services.WebService
{ 
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    public  List<clspinused> objpinlist = new List<clspinused>();
    public List<clspinunused> objpinunlist = new List<clspinunused>();
    public List<clsuser> objuserlist = new List<clsuser>();
    public List<clsaccount> objacclist = new List<clsaccount>();

   
    [WebMethod(EnableSession = true)]
    public void loadusedpin()
    {
        try {
            string username = SessionData.Get<string>("newuser");
            string sql = "";
            if (username != "Admin")
            {
                sql = "select pin,amount,status,username from pinmgt where status='Used' and username='" + username + "'";

            }
            else
            {
                sql = "select pin,amount,status,username from pinmgt where status='Used'";// and username='" + username + "'";

            }  
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clspinused objusedpin = new clspinused();
                    objusedpin.pin = dt.Rows[i]["pin"].ToString();
                    objusedpin.amount= dt.Rows[i]["amount"].ToString();
                    objusedpin.username= dt.Rows[i]["username"].ToString();
                    objusedpin.status= dt.Rows[i]["status"].ToString();

                    objpinlist.Add(objusedpin);
                }


            }

           
        }
        catch (Exception ex)
        {

        }
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(objpinlist));
    }
    [WebMethod(EnableSession = true)]
    public void loadpin()
    {
        try
        {
            string username = SessionData.Get<string>("newuser");
            string sql = "";
            if (username != "Admin")
            {
                sql = "select pin,amount,status,username from pinmgt where status='Not Used' and username='" + username + "'";
            }
            else
            {
                sql = "select pin,amount,status,username from pinmgt";// where status='Not Used'";// and username='" + username + "'";

            }
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clspinunused objunusedpin = new clspinunused();
                    objunusedpin.pin = dt.Rows[i]["pin"].ToString();
                    objunusedpin.amount = dt.Rows[i]["amount"].ToString();
                    objunusedpin.username = dt.Rows[i]["username"].ToString();
                    objunusedpin.status = dt.Rows[i]["status"].ToString();

                    objpinunlist.Add(objunusedpin);
                }


            }


        }
        catch (Exception ex)
        {

        }
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(objpinunlist));
    }
    [WebMethod]
    public void loaddirect()
    {
        try
        {
            //string username = SessionData.Get<string>("newuser");
            string sql = "";
            //if (username != "Admin")
            //{
            //    sql = " select username, name, mobile, city, reffname, reffid, dateofjoining from register where reffid ='" + SessionData.Get<string>("newuser") + "'";

            //}
            //else
            //{

            //    sql = " select username, name, mobile, city, reffname, reffid, dateofjoining from register";

            //}
            sql = " select username, name, mobile, city, reffname, reffid, dateofjoining from register";
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsuser objuser = new clsuser();
                    objuser.city= dt.Rows[i]["city"].ToString();
                    objuser.mobile = dt.Rows[i]["mobile"].ToString();
                    objuser.name = dt.Rows[i]["name"].ToString();
                    objuser.reffid = dt.Rows[i]["reffid"].ToString();
                    objuser.reffname = dt.Rows[i]["reffname"].ToString();
                    objuser.username = dt.Rows[i]["username"].ToString();


                    objuserlist.Add(objuser);
                }


            }


        }
        catch (Exception ex)
        {

        }
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(objuserlist));
    }
    [WebMethod( EnableSession = true)]
    public void loadaccount()
    {
        try
        {
            string username = SessionData.Get<string>("newuser");
            string sql = "";
            if (username != "Admin")
            {
                sql = " select  username,credit,debit,date,payable from account where username ='" + username + "'";
            }
            else
            {
                sql = " select  username,credit,debit,date,payable from account";// where username ='" + username + "'";

            }
            DataTable dt = objcon.ReturnDataTableSql(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsaccount objacc = new clsaccount();
                    objacc.username = dt.Rows[i]["username"].ToString();
                    objacc.credit= dt.Rows[i]["credit"].ToString();
                    objacc.debit = dt.Rows[i]["debit"].ToString();
                    objacc.date = dt.Rows[i]["date"].ToString();
                    objacc.remark = dt.Rows[i]["payable"].ToString();



                    objacclist.Add(objacc);
                }


            }


        }
        catch (Exception ex)
        {

        }
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(objacclist));
    }

}
