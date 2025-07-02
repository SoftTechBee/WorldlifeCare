using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for IMPSAPI
/// </summary>
public class IMPSAPI
{
    public IMPSAPI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string HitIMPS(string postData)
    {
        string status = "";
        WebRequest request = WebRequest.Create("https://partners.hypto.in/api/transfers/initiate");
        request.Method = "POST";
        request.Credentials = CredentialCache.DefaultCredentials;
        WebHeaderCollection myWebHeaderCollection = request.Headers;
        myWebHeaderCollection.Add("Authorization:4dff92cb-1701-407a-832f-d25b4103ed8d");
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        status = ((HttpWebResponse)response).StatusDescription;

        // Get the stream containing content returned by the server.
        // The using block ensures the stream is automatically closed.
        using (dataStream = response.GetResponseStream())
        {
            //  Open the stream using a StreamReader for easy access.

            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            //Display the content.
            Console.WriteLine(responseFromServer);
        }

        //Close the response.
        response.Close();
        return status;

    }
   

}