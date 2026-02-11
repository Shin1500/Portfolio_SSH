#region 어셈블리 ArSetting.Net4, Version=18.7.26.1730, Culture=neutral, PublicKeyToken=null
// C:\Users\USER\Desktop\TSG-725T - v22 - 참고용\TSG-725T\OpticalCalibration_LGD_E61_Phase1\files\ArSetting.Net4.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace arUtil
{
    // Config파일 설정을 위한 클래스

    public class INIHelper
    {
        private DataTable dt;

        public string fileName { get; private set; }

        public Encoding TextEncoding { get; set; }

        public INIHelper(string file_ = "")
        {
            dt = new DataTable();
            dt.Columns.Add("section");
            dt.Columns.Add("key");
            dt.Columns.Add("value");
            fileName = file_;
            TextEncoding = Encoding.UTF8;
            if (File.Exists(fileName))
            {
                Load();
            }
        }

        public bool Exist()
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            return true;
        }

        public void SetFileName(string file)
        {
            fileName = file;
            if (File.Exists(fileName))
            {
                Load();
            }
        }

        public void CreateFile()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            string contents = "//init file  : create by arINIHelper ";
            File.WriteAllText(fileName, contents, TextEncoding);
        }

        public bool Load(string file_ = "")
        {
            if (file_ != "")
            {
                fileName = file_;
            }

            if (!File.Exists(fileName))
            {
                return false;
            }

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream, TextEncoding);
            string text = string.Empty;
            while (streamReader.Peek() > 0)
            {
                string text2 = streamReader.ReadLine().Trim();
                if (text2.StartsWith("//") || text2 == "")
                {
                    continue;
                }

                if (text == "")
                {
                    if (text2.StartsWith("[") && text2.EndsWith("]"))
                    {
                        text = text2.Substring(1, text2.Length - 2).Trim();
                    }
                }
                else if (text2.StartsWith("[") && text2.EndsWith("]"))
                {
                    text = text2.Substring(1, text2.Length - 2).Trim();
                }
                else if (text2.IndexOf("=") != -1)
                {
                    int num = text2.IndexOf('=');
                    string text3 = text2.Substring(0, num).Trim();
                    string text4 = text2.Substring(num + 1).Trim();
                    dt.Rows.Add(text, text3, text4);
                }
            }

            dt.AcceptChanges();
            streamReader.Close();
            fileStream.Close();
            return true;
        }

        public List<string> GetSectionList()
        {
            List<string> list = new List<string>();
            IGrouping<object, DataRow>[] array = (from t in dt.Select()
                                                  group t by t["section"]).ToArray();
            for (int i = 0; i < array.Count(); i++)
            {
                IGrouping<object, DataRow> grouping = array[i];
                list.Add(grouping.Key.ToString());
            }

            return list;
        }

        public Dictionary<string, string> GetItemList(string Section_)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Section_ = Section_.Replace("'", "");
            DataRow[] array = dt.Select("section='" + Section_ + "'", "key,value");
            if (array.Length < 1)
            {
                return dictionary;
            }

            DataRow[] array2 = array;
            foreach (DataRow dataRow in array2)
            {
                try
                {
                    dictionary.Add(dataRow["key"].ToString(), dataRow["value"].ToString());
                }
                catch
                {
                }
            }

            return dictionary;
        }

        public string get_Data(string Section_, string Key_, string Default_ = "")
        {
            Section_ = Section_.Replace("'", "");
            Key_ = Key_.Replace("'", "");
            DataRow[] array = dt.Select("section='" + Section_ + "' and key ='" + Key_ + "'");
            if (array.Length != 1)
            {
                return Default_;
            }

            return array[0]["value"].ToString();
        }

        public void set_Data(string Section_, string Key_, string Value_)
        {
            Value_ = Value_.Trim();
            Section_ = Section_.Replace("'", "");
            Key_ = Key_.Replace("'", "");
            DataRow[] array = dt.Select("section='" + Section_ + "' and key ='" + Key_ + "'");
            if (array.Length == 0)
            {
                dt.Rows.Add(Section_, Key_, Value_);
            }
            else
            {
                array[0]["value"] = Value_;
            }
        }

        public void Flush()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string text = string.Empty;
            DataRow[] array = dt.Select("", "section,key,value");
            foreach (DataRow dataRow in array)
            {
                if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached)
                {
                    string text2 = dataRow["section"].ToString().Trim();
                    string arg = dataRow["key"].ToString().Trim();
                    string arg2 = dataRow["value"].ToString().Trim();
                    if (text != text2)
                    {
                        stringBuilder.AppendLine("[" + text2 + "]");
                        text = text2;
                    }

                    stringBuilder.AppendLine($"{arg}={arg2}");
                }
            }

            File.WriteAllText(fileName, stringBuilder.ToString(), TextEncoding);
        }

        ~INIHelper()
        {
        }
    }
#if false // 디컴파일 로그
    캐시의 '16'개 항목
    ------------------
    확인: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    단일 어셈블리를 찾았습니다. 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\mscorlib.dll'
    ------------------
    확인: 'System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    단일 어셈블리를 찾았습니다. 'System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\System.Data.dll'
    ------------------
    확인: 'System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    단일 어셈블리를 찾았습니다. 'System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\System.Xml.dll'
    ------------------
    확인: 'System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    단일 어셈블리를 찾았습니다. 'System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\System.Core.dll'
    ------------------
    확인: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    단일 어셈블리를 찾았습니다. 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\System.dll'
    ------------------
    확인: 'System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    단일 어셈블리를 찾았습니다. 'System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\System.Windows.Forms.dll'
    ------------------
    확인: 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
    단일 어셈블리를 찾았습니다. 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
    로드 위치: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.2\System.Drawing.dll'
#endif
}
