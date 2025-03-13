using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JidamVision.Algorithm;
using JidamVision.Core;
using JidamVision.Teach;
using OpenCvSharp;

namespace JidamVision.Property
{ /*
    /*
    #BINARY FILTER# - <<<이진화 검사 개발>>> 
    입력된 lower, upper 임계값을 이용해, 영상을 이진화한 후, Filter(area)등을 이용해, 원하는 영역을 찾는다.
     */


    //#BINARY FILTER#7 이진화 하이라이트, 이외에, 이진화 이미지를 보기 위한 옵션
    public enum ShowBinaryMode
    {
        ShowBinaryNone = 0,             //이진화 하이라이트 끄기
        ShowBinaryHighlight,            //이진화 하이라이트 보기
        ShowBinaryOnly                  //배경 없이 이진화 이미지만 보기
    }


    public partial class BinaryInspProp : UserControl
    {
        public event EventHandler<RangeChangedEventArgs> RangeChanged;

        // 속성값을 이용하여 이진화 임계값 설정

        public int LowerValue => trackBarLower.Value; //trackBarLower의 Value값을 가져옴
        public int UpperValue => trackBarUpper.Value; //trackBarUpper의 Value값을 가져옴
        public BinaryInspProp()
        {
            InitializeComponent();

            ////TrackBar 초기설정

            //trackBarLower.ValueChanged += OnValueChanged; //trackBarLower의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행
            //trackBarUpper.ValueChanged += OnValueChanged; //trackBarUpper의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행

            //trackBarLower.Value = 0; //trackBarLower의 Value값을 0으로 초기화
            //trackBarUpper.Value = 255; //trackBarUpper의 Value값을 255로 초기화
        }

        //#BIN PROP# 이진화 검사 속성값을 GUI에 설정
        public void LoadInspParam()
        {
            //TrackBar 초기설정
            trackBarLower.ValueChanged += OnValueChanged; //trackBarLower의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행
            trackBarUpper.ValueChanged += OnValueChanged; //trackBarUpper의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행

            trackBarLower.Value = 0; //trackBarLower의 Value값을 0으로 초기화
            trackBarUpper.Value = 128; //trackBarUpper의 Value값을 128

            //#BINARY FILTER#8 이진화 검사 속성값을 GUI에 설정
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow != null)
            {
                BlobAlgorithm blobAlgo = inspWindow.BlobAlgorithm;
                if (blobAlgo != null)
                {
                    int filterArea = blobAlgo.AreaFilter;
                    txtArea.Text = filterArea.ToString();
                }
            }
        }

        //#BINARY FILTER#10 이진화 옵션을 선택할때마다, 이진화 이미지가 갱신되도록 하는 함수
        private void UpdateBinary()
        {
            bool invert = chkInvert.Checked;
            bool highlight = chkHighlight.Checked;

            ShowBinaryMode showBinaryMode = ShowBinaryMode.ShowBinaryNone;
            if (highlight)
            {
                showBinaryMode = ShowBinaryMode.ShowBinaryHighlight;

                bool showBinary = chkShowBinary.Checked;

                if (showBinary)
                    showBinaryMode = ShowBinaryMode.ShowBinaryOnly;
            }

            RangeChanged?.Invoke(this, new RangeChangedEventArgs(LowerValue, UpperValue, invert, showBinaryMode));
        }

        //#BINARY FILTER#11 GUI 이벤트와 UpdateBinary함수 연동
        private void OnValueChanged(object sender, EventArgs e)
        {
            //RangeChanged?.Invoke(this, new RangeChangedEventArgs(trackBarLower.Value, trackBarUpper.Value)); //null값이 아니면 RangeChanged 이벤트 발생
            UpdateBinary();
        }

        private void trackBarLower_Scroll(object sender, EventArgs e)
        {

        }
        private void chkBinaryOnly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBinary();
        }
        private void chkInvert_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBinary();
        }
        private void chkHighlight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBinary();
        }

        private void BinaryInspProp_Load(object sender, EventArgs e)
        {

        }

        private void grpBinary_Enter(object sender, EventArgs e)
        {

        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow is null)
                return;

            BlobAlgorithm blobAlgo = inspWindow.BlobAlgorithm;
            if (blobAlgo is null)
                return;

            BinaryThreshold threshold = new BinaryThreshold();
            threshold.upper = UpperValue;
            threshold.lower = LowerValue;
            threshold.invert = chkInvert.Checked;

            blobAlgo.BinThreshold = threshold;

            int filterArea = int.Parse(txtArea.Text);
            blobAlgo.AreaFilter = filterArea;

            Mat srcImage = Global.Inst.InspStage.GetMat();

            if (blobAlgo.DoInspect(srcImage))
            {
                List<Rect> rects;
                int findCount = blobAlgo.GetResultRect(out rects);
                if (findCount > 0)
                {
                    //찾은 위치를 이미지상에서 표시
                    var cameraForm = MainForm.GetDockForm<CameraForm>();
                    if (cameraForm != null)
                    {
                        cameraForm.AddRect(rects);
                    }
                }
            }
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbArea_Click(object sender, EventArgs e)
        {

        }
    }
    //#BINARY FILTER#9 이진화 관련 이벤트 발생시, 전달할 값 추가
    public class RangeChangedEventArgs : EventArgs //RangeChanged 이벤트를 위한 클래스
        {
            public int LowerValue { get; }
            public int UpperValue { get; }
            public bool Invert { get; }
            public ShowBinaryMode ShowBinMode { get; }

            public RangeChangedEventArgs(int lowerValue, int upperValue, bool invert, ShowBinaryMode showBinaryMode)
            {

                LowerValue = lowerValue;
                UpperValue = upperValue;
                Invert = invert;
                ShowBinMode = showBinaryMode;
            }
        }
    }

