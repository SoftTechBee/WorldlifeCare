using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Summary description for ClsDoopme
/// </summary>
public class ClsDoopme
{
    public ClsDoopme()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string GETBankList()
    {
        byte[] buffer;
        System.Net.HttpWebRequest webRequest;
        string sWSRequest = string.Empty;
        string sWSResponse = string.Empty;
        string sRequest = string.Empty;
        string sMobileNo = string.Empty;
        string sAPIKey = string.Empty;
        string sRespType = string.Empty;
        string sChecksum = string.Empty;
        string sAPIVersion = string.Empty;
        string sAgentCode = string.Empty;
        string sURL = string.Empty;
        string myoutput = string.Empty;


        try
        {
            sURL = " https://www.doopme.com/RechargeAPI/PBPDMRService.asmx ";
            sMobileNo = "9172153393"; //Please use your registered mobile no
            sAPIKey = "EdOxWROUcmJhwOhUG7ReqGiaF5w6NBQGbFI"; //Please use your API Key
            sRespType = "JSON";
            sAPIVersion = "1.0";
            sAgentCode = "RT001"; //Please use your Retailer's Unique ID/Code

            sRequest = "<NTDREQ><REQTYPE>GBL</REQTYPE></NTDREQ>";
            sChecksum = GenerateSHA512(sAPIKey, sRequest);

            sWSRequest = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Header><DMRAuthHeader xmlns=\"http://tempuri.org/\"><MobileNo>" + sMobileNo + "</MobileNo><APIKey>" + sAPIKey + "</APIKey><ResponseType>" + sRespType + "</ResponseType><Checksum>" + sChecksum + "</Checksum><Version>" + sAPIVersion + "</Version><AgentCode>" + sAgentCode + "</AgentCode></DMRAuthHeader></soap:Header><soap:Body><GetBankList  xmlns='http://tempuri.org/'><sRequest>" + EncodeForXml(sRequest) + "</sRequest>    </GetBankList ></soap:Body></soap:Envelope>";

            buffer = System.Text.Encoding.ASCII.GetBytes(sWSRequest);
            webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sURL);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.ContentLength = buffer.Length;

            System.IO.Stream stream = webRequest.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
            
            using (System.IO.StreamReader responseReader = new System.IO.StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                sWSResponse = responseReader.ReadToEnd();
            }
            XDocument docX = XDocument.Parse(sWSResponse);
            XNamespace ns = "http://tempuri.org/";

            var result = docX.Root.Descendants(ns + "GetBankListResult").FirstOrDefault();
            if (!String.IsNullOrEmpty(result.Value.ToString()))
            {
              myoutput= result.Value.ToString();
            }
            return myoutput;
        }
        catch (Exception ex)
        {
            return myoutput;
            //Handle your exception here
        }
    }

    public string AddCustomer(string CustomerNo,string FNAME, string LNAME, string Address, string ADD1, string ADD2, string City, string State,string Pincode)
    {
        byte[] buffer;
        System.Net.HttpWebRequest webRequest;
        string sWSRequest = string.Empty;
        string sWSResponse = string.Empty;
        string sRequest = string.Empty;
        string sMobileNo = string.Empty;
        string sAPIKey = string.Empty;
        string sRespType = string.Empty;
        string sChecksum = string.Empty;
        string sAPIVersion = string.Empty;
        string sAgentCode = string.Empty;
        string sURL = string.Empty;
        string myoutput = string.Empty;


        try
        {
            sURL = " https://www.doopme.com/RechargeAPI/PBPDMRService.asmx ";
            sMobileNo = "9172153393"; //Please use your registered mobile no
            sAPIKey = "EdOxWROUcmJhwOhUG7ReqGiaF5w6NBQGbFI"; //Please use your API Key
            sRespType = "JSON";
            sAPIVersion = "1.0";
            sAgentCode = "RT001"; //Please use your Retailer's Unique ID/Code
            sRequest = "<NTDREQ><REQTYPE>AC</REQTYPE>" +
                "<CUSTOMERNO>"+CustomerNo+"</CUSTOMERNO><FNAME>"+ FNAME + "</FNAME><LNAME>"+ LNAME + "</LNAME><ANAME>" + Address+"</ANAME><ADD1>"+ ADD1 + "</ADD1><ADD2>"+ ADD2 + "</ADD2><CITY> "+City+" </CITY><STATE> "+State+" </STATE><COUNTRY> India </COUNTRY><PCODE> "+Pincode+" </PCODE></NTDREQ>";
            sChecksum = GenerateSHA512(sAPIKey, sRequest);
            sWSRequest = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Header><DMRAuthHeader xmlns=\"http://tempuri.org/\"><MobileNo>" + sMobileNo + "</MobileNo><APIKey>" + sAPIKey + "</APIKey><ResponseType>" + sRespType + "</ResponseType><Checksum>" + sChecksum + "</Checksum><Version>" + sAPIVersion + "</Version><AgentCode>" + sAgentCode + "</AgentCode></DMRAuthHeader></soap:Header><soap:Body><AddCustomer   xmlns='http://tempuri.org/'><sRequest>" + EncodeForXml(sRequest) + "</sRequest>    </AddCustomer></soap:Body></soap:Envelope>";

            buffer = System.Text.Encoding.ASCII.GetBytes(sWSRequest);
            webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sURL);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.ContentLength = buffer.Length;

            System.IO.Stream stream = webRequest.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
           
            using (System.IO.StreamReader responseReader = new System.IO.StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                sWSResponse = responseReader.ReadToEnd();
            }
            XDocument docX = XDocument.Parse(sWSResponse);
            XNamespace ns = "http://tempuri.org/";

            var result = docX.Root.Descendants(ns + "AddCustomerResult").FirstOrDefault();
            if (!String.IsNullOrEmpty(result.Value.ToString()))
            {
                myoutput = result.Value.ToString();
            }
            return myoutput;


        }
        catch (Exception ex)
        {
            return myoutput;
            //Handle your exception here
        }
    }

    public string AddBeneficiary(string CustomerNo, string NAME, string BANKID, string ACCNO, string IFSC)
    {
        byte[] buffer;
        System.Net.HttpWebRequest webRequest;
        string sWSRequest = string.Empty;
        string sWSResponse = string.Empty;
        string sRequest = string.Empty;
        string sMobileNo = string.Empty;
        string sAPIKey = string.Empty;
        string sRespType = string.Empty;
        string sChecksum = string.Empty;
        string sAPIVersion = string.Empty;
        string sAgentCode = string.Empty;
        string sURL = string.Empty;
        string myoutput= string.Empty;


        try
        {
            sURL = " https://www.doopme.com/RechargeAPI/PBPDMRService.asmx ";
            sMobileNo = "9172153393"; //Please use your registered mobile no
            sAPIKey = "EdOxWROUcmJhwOhUG7ReqGiaF5w6NBQGbFI"; //Please use your API Key
            sRespType = "JSON";
            sAPIVersion = "1.0";
            sAgentCode = "RT001"; //Please use your Retailer's Unique ID/Code
            sRequest = "<NTDREQ><REQTYPE>AB</REQTYPE><CUSTOMERNO> "+CustomerNo+" </CUSTOMERNO><NAME> "+ NAME + " </NAME><MOBILENO> " + CustomerNo+" </MOBILENO><BANKID> "+ BANKID + " </BANKID><ACCNO> "+ ACCNO + " </ACCNO><IFSC> "+ IFSC + " </IFSC></NTDREQ>";
            sChecksum = GenerateSHA512(sAPIKey, sRequest);
            sWSRequest = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Header><DMRAuthHeader xmlns=\"http://tempuri.org/\"><MobileNo>" + sMobileNo + "</MobileNo><APIKey>" + sAPIKey + "</APIKey><ResponseType>" + sRespType + "</ResponseType><Checksum>" + sChecksum + "</Checksum><Version>" + sAPIVersion + "</Version><AgentCode>" + sAgentCode + "</AgentCode></DMRAuthHeader></soap:Header><soap:Body><AddBeneficiary xmlns='http://tempuri.org/'><sRequest>" + EncodeForXml(sRequest) + "</sRequest>    </AddBeneficiary></soap:Body></soap:Envelope>";

            buffer = System.Text.Encoding.ASCII.GetBytes(sWSRequest);
            webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sURL);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.ContentLength = buffer.Length;

            System.IO.Stream stream = webRequest.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();           
            using (System.IO.StreamReader responseReader = new System.IO.StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                sWSResponse = responseReader.ReadToEnd();
            }
            XDocument docX = XDocument.Parse(sWSResponse);
            XNamespace ns = "http://tempuri.org/";

            var result = docX.Root.Descendants(ns + "AddBeneficiaryResult").FirstOrDefault();
            if (!String.IsNullOrEmpty(result.Value.ToString()))
            {
                myoutput = result.Value.ToString();
            }
            return myoutput;
        }
        catch (Exception ex)
        {
            return myoutput; //Handle your exception here
        }
    }

    public string RemoveBeneficiary(string CustomerNo, string BENEID)
    {
        byte[] buffer;
        System.Net.HttpWebRequest webRequest;
        string sWSRequest = string.Empty;
        string sWSResponse = string.Empty;
        string sRequest = string.Empty;
        string sMobileNo = string.Empty;
        string sAPIKey = string.Empty;
        string sRespType = string.Empty;
        string sChecksum = string.Empty;
        string sAPIVersion = string.Empty;
        string sAgentCode = string.Empty;
        string sURL = string.Empty;
        string myoutput = string.Empty;


        try
        {
            sURL = " https://www.doopme.com/RechargeAPI/PBPDMRService.asmx ";
            sMobileNo = "9172153393"; //Please use your registered mobile no
            sAPIKey = "EdOxWROUcmJhwOhUG7ReqGiaF5w6NBQGbFI"; //Please use your API Key
            sRespType = "JSON";
            sAPIVersion = "1.0";
            sAgentCode = "RT001"; //Please use your Retailer's Unique ID/Code
            sRequest = "<NTDREQ><REQTYPE>DB</REQTYPE><CUSTOMERNO> " + CustomerNo + " </CUSTOMERNO><BENEID> " + BENEID + " </BENEID></NTDREQ>";
            sChecksum = GenerateSHA512(sAPIKey, sRequest);
            sWSRequest = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Header><DMRAuthHeader xmlns=\"http://tempuri.org/\"><MobileNo>" + sMobileNo + "</MobileNo><APIKey>" + sAPIKey + "</APIKey><ResponseType>" + sRespType + "</ResponseType><Checksum>" + sChecksum + "</Checksum><Version>" + sAPIVersion + "</Version><AgentCode>" + sAgentCode + "</AgentCode></DMRAuthHeader></soap:Header><soap:Body><AddBeneficiary xmlns='http://tempuri.org/'><sRequest>" + EncodeForXml(sRequest) + "</sRequest>    </AddBeneficiary></soap:Body></soap:Envelope>";

            buffer = System.Text.Encoding.ASCII.GetBytes(sWSRequest);
            webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sURL);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.ContentLength = buffer.Length;

            System.IO.Stream stream = webRequest.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
            using (System.IO.StreamReader responseReader = new System.IO.StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                sWSResponse = responseReader.ReadToEnd();
            }
            XDocument docX = XDocument.Parse(sWSResponse);
            XNamespace ns = "http://tempuri.org/";

            var result = docX.Root.Descendants(ns + "AddBeneficiaryResult").FirstOrDefault();
            if (!String.IsNullOrEmpty(result.Value.ToString()))
            {
                myoutput = result.Value.ToString();
            }
            return myoutput;
        }
        catch (Exception ex)
        {
            return myoutput; //Handle your exception here
        }
    }
    public string SendMoney(string CustomerNo, string Benid, string Amount, string TransactionID)
    {
        byte[] buffer;
        System.Net.HttpWebRequest webRequest;
        string sWSRequest = string.Empty;
        string sWSResponse = string.Empty;
        string sRequest = string.Empty;
        string sMobileNo = string.Empty;
        string sAPIKey = string.Empty;
        string sRespType = string.Empty;
        string sChecksum = string.Empty;
        string sAPIVersion = string.Empty;
        string sAgentCode = string.Empty;
        string sURL = string.Empty;
        string myoutput = string.Empty;


        try
        {
            sURL = " https://www.doopme.com/RechargeAPI/PBPDMRService.asmx ";
            sMobileNo = "9172153393"; //Please use your registered mobile no
            sAPIKey = "EdOxWROUcmJhwOhUG7ReqGiaF5w6NBQGbFI"; //Please use your API Key
            sRespType = "JSON";
            sAPIVersion = "1.0";
            sAgentCode = "RT001"; //Please use your Retailer's Unique ID/Code
            sRequest = "<NTDREQ><REQTYPE>SM</REQTYPE><CUSTOMERNO>"+CustomerNo+" </CUSTOMERNO> <BENEID> "+ Benid + " </BENEID><AMT> "+Amount+" </AMT><TRNTYPE> 1 </TRNTYPE><IMPS_SCHEDULE> 1 </IMPS_SCHEDULE><REFNO> "+ TransactionID + " </REFNO><CHN> WEB </CHN><CUR> INR </CUR><AG_LAT></AG_LAT><AG_LONG></AG_LONG></NTDREQ>";
            sChecksum = GenerateSHA512(sAPIKey, sRequest);
            sWSRequest = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Header><DMRAuthHeader xmlns=\"http://tempuri.org/\"><MobileNo>" + sMobileNo + "</MobileNo><APIKey>" + sAPIKey + "</APIKey><ResponseType>" + sRespType + "</ResponseType><Checksum>" + sChecksum + "</Checksum><Version>" + sAPIVersion + "</Version><AgentCode>" + sAgentCode + "</AgentCode></DMRAuthHeader></soap:Header><soap:Body><SendMoney  xmlns='http://tempuri.org/'><sRequest>" + EncodeForXml(sRequest) + "</sRequest></SendMoney></soap:Body></soap:Envelope>";

            buffer = System.Text.Encoding.ASCII.GetBytes(sWSRequest);
            webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sURL);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.ContentLength = buffer.Length;

            System.IO.Stream stream = webRequest.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
           
            using (System.IO.StreamReader responseReader = new System.IO.StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                sWSResponse = responseReader.ReadToEnd();
            }
            
            XDocument docX = XDocument.Parse(sWSResponse);
            XNamespace ns = "http://tempuri.org/";

            var result = docX.Root.Descendants(ns + "SendMoneyResult").FirstOrDefault();
            if (!String.IsNullOrEmpty(result.Value.ToString()))
            {
                myoutput = result.Value.ToString();
            }
            return myoutput;
        }
        catch (Exception ex)
        {
            return myoutput; //Handle your exception here
        }
    }
    private string EncodeForXml(string data)
    {
        System.Text.RegularExpressions.Regex badAmpersand = new System.Text.RegularExpressions.Regex("&(?![a-zA-Z]{2,6};|#[0-9]{2,4};)");
        data = badAmpersand.Replace(data, "&amp;");

        return data.Replace("<", "&lt;").Replace("\"", "&quot;").Replace(">", "&gt;");
    }

    private string GenerateSHA512(string keyString, string inputString)
    {
        System.Text.UTF8Encoding mEncoding = new System.Text.UTF8Encoding();
        string sResult = string.Empty;
        byte[] keyBytes;
        byte[] messageBytes;
        try
        {
            keyBytes = mEncoding.GetBytes(keyString);
            messageBytes = mEncoding.GetBytes(inputString);

            using (var hmacsha = new System.Security.Cryptography.HMACSHA512(keyBytes))
            {
                hmacsha.ComputeHash(messageBytes);
                sResult = GetStringFromHash(hmacsha.Hash);
            }

            return sResult;
        }
        catch (Exception ex)
        {
            // Handle your exception here
            return "";
        }
    }

    private string GetStringFromHash(byte[] hash)
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();
        for (int i = 0; i <= hash.Length - 1; i++)
            result.Append(hash[i].ToString("X2"));

        return result.ToString();
    }

}
