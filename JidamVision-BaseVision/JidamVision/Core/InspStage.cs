
using JidamVision.Grab;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JidamVision.Core
{
    //검사와 관련된 클래스를 관리하는 클래스
    public class InspStage
    {
        public static readonly int MAX_GRAB_BUF = 5;

        private ImageSpace _imageSpace = null;
        private GrabModel _grabManager = null;
        private CameraType _camType = CameraType.WebCam;  //카메라 정해줌  
        private PreviewImage _previewImage = null;

        public ImageSpace ImageSpace
        {
            get => _imageSpace;
        }
        public PreviewImage PreView
        {
            get => _previewImage;
        }
        public bool LiveMode { get; set; } = false;

        public InspStage() { }

        public bool Initialize()
        {
            _imageSpace = new ImageSpace();
            _previewImage = new PreviewImage();
            switch (_camType)
            {
                case CameraType.WebCam:
                    {
                        _grabManager = new WebCam();//카메라가 webcam이면 webcam객체 _grabManager에 할당
                        break;
                    }
                case CameraType.HikRobotCam:
                    {
                        _grabManager = new HikRobotCam();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Not supported camera type!");
                        return false;
                    }
            }

            if (_grabManager.InitGrab() == true) //
            {
                _grabManager.TransferCompleted += _multiGrab_TransferCompleted;

                InitModelGrab(MAX_GRAB_BUF);
            }

            _grabManager.SetExposureTime(-2);

            _grabManager.SetGain(1);


            return true;
        }



        private async void _multiGrab_TransferCompleted(object sender, object e)
        {

            int bufferIndex = (int)e;
            Console.WriteLine($"_multiGrab_TransferCompleted {bufferIndex}");

            _imageSpace.Split(bufferIndex);

            DisplayGrabImage(bufferIndex);

            if (_previewImage != null)
            {
                Bitmap bitmap = ImageSpace.GetBitmap(0);
                _previewImage.SetImage(BitmapConverter.ToMat(bitmap));
            }

            //if (LiveMode == true)
            //{
            //    Task.Factory.StartNew(() => //비동기로 작업시작
            //    {
            //        System.Threading.Thread.Sleep(100); 
            //        _grabManager.Grab(bufferIndex, true); //계속 grab 반복
            //    });
            //}

            if(LiveMode == true)   
            {
                await Task.Delay(1);//비동기 대기 (async 통해 앞 작업 긑나지 않아도 다음작업시작될수있도록 함)
                _grabManager.Grab(bufferIndex, true);
            }

        }

        public void InitModelGrab(int bufferCount)//
        {
            if (_grabManager == null)
                return;

            int pixelBpp = 8;
            _grabManager.GetPixelBpp(out pixelBpp); //한픽셀당 비트수

            int inspectionWidth;
            int inspectionHeight;
            int inspectionStride;
            _grabManager.GetResolution(out inspectionWidth, out inspectionHeight, out inspectionStride);

            if (_imageSpace != null)
            {
                _imageSpace.SetImageInfo(pixelBpp, inspectionWidth, inspectionHeight, inspectionStride);
            }

            SetBuffer(bufferCount);

           

        }

        public void SetBuffer(int bufferCount)
        {
            if (_grabManager == null)
                return;

            if (_imageSpace.BufferCount == bufferCount)
                return;

            _imageSpace.InitImageSpace(bufferCount);
            _grabManager.InitBuffer(bufferCount);

            for (int i = 0; i < bufferCount; i++)
            {
                _grabManager.SetBuffer(
                    _imageSpace.GetInspectionBuffer(i),
                    _imageSpace.GetnspectionBufferPtr(i),
                    _imageSpace.GetInspectionBufferHandle(i),
                    i);
            }
        }

        public void Grab(int bufferIndex)
        {
            if (_grabManager == null)
                return;

            _grabManager.Grab(bufferIndex, true);

        }


        private void DisplayGrabImage(int bufferIndex)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.UpdateDisplay();
            }
        }



    }
}
