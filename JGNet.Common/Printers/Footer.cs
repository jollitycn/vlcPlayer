using System;
using System.Collections.Generic;
using System.Text;

namespace GoldPrinter
{ 
        public class Footer : Outer
        {
            public Footer()
            {
                //
                // TODO: 在此处添加构造函数逻辑
                //
            }

            public Footer(int rows, int cols) : this()
            {
                base.Initialize(rows, cols);
            }

        public int FooterCurRowIndex { get; set; } 
        }//End Class
    
}
