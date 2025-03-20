﻿using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JidamVision.Core;
using JidamVision.Teach;
using OpenCvSharp;

namespace JidamVision.Inspect
{
    //검사 결과로 사용할 프로퍼티 만듬
    //-> 검사결과 저장 및 출력을 위한 클래스
    public class InspResult
    {  
        //검사한 ROI 정보 
        public InspWindow InspObject { get;set; }
        //ROI 여러개있을때, 기준이 되는 ROI
        public string BaseID { get; set; }
        //실제 검사한 ROI
        public string ObjectID { get; set; }

        //검사한 ROI의 타입
        public InspWindowType ObjectType { get; set; }
        //검사 결과 코드
        public int ErrorCode { get; set; }

        //결과가 불량인지 여부
        public bool IsDefect { get; set; }
        //결과 점수
        public float ResultScore { get; set; }
        //결과 값(점수가 아닌 실제 값)
        public float ResultValue { get; set; }
        //세부적인 검사 결과
        public string ResultInfo { get; set; }

        //검사 결과로 찾은 불량 위치
        public List<Rect> ResutRectList { get; set; } = null;


        public InspResult()
        {
            InspObject = new InspWindow();
            BaseID = string.Empty;
            ObjectID = string.Empty;
            ObjectType = InspWindowType.None;
            ErrorCode = 0;
            IsDefect = false;
            ResultScore = 0;
            ResultValue = 0;
            ResultInfo = string.Empty;
        }

        public InspResult(InspWindow window, string baseID, string objectID, InspWindowType objectType)
        {
            InspObject = window;
            BaseID = baseID;
            ObjectID = objectID;
            ObjectType = objectType;
            ErrorCode = 0;
            IsDefect = false;
            ResultScore = 0;
            ResultValue = 0;
            ResultInfo = string.Empty;
        }
    }
}
