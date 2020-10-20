using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    public class GuideMemoPagePara : BasePagePara
    {
        public string GuideID { get; set; }
    }

    public class GuideMemoPage : BasePage
    {
        public List<GuideMemo> GuideMemos { get; set; }
    }
}
