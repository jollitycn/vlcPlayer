using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PhotoData
    {
        public EmCostumePhoto EmCostumePhoto { get; set; }

        public string Name { get; set; }

        public Byte[] Datas { get; set; }
    }
    
    public class PosterImage
    {
        public EmPosterImage EmPosterImage { get; set; }

        public Byte[] Datas { get; set; }
    }

    public class DeletePosterImagePara
    {
        public string BusinessAccountID { get; set; }

        public string Name { get; set; }
    }

    public class UploadHeadImagePara
    {
        public string MemberID { get; set; }

        public byte[] HeadImage { get; set; }
    }
}
