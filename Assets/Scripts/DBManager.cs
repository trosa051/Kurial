using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    public static string email;
    public static char AccStanding;
    public static string LastLog;

    public static bool LoggedIn { get { return username != null; } }

    public static void Logout()
    {
        username = null;
        email = null;
        AccStanding = '0';
        LastLog = null;
    }

}   
