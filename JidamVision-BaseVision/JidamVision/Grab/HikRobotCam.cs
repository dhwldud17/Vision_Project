using MvCamCtrl.NET; //MyCamera 라이브러리
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MvCamCtrl.NET.MyCamera;

namespace JidamVision.Grab
{
    struct GrabUserBuffer
    {
        private byte[] _imageBuffer;
        private IntPtr _imageBufferPtr;
        private GCHandle _imageHandle;

        public byte[] ImageBuffer
        {
            get
            {
                return _imageBuffer;
            }
            set
            {
                _imageBuffer = value;
            }
        }
        public IntPtr ImageBufferPtr
        {
            get
            {
                return _imageBufferPtr;
            }
            set
            {
                _imageBufferPtr = value;
            }
        }
        public GCHandle ImageHandle
        {
            get
            {
                return _imageHandle;
            }
            set
            {
                _imageHandle = value;
            }
        }
    }
    internal class HikRobotCam
    {
        private MyCamera _camera = null;

        public delegate void GrabEventHandler<T>(object sender, T obj = null) where T : class; 
        //delegate: 외부에서 만든 함수 불러와서 사용 / 메서드의 참조를 저장하는 타입(특정한 형태의 메서드 가리키는 변수처럼 사용)
        public event GrabEventHandler<object> GrabCompleted;
        public event GrabEventHandler<object> TransferCompleted;

        int nRet = MyCamera.MV_OK;
        IntPtr pBufForConvert = IntPtr.Zero;
        public static MyCamera.cbOutputExdelegate ImageCallback;

        protected GrabUserBuffer[] _userImageBuffer = null;
        public int BufferIndex { get; set; } = 0; //변수가 아니라 프로포티(?)이기때문에 대문자로시작

        // 이미지 캡처 시 자동 호출되는 콜백 함수
        private void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            OnGrabCompleted(BufferIndex);
            if (_userImageBuffer[BufferIndex].ImageBuffer != null)
            {
                if (pFrameInfo.enPixelType == MvGvspPixelType.PixelType_Gvsp_Mono8)
                {
                    if (_userImageBuffer[BufferIndex].ImageBuffer != null)
                        Marshal.Copy(pData, _userImageBuffer[BufferIndex].ImageBuffer, 0, (int)pFrameInfo.nFrameLen);
                }
                else
                {
                    MV_PIXEL_CONVERT_PARAM _pixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                    _pixelConvertParam.nWidth = pFrameInfo.nWidth;
                    _pixelConvertParam.nHeight = pFrameInfo.nHeight;
                    _pixelConvertParam.pSrcData = pData;
                    _pixelConvertParam.nSrcDataLen = pFrameInfo.nFrameLen;
                    _pixelConvertParam.enSrcPixelType = pFrameInfo.enPixelType;
                    _pixelConvertParam.enDstPixelType = MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                    _pixelConvertParam.pDstBuffer = _userImageBuffer[BufferIndex].ImageBufferPtr;
                    _pixelConvertParam.nDstBufferSize = pFrameInfo.nFrameLen * 3;

                    int nRet = _camera.MV_CC_ConvertPixelType_NET(ref _pixelConvertParam);
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("Convert pixel type Failed:{0:x8}", nRet);
                        return;
                    }
                }
            }

            OnTransferCompleted(BufferIndex);
        }

        internal bool Create() //성공하면(끝까지 갔을 때) true, 실패시 false
        {

            MyCamera _camera = new MyCamera();

            // ch:枚举设备 | en:Enum deivce
            MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Enum device failed:{0:x8}", nRet);
                return false; //break대신
            }
            Console.WriteLine("Enum device count :{0} \n", stDevList.nDeviceNum);
            if (0 == stDevList.nDeviceNum)
            {
                return false;
            }

            MyCamera.MV_CC_DEVICE_INFO stDevInfo;

            // ch:打印设备信息 | en:Print device info
            for (Int32 i = 0; i < stDevList.nDeviceNum; i++)
            {
                stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
                {
                    MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                    uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
                    uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
                    uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
                    uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);
                    Console.WriteLine("[device " + i.ToString() + "]:");
                    Console.WriteLine("DevIP:" + nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4);
                    Console.WriteLine("UserDefineName:" + stGigEDeviceInfo.chUserDefinedName + "\n");
                }
                else if (MyCamera.MV_USB_DEVICE == stDevInfo.nTLayerType)
                {
                    MyCamera.MV_USB3_DEVICE_INFO stUsb3DeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                    Console.WriteLine("[device " + i.ToString() + "]:");
                    Console.WriteLine("SerialNumber:" + stUsb3DeviceInfo.chSerialNumber);
                    Console.WriteLine("UserDefineName:" + stUsb3DeviceInfo.chUserDefinedName + "\n");
                }
            }

            Int32 nDevIndex = 0;
            Console.Write("Please input index(0-{0:d}):", stDevList.nDeviceNum - 1);
            try
            {
                nDevIndex = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Write("Invalid Input!\n");
                return false;
            }

            if (nDevIndex > stDevList.nDeviceNum - 1 || nDevIndex < 0)
            {
                Console.Write("Input Error!\n");
                return false;
            }
            stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[nDevIndex], typeof(MyCamera.MV_CC_DEVICE_INFO));

            // ch:创建设备 | en: Create device
            nRet = _camera.MV_CC_CreateDevice_NET(ref stDevInfo);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Create device failed:{0:x8}", nRet);
                return false;
            }
            return true;
        }

        internal bool Open()
        {
            int nRet = MyCamera.MV_OK;



            // ch:打开设备 | en:Open device
            nRet = _camera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Open device failed:{0:x8}", nRet);
                return false;
            }

            // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
            //GiGe Camera만 사용할거라 Gige camera if문 삭제함
            int nPacketSize = _camera.MV_CC_GetOptimalPacketSize_NET();
            if (nPacketSize > 0)
            {
                nRet = _camera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                if (nRet != MyCamera.MV_OK)
                {
                    Console.WriteLine("Warning: Set Packet Size failed {0:x8}", nRet);
                }
            }
            else
            {
                Console.WriteLine("Warning: Get Packet Size failed {0:x8}", nPacketSize);
            }


            // ch:设置触发模式为on || en:set trigger mode as on //동영상말고 grab할거라 트리거모드 ON 으로해놈
            nRet = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON); //1대신에 직관적으로 
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Set TriggerMode failed:{0:x8}", nRet);
                return false;
            }


            // 9. 이미지 캡처 시 호출할 콜백 함수 등록  //Grab_callback.s에서 가져옴
            ImageCallback = new MyCamera.cbOutputExdelegate(ImageCallbackFunc);
            nRet = _camera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Register image callback failed!");
                return false;
            }

            // ch:开启抓图 || en: start grab image
            nRet = _camera.MV_CC_StartGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Start grabbing failed:{0:x8}", nRet);
                return false;
            }
            return true;
        }
        internal bool Grab()
        {

            // ch:触发命令 | en:Trigger command  //찍기
            int nRet = _camera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Trigger Software Fail!", nRet);
            }
            return true;
        }
        internal bool Close()
        { // ch:停止抓图 | en:Stop grabbing
            nRet = _camera.MV_CC_StopGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Stop grabbing failed:{0:x8}", nRet);
                return false;
            }

            // ch:关闭设备 | en:Close device
            nRet = _camera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Close device failed:{0:x8}", nRet);
                return false;
            }

            // ch:销毁设备 | en:Destroy device
            nRet = _camera.MV_CC_DestroyDevice_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Destroy device failed:{0:x8}", nRet);
                return false;
            }
            return true;
        }
        internal bool GetResolution(out int width, out int height, out int stride)
        {
            width = 0;
            height = 0;
            stride = 0;

            if (_camera == null)
                return false;

            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
            int nRet = _camera.MV_CC_GetIntValue_NET("Width", ref stParam);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get Width failed: nRet {0:x8}", nRet);
                return false;
            }
            width = (ushort)stParam.nCurValue;

            nRet = _camera.MV_CC_GetIntValue_NET("Height", ref stParam);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get Height failed: nRet {0:x8}", nRet);
                return false;
            }
            height = (ushort)stParam.nCurValue;

            MyCamera.MVCC_ENUMVALUE stEnumValue = new MyCamera.MVCC_ENUMVALUE();
            nRet = _camera.MV_CC_GetEnumValue_NET("PixelFormat", ref stEnumValue);
            if (MyCamera.MV_OK != nRet)
            {
                Console.WriteLine("Get PixelFormat failed: nRet {0:x8}", nRet);
                return false;
            }

            if ((MvGvspPixelType)stEnumValue.nCurValue == MvGvspPixelType.PixelType_Gvsp_Mono8)
                stride = width * 1;
            else
                stride = width * 3;

            return true;
        }
        internal bool InitBuffer(int bufferCount = 1)
        {
            if (bufferCount < 1)
                return false;

            _userImageBuffer = new GrabUserBuffer[bufferCount];
            return true;
        }

        internal bool SetBuffer(byte[] buffer, IntPtr bufferPtr, GCHandle bufferHandle, int bufferIndex = 0)
        {
            _userImageBuffer[bufferIndex].ImageBuffer = buffer;
            _userImageBuffer[bufferIndex].ImageBufferPtr = bufferPtr;
            _userImageBuffer[bufferIndex].ImageHandle = bufferHandle;

            return true;
        }
        protected void OnGrabCompleted(object obj = null)
        {
            GrabCompleted?.Invoke(this, obj);
        }
        protected void OnTransferCompleted(object obj = null) //전송 처리가됬다
        {
            TransferCompleted?.Invoke(this, obj);
        }
    }
}
