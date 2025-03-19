using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JidamVision.Algorithm;
using JidamVision.Core;
using JidamVision.Teach;
using OpenCvSharp;

namespace JidamVision.Inspect
{ /*
    #INSP WORKER# - <<<검사 알고리즘 통합 및 검사 관리 클래스 추가>>> 
    검사 관리 클래스 : 전체 검사 또는 개별 검사 동작
    검사 알고리즘 추상화
     */

    //검사 관련 처리 클래스
    public class InspWorker
    {

        public InspWorker() { }

        //#INSP WORKER#2 InspStage내의 모든 InspWindow들을 검사하는 함수
        public bool RunInspect()
        {
            List<InspWindow> inspWindowList = Global.Inst.InspStage.InspWindowList;//InspStage의 InspWindowList를 가져옴
            foreach (var inspWindow in inspWindowList) //InspWindowList의 모든 InspWindow에 대해
            {
                if (inspWindow is null)
                    continue;

                List<InspAlgorithm> inspAlgorithmList = inspWindow.AlgorithmList; //각 InspWindow의 AlgorithmList를 가져옴
                foreach (var algorithm in inspAlgorithmList)
                {
                    UpdateInspData(algorithm); //알고리즘에 필요한 데이터를 업데이트
                }
            }
            foreach (var inspWindow in inspWindowList)
            {
                inspWindow.DoInpsect(InspectType.InspNone);//모든 알고리즘 검사
                DisplayResult(inspWindow, InspectType.InspNone); //검사 결과를 화면에 표시
            }
            return true;

        }

        //#INSP WORKER#5 특정 InspWindow에 대한 검사 진행
        //inspType이 있다면 그것만을 검사하고, 없다면 InpsWindow내의 모든 알고리즘 검사
        public bool TryInspect(InspWindow inspObj, InspectType inspType) //InspWindow와 검사 타입을 받아서 검사 진행
        {
            if (inspObj is null)
                return false;

            InspAlgorithm inspAlgo = inspObj.FindInspAlgorithm(inspType); //InspWindow 내에서 검사 타입에 해당하는 InspAlgorithm을 찾음
            if (inspAlgo is null)
                return false;

            if (!UpdateInspData(inspAlgo)) //검사에 필요한 데이터를 입력
                return false;

            if (!inspObj.DoInpsect(inspType)) //검사 진행
                return false;

            DisplayResult(inspObj, inspType); //검사 결과를 화면에 표시
            return true;
        }

        //#INSP WORKER#3 각 알고리즘 타입 별로 검사에 필요한 데이터를 입력하는 함수
        private bool UpdateInspData(InspAlgorithm inspAlgo)
        {
            InspectType inspType = inspAlgo.InspectType;

            switch (inspType)
            {
                case InspectType.InspBinary:
                    {
                        BlobAlgorithm blobAlgo = (BlobAlgorithm)inspAlgo;

                        Mat srcImage = Global.Inst.InspStage.GetMat();
                        blobAlgo.SetInspData(srcImage);
                        break;
                    }
                case InspectType.InspMatch:
                    {
                        MatchAlgorithm matchAlgo = (MatchAlgorithm)inspAlgo;
                        Mat srcImage = Global.Inst.InspStage.GetMat();
                        matchAlgo.SetInspData(srcImage);
                        break;
                    }
               default:
                    {
                        Console.WriteLine($"Not support inspection type : %s", inspType.ToString());
                        return false;
                    }
            }
            return true;

        }


        //#INSP WORKER#4 검사 결과를 화면에 표시하는 함수

        private bool DisplayResult(InspWindow inspObj, InspectType inspType) //검사 결과를 화면에 표시
        {
            if (inspObj is null)
                return false;
            List<Rect> totalArea = new List<Rect>();

            List<InspAlgorithm> inspAlgorithmList = inspObj.AlgorithmList; //InspWindow의 AlgorithmList를 가져옴
            foreach (var algorithm in inspAlgorithmList)
            {
                if (algorithm.InspectType != inspType && algorithm.InspectType != InspectType.InspNone)//검사 타입이 inspType이 아니고, InspNone이 아니면 다음으로
                    continue;

                List<Rect> resultArea = new List<Rect>();
                int resultCnt = algorithm.GetResultRect(out resultArea);//검사 결과를 Rect 리스트로 반환
                if (resultCnt > 0)
                    totalArea.AddRange(resultArea); //찾은 위치를 totalArea에 추가
            }

            if (totalArea.Count >= 0) //찾은 위치가 있다면
            {   //찾은 위치를 이미지상에서 표시 
                var cameraForm = MainForm.GetDockForm<CameraForm>(); //CameraForm을 가져옴
                if (cameraForm != null) //CameraForm이 있다면
                {
                    cameraForm.AddRect(totalArea); //찾은 위치를 표시
                }

            }
            return true;
        }
    }
}
