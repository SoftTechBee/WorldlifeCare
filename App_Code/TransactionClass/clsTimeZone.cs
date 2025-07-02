using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsTimeZone
/// </summary>
public class clsTimeZone
{
    public clsTimeZone()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DateTime returnDateTimeServerMachTime()
    {
        string time = DateTime.Now.AddHours(0).ToString();
        DateTime Servertime = Convert.ToDateTime(time);
        return Servertime;

    }
    public string  returnStringServerMachTime()
    {
        string time = DateTime.Now.AddHours(0).ToString("yyyy-MM-dd");      
        return time;

    }
    public string returnStringServerMachTime1()
    {
        string time = DateTime.Now.AddHours(0).ToString("dd");
        return time;

    }
    public string returnStringServerMachTimeHHMM()
    {
        string time = DateTime.Now.AddHours(0).ToString("yyyy-MM-dd HH:mm:ss");
        return time;

    }
    public string returnCurrentSurverTimeHHMM()
    {
        string time = DateTime.Now.AddHours(0).ToString("HH:mm:ss");
        return time;

    }
    public string returnCurrentDay()
    {
        string time = DateTime.Now.AddHours(0).ToString("dddd");
        return time;

    }
    public string returnCurrentTime()
    {
        string time = DateTime.Now.AddHours(0).ToString("HH:mm:ss");
        return time;

    }
  
}