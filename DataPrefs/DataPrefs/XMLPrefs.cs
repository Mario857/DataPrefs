using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Security;

namespace UnitySaving
{
    public class XMLPrefs
    {
        private static string FileType = ".xml";
        public static string FolderName = "XMLSaves";
        private static void SetString(string name, string value) {
            CreateFolder(FolderName);
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                sw.WriteLine(value);
            }
        }
        private static string GetString(string name) {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                return sr.ReadLine();
            }
        }      
        public static void SaveString(string name,string elementname,string value) {
            CreateFolder(FolderName);
            SetString(name, "<" + elementname + ">" + value + "</" + elementname + ">");
        }
        public static void SaveFloat(string name, string elementname, float value) {
            SaveString(name, elementname, value.ToString());
        }
        public static void SaveBool(string name, string elementname, bool value) {
            SaveString(name, elementname, Convert.ToString(value));
        }
        public static void SaveInt(string name, string elementname, int value) { 
            SaveString(name,elementname,value.ToString());
        }
        public static void SaveByte(string name, string elementname, byte value) {
            SaveString(name, elementname, value.ToString());
        }
        public static void SaveUint(string name, string elementname, uint value) {
            SaveString(name, elementname, Convert.ToString(value));
        }
        public static void SaveSbyte(string name, string elementname, sbyte value) {
            SaveString(name, elementname, Convert.ToString(value));
        }
        public static void SaveLong(string name, string elementname, long value) {
            SaveString(name, elementname, Convert.ToString(value));
        }
        private static void CreateFolder(string name)
        {
            if (FolderExists(name) == true)
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(Application.dataPath + "/" + name);
            }

        }
        private static bool FolderExists(string name)
        {
            return Directory.Exists(Application.dataPath + "/" + name);
        }
    }
}
