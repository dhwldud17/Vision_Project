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
            if (_orinalImage == null)
                return;

            Mat grayImage = new Mat();
            if (_orinalImage.Type() == MatType.CV_8UC3)
                Cv2.CvtColor(_orinalImage, grayImage, ColorConversionCodes.BGR2GRAY);
            else
                grayImage = _orinalImage;

            Mat binaryMask = new Mat();
            //Cv2.Threshold(grayImage, binaryMask, lowerValue, upperValue, ThresholdTypes.Binary);
            Cv2.InRange(grayImage, lowerValue, upperValue, binaryMask);

            // 원본 이미지 복사본을 만들어 이진화된 부분에만 색을 덧씌우기
            Mat overlayImage = _orinalImage.Clone();
            overlayImage.SetTo(new Scalar(0, 0, 255), binaryMask); // 빨간색으로 마스킹

            // 원본과 합성 (투명도 적용)
            Cv2.AddWeighted(_orinalImage, 0.7, overlayImage, 0.3, 0, _previewImage);

            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                Bitmap bmpImage = BitmapConverter.ToBitmap(_previewImage);
                cameraForm.UpdateDisplay(bmpImage);
            }

        }
    }
}
