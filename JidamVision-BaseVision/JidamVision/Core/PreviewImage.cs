using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JidamVision.Property;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace JidamVision.Core
{

    public class PreviewImage
    {
        private Mat _orinalImage = null;
        private Mat _previewImage = null;
        private Mat _tempImage = null;
        eImageChannel _currentImageChannel = eImageChannel.Color;
        public void SetImage(Mat image)
        {
            _orinalImage = image;
            _previewImage = new Mat();
            //_previewImage = null;
            //_tempImage = new Mat(image.Size(), MatType.CV_8UC1,new Scalar(0));
        }

        //#BINARY FILTER#15 기존 이진화 프리뷰에, 배경없이 이진화 이미지만 보이는 모드 추가
        //이진화 기능
        public void SetBinary(int lowerValue, int upperValue, bool invert, ShowBinaryMode showBinMode)
        {
            if (_orinalImage == null)
                return;
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm == null)
                return;

            Bitmap bmpImage;
            if (showBinMode == ShowBinaryMode.ShowBinaryNone)
            {
                bmpImage = BitmapConverter.ToBitmap(_orinalImage);
                cameraForm.UpdateDisplay(bmpImage);
                return;
            }

            Mat grayImage = new Mat();
            if (_orinalImage.Type() == MatType.CV_8UC3)
                Cv2.CvtColor(_orinalImage, grayImage, ColorConversionCodes.BGR2GRAY);
            else
                grayImage = _orinalImage;

            Mat binaryMask = new Mat();
            //Cv2.Threshold(grayImage, binaryMask, lowerValue,upperValue, ThresholdTypes.Binary);
            Cv2.InRange(grayImage, lowerValue, upperValue, binaryMask);

            if (invert)
                binaryMask = ~binaryMask; //이진화 반전

            if (showBinMode == ShowBinaryMode.ShowBinaryOnly)
            {
                bmpImage = BitmapConverter.ToBitmap(binaryMask);
                cameraForm.UpdateDisplay(bmpImage);
                return;
            }
            //원본 이미지 복사본을 만들어 이진화된 부분에만 색을 덧씌우기
            Mat overlayImage;
            if (_orinalImage.Type() == MatType.CV_8UC1)
            {
                overlayImage = new Mat();
                Cv2.CvtColor(_orinalImage, overlayImage, ColorConversionCodes.GRAY2BGR); //그레이스케일 이미지를 컬러 이미지로 변환

                Mat colorOrinal = overlayImage.Clone();

                overlayImage.SetTo(new Scalar(0, 0, 255), binaryMask); //이진화된 부분에 빨간색 덧씌우기
                //원본과 합성 (투명도 적용)
                Cv2.AddWeighted(colorOrinal, 0.7, overlayImage, 0.3, 0, _previewImage);
            }
            else
            {
                overlayImage = _orinalImage.Clone();
                overlayImage.SetTo(new Scalar(0, 0, 255), binaryMask); //이진화된 부분에 빨간색 덧씌우기
                //원본과 합성 (투명도 적용)
                Cv2.AddWeighted(_orinalImage, 0.7, overlayImage, 0.3, 0, _previewImage);
            }
            bmpImage = BitmapConverter.ToBitmap(_previewImage);
            cameraForm.UpdateDisplay(bmpImage);
        }

        public void ApplyFilter(String selected_filter1, int selected_filter2,//ROI이미지데이터)
        {
            if (_orinalImage == null)
                return;
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm == null)
                return;

          //  ROI 영역이 지정되면 해당 부분만 효과 들어가도록.
            if (imageViewCCtrl.GetRoiRect() != null)
            {

                // 현재 설정된 ROI 영역 가져오기

                Rectangle roiRect = imageViewCCtrl.GetRoiRect();

                if (roiRect.IsEmpty)
                    return;
                //// ROI 영역만 추출
                ////전체 이미지에서 ROI 영역만을 roiImage에 저장

                //  Mat roiImage = new Mat(currentImage, new Rect(roiRect.X, roiRect.Y, roiRect.Width, roiRect.Height));
                // OpenCvSharp.Rect roiOpenCvRect = new OpenCvSharp.Rect(roiRect.X, roiRect.Y, roiRect.Width, roiRect.Height);
                Rect roi = new Rect(roiRect.X, roiRect.Y, roiRect.Width, roiRect.Height);
                Mat roiImage = new Mat(currentImage, roi);
                _orinalImage = roiImage;
            }

            Mat filteredImage = new Mat();
            Bitmap bmpImage;

            switch (selected_filter1)
            {
                case "연산":
                    // 연산 관련 enum 값 매핑
                    ImageOperation operation = (ImageOperation)selected_filter2;
                    string op_values = "30 30 30";  //연산값 지정
                    FilterFunction.ApplyImageOperation(operation, _orinalImage, op_values, out filteredImage);
                    break;
                case "비트연산(Bitwise)":
                    // 비트 연산 관련 enum 값 매핑
                    Bitwise bitwise = (Bitwise)selected_filter2;
                    FilterFunction.ApplyBitwiseOperation(bitwise, _orinalImage, out filteredImage);
                    break;
                case "블러링":
                    ImageFilter filter = (ImageFilter)selected_filter2;
                    FilterFunction.ApplyImageFiltering(filter, _orinalImage, out filteredImage);
                    break;
                case "Edge":
                    ImageEdge edge = (ImageEdge)selected_filter2;
                    FilterFunction.ApplyEdgeDetection(edge, _orinalImage, out filteredImage);
                    break;

                default:
                    return;
            }

            //원본이랑 합성
            _previewImage = filteredImage;
            bmpImage = BitmapConverter.ToBitmap(_previewImage);
            cameraForm.UpdateDisplay(bmpImage);


        }
    }
}
