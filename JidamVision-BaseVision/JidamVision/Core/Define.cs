using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Core
{
    public enum InspWindowType
    {
        None = 0,
        Global,
        Base,
        Sub,
        ID,
        Group
    }
    internal class Define
    {//전역적으로, ROI 저장 파일명을 설정
        public static readonly string ROI_IMAGE_NAME = "RoiImage.bmp";
    }
}
