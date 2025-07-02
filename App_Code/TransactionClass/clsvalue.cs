using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsvalue
/// </summary>
public class clsvalue
{
    public clsvalue()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
    
public class clspinused
{
    public string username { get; set; }
    public string pin { get; set; }
    public string amount { get; set; }
    public string status { get; set; }

}

public class clspinunused
{
    public string username { get; set; }
    public string pin { get; set; }
    public string amount { get; set; }
    public string status { get; set; }

}
public class clsuser
{
    public string username { get; set; }
    public string  name { get; set; }
    public string mobile { get; set; }
    public string reffid { get; set; }
    public string reffname { get; set; }
    public string city { get; set; }
    public string position { get; set; }
    public string JoinAmt { get; set; }
    public string dateofjoin { get; set; }
    public string doa { get; set; }


}
public class clsaccount
{
    public string username { get; set; }
    public string date { get; set; }
    public string debit { get; set; }
    public string credit { get; set; }
    public  int tdebit { get; set; }
    public int tcredit { get; set; }
    public string remark { get; set; }

}

public class clsTotalBinary
{
    public string username { get; set; }
    public string leftcount { get; set; }
    public string rightcount { get; set; }

}
public class clsnewTotalBinary
{
    public string username { get; set; }
    public string leftcount { get; set; }
    public string rightcount { get; set; }

}
public class clsBinary
{
    public string username { get; set; }
    public string left { get; set; }
    public string right { get; set; }
    public string count { get; set; }

}


