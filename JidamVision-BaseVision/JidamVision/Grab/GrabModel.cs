using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MvCamCtrl.NET.MyCamera;

namespace JidamVision.Grab
{
    public enum CameraType
    {
        None = 0,
        WebCam,
        HikRobotCam
    }

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
    
    internal abstract class GrabModel
    {
        public delegate void GrabEventHandler<T>(object sender, T obj = null) where T : class;

        public event GrabEventHandler<object> GrabCompleted;
        public event GrabEventHandler<object> TransferCompleted;

        protected GrabUserBuffer[] _userImageBuffer = null;
        public int BufferIndex { get; set; } = 0;

        internal bool HardwareTrigger { get; set; } = false;
        internal bool IncreaseBufferIndex { get; set; } = false;

        internal abstract bool Create(string strIpAddr = null);

        internal abstract bool Grab(int bufferIndex, bool waitDone = true);

        internal abstract bool Close();

        internal abstract bool Open();

        internal virtual bool Reconnect() { return true; }

        internal abstract bool GetPixelBpp(out int pixelBpp);

        internal abstract bool SetExposureTime(long exposure);

        internal abstract bool GetExposureTime(out long exposure);

        internal abstract bool SetGain(long gain);

        internal abstract bool GetGain(out long gain);

        internal abstract bool GetResolution(out int width, out int height, out int stride);

        internal virtual bool SetTriggerMode(bool hardwareTrigger) { return true; }

        internal abstract bool InitGrab();
        internal abstract bool InitBuffer(int bufferCount = 1);
        internal abstract bool SetBuffer(byte[] buffer, IntPtr bufferPtr, GCHandle bufferHandle, int bufferIndex = 0);

        protected virtual void OnGrabCompleted(object obj = null)
        {
            GrabCompleted?.Invoke(this, obj);
        }
        protected virtual void OnTransferCompleted(object obj = null)
        {
            TransferCompleted?.Invoke(this, obj);
        }

        internal abstract void Dispose();
    }
}
