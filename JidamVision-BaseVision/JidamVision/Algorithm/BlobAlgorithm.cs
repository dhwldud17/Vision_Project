using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace JidamVision.Algorithm
{ //#BINARY FILTER#1 이진화 필터를 위한 클래스


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

        public BinaryThreshold BinThreshold { get; set; } = new BinaryThreshold(); //이진화 임계값 설정


        //픽셀 영역으로 이진화 필터
        public int FilterAreaMin { get; set; } = 0;   // 최소 면적
        public int FilterAreaMax { get; set; } = 300; // 최대 면적

        public int FilterWidthMin { get; set; } = 0;   // 최소 너비
        public int FilterWidthMax { get; set; } = 300; // 최대 너비

        public int FilterHeightMin { get; set; } = 0;  // 최소 높이
        public int FilterHeightMax { get; set; } = 300; // 최대 높이


        public BlobAlgorithm()
        { //#ABSTRACT ALGORITHM#5 각 함수마다 자신의 알고리즘 타입 설정
            InspectType = InspectType.InspBinary;
        }
        //#BINARY FILTER#2 이진화 후, 필터를 이용해 원하는 영역을 얻음 
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

            if (FilterAreaMin > 0)
            {
                if (!BlobFilter(binaryImage, FilterAreaMin))
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
                if (area < FilterAreaMin || area > FilterAreaMax)
                    continue;

                // 너비, 높이 필터 적용
                if (boundingRect.Width < FilterWidthMin || boundingRect.Width > FilterWidthMax)
                    continue;
                if (boundingRect.Height < FilterHeightMin || boundingRect.Height > FilterHeightMax)
                    continue;

                _findArea.Add(boundingRect);

                // RotatedRect 정보 출력
                //Console.WriteLine($"RotatedRect - Center: {rotatedRect.Center}, Size: {rotatedRect.Size}, Angle: {rotatedRect.Angle}");

                // BoundingRect 정보 출력
                //Console.WriteLine($"BoundingRect - X: {boundingRect.X}, Y: {boundingRect.Y}, Width: {boundingRect.Width}, Height: {boundingRect.Height}");

            }
            return true;
        }

        //#BINARY FILTER#4 이진화 영역 반환
        public int GetResultRect(out List<Rect> resultArea)
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
