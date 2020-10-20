namespace CJBasic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommonJsonModelAnalyzer
    {
        protected List<string> _GetCollection(string rawjson)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(rawjson))
            {
                rawjson = rawjson.Trim();
                StringBuilder builder = new StringBuilder();
                int num = -1;
                int num2 = -1;
                for (int i = 0; i < rawjson.Length; i++)
                {
                    if ((i != 0) && (i != (rawjson.Length - 1)))
                    {
                        char ch = rawjson[i];
                        switch (ch)
                        {
                            case '{':
                                num++;
                                break;

                            case '}':
                                num--;
                                break;

                            case '[':
                                num2++;
                                break;

                            case ']':
                                num2--;
                                break;
                        }
                        if (((ch == ',') && (num == -1)) && (num2 == -1))
                        {
                            list.Add(builder.ToString());
                            builder = new StringBuilder();
                        }
                        else
                        {
                            builder.Append(ch);
                        }
                    }
                }
                if (builder.Length > 0)
                {
                    list.Add(builder.ToString());
                }
            }
            return list;
        }

        protected string _GetKey(string rawjson)
        {
            if (string.IsNullOrEmpty(rawjson))
            {
                return rawjson;
            }
            rawjson = rawjson.Trim();
            string[] strArray = rawjson.Split(new char[] { ':' });
            if (strArray.Length < 2)
            {
                return rawjson;
            }
            return strArray[0].Replace("\"", "").Trim();
        }

        protected string _GetValue(string rawjson)
        {
            if (string.IsNullOrEmpty(rawjson))
            {
                return rawjson;
            }
            rawjson = rawjson.Trim();
            string[] strArray = rawjson.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length < 2)
            {
                return rawjson;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i < strArray.Length; i++)
            {
                builder.Append(strArray[i]);
                builder.Append(":");
            }
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            string str = builder.ToString();
            if (str.StartsWith("\""))
            {
                str = str.Substring(1);
            }
            if (str.EndsWith("\""))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }
    }
}

