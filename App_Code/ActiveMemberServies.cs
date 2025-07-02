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
/// Summary description for ActiveMemberServies
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ActiveMemberServies : System.Web.Services.WebService
{
    clsList objlist = new clsList();
    clsConnection objcon = new clsConnection();
    public List<clspinused> objpinlist = new List<clspinused>();
    public List<clspinunused> objpinunlist = new List<clspinunused>();
    public List<clsuser> objuserlist = new List<clsuser>();
    public ActiveMemberServies()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
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
                    objuser.city = dt.Rows[i]["city"].ToString();
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

}

