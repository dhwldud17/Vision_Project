using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Algorithm
{
    internal class MatchAlgorithm : InspAlgorithm
    {
        int _matchScore;
        Size _extSize;
        Mat _templateImage;

        int _outScore;
        Point2f _outPoint;

        public MatchAlgorithm()
        {
            _matchScore = 60;
            _extSize = new Size(100, 100);
            _outPoint = new Point2f();
        }

        public void SetTemplateImage(Mat templateImage)
        {
            _templateImage = templateImage;
        }

        //public void Main()
        //{
        //    string imagePath = "image.png";        // 원본 이미지
        //    string templatePath = "template.png";  // 템플릿 이미지

        //    // 이미지 로드
        //    using Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
        //    using Mat template = Cv2.ImRead(templatePath, ImreadModes.Color);

        //    if (image.Empty() || template.Empty())
        //    {
        //        Console.WriteLine("이미지를 로드할 수 없습니다.");
        //        return;
        //    }

        //    // 단일 매칭 (가장 높은 점수 1개만 반환)
        //    MatchTemplateSingle(image, template);

        //    // 여러 개의 매칭 (임계값 이상인 위치 반환)
        //    MatchTemplateMultiple(image, template, 0.8);
        //}

        /// <summary>
        /// 하나의 최적 매칭 위치만 찾기
        /// </summary>
        public bool MatchTemplateSingle(Mat image, out Point outPos, out int outScore)
        {
            outPos.X = outPos.Y = 0;
            outScore = 0;

            if (_templateImage is null)
                return false;

            Mat result = new Mat();

            // 템플릿 매칭 수행
            Cv2.MatchTemplate(image, _templateImage, result, TemplateMatchModes.CCoeffNormed);

            // 가장 높은 점수 위치 찾기
            Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out Point maxLoc);

            _outScore = (int)(maxVal * 100);

            Console.WriteLine($"최적 매칭 위치: {maxLoc}, 신뢰도: {maxVal:F2}");

            // 매칭된 위치에 사각형 표시
            //Cv2.Rectangle(image, new Rect(maxLoc, template.Size()), Scalar.Red, 2);
            //Cv2.ImShow("Best Match", image);
            //Cv2.WaitKey(0);

            outPos = maxLoc;
            outScore = _outScore;

            return true;
        }

        /// <summary>
        /// 여러 개의 매칭 위치 찾기 (임계값 이상인 경우)
        /// </summary>
        public int MatchTemplateMultiple(Mat image,out List<Point> outPos)
        {
            outPos = new List<Point>();

            float matchScore = _matchScore * 0.01f;

            Mat result = new Mat();

            // 템플릿 매칭 수행
            Cv2.MatchTemplate(image, _templateImage, result, TemplateMatchModes.CCoeffNormed);

            // 임계값(threshold) 이상인 위치 찾기
            for (int y = 0; y < result.Rows; y++)
            {
                for (int x = 0; x < result.Cols; x++)
                {
                    if (result.At<float>(y, x) >= matchScore)
                    {
                        Point matchLoc = new Point(x, y);
                        outPos.Add(matchLoc);
                        //Console.WriteLine($"매칭 위치: {matchLoc}, 신뢰도: {result.At<float>(y, x):F2}");

                        //// 매칭된 위치에 사각형 표시
                        //Cv2.Rectangle(image, new Rect(matchLoc, template.Size()), Scalar.Green, 2);
                    }
                }
            }

            return outPos.Count;
        }
    }
}
