using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using UnityEngine;
using System.Security;
namespace UnitySaving
{
    public enum Mode
    {
        Overwrite,
        NoOverwrite,
        Append
    }
    public sealed class DataPrefs
    {
        public static string FileType = ".data";
        public static string FolderName = "GameSaves";

        //private static byte[] loadbyte = null;
        public DataPrefs(){
            CreateFolder(FolderName);
        }
        public static void SaveColor32(string name, Color32 value, Mode m = 0) { 
           SaveColor(name,value,m);
        }
        public static Color32 LoadColor32(string name) {
            return LoadColor(name);
        }
        public static void SaveLong(string name, long value , Mode m=0) {
            if (m == Mode.Overwrite) {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);

                using (StreamWriter sw = path.AppendText()) {
                    sw.WriteLine(value);
                }
            }
        }
        public static long LoadLong(string name) {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                return Convert.ToInt64(sr.ReadLine());
            }
        }
        public static void SaveObject(string name, object value, Mode m = 0) {
            SaveString(name,value.ToString(), m);
        }
        public static object LoadObject(string name) {
            return LoadString(name);
        }
        public static void SaveByteArray(string name, byte[] value,Mode m=0) {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
            if(m == Mode.NoOverwrite) {
                if (!Exists(name))
                {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            sw.WriteLine(value[i]);
                        }
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo fi = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = fi.AppendText())
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
        }
        public static byte[] LoadByteArray(string name) {
            byte[] loadbyte = null;
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                loadbyte = new Byte[CountLines(name)];
                for (int i = 0; i < CountLines(name); i++) {
                    loadbyte[i] = Convert.ToByte(sr.ReadLine());
                }
                return loadbyte;
            }
        }
        public static void SaveByte(string name, byte value,Mode m=0) {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name))
                {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText())
                {
                    sw.WriteLine(value);
                }
            }
        }
        public static void SaveSbyte(string name,sbyte value,Mode m=0) {
            SaveString(name,Convert.ToString(value), m);
        }
        public static sbyte LoadSbyte(string name) {
            return Convert.ToSByte(LoadString(name));
        }
        public static byte LoadByte(string name) {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                return Convert.ToByte(sr.ReadLine());
            }
        }
        public static void SaveQuaternion(string name, Quaternion value,Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value.x);
                    sw.WriteLine(value.y);
                    sw.WriteLine(value.z);
                    sw.WriteLine(value.w);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value.x);
                        sw.WriteLine(value.y);
                        sw.WriteLine(value.z);
                        sw.WriteLine(value.w);
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText())
                {
                    sw.WriteLine(value.x);
                    sw.WriteLine(value.y);
                    sw.WriteLine(value.z);
                    sw.WriteLine(value.w);
                }
            }
        }
        public static Quaternion LoadQuaternion(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return new Quaternion(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));
            }
        }
        public static void SaveIntArray(string name, int[] value,Mode m=0){
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
            if(m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            sw.WriteLine(value[i]);
                        }
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText())
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
        }
        public static int[] LoadIntArray(string name) {
            int[] loadint = null;
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                loadint = new int[CountLines(name)];
                for (int i = 0; i < CountLines(name); i++)
                {
                    loadint[i] = Convert.ToInt32(sr.ReadLine());
                    
                }
                return loadint;
            }
        }
        public static void SaveInt(string name, int value,Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if (m == Mode.NoOverwrite) { 
                if(!Exists(name)){
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText())
                {
                    sw.WriteLine(value);
                }
            }
        }
        public static void SaveFloatArray(string name,float[] value,Mode m=0) {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            sw.WriteLine(value[i]);
                        }
                    }
                }
            }
            if (m == Mode.Append) {
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()){
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
        }
        public static float[] LoadFloatArray(string name) {
            float[] loadfloat = null;
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                loadfloat = new float[CountLines(name)];
                for (int i = 0; i < CountLines(name); i++)
                {
                    loadfloat[i] = Convert.ToSingle(sr.ReadLine());

                }
                return loadfloat;
            }
        }
        public static int LoadInt(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return Convert.ToInt32(sr.ReadLine());
            }
        }
        public static void SaveDoubleArray(string name, double[] value, Mode m = 0) {
            if (m == Mode.Overwrite) {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                    for (int i = 0; i < value.Length; i++) {
                        sw.WriteLine(value[i]);
                    }
                }
            }
            if(m== Mode.NoOverwrite){
                if(!Exists(name)){
                  using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                        for (int i = 0; i < value.Length; i++) {
                            sw.WriteLine(value[i]);
                        }
                    }
                }
            }
            if (m == Mode.Append) { 
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                     for (int i = 0; i < value.Length; i++)
                     {
                         sw.WriteLine(value[i]);
                     }
                 }
            }
        }
        public static double[] LoadDoubleArray(string name) {
            double[] returndouble = null;
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                returndouble = new double[CountLines(name)];
                for (int i = 0; i < CountLines(name); i++) {
                    returndouble[i] = Convert.ToDouble(sr.ReadLine());
                }
                return returndouble;
            }
        }
        public static void SaveString(string name, string value,Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) { 
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                     sw.WriteLine(value);
                 }
            }
        }
        public static string LoadString(string name)
        {

            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return sr.ReadLine();
            }
        }
        public static void SaveStringArray(string name, string[] value,Mode m=0) {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            sw.WriteLine(value[i]);
                        }
                    }
                }
            }
            if (m == Mode.Append) { 
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                     for (int i = 0; i < value.Length; i++)
                     {
                         sw.WriteLine(value[i]);
                     }
                 }
            }
        }
        public static string[] LoadStringArray(string name) {
            string[] loadstring = null;
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                loadstring = new string[CountLines(name)];
                for (int i = 0; i < CountLines(name); i++)
                {
                    loadstring[i] = sr.ReadLine();

                }
                return loadstring;
            } 
        }
        public static void SaveVector3(string name, Vector3 value,Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value.x);
                    sw.WriteLine(value.y);
                    sw.WriteLine(value.z);
                }
            }
            if(m == Mode.NoOverwrite){
                if(!Exists(name)){
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value.x);
                        sw.WriteLine(value.y);
                        sw.WriteLine(value.z);
                    }
                }
            }
            if (m == Mode.Append) { 
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                     sw.WriteLine(value.x);
                     sw.WriteLine(value.y);
                     sw.WriteLine(value.z);
                 }
            }
        }
        public static Vector3 LoadVector3(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return new Vector3(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));
            }
        }
        public static void SaveVector2(string name, Vector2 value,Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value.x);
                    sw.WriteLine(value.y);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value.x);
                        sw.WriteLine(value.y);
                    }
                }
            }
            if(m==Mode.Append){
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                     sw.WriteLine(value.x);
                     sw.WriteLine(value.y);
                 }
            }
        }
        public static Vector2 LoadVector2(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return new Vector2(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));
            }
        }
        public static void SaveRect(string name, Rect value , Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value.x);
                    sw.WriteLine(value.y);
                    sw.WriteLine(value.width);
                    sw.WriteLine(value.height);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value.x);
                        sw.WriteLine(value.y);
                        sw.WriteLine(value.width);
                        sw.WriteLine(value.height);
                    }
                }
            }
            if (m == Mode.Append) {
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText())
                {
                    sw.WriteLine(value.x);
                    sw.WriteLine(value.y);
                    sw.WriteLine(value.width);
                    sw.WriteLine(value.height);
                }
            }
        }
        public static Rect LoadRect(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return new Rect(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()));
            }
        }
        public static void SaveColor(string name, Color value , Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value.r);
                    sw.WriteLine(value.b);
                    sw.WriteLine(value.g);
                    sw.WriteLine(value.a);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value.r);
                        sw.WriteLine(value.b);
                        sw.WriteLine(value.g);
                        sw.WriteLine(value.a);
                    }
                }
            }
            if (m == Mode.Append) { 
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                     sw.WriteLine(value.r);
                     sw.WriteLine(value.b);
                     sw.WriteLine(value.g);
                     sw.WriteLine(value.a);
                 }
            }
        }
        public static Color LoadColor(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return new Color(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));
            }
        }
        public static void SaveBoolArray(string name, bool[] value, Mode m = 0) {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite) { 
                using(StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType)){
                    for(int i = 0; i < value.Length; i++){
                        sw.WriteLine(value[i]);
                    }
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            sw.WriteLine(value[i]);
                        }
                    }
                }
            }
            if (m == Mode.Append) { 
                 FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                 using (StreamWriter sw = path.AppendText()) {
                    for (int i = 0; i < value.Length; i++)
                    {
                        sw.WriteLine(value[i]);
                    }
                }
            }
        }
        public static bool[] LoadBoolArray(string name) {
            bool[] returnbool = null;
            using(StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType)){
                returnbool = new bool[CountLines(name)];
                for (int i = 0; i < CountLines(name); i++)
                {
                    returnbool[i] = Convert.ToBoolean(sr.ReadLine());
                }
                return returnbool;
            }
        }
        public static void SaveBool(string name, bool value , Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) { 
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText()) {
                    sw.WriteLine(value);
                }
            }
        }
        public static bool LoadBool(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return Convert.ToBoolean(sr.ReadLine());
            }
        }
        public static void SaveUint(string name, uint value , Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if(m == Mode.NoOverwrite){
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) { 
                FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
                using (StreamWriter sw = path.AppendText()) {
                    sw.WriteLine(value);
                }
            }
        }
        public static uint LoadUint(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return Convert.ToUInt32(sr.ReadLine());
            }
        }
        public static void SaveFloat(string name, float value , Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if(m == Mode.NoOverwrite){
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) { 
               FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
               using (StreamWriter sw = path.AppendText()) {
                   sw.WriteLine(value);        
               }
            }
        }
        public static float LoadFloat(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return Convert.ToSingle(sr.ReadLine());
            }
        }
        public static void SaveDouble(string name, double value , Mode m=0)
        {
            CreateFolder(FolderName);
            if (m == Mode.Overwrite)
            {
                using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                {
                    sw.WriteLine(value);
                }
            }
            if (m == Mode.NoOverwrite) {
                if (!Exists(name)) {
                    using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType))
                    {
                        sw.WriteLine(value);
                    }
                }
            }
            if (m == Mode.Append) { 
               FileInfo path = new FileInfo(Application.dataPath + "/" + FolderName + "/" + name + FileType);
               using (StreamWriter sw = path.AppendText()) {
                   sw.WriteLine(value);             
               }
            }
        }
        public static double LoadDouble(string name)
        {

            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                return Convert.ToDouble(sr.ReadLine());
            }
        }
        public static void Remove(string name) {
            File.Delete(Application.dataPath + "/" + FolderName + "/" + name + FileType);
        }
        public static void Clear(string name) {
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + FolderName + "/" + name + FileType)) {
                sw.Flush();
            }
        }
        public static string ReadAllLines(string name) {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                 return sr.ReadToEnd();
            }
        }
        public static bool Exists(string name)
        {
            return File.Exists(Application.dataPath + "/" + FolderName + "/" + name + FileType);
        }
        public static void Replace(string source,string target) {
            if (Exists(source) && Exists(target)) {
                File.Replace(Application.dataPath + "/" + FolderName + "/" + source + FileType, Application.dataPath + "/" + FolderName + "/" + target + FileType, Application.dataPath + "/" + FolderName + "/" + "Backup" +source+ FileType);
            }
        }
        public static int CountLines(string name)
        {
            using (StreamReader sr = new StreamReader(Application.dataPath + "/" + FolderName + "/" + name + FileType))
            {
                long count = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                }
                return Convert.ToInt32(count);
            }
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
        public static bool SaveFolderExist {
            get {return FolderExists(FolderName); }
        }
        public static void WriteText(string name,string text) {
            CreateFolder(FolderName);
            File.WriteAllText(Application.dataPath + "/" + FolderName + "/" + name + ".txt", text);
        }
        public static string ReadText(string name) {
            return File.ReadAllText(Application.dataPath + "/" + FolderName + "/" + name + ".txt");
        }
    }
}
