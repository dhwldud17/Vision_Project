﻿using JidamVision.Core;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;

namespace JidamVision.Algorithm
{
    //#BINARY FILTER#1 이진화 필터를 위한 클래스


    //이진화 임계값 설정을 구조체로 만들기
    public struct BinaryThreshold
    {
        public int lower;
        public int upper;
        public bool invert;
    }

    public class BlobAlgorithm : InspAlgorithm
    {
        //이진화 필터로 찾은 영역
        private List<Rect> _findArea;

        public BinaryThreshold BinThreshold { get; set; } = new BinaryThreshold();
        public bool SetArea = false;
        public bool SetHeight = false;
        public bool SetWidth = false;

        //픽셀 영역으로 이진화 필터
        public int FilterAreaMin { get; set; } = 1;   // 최소 면적
        public int FilterAreaMax { get; set; } = 5000000;// 최대 면적

        public int FilterWidthMin { get; set; } = 1;   // 최소 너비
        public int FilterWidthMax { get; set; } = 5000;// 최대 너비

        public int FilterHeightMin { get; set; } = 1;  // 최소 높이
        public int FilterHeightMax { get; set; } = 5000;// 최대 높이


        public BlobAlgorithm()
        {
            //#ABSTRACT ALGORITHM#5 각 함수마다 자신의 알고리즘 타입 설정
            InspectType = InspectType.InspBinary;
        }


        public void SetImage(Mat newImage)
        {
            if (newImage is null || newImage.Empty())
                return;

            _srcImage = newImage.Clone(); // 새로운 이미지로 업데이트
        }



        //#BINARY FILTER#2 이진화 후, 필터를 이용해 원하는 영역을 얻음 

        //#ABSTRACT ALGORITHM#6 
        //InspAlgorithm을 상속받아, 구현하고, 인자로 입력받던 것을 부모의 _srcImage 이미지 사용
        //검사 시작전 IsInspected = false로 초기화하고, 검사가 정상적으로 완료되면,IsInspected = true로 설정
        public override bool DoInspect()
        {
            IsInspected = false;

            if (_srcImage == null)
                return false;
          
            Mat grayImage = new Mat();
            if (_srcImage.Type() == MatType.CV_8UC3)
                Cv2.CvtColor(_srcImage, grayImage, ColorConversionCodes.BGR2GRAY);
            else
                grayImage = _srcImage;

            Mat binaryImage = new Mat();
            //Cv2.Threshold(grayImage, binaryMask, lowerValue, upperValue, ThresholdTypes.Binary);
            Cv2.InRange(grayImage, BinThreshold.lower, BinThreshold.upper, binaryImage);

            if (BinThreshold.invert)
                binaryImage = ~binaryImage;


            //실제 필터 구현  //버튼 사용X   //버튼 사용해서 나오는 결과는 검사에 사용하는 이미지가 아니라 우리한테 보여줄려는 이미지를 그때 만들어서 보여주는거임. 따로!!!!
            //버튼 사용해서 나오는건 preview에 뿌리면됨



            if (FilterAreaMin > 0)
            {
                if (!BlobFilter(binaryImage, FilterAreaMin)) //만약 
                    return false;
            }

            IsInspected = true;

            return true;
        }
        //#BINARY FILTER#3 이진화 필터처리 함수
        private bool BlobFilter(Mat binImage, int areaFilter)
        {
            //컨투어 찾기
            Point[][] contours; //컨투어 정보
            HierarchyIndex[] hierarchy; //컨투어 계층 정보
            Cv2.FindContours(binImage, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            //필터링된 객체를 담을 리스트
            Mat filteredImage = Mat.Zeros(binImage.Size(), MatType.CV_8UC1);

            if (_findArea is null)
                _findArea = new List<Rect>();

            _findArea.Clear();
            foreach (var contour in contours)
            {
                double area = Cv2.ContourArea(contour);
                // 면적 필터 적용

                // 필터링된 객체를 이미지에 그림
                //Cv2.DrawContours(filteredImage, new Point[][] { contour }, -1, Scalar.White, -1);

                //width, height, x, y 구하는 거 추가하기(?) ->딱 맞는 사각형 구하기위해 

                //딱맞는 영역 사각형 구하기 위해 각도 정보 
                // RotatedRect 정보 계산 
                //RotatedRect rotatedRect = Cv2.MinAreaRect(contour);//최소 회전된 사각형
                Rect boundingRect = Cv2.BoundingRect(contour);
                if (SetArea)
                { //
                    if(area < FilterAreaMin || area > FilterAreaMax)
                        continue;
                }
                if (SetWidth)
                {
                    if(boundingRect.Width < FilterWidthMin || boundingRect.Width > FilterWidthMax)
                        continue;
                }
                if (SetHeight)
                {
                    if (boundingRect.Height < FilterHeightMin || boundingRect.Height > FilterHeightMax)
                        continue;
                }
                // 너비, 높이 필터 적용



                _findArea.Add(boundingRect);

                // RotatedRect 정보 출력
                //Console.WriteLine($"RotatedRect - Center: {rotatedRect.Center}, Size: {rotatedRect.Size}, Angle: {rotatedRect.Angle}");

                // BoundingRect 정보 출력
                //Console.WriteLine($"BoundingRect - X: {boundingRect.X}, Y: {boundingRect.Y}, Width: {boundingRect.Width}, Height: {boundingRect.Height}");

            }
            return true;
        }

        //#BINARY FILTER#4 이진화 영역 반환
        public override int GetResultRect(out List<Rect> resultArea)
        {
            resultArea = null;

            //#ABSTRACT ALGORITHM#7 검사가 완료되지 않았다면, 리턴
            if (!IsInspected)
                return -1;

            if (_findArea is null || _findArea.Count <= 0)
                return -1;

            resultArea = _findArea;
            return resultArea.Count;
        }
    }
}
