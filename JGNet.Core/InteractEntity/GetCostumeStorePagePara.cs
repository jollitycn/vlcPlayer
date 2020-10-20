using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GetCostumeStorePagePara : BasePagePara
    {
        public string ShopID { get; set; }
        
    }

    public class CostumeStorePage : BasePage
    {
        public List<CostumeStore> CostumeStores { get; set; }
    }
}
