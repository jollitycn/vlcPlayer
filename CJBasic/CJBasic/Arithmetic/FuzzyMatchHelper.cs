namespace CJBasic.Arithmetic
{
    using System;
    using System.Runtime.InteropServices;

    public static class FuzzyMatchHelper
    {
        private static bool ContainString(string sourceString, int startInSouce, string containString, out int startIndex, out int endIndex)
        {
            for (int i = startInSouce; i < sourceString.Length; i++)
            {
                if ((sourceString[i] != containString[0]) && (containString[0] != '_'))
                {
                    continue;
                }
                startIndex = i;
                int num2 = 1;
                while (num2 < containString.Length)
                {
                    if (((i + num2) >= sourceString.Length) || ((containString[num2] != '_') && (containString[num2] != sourceString[startIndex + num2])))
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 == containString.Length)
                {
                    endIndex = startIndex + containString.Length;
                    return true;
                }
            }
            startIndex = -1;
            endIndex = -1;
            return false;
        }

        public static bool IsLike(string matchingStr, string targetStr)
        {
            string[] strArray = matchingStr.Split(new char[] { '%' });
            int startInSouce = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != "")
                {
                    int num3;
                    int num4;
                    if (!ContainString(targetStr, startInSouce, strArray[i], out num3, out num4))
                    {
                        return false;
                    }
                    if ((i == 0) && (num3 != 0))
                    {
                        return false;
                    }
                    if ((i == (strArray.Length - 1)) && (num4 != targetStr.Length))
                    {
                        startInSouce++;
                        i--;
                    }
                    else
                    {
                        startInSouce = num4;
                    }
                }
            }
            return true;
        }
    }
}

