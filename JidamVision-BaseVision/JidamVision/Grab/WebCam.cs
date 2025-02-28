using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MvCamCtrl.NET;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using static MvCamCtrl.NET.MyCamera;

namespace JidamVision.Grab
{
    internal class WebCam : GrabModel
    //카메라가 webcam일때 -> 노트북 카메라
    {
        private VideoCapture _capture = null;
        private Mat _frame = null;  //이미지클래스

        #region Private Field
        //책갈피처럼 접었다가 필수 잇음
        private bool _disposed = false;
        #endregion


        #region Method
        internal override bool Create(string strIpAddr = null)
        {
            _capture = new VideoCapture(0); //0번 기본카메라
            if (_capture == null)
                return false;
            return true;
        }

        internal override bool Grab(int bufferIndex, bool waitDone)
        {
            if (_frame is null)
                _frame = new Mat();

            _capture.Read(_frame);
            if (!_frame.Empty())
            {
                OnGrabCompleted(BufferIndex);

                int bufSize = (int)(_frame.Total() * _frame.ElemSize());

                if (_userImageBuffer != null && _userImageBuffer.Length > BufferIndex)
                {
                    if (_userImageBuffer[BufferIndex].ImageBuffer.Length >= bufSize)
                    {
                        Marshal.Copy(_frame.Data, _userImageBuffer[BufferIndex].ImageBuffer, 0, bufSize); // Mat의 데이터를 byte 배열로 복사
                    }
                    else
                    {
                        Console.WriteLine("Error: Buffer size is too small.");
                    }
                }

                OnTransferCompleted(BufferIndex);

                if (IncreaseBufferIndex)
                {
                    BufferIndex++;
                    if (BufferIndex >= _userImageBuffer.Count())
                        BufferIndex = 0;
                }
            }
            return true;
        }
        internal override bool Close()
        {
            if (_capture != null) //카메라가 생성되어 있을 경우
                _capture.Release(); //카메라 해제
            return true;
        }


        internal override bool Open()
        {
            if (_capture == null)
                return false;

            //if (!_capture.Open(0))
            //{
            //    Console.WriteLine("Failed open the webcam!");
            //    return false;
            //}

            // BGR 포맷을 강제 설정 (산업용 카메라나 특정 드라이버에 따라 가능)

            // BGR24 포맷 (컬러)
            int fourccBGR3 = VideoWriter.FourCC('B', 'R', '3', '0');//BGR24
            _capture.Set(VideoCaptureProperties.CodecPixelFormat, fourccBGR3);//포맷 설정

            return true;
        }

        internal override bool Reconnect()
        {
            Close();
            return Open();
        }

        internal override bool GetPixelBpp(out int pixelBpp) //Bpp: 한 픽셀당 비트수
        {
            pixelBpp = 8; //8비트로 초기화
            //모노 이미지 : 1바이트(8비트) -> 한픽셀당 256개 생삭 가능. 0~255 2^8승 
            //컬러 이미지 : 3바이트(24비트 / 8비트 X 3채널)
            //RGBA 이미지 : 4바이트(32비트 / 8비트 X 4채널)

            if (_capture == null)
                return false;

            if (_frame is null)
            {
                _frame = new Mat();
                _capture.Read(_frame); // 프레임 캡처
            }

            pixelBpp = _frame.ElemSize() * 8;
            //_frame.ElemSize(): 픽셀 하나가 차지하는 바이트 크기 반환
            //우리가 알고싶은건 비트수. 1바이트가 8비트니까 elemsize에 8을 곱해줌

            return true;
        }


        internal override bool SetTriggerMode(bool hardwareTrigger)
        {
            if (_capture is null)
                return false;

            HardwareTrigger = hardwareTrigger;

            return true;
        }

        internal override bool SetExposureTime(long exposureTime)//사용자가 지정한 Exposure 값을 카메라에 설정
        {
            if (_capture == null)
                return false;
            _capture.Set(VideoCaptureProperties.Exposure, exposureTime); //해당 메서드를 사용하여 카메라의 Exposure 값을 설정
            return true;
        }

        internal override bool SetGain(long gain)//사용자가 지정한 Gain 값을 카메라에 설정
        {
            if (_capture == null)
                return false;
            _capture.Set(VideoCaptureProperties.Gain, gain); //해당 메서드를 사용하여 카메라의 Gain 값을 설정
            return true;
        }
        internal override bool GetExposureTime(out long exposureTime)//카메라에 현재 설정된 Exposure 값을 가져와서 문자열로 반환
        { //파라미터 out: out 키워드를 사용하면 메서드가 여러 개의 값을 반환
            exposureTime = 0;
            if (_capture == null)
                return false;
            exposureTime = (long)_capture.Get(VideoCaptureProperties.Exposure); //해당 메서드를 사용하여 카메라의 Exposure 값을 가져옴

            return true;
        }
        internal override bool GetGain(out long gain)  //카메라에 현재 설정된 Gain 값을 가져와서 문자열로 반환
        {

            gain = 0;
            if (_capture == null)
                return false;

            gain = (long)_capture.Get(VideoCaptureProperties.Gain); //해당 메서드를 사용하여 카메라의 Gain 값을 가져옴
            return true;
        }

        internal override bool GetResolution(out int width, out int height, out int stride)
        {
            width = 0;
            height = 0;
            stride = 0;

            if (_capture == null)
                return false;

            width = (int)_capture.Get(VideoCaptureProperties.FrameWidth); //해당 메서드를 사용하여 카메라의 가로 해상도를 가져옴
            height = (int)_capture.Get(VideoCaptureProperties.FrameHeight); //해당 메서드를 사용하여 카메라의 세로 해상도를 가져옴

            int bpp = 8;
            GetPixelBpp(out bpp); //해당 메서드를 사용하여 카메라의 한 픽셀당 비트수를 가져옴

            if (bpp == 8)
                stride = width * 1; //모노 이미지의 경우
            else //bpp 8이 아닌경우 컬러니까
                stride = width * 3; //컬러 이미지의 경우

            return true;
        }
        #endregion

        #region Dispose
        internal override void Dispose()
        {
            Dispose(disposing: true);
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_capture != null)
                    _capture.Release();
            }
            _disposed = true;
        }

        ~WebCam()
        {
            Dispose(disposing: false);
        }
        #endregion

    }
}
