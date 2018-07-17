using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using System.Security;

namespace UnitySaving
{
    public class SingleSave
    {
        public static int[] IntArray(string name,int[] value,Mode m = 0){
            DataPrefs.SaveIntArray(name,value,m);
            return DataPrefs.LoadIntArray(name);
        }
        public static int Int(string name, int value, Mode m = 0)
        {
            DataPrefs.SaveInt(name, value , m);
            return DataPrefs.LoadInt(name);
        }
        public static float[] FloatArray(string name,float[] value,Mode m=0){
            DataPrefs.SaveFloatArray(name, value, m);
            return DataPrefs.LoadFloatArray(name);
        }
        public static float Float(string name, float value, Mode m = 0)
        {
            DataPrefs.SaveFloat(name, value, m);
            return DataPrefs.LoadFloat(name);
        }
        public static string[] StringArray(string name, string[] value, Mode m = 0) {
            DataPrefs.SaveStringArray(name, value, m);
            return DataPrefs.LoadStringArray(name);
        }
        public static string String(string name, string value, Mode m = 0)
        {
            DataPrefs.SaveString(name, value, m);
            return DataPrefs.LoadString(name);
        }
        public static double[] DoubleArray(string name, double[] value, Mode n = 0) {
            DataPrefs.SaveDoubleArray(name, value, n);
            return DataPrefs.LoadDoubleArray(name);
        }
        public static double Double(string name, double value, Mode m = 0)
        {
            DataPrefs.SaveDouble(name, value, m);
            return DataPrefs.LoadDouble(name);
        }
        public static uint Uint(string name, uint value, Mode m = 0)
        {
            DataPrefs.SaveUint(name, value , m);
            return DataPrefs.LoadUint(name);
        }
        public static byte[] ByteArray(string name, byte[] value, Mode m = 0) {
            DataPrefs.SaveByteArray(name, value, m);
            return DataPrefs.LoadByteArray(name);
        }
        public static byte Byte(string name, byte value, Mode m = 0)
        {
            DataPrefs.SaveByte(name, value);
            return DataPrefs.LoadByte(name);
        }
        public static bool[] BoolArray(string name, bool[] value, Mode m=0){
            DataPrefs.SaveBoolArray(name, value, m);
            return DataPrefs.LoadBoolArray(name);
        }
        public static bool Bool(string name, bool value, Mode m = 0)
        {
            DataPrefs.SaveBool(name, value, m);
            return DataPrefs.LoadBool(name);
        }
        public static sbyte Sbyte(string name, sbyte value, Mode m = 0) {
            DataPrefs.SaveSbyte(name, value, m);
            return DataPrefs.LoadSbyte(name);
        }
        public static long Long(string name, long value, Mode m = 0) {
            DataPrefs.SaveLong(name, value, m);
            return DataPrefs.LoadLong(name);
        }
    }
}
