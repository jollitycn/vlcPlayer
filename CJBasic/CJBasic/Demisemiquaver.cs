namespace CJBasic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Demisemiquaver
    {
        private static IDictionary<long, string> CodeDictionary = new Dictionary<long, string>();

        static Demisemiquaver()
        {
            int num = 0;
            int num2 = 0x41;
            for (int i = 0; i < 0x20; i++)
            {
                if (i == 0)
                {
                    CodeDictionary.Add((long) i, "Z");
                }
                else if (i < 10)
                {
                    CodeDictionary.Add((long) i, i.ToString());
                }
                else
                {
                    int num4 = i - 10;
                    char ch = (char) (num2 + num4);
                    char ch2 = (char) (ch + num);
                    switch (ch2)
                    {
                        case 'I':
                        case 'O':
                        case 'U':
                            num++;
                            break;
                    }
                    CodeDictionary.Add((long) i, ((char) (ch + num)).ToString());
                }
            }
        }

        public static string Convert(long num)
        {
            List<string> list = new List<string>();
            StringBuilder builder = new StringBuilder("");
            while (num > 0L)
            {
                builder.Insert(0, CodeDictionary[num % 0x20L]);
                num = num >> 5;
            }
            return builder.ToString();
        }
    }
}

