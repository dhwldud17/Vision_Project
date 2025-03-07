using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace JidamVision.Core
{
    public class PreviewImage
    {
        private Mat _orinalImage = null;
        private Mat _previewImage = null;
        private Mat _tempImage = null;

        public void SetImage(Mat image)
        {
            _orinalImage = image;
            _previewImage = new Mat();
            //_previewImage = null;
            //_tempImage = new Mat(image.Size(), MatType.CV_8UC1,new Scalar(0));
        }

       public void SetBinary(int lowerValue, int upperValue)
        {
            if(_orinalImage == null)
                return;

            Mat grayImage = new Mat();
            if(_orinalImage.Type() == MatType.CV_8UC3)
            {
                Cv2.CvtColor(_orinalImage, grayImage, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                grayImage = _orinalImage;
            }
            Mat binaryMask = new Mat();

            //Cv2.Threshold(grayImage, binaryMask, lowerValue, upperValue, ThresholdTypes.Binary);
            //OpenCV에서 임계값을 기준으로 이진화하는 함수 (입력이미지,출력이미지, 임계값,임계값 초과시 적용할 최대값, 임계값 적용방식)
            //-> upperValue보다 큰픽셀만 255로 바꿔줌ㅕㄴ화. 나머지는 0 

            Cv2.InRange(grayImage, new Scalar(lowerValue), new Scalar(upperValue), binaryMask);
            //OpenCV에서 특정 범위의 픽셀 값만 추출하는 함수 (입력이미지,최소범위값, 최대범위값,출력마스크)
            //lowerBound <= 픽셀 값 <= upperBound 인 경우 255(흰색), 나머지는 0(검은색)




            //원본 이미지 복사본을 만들어 이진화된 부분에만 색을 덧씌우기
            Mat overlayImage = _orinalImage.Clone();
            overlayImage.SetTo(new Scalar(0, 0, 255), binaryMask); //빨간색으로 마스크 적용

            //원본과 합성 (투명도 적용)
            Cv2.AddWeighted(overlayImage, 0.7, _orinalImage, 0.7, 0, _previewImage);

            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if(cameraForm != null)
            {
                Bitmap bmpImage = BitmapConverter.ToBitmap(_previewImage);
                cameraForm.UpdateDisplay(bmpImage);

            }
        }
    }
}
