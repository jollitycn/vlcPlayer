using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class CostumeClass
    {

        public List<ListItem<String>> SmallClassListItem
        {
            get
            {
                List<ListItem<String>> listItems = new List<ListItem<string>>();
                string[] sts = this.SmallClassStr.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in sts)
                {
                    listItems.Add(new ListItem<string>(str, str));
                }

                return listItems;
            }
        }


        public static String GetSmallClassStrFromListItems(List<ListItem<String>> items)
        { 
                String str = ""; 
                if (items != null && items.Count>0) {
                    foreach (var item in items)
                    {
                        str+= item.Key+",";
                    }
                    str = str.Remove(str.LastIndexOf(","));
                }
                return str; 
        }

        private List<string> smallClassList = null;
        public List<string> SmallClassList
        {
            get
            {
                if (this.smallClassList == null)
                {
                    string[] sts = this.SmallClassStr.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    this.smallClassList = new List<string>();
                    foreach (string str in sts)
                    {
                        this.smallClassList.Add(str);
                    }
                }
                return this.smallClassList;
            }
        }
    }
}
