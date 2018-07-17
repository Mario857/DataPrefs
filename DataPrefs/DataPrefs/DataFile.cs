using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Security;
using System.IO;
namespace UnitySaving
{
    public sealed class DataFile
    {
        public static string FullFilePath(string name)
        {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.FullName;
        }
        public static string LastFileEdit(string name) {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.LastWriteTime.ToString();
        }
        public static string CreationTime(string name) {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.CreationTime.ToString();
        }
        public static string Atributes(string name) {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.Attributes.ToString();
        }
        public static bool IsReadOnly(string name) {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.IsReadOnly;
        }
        public static long FileSize(string name) {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.Length;
        }
        public static bool Exists(string name) {
            FileInfo file = new FileInfo(Application.dataPath + "/" + DataPrefs.FolderName + "/" + name + DataPrefs.FileType);
            return file.Exists;
        }
        public static string[] GetAllPathsOfFilesInSaveDirectory(){
            string[] filePaths = Directory.GetFiles(Application.dataPath + "/" + DataPrefs.FolderName);
            return filePaths;
        }
        public static int CountOfSaves() {
            string[] filePaths = Directory.GetFiles(Application.dataPath + "/" + DataPrefs.FolderName);
            return filePaths.Length;
        }
        public static string SaveDirectoryAttributes()
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(Application.dataPath + "/" + DataPrefs.FolderName);
            return directoryinfo.Attributes.ToString();
        }
        public static string SaveDirectoryCreationTime() {
            DirectoryInfo directoryinfo = new DirectoryInfo(Application.dataPath + "/" + DataPrefs.FolderName);
            return directoryinfo.CreationTime.ToString();
        }
        public static string[] GetFilesFromSaveDirectory() {
            string[] returnstring = null;
            DirectoryInfo directoryinfo = new DirectoryInfo(Application.dataPath + "/" + DataPrefs.FolderName);
            FileInfo[] files = directoryinfo.GetFiles();
            returnstring = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                returnstring[i] = files[i].Name;
            }
            return returnstring;
        }
    }
}
