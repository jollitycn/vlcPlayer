using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Pf.InteractEntity
{
    [Serializable]
    public class UpdatePfShoppingCartInfo
    {
        public string ShoppingCartId { get; set; }

        public int BuyCount { get; set; }
    }
}
