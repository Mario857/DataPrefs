using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
namespace UnitySaving
{
    public struct FTPServer{
        private string s_serverpath;
        private string s_name;
        private string s_password;
        public string ServerPath {
            get
            {
                return s_serverpath;
            }
            set
            {
                s_serverpath = value;
            }
        }
        public string Name
        {
            get
            {
                return s_name;
            }
            set
            {
                s_name = value;
            }
        }
        public string Password {
            get
            {
                return s_password;
            }
            set
            {
                s_password = value;
            }
        }
        public FTPServer(string serverpath,string name, string password)
        {
            s_name = name;
            s_password = password;
            s_serverpath = serverpath;
        }
    }
    public class FTPPrefs
    {
        public class FreeCentral
        {
            public static string FileType = ".data";
            public static void SendString(string name, string value)
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("a3051081", "XF-Axe22");
                client.UploadString("ftp://unitygamingcloud.comule.com/" + name + FileType, value);
            }
            public static string ReceiveString(string name)
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("a3051081", "XF-Axe22");
                return client.DownloadString("ftp://unitygamingcloud.comule.com/" + name + FileType);
            }
            public static float ReceiveFloat(string name)
            {
                return Convert.ToSingle(ReceiveString(name));
            }
            public static int ReceiveInt(string name)
            {
                return (int)ReceiveFloat(name);
            }
            public static bool ReceiveBool(string name)
            {
                return Convert.ToBoolean(ReceiveString(name));
            }
            public static void SendFloat(string name, float value)
            {
                SendString(name, Convert.ToString(value));
            }
            public static void SendInt(string name, int value)
            {
                SendFloat(name, value);
            }
            public static void SendBool(string name, bool value)
            {
                SendString(name, Convert.ToString(value));
            }
            public static string CentralInfo()
            {
                return "UnityGamingCloud.comule.com";
            }
        }
        public class OwnCentral {
            public static string FileType = ".data";
            public static void SendString(string name, string value, FTPServer s) 
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(s.Name,s.Password);
                client.UploadString(s.ServerPath + name + FileType, value);
            }
            public static void SendInt(string name, int value, FTPServer s) {
                SendString(name, Convert.ToString(value), s);
            }
            public static void SendFloat(string name, float value, FTPServer s) {
                SendString(name, value.ToString(), s);
            }
            public static void SendBool(string name,bool value,FTPServer s)
            {
                SendString(name, Convert.ToString(value), s);
            }
            public static string ReceiveString(string name, FTPServer s) {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(s.Name, s.Password);
                return client.DownloadString(s.ServerPath + name + FileType);
            }
            public static float ReceiveFloat(string name, FTPServer s) {
                return Convert.ToSingle(ReceiveString(name, s));
            }
            public static int ReceiveInt(string name,FTPServer s)
            {
                return Convert.ToInt32(ReceiveString(name, s));
            }
            public static bool ReceiveBool(string name, FTPServer s) {
                return Convert.ToBoolean(ReceiveString(name, s));
            }
        }
    }
}
