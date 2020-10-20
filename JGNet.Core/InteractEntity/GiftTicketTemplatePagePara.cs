using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GiftTicketTemplatePagePara : BasePagePara
    {

    }

    public class GiftTicketTemplatePage : BasePage
    {
        public List<GiftTicketTemplate> GiftTicketTemplates { get; set; }
    }
}
