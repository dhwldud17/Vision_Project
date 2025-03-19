using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace JidamVision.Property
{
    //검사유형
    public enum InspectionType
    {
        BINARY,
        MATCH
    }
    #region 필터유형
    public enum ImageOperation
    {
        OpAdd = 0,         // 덧셈
        OpSubtract,        // 뺄셈
        OpMultiply,        // 곱셈
        OpDivide,          // 나눗셈
        OpMax,             // 최대값
        OpMin,             // 최소값
        OpAbs,             // 절댓값
        OpAbsDiff          // 절댓값 차이
    }

    // 비트 연산 (AND, OR, XOR 등)을 위한 열거형
    public enum Bitwise
    {
        OnAnd = 0,         // AND
        OnOr,              // OR
        OnXor,             // XOR
        OnNot,             // NOT
        OnCompare          // 비교
    }

    // 이미지 필터링 (블러, 박스 필터 등)을 위한 열거형
    public enum ImageFilter
    {
        FilterBlur = 0,           // 블러
        FilterBoxFilter,          // 박스 필터
        FilterMedianBlur,         // 미디안 블러
        FilterGaussianBlur,       // 가우시안 블러
        FilterBilateral           // 양방향 필터
    }

    // 가장자리 검출 (Sobel, Scharr, Laplacian, Canny 등)을 위한 열거형
    public enum ImageEdge
    {
        FilterSobel = 0,          // Sobel 필터
        FilterScharr,             // Scharr 필터
        FilterLaplacian,          // Laplacian 필터
        FilterCanny               // Canny 엣지 검출
    }

    //모폴로지 연산 추가
    public enum Mopology
    {
        Erode = 0,          // 침식
        Dilate,             // 팽창
        Open,               // 열기
        Close               // 닫기
    }
    #endregion
    public class FilterFunction
    {


        // 필터 목록을 Dictionary로 관리
       public static readonly Dictionary<string, List<string>> _filterMap = new Dictionary<string, List<string>>()
    {
        { "연산", new List<string> { "더하기", "빼기", "곱하기", "나누기", "최대값 비교", "최소값 비교", "절대값 계산", "절대값 차이 계산" } },
        { "비트연산(Bitwise)", new List<string> { "AND 연산", "OR 연산", "XOR 연산", "NOT 연산" } },
        { "블러링", new List<string> { "블러 필터", "박스 필터", "미디안 블러", "가우시안 블러", "양방향 필터" } },
        { "Edge", new List<string> { "Sobel 필터", "Scharr 필터", "Laplacian 필터", "Canny 엣지" } },

          //각 상황에 맞는 필터목록 추가하기
        {"이진화", new List<string>{"미디안 블러", "가우시안 블러"} },
        {"매칭", new List<string>{ "Sobel 필터", "Scharr 필터", "Laplacian 필터", "Canny 엣지"} }

    };
        // 특정 필터 목록 가져오기
        public static List<string> GetFilters(string filterType)
        {
            if (_filterMap.ContainsKey(filterType))
            {
                return _filterMap[filterType];
            }

            return new List<string>();
        }


        //ex)
        ///Mat filteredImage = FilterFunction.ApplyFilter(inputImage, "블러링", 1); 으로 사용
        public static Mat ApplyFilter(Mat originalImage, string selectedFilter1, int selectedFilter2, Rect? roiRect = null)
        {
            if (originalImage == null)
                return null;

            Mat filteredImage = new Mat();
            Mat imageToProcess = originalImage.Clone(); // 원본 보호를 위해 깊은 복사

            // ROI가 설정된 경우 해당 영역만 필터 적용
            if (roiRect != null && roiRect.Value.Width > 0 && roiRect.Value.Height > 0)
            {
                imageToProcess = new Mat(originalImage, roiRect.Value);
            }

            switch (selectedFilter1)
            {
                case "연산":
                    ImageOperation operation = (ImageOperation)selectedFilter2;
                    string opValues = "30 30 30";
                    FilterFunction.ApplyImageOperation(operation, imageToProcess, opValues, out filteredImage);
                    break;
                case "비트연산(Bitwise)":
                    Bitwise bitwise = (Bitwise)selectedFilter2;
                    FilterFunction.ApplyBitwiseOperation(bitwise, imageToProcess, out filteredImage);
                    break;
                case "블러링":
                    ImageFilter filter = (ImageFilter)selectedFilter2;
                    FilterFunction.ApplyImageFiltering(filter, imageToProcess, out filteredImage);
                    break;
                case "Edge":
                    ImageEdge edge = (ImageEdge)selectedFilter2;
                    FilterFunction.ApplyEdgeDetection(edge, imageToProcess, out filteredImage);
                    break;
                case "이진화":
                    if (selectedFilter2 == 0)
                    {
                        FilterFunction.ApplyImageFiltering(ImageFilter.FilterMedianBlur, imageToProcess, out filteredImage);
                    }
                    else if (selectedFilter2 == 1)
                    {
                        FilterFunction.ApplyImageFiltering(ImageFilter.FilterGaussianBlur, imageToProcess, out filteredImage);
                    }
                    break;
                case "매칭":
                    switch (selectedFilter2)
                    {
                        case 0: FilterFunction.ApplyEdgeDetection(ImageEdge.FilterSobel, imageToProcess, out filteredImage); break;
                        case 1: FilterFunction.ApplyEdgeDetection(ImageEdge.FilterScharr, imageToProcess, out filteredImage); break;
                        case 2: FilterFunction.ApplyEdgeDetection(ImageEdge.FilterLaplacian, imageToProcess, out filteredImage); break;
                        case 3: FilterFunction.ApplyEdgeDetection(ImageEdge.FilterCanny, imageToProcess, out filteredImage); break;
                    }
                    break;
                default:
                    return originalImage.Clone(); // 필터가 없으면 원본 유지
            }

            // ROI 적용: 필터링된 이미지를 원본에 반영
            if (roiRect != null && roiRect.Value.Width > 0 && roiRect.Value.Height > 0)
            {
                filteredImage.CopyTo(originalImage[roiRect.Value]);
                return originalImage;
            }

            return filteredImage.Clone(); // 전체 이미지 변환 시 반환
        }







        #region 필터 적용 함수
        public static void ApplyImageOperation(ImageOperation operation, Mat src1, string op_value, out Mat resultImage) // 이미지 연산 코드
                                                                                                                         // 아래 코드는 이미지 연산을 수행하는 코드로, 두 이미지를 연산하여 결과를 보여주는 방식
                                                                                                                         // 예시: 덧셈, 뺄셈, 곱셈, 나눗셈, 최대값, 최소값 등을 계산할 수 있음
        {
            // 공백으로 구분된 값이 3개인지 확인
            string[] values = op_value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //if (string.IsNullOrWhiteSpace(op_value)) // 빈 값 처리
            //{
            //    // 유효하지 않은 입력이 있을 경우 오류 메시지 표시
            //    MessageBox.Show("연산값을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (values.Length != 3)
            //{
            //    // 유효하지 않은 입력이 있을 경우 오류 메시지 표시
            //    MessageBox.Show("연산값은 공백으로 구분된 3개의 숫자를 입력해야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //return;
            //}

            //// 숫자인지 확인
            //bool isValid = true;
            //foreach (string value in values)
            //{
            //    if (!int.TryParse(value, out _))  // 숫자가 아닌 값이 있을 경우
            //    {
            //        isValid = false;
            //        break;
            //    }
            //}

            //if (!isValid)
            //{
            //    // 숫자가 아닌 값이 있을 경우 오류 메시지 표시
            //    MessageBox.Show("모든 연산값은 숫자여야 합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //return;
            //}

            // 각각의 값을 정수로 변환
            int value1 = Convert.ToInt32(values[0]);
            int value2 = Convert.ToInt32(values[1]);
            int value3 = Convert.ToInt32(values[2]);

            Mat src2 = new Mat(src1.Size(), MatType.CV_8UC3, new Scalar(value1, value2, value3)); //두 번째 이미지 소스(연산값 받아옴)
            Mat dst = new Mat();

            switch (operation)
            {
                case ImageOperation.OpAdd:
                    Cv2.Add(src1, src2, dst);  // 두 이미지를 더하기
                    break;
                case ImageOperation.OpSubtract:
                    Cv2.Subtract(src1, src2, dst);  // 두 이미지의 차이 구하기
                    break;
                case ImageOperation.OpMultiply:
                    Cv2.Multiply(src1, src2, dst);  // 두 이미지를 곱하기
                    break;
                case ImageOperation.OpDivide:
                    Cv2.Divide(src1, src2, dst);  // 두 이미지 나누기
                    break;
                case ImageOperation.OpMax:
                    Cv2.Max(src1, src2, dst);  // 두 이미지의 최대값 비교
                    break;
                case ImageOperation.OpMin:
                    Cv2.Min(src1, src2, dst);  // 두 이미지의 최소값 비교
                    break;
                case ImageOperation.OpAbs:
                    Cv2.Multiply(src1, src2, dst);
                    Cv2.Abs(dst); // 절대값 계산
                    break;
                case ImageOperation.OpAbsDiff:
                    Mat matMul = new Mat();
                    Cv2.Multiply(src1, src2, matMul);
                    Cv2.Absdiff(src1, matMul, dst); // 절대값 차이 계산
                    break;
            }
            resultImage = dst;



        }

        public static void ApplyBitwiseOperation(Bitwise operation, Mat src1, out Mat resultImage)  // 이미지 Bitwise 연산 코드
                                                                                                    // 두 이미지를 비트 연산(AND, OR, XOR, NOT 등)으로 결합하는 예시
        {
            Mat dst = new Mat();
            Mat src2 = src1.Flip(FlipMode.Y); //Y축 기준으로 반전한 이미지 
            switch (operation)
            {
                case Bitwise.OnAnd:
                    Cv2.BitwiseAnd(src1, src2, dst);  // AND 연산
                    break;
                case Bitwise.OnOr:
                    Cv2.BitwiseOr(src1, src2, dst);  // OR 연산
                    break;
                case Bitwise.OnXor:
                    Cv2.BitwiseXor(src1, src2, dst);  // XOR 연산
                    break;
                case Bitwise.OnNot:
                    Cv2.BitwiseNot(src1, dst);  // NOT 연산
                    break;
                case Bitwise.OnCompare:
                    // 비트 비교 연산 추가 가능
                    break;
            }
            resultImage = dst;
        }

        public static void ApplyImageFiltering(ImageFilter filterType, Mat src, out Mat resultImage) // 블러링 효과 코드
                                                                                                     // 다양한 필터를 사용하여 이미지에 흐림 효과를 적용하는 예시
        {
            Mat dst = new Mat();
            switch (filterType)
            {
                case ImageFilter.FilterBlur:
                    Cv2.Blur(src, dst, new OpenCvSharp.Size(5, 5));  // 블러 필터 적용
                    break;
                case ImageFilter.FilterBoxFilter:
                    Cv2.BoxFilter(src, dst, src.Depth(), new OpenCvSharp.Size(30, 30));  // 박스 필터 적용
                    break;
                case ImageFilter.FilterMedianBlur:
                    Cv2.MedianBlur(src, dst, 31);  // 미디안 블러 적용
                    break;
                case ImageFilter.FilterGaussianBlur:
                    Cv2.GaussianBlur(src, dst, new OpenCvSharp.Size(31, 31), 0);  // 가우시안 블러 적용
                    break;
                case ImageFilter.FilterBilateral:
                    Cv2.BilateralFilter(src, dst, 9, 75, 75);  // 양방향 필터 적용
                    break;
            }
            resultImage = dst;
        }

        public static void ApplyEdgeDetection(ImageEdge edgeType, Mat src, out Mat resultImage)// 엣지(가장자리) 검출 코드
                                                                                               // Sobel, Scharr, Laplacian, Canny 필터를 사용해 이미지의 가장자리를 검출하는 예시
        {
            Mat dst = new Mat();
            switch (edgeType)
            {
                case ImageEdge.FilterSobel:
                    Cv2.Sobel(src, dst, MatType.CV_8U, 1, 1);  // Sobel 필터 적용
                    break;
                case ImageEdge.FilterScharr:
                    Cv2.Scharr(src, dst, MatType.CV_8U, 1, 0);  // Scharr 필터 적용
                    break;
                case ImageEdge.FilterLaplacian:
                    Cv2.Laplacian(src, dst, MatType.CV_8U);  // Laplacian 필터 적용
                    break;
                case ImageEdge.FilterCanny:
                    Cv2.Canny(src, dst, 100, 200);  // Canny 엣지 검출 적용
                    break;
            }
            resultImage = dst;
        }
        #endregion

        //모폴로지 연산 추가
        public static void ApplyMopology(Mopology operation, Mat src, out Mat resultImage)
        {
            Mat dst = new Mat();
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(3, 3));
            switch (operation)
            {
                case Mopology.Erode:
                    Cv2.Erode(src, dst, kernel);  // 침식
                    break;
                case Mopology.Dilate:
                    Cv2.Dilate(src, dst, kernel);  // 팽창
                    break;
                case Mopology.Open:
                    Cv2.MorphologyEx(src, dst, MorphTypes.Open, kernel);  // 열기
                    break;
                case Mopology.Close:
                    Cv2.MorphologyEx(src, dst, MorphTypes.Close, kernel);  // 닫기
                    break;
            }
            resultImage = dst;
        }
    }
}
