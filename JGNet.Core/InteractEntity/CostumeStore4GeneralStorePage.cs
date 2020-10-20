using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class CostumeStore4GeneralStorePage : BasePage
    {
        public List<CostumeStore> CostumeStoreList { get; set; } 
    }

    public class CostumeStore4GeneralStorePagePara : BasePagePara
    {
        public string CostumeID { get; set; }
        
    }
}
