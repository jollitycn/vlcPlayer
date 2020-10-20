using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CostumeGiftTicketInfo
    {
        public bool IsUse { get; set; }

        private List<string> costumeIDs = new List<string>();
        public List<string> CostumeIDs
        {
            get => this.costumeIDs;
            set => this.costumeIDs = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.IsUse ? 1 : 0).Append("^");
            if (this.costumeIDs.Count == 0)
            {
                return sb.ToString();
            }
            foreach (string costumeID in this.costumeIDs)
            {
                sb.Append(costumeID).Append("#");
            }
            string str = sb.ToString();
            return str.Substring(0, str.Length - 1);
        }

        public void StringToObj(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            string[] result = str.Split("^".ToCharArray());
            this.IsUse = result[0] == "1";
            string costumeIDsString = result[1];
            if (string.IsNullOrEmpty(costumeIDsString))
            {
                return;
            }
            string[] costumeIDs = costumeIDsString.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string costumeID in costumeIDs)
            {
                this.costumeIDs.Add(costumeID);
            }
        }
    }
}
