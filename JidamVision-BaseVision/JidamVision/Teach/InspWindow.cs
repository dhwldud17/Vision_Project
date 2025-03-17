using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JidamVision.Algorithm;
using OpenCvSharp;
using JidamVision.Core;
using System.Security.Policy;
using System.Drawing;
using System.IO;

namespace JidamVision.Teach
{
    //#MATCH PROP#3 InspWindow 클래스 추가, ROI 관리 및 검사를 처리하는 클래스
    //검사 알고리즘를 관리하는 클래스

    public class InspWindow
    {
        //템플릿 매칭할 윈도우 크기
        private System.Drawing.Rectangle _rect;
        //템플릿 매칭 이미지
        private Mat _teachingImage;

        public InspWindowType InspWindowType {  get; private set; }

        public string Name {  get; private set; }
        public string UID { get; set; }

        public Rect WindowArea { get; set; }

        //#ABSTRACT ALGORITHM#9 개별 변수로 있던, MatchAlgorithm과 BlobAlgorithm을
        //InspAlgorithm으로 추상화하여 리스트로 관리하도록 변경

        public List<InspAlgorithm> AlgorithmList { get; set; } = new List<InspAlgorithm>();

        public InspWindow()
        {
            //#ABSTRACT ALGORITHM#13 매칭 알고리즘과 이진화 알고리즘 추가
            AddInspAlgorithm(InspectType.InspMatch);
            AddInspAlgorithm(InspectType.InspBinary);
        }

        public InspWindow(InspWindowType windowType, string name)
        {
            InspWindowType = windowType;
            Name = name;
            AddInspAlgorithm(InspectType.InspMatch);
            AddInspAlgorithm(InspectType.InspBinary);
        }

        public bool SetTeachingImage(Mat image, System.Drawing.Rectangle rect)
        {
            _rect = rect;
            _teachingImage = new Mat(image, new Rect(rect.X, rect.Y, rect.Width, rect.Height));
            return true;
        }

        //#MATCH PROP#4 템플릿 매칭 이미지 로딩
        public bool PatternLearn()
        {
            foreach (var algorithm in AlgorithmList)
            {
                if (algorithm.InspectType != InspectType.InspMatch)
                    continue;

                MatchAlgorithm matchAlgo = (MatchAlgorithm)algorithm;

                string templatePath = Path.Combine(Directory.GetCurrentDirectory(), Define.ROI_IMAGE_NAME);
                if (File.Exists(templatePath))
                {
                    _teachingImage = Cv2.ImRead(templatePath);

                    if (_teachingImage != null)
                        matchAlgo.SetTemplateImage(_teachingImage);
                }
            }

            return true;
        }
        
        //#ABSTRACT ALGORITHM#10 타입에 따라 알고리즘을 추가하는 함수
        public bool AddInspAlgorithm(InspectType inspType)
        {
            InspAlgorithm inspAlgo = null;

            switch(inspType)
            {
                case InspectType.InspBinary:
                    inspAlgo = new BlobAlgorithm();
                    break;
                case InspectType.InspMatch:
                    inspAlgo = new MatchAlgorithm();
                    break;
            }

            if (inspAlgo is null)
                return false;

            AlgorithmList.Add(inspAlgo);

            return true;
        }


        //#ABSTRACT ALGORITHM#11 알고리즘을 리스트로 관리하므로, 필요한 타입의 알고리즘을 찾는 함수
        public InspAlgorithm FindInspAlgorithm(InspectType inspType)
        {
            foreach (var algorithm in AlgorithmList)
            {
                if (algorithm.InspectType == inspType)
                    return algorithm;
            }
            return null;
        }

        //#ABSTRACT ALGORITHM#12 클래스 내에서, 인자로 입력된 타입의 알고리즘을 검사하거나,
        ///모든 알고리즘을 검사하는 옵션을 가지는 검사 함수
        public bool DoInpsect(InspectType inspType)
        {
            foreach( var inspAlgo in AlgorithmList)
            {
                if (inspAlgo.InspectType == inspType || inspAlgo.InspectType == InspectType.InspNone)
                    inspAlgo.DoInspect();
            }

            return true;
        }
    }
}
