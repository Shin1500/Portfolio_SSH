using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_EX
{
    // Config파일 설정을 위한 클래스

    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        public string path;

        ////[DllImport("kernel32", CharSet = CharSet.Unicode)]
        //[DllImport("kernel32")]
        //private static extern long WritePrivateProfileString(string section,
        //    string key, string val, string filePath);
        ////[DllImport("kernel32", CharSet = CharSet.Unicode)]
        //[DllImport("kernel32", CharSet = CharSet.Unicode)]
        //private static extern int GetPrivateProfileString(string section,
        //         string key, string def, StringBuilder retVal,
        //    int size, string filePath);

        private arUtil.INIHelper ini = new arUtil.INIHelper();

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
            ini.SetFileName(INIPath);
        }

        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            //WritePrivateProfileString(Section, Key, Value, this.path);

            ini.set_Data(Section, Key, Value);
            ini.Flush();
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int i = GetPrivateProfileString(Section, Key, "", temp,
            //                                255, this.path);
            //return temp.ToString();

            return ini.get_Data(Section, Key);
        }

        /// <returns></returns>
        public string IniReadValue(string Section, string Key, string sDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int i = GetPrivateProfileString(Section, Key, "", temp,
            //                                255, this.path);
            //if (i == 0)
            //{
            //    temp.Append(sDefault);
            //}
            //return temp.ToString();
            return ini.get_Data(Section, Key, sDefault);
        }

        public int IniReadValue(string Section, string Key, int iDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int i = GetPrivateProfileString(Section, Key, "", temp,
            //                                255, this.path);
            //int iTemp = 0;
            //bool bOK = Int32.TryParse(temp.ToString(), out iTemp);
            //if (bOK == false)
            //{
            //    iTemp = iDefault;
            //}

            //return iTemp;
            string sData = ini.get_Data(Section, Key);
            int.TryParse(sData, out iDefault);
            return iDefault;
        }

        public bool IniReadValue(string Section, string Key, bool iDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int i = GetPrivateProfileString(Section, Key, "", temp,
            //                                255, this.path);
            //bool iTemp = false;
            //bool bOK = bool.TryParse(temp.ToString(), out iTemp);
            //if (bOK == false)
            //{
            //    iTemp = iDefault;
            //}
            //return iTemp;

            string sData = ini.get_Data(Section, Key);
            bool.TryParse(sData, out iDefault);
            return iDefault;

        }

        public float IniReadValue(string Section, string Key, float iDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            //float iTemp = 0;
            //bool bOK = float.TryParse(temp.ToString(), out iTemp);
            //if (bOK == false)
            //{
            //    iTemp = iDefault;
            //}
            //return iTemp;

            string sData = ini.get_Data(Section, Key);
            float.TryParse(sData, out iDefault);
            return iDefault;
        }

        public double IniReadValue(string Section, string Key, double iDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            //double iTemp = 0;
            //bool bOK = double.TryParse(temp.ToString(), out iTemp);
            //if (bOK == false)
            //{
            //    iTemp = iDefault;
            //}
            //return iTemp;

            string sData = ini.get_Data(Section, Key);
            double.TryParse(sData, out iDefault);
            return iDefault;

        }

        public int IniReadValue_Safe(string Section, string Key, int iDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //int iTemp = iDefault;
            //try
            //{
            //    GetPrivateProfileString(Section, Key, "", temp, 255, this.path);

            //    bool bOK = Int32.TryParse(temp.ToString(), out iTemp);
            //    if (bOK == false)
            //    {
            //        iTemp = iDefault;
            //    }
            //}
            //catch (Exception)
            //{
            //    iTemp = iDefault;
            //}
            //return iTemp;

            string sData = ini.get_Data(Section, Key);
            int.TryParse(sData, out iDefault);
            return iDefault;
        }

        public string IniReadValue_Safe(string Section, string Key, string sDefault)
        {
            //StringBuilder temp = new StringBuilder(255);
            //try
            //{
            //    int i = GetPrivateProfileString(Section, Key, "", temp,
            //                                    255, this.path);
            //    if (i == 0)
            //    {
            //        temp.Append(sDefault);
            //    }
            //}
            //catch (Exception)
            //{
            //    temp.Append(sDefault);            
            //}
            //return temp.ToString();
            //return convertUNI(temp.ToString());


            return ini.get_Data(Section, Key, sDefault);
        }

        public static string ReadString(string fileName, string IpAppName, string IpKeyName, string Default)
        {
            //string inifile = fileName;    //Path + File

            //StringBuilder result = new StringBuilder(255);
            //GetPrivateProfileString(IpAppName, IpKeyName, "error", result, 255, inifile);

            //if (result.ToString() == "error")
            //{
            //    return Default;
            //}
            //else
            //{
            //    return result.ToString();
            //}

            arUtil.INIHelper ini = new arUtil.INIHelper(fileName);
            return ini.get_Data(IpAppName, IpKeyName, Default);
        }

        //private string convertUNI(string value)
        //{
        //    byte[] convertByte = Encoding.Default.GetBytes(value);
        //    value = Encoding.Default.GetString(convertByte);
        //    return value;
        //}
    }
}
