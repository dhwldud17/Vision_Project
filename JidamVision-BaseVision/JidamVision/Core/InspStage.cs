using JidamVision.Grab;
using JidamVision.Inspect;
using JidamVision.Teach;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JidamVision.Core
{
    //검사와 관련된 클래스를 관리하는 클래스
    public class InspStage
    {
        public static readonly int MAX_GRAB_BUF = 5;

        private ImageSpace _imageSpace = null;
        private GrabModel _grabManager = null;
        private CameraType _camType = CameraType.WebCam;
        private PreviewImage _previewImage = null;

      

        //#INSP WORKER#6 InspWorker 변수 추가 
        private InspWorker _inspWorker = null;

        private InspWindow _inspWindow = null;

        public ImageSpace ImageSpace
        {
            get => _imageSpace;
        }

        public PreviewImage PreView
        {
            get => _previewImage;
        }

        public InspWindow InspWindow
        {
            get => _inspWindow;
        }
        public InspWorker InspWorker
        {
            get => _inspWorker;
        }

        //#INSP WORKER#1 1개만 있던 InspWindow를 리스트로 변경하여, 여러개의 ROI를 관리하도록 개선
        public List<InspWindow> InspWindowList { get; set; } = new List<InspWindow>();

        public bool LiveMode { get; set; } = false;

        public int SelBufferIndex { get; set; } = 0;
        public eImageChannel SelImageChannel { get; set; } = eImageChannel.Gray;

        public InspStage() { }

        public bool Initialize()
        {
            _imageSpace = new ImageSpace();
            _previewImage = new PreviewImage();

            switch (_camType)
            {
                case CameraType.WebCam:
                    {
                        _grabManager = new WebCam();
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

            if (_grabManager.InitGrab() == true)
            {
                _grabManager.TransferCompleted += _multiGrab_TransferCompleted;

                InitModelGrab(MAX_GRAB_BUF);
            }

            InitInspWindow();

            return true;
        }


        public void InitModelGrab(int bufferCount)
        {
            if (_grabManager == null)
                return;

            int pixelBpp = 8;
            _grabManager.GetPixelBpp(out pixelBpp);

            int imageWidth;
            int imageHeight;
            int imageStride;
            _grabManager.GetResolution(out imageWidth, out imageHeight, out imageStride);

            if (_imageSpace != null)
            {
                _imageSpace.SetImageInfo(pixelBpp, imageWidth, imageHeight, imageStride);
            }

            SetBuffer(bufferCount);
        }
        public void SetImageBuffer(string filePath)
        {
            if (_grabManager == null)
                return;

            Mat matImage = Cv2.ImRead(filePath);

            int pixelBpp = 8;
            int imageWidth;
            int imageHeight;
            int imageStride;

            if (matImage.Type() == MatType.CV_8UC3)
                pixelBpp = 24;

            imageWidth = (matImage.Width + 3) / 4 * 4;
            imageHeight = matImage.Height;
            //imageStride = (int)matImage.Step();
            imageStride = imageWidth * matImage.ElemSize();

            if (_imageSpace != null)
            {
                _imageSpace.SetImageInfo(pixelBpp, imageWidth, imageHeight, imageStride);
            }

            SetBuffer(1);

            int bufferIndex = 0;

            // Mat의 데이터를 byte 배열로 복사
            int bufSize = (int)(matImage.Total() * matImage.ElemSize());
            Marshal.Copy(matImage.Data, ImageSpace.GetInspectionBuffer(bufferIndex), 0, bufSize);

            _imageSpace.Split(bufferIndex);

            DisplayGrabImage(bufferIndex);

            if (_previewImage != null)
            {
                Bitmap bitmap = ImageSpace.GetBitmap(0);
                _previewImage.SetImage(BitmapConverter.ToMat(bitmap));
            }
        }

        public void SetBuffer(int bufferCount)
        {
            if (_grabManager == null)
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

        // NOTE
        // async / await란?
        // async / await는 비동기 프로그래밍(Asynchronous Programming)을 쉽게 구현할 수 있도록 도와주는 키워드입니다.
        //기본 개념은 작업(Task)이 끝날 때까지 기다리지 않고 다른 작업을 진행할 수 있도록 하는 것입니다.
        //이를 통해 UI가 멈추지 않으며(프리징 방지), 응답성이 높은 프로그램을 만들 수 있습니다.
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

            if (LiveMode)
            {
                await Task.Delay(100);  // 비동기 대기
                _grabManager.Grab(bufferIndex, true);  // 다음 촬영 시작
            }
        }

        private void DisplayGrabImage(int bufferIndex)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.UpdateDisplay();
            }
        }

        public void SaveCurrentImage(string filePath)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                Mat displayImage = cameraForm.GetDisplayImage();
                Cv2.ImWrite(filePath, displayImage);
            }
        }

        public Bitmap GetBitmap(int bufferIndex = -1, eImageChannel imageChannel = eImageChannel.Gray)
        {
            if (bufferIndex >= 0)
                SelBufferIndex = bufferIndex;
            //#BINARY FILTER#13 채널 정보가 유지되도록, eImageChannel.None 타입을 추가
            if (imageChannel != eImageChannel.None)
                SelImageChannel = imageChannel;

            return Global.Inst.InspStage.ImageSpace.GetBitmap(SelBufferIndex, SelImageChannel);
        }
        public Mat GetMat(int bufferIndex = -1, eImageChannel imageChannel = eImageChannel.Gray)
        {
            if (bufferIndex >= 0)
                SelBufferIndex = bufferIndex;

            //#BINARY FILTER#14 채널 정보가 유지되도록, eImageChannel.None 타입을 추가
            if (imageChannel != eImageChannel.None)
                SelImageChannel = imageChannel;
            return Global.Inst.InspStage.ImageSpace.GetMat(SelBufferIndex, SelImageChannel);
        }

        private void InitInspWindow()
        {
            _inspWindow = new InspWindow();

            var propForm = MainForm.GetDockForm<PropertiesForm>();
            if (propForm != null)
            {//#PANEL TO TAB#4 초기화 과정에서 모든 속성 추가
                propForm.SetInspType(InspectType.InspMatch);
                propForm.SetInspType(InspectType.InspBinary);
                propForm.SetInspType(InspectType.InspFilter);
            }
        }
    }
}
