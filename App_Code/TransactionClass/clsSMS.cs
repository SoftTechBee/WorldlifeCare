using System;
using System.Data;
using System.IO;
using System.Net;

/// <summary>
/// Summary description for clsSMS
/// </summary>
public class clsSMS
{
	public clsSMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void sendsms(string ReciverMobile, string Msg)
    {
        try
        {
           WebClient client = new WebClient();
            double messto = Convert.ToDouble(ReciverMobile);
            string baseurl = "http://sms.bulksmsind.in/sendSMS?username=Junaid&message=" + Msg + "&sendername=HPAYIN&smstype=TRANS&numbers=" + messto + "&apikey=c7b58a31-0eb5-4ed0-8aed-2b4d111b2e64";
            client.OpenRead(baseurl);

        }
        catch (Exception ex) { }
    }
  

    public string  Recharge(string Mobile, string Amount,string OpCode,string RequestID)
    {
        string Status = "";
        try
        {
            DataTable dt = new System.Data.DataTable();

            WebClient client = new WebClient();
            string baseurl = "http://happykwik.com/retailer/api/do_recharge_transaction.aspx?key=V2ttppYhY8Hb8m0HpjfKOSWUgsdGdA61v%2f224TfoEII%3d&password=7703877021&mobile="+Mobile+"&amount="+ Amount + "&opcode="+ OpCode + "&requestid="+ RequestID +" ";
           Stream valu= client.OpenRead(baseurl);
            StreamReader sr = new StreamReader(valu);
             string xmldata = sr.ReadToEnd();
            // Close the stream. 
            valu.Close();
           
            String[] spearator = { "<Status>" };
            Int32 count = 2;

            // using the method 
            String[] strlist = xmldata.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);
            string finalstatus = strlist[1].ToString();
            String[] spearator1 = { "</" };
            String[] strlist1 = finalstatus.Split(spearator1, count, StringSplitOptions.RemoveEmptyEntries);
            Status = strlist1[0];
        }
        catch (Exception ex) { }
        return Status;
    }
    public string RechargeApiSecond(string Mobile, string Amount, string OpCode, string RequestID,string username)
    {
        string Status = "";
        try
        {
            DataTable dt = new System.Data.DataTable();

            WebClient client = new WebClient();
            string baseurl = "http://instant.rechargeboss.com/api/allrechargeapiM.php?usrnm=snapfactory&psw=snap850&mobile="+ Mobile + "&opid="+ OpCode + "&amt="+Amount+ "&unique_idn="+RequestID+"&opt1=" + username + "&opt2=&opt3=&opt4=";
            Stream valu = client.OpenRead(baseurl);
            StreamReader sr = new StreamReader(valu);
            string xmldata = sr.ReadToEnd();
            // Close the stream. 
            valu.Close();

            String[] spearator = { "<RequestResponse>" };
            Int32 count = 2;

            // using the method 
            String[] strlist = xmldata.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);
            string finalstatus = strlist[1].ToString();
            String[] spearator1 = { "</" };
            String[] strlist1 = finalstatus.Split(spearator1, count, StringSplitOptions.RemoveEmptyEntries);
            Status = strlist1[0];
        }
        catch (Exception ex) {

            Status = "Failed";
        }
        return Status;
    }


    public double bitcoinvalue(double dollor)
    {
        double bitcoin = 0;
        try
        {

            var uri = String.Format(@"https://blockchain.info/tobtc?currency=USD&value="+ dollor);

            WebClient client = new WebClient();

            client.UseDefaultCredentials = true;

            var data = client.DownloadString(uri);

            var result = Convert.ToDouble(data.Replace('.', ',')); //you will receive 1 btc = result;

        }
        catch (Exception ex)
        { }

        return bitcoin;
    
    }


}