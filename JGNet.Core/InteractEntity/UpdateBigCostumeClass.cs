using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    #region 大类
    [Serializable]
    public class UpdateBigClassPara
    {
        public int ID { get; set; }

        public string NewClass { get; set; }

        public string ClassCode { get; set; }

        public int OrderNo { get; set; }
    }

    [Serializable]
    public class InsertCostumeClassPara
    {
        public string BigClass { get; set; }

        public int OrderNo { get; set; }

        public string ClassCode { get; set; }
    }

    [Serializable]
    public class DeleteBigCostumeClassPara
    {
        public List<int> IDs { get; set; }
    }
    #endregion

    #region 小类
    [Serializable]
    public class InsertSmallClassPara
    {
        public int ParentAutoID { get; set; }

        public string SmallClass { get; set; }

        public int OrderNo { get; set; }

        public string ClassCode { get; set; }
    }

    [Serializable]
    public class UpdateSmallClassPara
    {
        public int ID { get; set; }

        public string NewClass { get; set; }

        public string ClassCode { get; set; }

        public int OrderNo { get; set; }
    }

    [Serializable]
    public class DeleteSmallClassPara
    {
        public List<int> IDs { get; set; }
    }
    #endregion

    #region 次小类
    [Serializable]
    public class InsertSubSmallClassPara
    {
        public int ParentAutoID { get; set; }

        public string SubSmallClass { get; set; }

        public int OrderNo { get; set; }

        public string ClassCode { get; set; }
    }

    [Serializable]
    public class UpdateSubSmallClassPara
    {
        public int ID { get; set; }

        public string NewClass { get; set; }

        public string ClassCode { get; set; }

        public int OrderNo { get; set; }
    }

    [Serializable]
    public class DeleteSubSmallClassPara
    {
        public List<int> IDs { get; set; }
    } 
    #endregion
}
