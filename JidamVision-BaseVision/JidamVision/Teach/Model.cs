using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JidamVision.Core;

namespace JidamVision.Teach
{
    

    public class Model
    { //새로운 ROI생성 = InspWindow 생성
        //#MODEL#1 InspStage에 있던 InspWindowList 위치를 이곳으로 변경
        public List<InspWindow> InspWindowList { get; set; }

        public Model()
        {
            InspWindowList = new List<InspWindow>();
        }
        //새로운 InspWindow를 추가하는 기능
        public InspWindow AddInspWindow(InspWindowType windowType)
        {
            InspWindow inspWindow = InspWindowFactory.Inst.Create(windowType);
            InspWindowList.Add(inspWindow);

            return inspWindow;
        }
        //#MODEL#5 기존 InspWindow를 삭제할때
        public bool DelInspWindow(InspWindow inspWindow)
        {
            if (InspWindowList.Contains(inspWindow))
            {
                InspWindowList.Remove(inspWindow);
                return true;
            }
            return false;
        }
    }
}
