namespace CJBasic.Arithmetic
{
    using System;

    public static class GenericKMP
    {
        public static int ExecuteKMP<T>(T[] source, T[] pattern) where T: IEquatable<T>
        {
            int[] next = Next<T>(pattern);
            return ExecuteKMP<T>(source, 0, source.Length, pattern, next);
        }

        public static int ExecuteKMP<T>(T[] source, T[] pattern, int[] next) where T: IEquatable<T>
        {
            return ExecuteKMP<T>(source, 0, source.Length, pattern, next);
        }

        public static int ExecuteKMP<T>(T[] source, int sourceOffset, int sourceCount, T[] pattern) where T: IEquatable<T>
        {
            int[] next = Next<T>(pattern);
            return ExecuteKMP<T>(source, sourceOffset, sourceCount, pattern, next);
        }

        public static int ExecuteKMP<T>(T[] source, int sourceOffset, int sourceCount, T[] pattern, int[] next) where T: IEquatable<T>
        {
            int index = sourceOffset;
            int num2 = 0;
            while ((num2 < pattern.Length) && (index < (sourceOffset + sourceCount)))
            {
                if (source[index].Equals(pattern[num2]))
                {
                    index++;
                    num2++;
                }
                else
                {
                    num2 = next[num2];
                    if (num2 == -1)
                    {
                        index++;
                        num2++;
                    }
                }
            }
            return ((num2 < pattern.Length) ? -1 : (index - num2));
        }

        public static int[] Next<T>(T[] pattern) where T: IEquatable<T>
        {
            int[] numArray = new int[pattern.Length];
            numArray[0] = -1;
            if (pattern.Length >= 2)
            {
                numArray[1] = 0;
                int num = 2;
                int index = 0;
                while (num < pattern.Length)
                {
                    if (pattern[num - 1].Equals(pattern[index]))
                    {
                        numArray[num++] = ++index;
                    }
                    else
                    {
                        index = numArray[index];
                        if (index == -1)
                        {
                            numArray[num++] = ++index;
                        }
                    }
                }
            }
            return numArray;
        }
    }
}

