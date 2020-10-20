namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class StringHelper
    {
        private static string[] pystr = new string[] { 
            "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian", "biao",
            "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan", "chang",
            "chao", "che", "chen", "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong",
            "cou", "cu", "cuan", "cui", "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao",
            "die", "ding", "diu", "dong", "dou", "du", "duan", "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang",
            "fei", "fen", "feng", "fo", "fou", "fu", "ga", "gai", "gan", "gang", "gao", "ge", "gei", "gen", "geng", "gong",
            "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo", "ha", "hai", "han", "hang", "hao", "he", "hei",
            "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun", "huo", "ji", "jia", "jian", "jiang",
            "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan", "kang", "kao", "ke",
            "ken", "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan", "lang",
            "lao", "le", "lei", "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu",
            "lv", "luan", "lue", "lun", "luo", "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian",
            "miao", "mie", "min", "ming", "miu", "mo", "mou", "mu", "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen",
            "neng", "ni", "nian", "niang", "niao", "nie", "nin", "ning", "niu", "nong", "nu", "nv", "nuan", "nue", "nuo", "o",
            "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng", "pi", "pian", "piao", "pie", "pin", "ping", "po",
            "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu", "qu", "quan", "que", "qun", "ran",
            "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa", "sai", "san",
            "sang", "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi", "shou", "shu",
            "shua", "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun", "suo", "ta",
            "tai", "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan", "tui",
            "tun", "tuo", "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao",
            "xie", "xin", "xing", "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin",
            "ying", "yo", "yong", "you", "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen",
            "zeng", "zha", "zhai", "zhan", "zhang", "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan",
            "zhuang", "zhui", "zhun", "zhuo", "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo"
        };
        private static int[] pyvalue = new int[] { 
            -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032, -20026, -20002, -19990,
            -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, -19741, -19739, -19728, -19725, -19715,
            -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, -19263, -19261, -19249,
            -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977, -18961,
            -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501,
            -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211, -18201, -18184, -18183, -18181, -18012,
            -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, -17733, -17730, -17721, -17703,
            -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, -17185, -16983,
            -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448,
            -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220, -16216, -16212, -16205, -16202, -16187,
            -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, -15903, -15889, -15878, -15707, -15701,
            -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419, -15416, -15408, -15394,
            -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, -15141,
            -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922,
            -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678, -14674, -14670, -14668, -14663, -14654,
            -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345, -14170, -14159, -14151, -14149,
            -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, -14087, -14083,
            -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601,
            -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356, -13343, -13340, -13329, -13326, -13318,
            -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, -12888, -12875, -12871, -12860, -12858,
            -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359, -12346, -12320, -12300,
            -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, -11536,
            -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019,
            -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544, -10533, -10519, -10331, -10329, -10328,
            -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254
        };

        public static IDictionary<string, string> AnalyzeConfigString(string configStr)
        {
            if ((configStr == null) && (configStr.Trim() == ""))
            {
                return null;
            }
            string[] strArray = configStr.Split(new char[] { ';' });
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string str in strArray)
            {
                string str2 = str.Trim();
                if (str2 != "")
                {
                    string[] strArray2 = str2.Split(new char[] { '=' });
                    dictionary.Add(strArray2[0].Trim(), strArray2[1].Trim());
                }
            }
            return dictionary;
        }

        public static string CombinDictionaryIntoString<TKey, TVal>(Dictionary<TKey, TVal> dic, char itemSeparator, char keyValSeparator)
        {
            if ((dic == null) || (dic.Count == 0))
            {
                return "";
            }
            StringBuilder builder = new StringBuilder("");
            int num = 0;
            foreach (KeyValuePair<TKey, TVal> pair in dic)
            {
                builder.Append(string.Format("{0}{1}{2}", pair.Key, keyValSeparator, pair.Value));
                if (num < (dic.Count - 1))
                {
                    builder.Append(itemSeparator.ToString());
                }
            }
            return builder.ToString();
        }

        public static IList<string> CombineStringList(params IList<string>[] strLists)
        {
            IList<string> list = new List<string>();
            foreach (IList<string> list2 in strLists)
            {
                foreach (string str in list2)
                {
                    if (!list.Contains(str))
                    {
                        list.Add(str);
                    }
                }
            }
            return list;
        }

        public static void Compare(string s1, string s2, out string samll, out string big)
        {
            if (s1.CompareTo(s2) > 0)
            {
                samll = s2;
                big = s1;
            }
            else
            {
                samll = s1;
                big = s2;
            }
        }

        public static string ContactString<T>(IList<T> objList, string contactor)
        {
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; i < objList.Count; i++)
            {
                builder.Append(objList[i].ToString());
                if (i != (objList.Count - 1))
                {
                    builder.Append(contactor);
                }
            }
            return builder.ToString();
        }

        public static string ContactString<T>(string contactor, params T[] objs)
        {
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; i < objs.Length; i++)
            {
                builder.Append(objs[i].ToString());
                if (i != (objs.Length - 1))
                {
                    builder.Append(contactor);
                }
            }
            return builder.ToString();
        }

        public static string ConvertChineseToSpell(string chineseStr)
        {
            byte[] bytes = new byte[2];
            string str = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            char[] chArray = chineseStr.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                bytes = Encoding.Default.GetBytes(chArray[i].ToString());
                num2 = bytes[0];
                num3 = bytes[1];
                num = ((num2 * 0x100) + num3) - 0x10000;
                if ((num > 0) && (num < 160))
                {
                    str = str + chArray[i];
                }
                else
                {
                    for (int j = pyvalue.Length - 1; j >= 0; j--)
                    {
                        if (pyvalue[j] <= num)
                        {
                            str = str + pystr[j];
                            break;
                        }
                    }
                }
            }
            return str;
        }

        public static string CreateDateTimeString()
        {
            return CreateDateTimeString(DateTime.Now, true, false);
        }

        public static string CreateDateTimeString(bool toMilliSeconds)
        {
            return CreateDateTimeString(DateTime.Now, true, toMilliSeconds);
        }

        public static string CreateDateTimeString(DateTime dt)
        {
            return CreateDateTimeString(dt, false, false);
        }

        public static string CreateDateTimeString(DateTime dt, bool shortYear)
        {
            return CreateDateTimeString(dt, shortYear, false);
        }

        public static string CreateDateTimeString(DateTime dt, bool shortYear, bool toMilliSeconds)
        {
            string str = shortYear ? ((dt.Year - 0x7d0)).ToString() : dt.Year.ToString();
            string str3 = str;
            str = str3 + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            if (toMilliSeconds)
            {
                str = str + dt.Millisecond.ToString("00");
            }
            return str;
        }

        public static string GetIDOfString(string content)
        {
            if (content == null)
            {
                return null;
            }
            return content.Split(new char[] { ' ' })[0];
        }

        public static string GetNameOfString(string content)
        {
            if (content == null)
            {
                return null;
            }
            return content.Split(new char[] { ' ' })[1];
        }

        public static string LowerFirstChar(string str)
        {
            return (str.ToLower().Substring(0, 1) + str.Substring(1, str.Length - 1));
        }

        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static TOutput[] SplitStringTo<TOutput>(string target, char separator)
        {
            if ((target == null) || (target.Trim() == ""))
            {
                return null;
            }
            string[] strArray = target.Split(new char[] { separator });
            TOutput[] localArray = new TOutput[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                localArray[i] = (TOutput) TypeHelper.ChangeType(typeof(TOutput), strArray[i].Trim());
            }
            return localArray;
        }

        public static Dictionary<TKey, TVal> SplitStringToDictionary<TKey, TVal>(string target, char itemSeparator, char keyValSeparator)
        {
            Dictionary<TKey, TVal> dictionary = new Dictionary<TKey, TVal>();
            string[] strArray = target.Split(new char[] { itemSeparator });
            foreach (string str in strArray)
            {
                if (!string.IsNullOrEmpty(str.Trim()))
                {
                    string[] strArray2 = str.Split(new char[] { keyValSeparator });
                    object val = strArray2[0];
                    object obj3 = strArray2[1];
                    if ((typeof(TKey) == typeof(string)) && (typeof(TVal) == typeof(string)))
                    {
                        dictionary.Add((TKey) val, (TVal) obj3);
                    }
                    else if (typeof(TKey) == typeof(string))
                    {
                        TVal local = (TVal) TypeHelper.ChangeType(typeof(TVal), obj3);
                        dictionary.Add((TKey) val, local);
                    }
                    else if (typeof(TVal) == typeof(string))
                    {
                        TKey key = (TKey) TypeHelper.ChangeType(typeof(TKey), val);
                        dictionary.Add(key, (TVal) obj3);
                    }
                    else
                    {
                        TKey local3 = (TKey) TypeHelper.ChangeType(typeof(TKey), val);
                        TVal local4 = (TVal) TypeHelper.ChangeType(typeof(TVal), obj3);
                        dictionary.Add(local3, local4);
                    }
                }
            }
            return dictionary;
        }

        public static string[] SplitStringToStrs(string target, char separator)
        {
            if (target == null)
            {
                return null;
            }
            string[] strArray = target.Split(new char[] { separator });
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = strArray[i].Trim();
            }
            return strArray;
        }

        public static string UpperFirstChar(string str)
        {
            return (str.ToUpper().Substring(0, 1) + str.Substring(1, str.Length - 1));
        }
    }
}

