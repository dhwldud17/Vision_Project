using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Teach
{ //#MULTI ROI#1 ImageViewer에 표시되는 ROI정보를 관리하는 클래스
    public class DiagramEntity
    {
        //ROI 연결된 InspWindow
        public InspWindow LinkedWindow { get; set; }
        //ROI 영역정보
        public Rectangle EntityROI { get; set; }
        //ROI 표시 칼라
        public Color EntityColor { get; set; }
        //ROI 위치 이동을 하지 못하게 할지 여부
        public bool IsHold { get; set; }

        public DiagramEntity()
        {
            LinkedWindow = null;
            EntityROI = new Rectangle(0, 0, 0, 0);
            EntityColor = Color.White;
            IsHold = false;
        }
        public DiagramEntity(Rectangle rect, Color entityColor, bool hold = false)
        {
            LinkedWindow = null;
            EntityROI = rect;
            EntityColor = entityColor;
            IsHold = hold;
        }
    }
}
