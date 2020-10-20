using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class AddPfShoppingCart
    {
        public string SizeName { get; set; }

        public int BuyCount { get; set; }
    }

    [Serializable]
    public class AddPfShoppingCartPara
    {
        public string ColorName { get; set; }

        public List<AddPfShoppingCart> Lists { get; set; }
    }
}
