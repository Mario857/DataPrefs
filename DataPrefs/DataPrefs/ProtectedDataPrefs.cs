using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security;
using UnityEngine;
namespace UnitySaving
{
    public class ProtectedDataPrefs
    {
        public static void SaveProtectedString(string name, string value) {
            byte[] entropy = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            byte[] enc = ProtectedData.Protect(Encoding.Unicode.GetBytes(value), entropy, DataProtectionScope.LocalMachine);

            byte[] dec = ProtectedData.Unprotect(enc, entropy, DataProtectionScope.CurrentUser);

            DataPrefs.SaveByteArray(name + "_Protected", dec, Mode.Overwrite);

            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType)) {
                sw.WriteLine(BitConverter.ToString(enc));
            }
            
        }
        public static string LoadProtectedString(string name){
            return Encoding.Unicode.GetString(DataPrefs.LoadByteArray(name + "_Protected"));
        }
        public static void SaveProtectedInt(string name, int value) {
            byte[] entropy = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            byte[] enc = ProtectedData.Protect(Encoding.Unicode.GetBytes(Convert.ToString(value)), entropy, DataProtectionScope.LocalMachine);

            byte[] dec = ProtectedData.Unprotect(enc, entropy, DataProtectionScope.CurrentUser);

            DataPrefs.SaveByteArray(name + "_Protected", dec, Mode.Overwrite);

            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType))
            {
                sw.WriteLine(BitConverter.ToString(enc));
            }
        }
        public static int LoadProtectedInt(string name) {
            return Convert.ToInt32(Encoding.Unicode.GetString(DataPrefs.LoadByteArray(name + "_Protected")));
        }
        public static void SaveProtectedFloat(string name, float value) {
            byte[] entropy = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            byte[] enc = ProtectedData.Protect(Encoding.Unicode.GetBytes(Convert.ToString(value)), entropy, DataProtectionScope.LocalMachine);

            byte[] dec = ProtectedData.Unprotect(enc, entropy, DataProtectionScope.CurrentUser);

            DataPrefs.SaveByteArray(name + "_Protected", dec, Mode.Overwrite);

            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType))
            {
                sw.WriteLine(BitConverter.ToString(enc));
            }
        }
        public static float LoadProtectedFloat(string name) {
            return Convert.ToSingle(Encoding.Unicode.GetString(DataPrefs.LoadByteArray(name + "_Protected")));
        }
        public static void SaveProtectedByte(string name,byte value) {
            byte[] entropy = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            byte[] enc = ProtectedData.Protect(Encoding.Unicode.GetBytes(Convert.ToString(value)), entropy, DataProtectionScope.LocalMachine);

            byte[] dec = ProtectedData.Unprotect(enc, entropy, DataProtectionScope.CurrentUser);

            DataPrefs.SaveByteArray(name + "_Protected", dec, Mode.Overwrite);

            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType))
            {
                sw.WriteLine(BitConverter.ToString(enc));
            }
        }
        public static byte LoadProtectedByte(string name) {
            return Convert.ToByte(Encoding.Unicode.GetString(DataPrefs.LoadByteArray(name + "_Protected")));
        }
        public static void SaveProtectedBool(string name, bool value) {
            byte[] entropy = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            byte[] enc = ProtectedData.Protect(Encoding.Unicode.GetBytes(Convert.ToString(value)), entropy, DataProtectionScope.LocalMachine);

            byte[] dec = ProtectedData.Unprotect(enc, entropy, DataProtectionScope.CurrentUser);

            DataPrefs.SaveByteArray(name + "_Protected", dec, Mode.Overwrite);

            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType))
            {
                sw.WriteLine(BitConverter.ToString(enc));
            }
        }
        public static bool LoadProtectedBool(string name) {
            return Convert.ToBoolean(Encoding.Unicode.GetString(DataPrefs.LoadByteArray(name + "_Protected")));
        }
        public static void SaveProtectedUint(string name, uint value) {
            SaveProtectedString(name, Convert.ToString(value)); 
        }
        public static uint LoadProtectedUint(string name) {
            return Convert.ToUInt32(LoadProtectedString(name));
        }
    }
}
