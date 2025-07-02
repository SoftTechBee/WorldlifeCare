using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripleITTransaction;

/// <summary>
/// Summary description for clsSecurity
/// </summary>
namespace TripleITTransaction
{
    public static class clsSecurity
    {
        private static string ConnectionStatus = "";

        private static string UserCode = "";
        private static string LoginCode = "";
        private static string LoginName = "";

        public static void SetConnectionStatus(string clsConnectionStatue)
        {
            ConnectionStatus = clsConnectionStatue;
        }

        public static string GetConnectionStatus
        {
            get { return ConnectionStatus; }
            set { ConnectionStatus = value; }
        }

        public static void SetUserCode(string clsUserCode)
        {
            UserCode = clsUserCode;
        }

        public static string GetUserCode
        {
            get { return UserCode; }
            set { UserCode = value; }
        }


        public static void SetLoginCode(string clsLoginCode)
        {
            LoginCode = clsLoginCode;
        }

        public static string GetLoginCode
        {
            get { return LoginCode; }
            set { LoginCode = value; }
        }

        public static void SetLoginName(string clsLoginName)
        {
            LoginName = clsLoginName;
        }

        public static string GetLoginName
        {
            get { return LoginName; }
            set { LoginName = value; }
        }

        //public static bool GetUserRight(string UserCode , int MenuCode, string IsAddModifyDelete)
        //{
            
        //    return true;
        //}
    }
}