using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DBManager : MonoBehaviour
{
    public static string username;
    public static int score;
     public static int coins;
     public static float x;
     public static float y;
     public static float z;

    public static bool LoggedIn{ get { return username != null; }}

    public static void LogOut()
    {
        username=null;
    }

    
     
    

}
