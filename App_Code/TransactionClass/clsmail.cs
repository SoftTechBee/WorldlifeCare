using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.IO;
using System.Xml;
using System.Net;
using TripleITTransaction;
/// <summary>
/// Summary description for clsmail
/// </summary>
public class clsmail
{
    public clsmail()
    {
        //
        // TODO: Add constructor logic here
        //info@worldlifecareenterprises.com
    }
    private static string MailSmtp = "smtpout.secureserver.net";
    //private static string MailSmtp = "relay-hosting.secureserver.net";
    private static string MailUserName = "info@worldlifecareenterprises.com";
    private static string MailPassword = "Admin@123";
    public string sendpass(string Name, string Username, string pass, string TransactionPass, string Email)
    {
        try
        {
                     


           
           string msg = "Dear " + Name + ",<br />Welcome toWorld Life Care .Your Registration has been Successfully completed.<br /><br /><bold>Your account details are as follows :</bold><br />Your UserName:-" + Username + "<br /> Your Password :-" + pass + "<br/>";
            msg += "Transaction Password:-" + TransactionPass + "<br /><br />";
            msg += "Please reachout to US, If you have any Concerns, simply write a mail to<br />";
            msg += "info@worldlifecareenterprises.com. We're always happy to help you..!!<br /><br />";
            msg += "<br/><br/>Cheers! <br/><h3> TEAMWorld Life Care <h3/> <br/>visit:-<a href=http://worldlifecareenterprises.com>www.worldlifecareenterprises.com</a>";

            MailAddress FromMailAddress = new MailAddress(MailUserName, "World Life Care ");
            MailMessage theTestMail = new MailMessage(FromMailAddress.ToString(), Email);
            theTestMail.Body = msg;
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "Registration  "; ;

            SmtpClient theTest = new SmtpClient();
            theTest.Port = 25;
            theTest.Timeout = 100;
            theTest.Host = MailSmtp;
            theTest.UseDefaultCredentials = true;
            theTest.EnableSsl = false;

            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(MailUserName, MailPassword);
            theTest.Credentials = theCredential;
            theTest.Send(theTestMail);



            string s = "Yes";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    public string DepositeFund(string Name, string Amount, string to)
    {
        try
        {


           
            string msg = "Dear " + Name + ",<br />" + Amount + "<br/>";
            msg += "Should you have any questions, reply to this email or simply write a mail to<br />";
            msg += "info@worldlifecareenterprises.com We're always happy to help you.<br /><br />";
            msg += "<br/><h3> TEAMWorld Life Care <h3/> <br/>visit:-<a https://worldlifecareenterprises.com>www.worldlifecareenterprises.com</a>";



            MailAddress FromMailAddress = new MailAddress(MailUserName, "World Life Care ");
            MailMessage theTestMail = new MailMessage(FromMailAddress.ToString(), to);
            theTestMail.Body = msg;
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "Fund Deposite"; ;

            SmtpClient theTest = new SmtpClient();
            theTest.Port = 25;
            theTest.Timeout = 100;
            theTest.Host = MailSmtp;
            theTest.UseDefaultCredentials = true;
            theTest.EnableSsl = false;

            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(MailUserName, MailPassword);
            theTest.Credentials = theCredential;
            theTest.Send(theTestMail);



            string s = "Successfully";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    public string ForgotPassword(string Name, string Username, string pass, string TransactionPass, string Email)
    {
        try
        {

            
           string msg= "Dear " + Name + ",<br /><bold>Your account details are as follows :</bold><br />Your UserName:-" + Username + "<br /> Your Password :-" + pass + "<br/>";
            msg += "Transaction Password:-" + TransactionPass + "<br /><br />";
            msg += "Should you have any questions, reply to this email or simply write a mail to<br />";
            msg += "info@worldlifecareenterprises.com We're always happy to help you.<br /><br />";
            msg += "<br/><h3> TEAMWorld Life Care <h3/> <br/>visit:-<a https://worldlifecareenterprises.com>www.worldlifecareenterprises.com</a>";



            MailAddress FromMailAddress = new MailAddress(MailUserName, "World Life Care ");
            MailMessage theTestMail = new MailMessage(FromMailAddress.ToString(), Email);
            theTestMail.Body = msg;
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "Forgot Password  "; ;

            SmtpClient theTest = new SmtpClient();
            theTest.Port = 25;
            theTest.Timeout = 100;
            theTest.Host = MailSmtp;
            theTest.UseDefaultCredentials = true;
            theTest.EnableSsl = false;

            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(MailUserName, MailPassword);
            theTest.Credentials = theCredential;
            theTest.Send(theTestMail);



            string s = "Password has sent successfully on your register '"+ Email + "'.";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }

    public string WithdrawFund(string Name, string Amount, string PaymentType, string Adddress, string Email)
    {
        try
        {

           
            string msg = "Dear  " + Name + ",<br />You've requested to withdraw " + Amount + " " + PaymentType + "to this Address:" + Adddress + "<br/>";

            msg += "Before going further with the withdrawal, pleasecheck carefully the target address.<br />";
            msg += "Be aware that if you confirm an incorrect address, we won't be able to assist you to recover your assets.< br />";
            msg += "Should you have any questions, simply write a mail to.<br />info@worldlifecareenterprises.com.We're always happy to help you..!!< br />";
            msg += "<br/>Cheers,<br/> <h3>Team DefiClub<h3/> <br/>visit:-<a https://www.deficlub.biz>https://www.deficlub.biz</a>";

            MailAddress FromMailAddress = new MailAddress(MailUserName, "Deficlub");
            MailMessage theTestMail = new MailMessage(FromMailAddress.ToString(), Email);
            theTestMail.Body = msg;
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "No need to rply   "; ;

            SmtpClient theTest = new SmtpClient();
            theTest.Port = 587;
            theTest.Timeout = 100;
            theTest.Host = MailSmtp;
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = false;

            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(MailUserName, MailPassword);
            theTest.Credentials = theCredential;
            theTest.Send(theTestMail);
            string s = "yes";
            return s;

        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    public string WithdrawApproved(string Name, string Amount, string Email)
    {
        try
        {


            string msg = "Dear " + Name + ",<br />" + Amount + "<br/>";
            msg += "Should you have any questions, reply to this email or simply write a mail to<br />";
            msg += "info@worldlifecareenterprises.com We're always happy to help you.<br /><br />";
            msg += "<br/><h3> TEAMWorld Life Care <h3/> <br/>visit:-<a https://worldlifecareenterprises.com>www.worldlifecareenterprises.com</a>";



            MailAddress FromMailAddress = new MailAddress(MailUserName, "World Life Care ");
            MailMessage theTestMail = new MailMessage(FromMailAddress.ToString(), Email);
            theTestMail.Body = msg;
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "Withdraw" ;

            SmtpClient theTest = new SmtpClient();
            theTest.Port = 25;
            theTest.Timeout = 100;
            theTest.Host = MailSmtp;
            theTest.UseDefaultCredentials = true;
            theTest.EnableSsl = false;

            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(MailUserName, MailPassword);
            theTest.Credentials = theCredential;
            theTest.Send(theTestMail);



            string s = "Successfully";
            return s;

        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    
    public string PackageActivate(string Name, string Amount, string to)
    {
        try
        {

            string SenderAddress = "info@worldlifecareenterprises.com";
            // any address Reciver where the email will be sending
            string toAddress = to;
            //Password of your gmail address
            const string SenderPassword = "Admin@123";
            // Passing the values and make a email formate to display


            MailMessage theTestMail = new MailMessage(SenderAddress, toAddress);
            theTestMail.Body = "Dear  " + Name + ",<br />Welcome to DefiClub.  Your  " + Amount + "$ Package has been Successfully Activated.<br/>";

            theTestMail.Body += "Enjoy The DefiClub Coin Benifits.<br />";
            theTestMail.Body += "Should you have any questions, simply write a mail to<br />";
            theTestMail.Body += "info@worldlifecareenterprises.com.We're always happy to help you..!!<br /><br />";
            theTestMail.Body += "<br/>Cheers<br/> <h3>Team DefiClub<h3/> <br/>visit:-<a href=https://www.deficlub.biz>https://www.deficlub.biz</a>";
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "No need to rply   ";

            SmtpClient theTest = new System.Net.Mail.SmtpClient();
            theTest.Port = 25;
            theTest.Host = "relay-hosting.secureserver.net";//from godaddy;//"smtpout.secureserver.net";// "smtp.gmail.com";
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = true;
            theTest.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(SenderAddress, SenderPassword);
            theTest.Credentials = theCredential;
            theTest.Timeout = 20000;
            theTest.Send(theTestMail);
            string s = "yes";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
     public void OTP(string Username, string pass, string to)
    {
        try
        {
           
           
            string msg = "Dear " + Username + ".<br />Your OneTimePassword :-" + pass + " <br/> For Withdraw Request";
            msg += "<br/><br/>Have a great day! <br/><h3>TeamWorld Life Care <h3/> <br/>visit:-<a href=https://worldlifecareenterprises.com>https://www.worldlifecareenterprises.com</a>";
             
             
             
             MailAddress FromMailAddress = new MailAddress(MailUserName, "World Life Care ");
          
          
            MailMessage theTestMail = new MailMessage(FromMailAddress.ToString(), to);
            theTestMail.Body = msg;
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "Withdrawal OTP(No need to rply)   "; ;

            SmtpClient theTest = new SmtpClient();
            theTest.Port = 587;
            theTest.Timeout = 100;
            theTest.Host = MailSmtp;
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = false;

            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(MailUserName, MailPassword);
            theTest.Credentials = theCredential;
            theTest.Send(theTestMail);
            string s = "yes";
           

        }
        catch (Exception ex)
        {
            string s = ex.Message;
            
        }

    }
    public string Notification(string Username, string msg, string to)
    {
        try
        {
            string SenderAddress = "info@worldlifecareenterprises.com";
            // any address Reciver where the email will be sending
            string toAddress = to;
            //Password of your gmail address
            const string SenderPassword = "Admin@123";
            // Passing the values and make a email formate to display


            MailMessage theTestMail = new MailMessage(SenderAddress, toAddress);
            theTestMail.Body = "HI " + Username + ".<br />" + msg + "<br/>";
            theTestMail.Body += "<br/><br/>Have a great day! <br/><h3>Team deficlub<h3/> <br/>visit:-<a href=https://www.deficlub.biz>https://www.deficlub.biz</a>";
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "No need to rply   " + DateTime.Now;


            SmtpClient theTest = new System.Net.Mail.SmtpClient();
            theTest.Port = 25;
            theTest.Host = "relay-hosting.secureserver.net";//from godaddy;//"smtpout.secureserver.net";// "smtp.gmail.com";
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = true;
            theTest.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(SenderAddress, SenderPassword);
            theTest.Credentials = theCredential;
            theTest.Timeout = 20000;
            theTest.Send(theTestMail);
            string s = "yes";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    public string Pack1(string Name,  string to)
    {
        try
        {

            string SenderAddress = "info@worldlifecareenterprises.com";
            // any address Reciver where the email will be sending
            string toAddress = to;
            //Password of your gmail address
            const string SenderPassword = "Admin@123";
            // Passing the values and make a email formate to display


            MailMessage theTestMail = new MailMessage(SenderAddress, toAddress);
            theTestMail.Body = "Dear  " + Name + ",<br />Welcome to DefiClub Crypto Community. Your Registration has been Successfully completed.<br/>";

            theTestMail.Body += "Please Join Our Premium Group : https://t.me/joinchat/rkNzcSTeBQk0ZWQx <br />";
            theTestMail.Body += "Please reach out to US, If you have any Concerns, simply write a mail to <br />";            
            theTestMail.Body += "info@worldlifecareenterprises.com.We're always happy to help you..!!<br /><br />";
            theTestMail.Body += "<br/>Cheers<br/> <h3>Team DefiClub<h3/> <br/>visit:-<a href=https://www.deficlub.biz>https://www.deficlub.biz</a>";
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "No need to rply   ";

            SmtpClient theTest = new System.Net.Mail.SmtpClient();
            theTest.Port = 25;
            theTest.Host = "relay-hosting.secureserver.net";//"smtpout.secureserver.net";// "smtp.gmail.com";
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = false;
            theTest.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(SenderAddress, SenderPassword);
            theTest.Credentials = theCredential;
            theTest.Timeout = 20000;
            theTest.Send(theTestMail);
            string s = "yes";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    public string Pack2(string Name, string to)
    {
        try
        {

            string SenderAddress = "info@worldlifecareenterprises.com";
            // any address Reciver where the email will be sending
            string toAddress = to;
            //Password of your gmail address
            const string SenderPassword = "Admin@123";
            // Passing the values and make a email formate to display


            MailMessage theTestMail = new MailMessage(SenderAddress, toAddress);
            theTestMail.Body = "Dear  " + Name + ",<br />Welcome to DefiClub Forex Community. Your Registration has been Successfully completed.<br/>";

            theTestMail.Body += "Please Join Our Premium Group : https://t.me/joinchat/vxdPSpX2uvs3MWRh <br />";
            theTestMail.Body += "Please reach out to US, If you have any Concerns, simply write a mail to <br />";
            theTestMail.Body += "info@worldlifecareenterprises.com.We're always happy to help you..!!<br /><br />";
            theTestMail.Body += "<br/>Cheers<br/> <h3>Team DefiClub<h3/> <br/>visit:-<a href=https://www.deficlub.biz>https://www.deficlub.biz</a>";
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "No need to rply   ";

            SmtpClient theTest = new System.Net.Mail.SmtpClient();
            theTest.Port = 25;
            theTest.Host = "relay-hosting.secureserver.net";//"smtpout.secureserver.net";// "smtp.gmail.com";
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = false;
            theTest.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(SenderAddress, SenderPassword);
            theTest.Credentials = theCredential;
            theTest.Timeout = 20000;
            theTest.Send(theTestMail);
            string s = "yes";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }
    public string Pack3(string Name, string to)
    {
        try
        {

            string SenderAddress = "info@worldlifecareenterprises.com";
            // any address Reciver where the email will be sending
            string toAddress = to;
            //Password of your gmail address
            const string SenderPassword = "Admin@123";
            // Passing the values and make a email formate to display


            MailMessage theTestMail = new MailMessage(SenderAddress, toAddress);
            theTestMail.Body = "Dear  " + Name + ",<br />Welcome to DefiClub Crypto/Forex  Community. Your Registration has been Successfully completed.<br/>";

            theTestMail.Body += "Please Join Our Crypto Premium Group : https://t.me/joinchat/rkNzcSTeBQk0ZWQx <br />";
            theTestMail.Body += "Please Join Our Forex  Premium Group : https://t.me/joinchat/vxdPSpX2uvs3MWRh <br />";
            theTestMail.Body += "Please reach out to US, If you have any Concerns, simply write a mail to <br />";
            theTestMail.Body += "info@worldlifecareenterprises.com.We're always happy to help you..!!<br /><br />";
            theTestMail.Body += "<br/>Cheers<br/> <h3>Team DefiClub<h3/> <br/>visit:-<a href=https://www.deficlub.biz>https://www.deficlub.biz</a>";
            theTestMail.IsBodyHtml = true;
            theTestMail.Priority = MailPriority.High;
            theTestMail.Subject = "No need to rply   ";

            SmtpClient theTest = new System.Net.Mail.SmtpClient();
            theTest.Port = 25;
            theTest.Host = "relay-hosting.secureserver.net";//"smtpout.secureserver.net";// "smtp.gmail.com";
            theTest.UseDefaultCredentials = false;
            theTest.EnableSsl = false;
            theTest.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(SenderAddress, SenderPassword);
            theTest.Credentials = theCredential;
            theTest.Timeout = 20000;
            theTest.Send(theTestMail);
            string s = "yes";
            return s;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            return s;
        }
    }

}