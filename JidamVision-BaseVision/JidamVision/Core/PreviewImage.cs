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

        public void ApplyFilter(string selected_filter1, int selected_filter2)
        {
            if (_orinalImage == null)
                return;

            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm == null)
                return;

            // 원본 이미지를 다시 가져와서 작업하도록 수정
            Mat originalImage = _orinalImage.Clone();  //깊은복사. 원본이미지를 보존하기 위해
            //Clone()을 사용하지 않으면 얉은 복사가 되서 원본이 같이 변경됨. 우리는 원본이미지를 보존해야함. 
            Mat filteredImage = new Mat();

            // ROI가 설정된 경우 또는 설정되지 않은 경우
            Rect roiRect = new Rect();  // roiRect를 여기에 한 번만 선언
            Mat imageToProcess = originalImage; // 기본적으로 원본 이미지로 설정

           //ROI영역이 존재하면 
            if (cameraForm.TryGetROI(out Mat roiImage, out roiRect))
            {
                // ROI가 있을 때는 ROI만 필터 적용
                imageToProcess = roiImage;
            }
            
                // 선택된 필터에 따라 필터 적용
                switch (selected_filter1)
            {
                case "연산":
                    ImageOperation operation = (ImageOperation)selected_filter2;
                    string op_values = "30 30 30";
                    FilterFunction.ApplyImageOperation(operation, imageToProcess, op_values, out filteredImage);
                    break;
                case "비트연산(Bitwise)":
                    Bitwise bitwise = (Bitwise)selected_filter2;
                    FilterFunction.ApplyBitwiseOperation(bitwise, imageToProcess, out filteredImage);
                    break;
                case "블러링":
                    ImageFilter filter = (ImageFilter)selected_filter2;
                    FilterFunction.ApplyImageFiltering(filter, imageToProcess, out filteredImage);
                    break;
                case "Edge":
                    ImageEdge edge = (ImageEdge)selected_filter2;
                    FilterFunction.ApplyEdgeDetection(edge, imageToProcess, out filteredImage);
                    break;

                case "이진화":
                    // selected_filter2가 0이면 "미디안 블러", 1이면 "가우시안 블러"
                    if (selected_filter2 == 0)
                    {
                        FilterFunction.ApplyImageFiltering(ImageFilter.FilterMedianBlur, imageToProcess, out filteredImage);
                    }
                    else if (selected_filter2 == 1)
                    {
                        FilterFunction.ApplyImageFiltering(ImageFilter.FilterGaussianBlur, imageToProcess, out filteredImage);
                    }
                    break;
                case "매칭":
                    switch (selected_filter2)
                    {
                        case 0: // Sobel
                            FilterFunction.ApplyEdgeDetection(ImageEdge.FilterSobel, imageToProcess, out filteredImage);
                            break;
                        case 1: // Scharr
                            FilterFunction.ApplyEdgeDetection(ImageEdge.FilterScharr, imageToProcess, out filteredImage);
                            break;
                        case 2: // Laplacian
                            FilterFunction.ApplyEdgeDetection(ImageEdge.FilterLaplacian, imageToProcess, out filteredImage);
                            break;
                        case 3: // Canny
                            FilterFunction.ApplyEdgeDetection(ImageEdge.FilterCanny, imageToProcess, out filteredImage);
                            break;
                    }
                    break;

                default:
                    return;
            }

            //// ROI가 설정된 경우, 필터링된 이미지를 해당 영역에만 반영
            if (cameraForm.TryGetROI(out _, out roiRect))
            {
                filteredImage.CopyTo(originalImage[roiRect]);
            }
            else
            {
                // ROI가 없으면 필터링된 이미지를 원본 이미지 전체에 반영
                originalImage = filteredImage.Clone(); // Clone()을 사용하여 새로운 이미지로 대체
            }

            // 필터링된 이미지를 화면에 표시
            _previewImage = originalImage;
            Bitmap bmpImage = BitmapConverter.ToBitmap(_previewImage);
            cameraForm.UpdateDisplay(bmpImage);
        }




    }
}
