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
        
        private bool SetAreaRange = false;
    private bool SetHeightRange = false;
    private bool SetWidthRange = false;

        private int _selected_effect = 0;
        public event EventHandler<RangeChangedEventArgs> RangeChanged;

        // 속성값을 이용하여 이진화 임계값 설정
        
        public int LowerValue => trackBarLower.Value; //trackBarLower의 Value값을 가져옴
        public int UpperValue => trackBarUpper.Value; //trackBarUpper의 Value값을 가져옴
        public BinaryInspProp()
        {
            InitializeComponent();

            txtArea_min.Visible = false;
            txtArea_max.Visible = false;

            txtWidth_min.Visible = false;
            txtWidth_max.Visible = false;

            txtHeight_min.Visible = false;
            txtHeight_max.Visible = false;
        }

        //#BIN PROP# 이진화 검사 속성값을 GUI에 설정
        public void LoadInspParam()
        {
            //TrackBar 초기설정
            trackBarLower.ValueChanged += OnValueChanged; //trackBarLower의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행
            trackBarUpper.ValueChanged += OnValueChanged; //trackBarUpper의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행

            trackBarLower.Value = 0; //trackBarLower의 Value값을 0으로 초기화
            trackBarUpper.Value =128; //trackBarUpper의 Value값을 128

            //#BINARY FILTER#8 이진화 검사 속성값을 GUI에 설정
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow != null)
            {//#INSP WORKER#13 inspWindow에서 이진화 알고리즘 찾는 코드
                BlobAlgorithm blobAlgo = (BlobAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspBinary);
                if (blobAlgo != null)
                {
                    //알고리즘에서 지정된값 가져옴
                    // FilterAreaMin, FilterAreaMax, FilterWidthMin, FilterWidthMax, FilterHeightMin, FilterHeightMax
                    int filterAreaMin = blobAlgo.FilterAreaMin;
                    int filterAreaMax = blobAlgo.FilterAreaMax;
                    int filterWidthMin = blobAlgo.FilterWidthMin;
                    int filterWidthMax = blobAlgo.FilterWidthMax;
                    int filterHeightMin = blobAlgo.FilterHeightMin;
                    int filterHeightMax = blobAlgo.FilterHeightMax;

                    // 텍스트 박스에 기존값 보여줌
                    txtArea_min.Text = filterAreaMin.ToString();
                    txtArea_max.Text = filterAreaMax.ToString();
                    txtWidth_min.Text = filterWidthMin.ToString();
                    txtWidth_max.Text = filterWidthMax.ToString();
                    txtHeight_min.Text = filterHeightMin.ToString();
                    txtHeight_max.Text = filterHeightMax.ToString();
                }
            }


            //모폴로지 필터 콤보박스 목록 추가

            FilterFunction._filterMap.TryGetValue("Mopology", out var initialFilterTypes);//"Mopology" 키가 있으면 리스트 값을 가져오고 initialFilterTypes에 저장
            foreach (var filterType in initialFilterTypes)
            {
                cbSetFilter.Items.Add(filterType);
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

            //#INSP WORKER#9 inspWindow에서 이진화 알고리즘 찾는 코드 추가
            BlobAlgorithm blobAlgo = (BlobAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspBinary);
            if (blobAlgo is null)
                return;

            BinaryThreshold threshold = new BinaryThreshold();
            threshold.upper = UpperValue;
            threshold.lower = LowerValue;
            threshold.invert = chkInvert.Checked;

            blobAlgo.BinThreshold = threshold;
            //끄면 값 기본으로 돌아가게 해야됨. 
            if (ckb_Area.Checked)
            {
                blobAlgo.SetArea = true;
                blobAlgo.FilterAreaMin = int.Parse(txtArea_min.Text);
                blobAlgo.FilterAreaMax = int.Parse(txtArea_max.Text);
            }
            else
            {   
                blobAlgo.SetArea = false;
                blobAlgo.FilterAreaMin = 1;
                blobAlgo.FilterAreaMax = 5000000;
            }

            if (ckb_Height.Checked)
            {
                blobAlgo.SetHeight = true;
                blobAlgo.FilterHeightMin = int.Parse(txtHeight_min.Text);
                blobAlgo.FilterHeightMax= int.Parse(txtHeight_max.Text);
            }
            else
            {
                blobAlgo.SetHeight = false;
                blobAlgo.FilterHeightMin = 1;
                blobAlgo.FilterHeightMax = 5000;
            }

            if (ckb_Width.Checked)
            {
                blobAlgo.SetWidth = true;
                blobAlgo.FilterWidthMin = int.Parse(txtWidth_min.Text);
                blobAlgo.FilterWidthMax = int.Parse(txtWidth_max.Text);
            }
            else
            {
                blobAlgo.SetWidth = false;
                blobAlgo.FilterWidthMin = 1;
                blobAlgo.FilterWidthMax = 5000;
            }



            //#INSP WORKER#10 이진화 검사시, 해당 InspWindow와 이진화 알고리즘만 실행
            Global.Inst.InspStage.InspWorker.TryInspect(inspWindow, InspectType.InspBinary);
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbArea_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ckb_Area_CheckedChanged(object sender, EventArgs e)
        {
            //Area 값 조절할수있도록.
          
            txtArea_min.Visible = ckb_Area.Checked;
            txtArea_max.Visible = ckb_Area.Checked;
        }

        private void ckb_Width_CheckedChanged(object sender, EventArgs e)
        {
            
            txtWidth_min.Visible = ckb_Width.Checked;
            txtWidth_max.Visible = ckb_Width.Checked;
        }

        private void ckb_Height_CheckedChanged(object sender, EventArgs e)
        {
            txtHeight_min.Visible = ckb_Height.Checked;
            txtHeight_max.Visible = ckb_Height.Checked;
        }

        private void cbSetFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected_effect = Convert.ToInt32(cbSetFilter.SelectedIndex);// 선택된 인덱스를 저장
        }

        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow is null)
                return;

            // BlobAlgorithm에서 이진화된 이미지 가져오기
            BlobAlgorithm blobAlgo = (BlobAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspBinary);
            if (blobAlgo is null)
                return;


            if (inputImage.Empty())
            {
                MessageBox.Show("이진화된 이미지가 없습니다.");
                return;
            }

            //여기서 사용하는 이미지넣고 필터 적용 한 후 내보내게 해야함.
            Mat filteredImage = FilterFunction.ApplyFilter(inputImage, "Mopology", _selected_effect);

            //여기 아님. preivew에서 뿌리기.



            // 필터링된 이미지를 BlobAlgorithm에 설정
            blobAlgo.SetImage(filteredImage);


            // 이진화 수행
            blobAlgo.DoInspect();

            // InspWindow를 새로고침하여 업데이트된 이미지 표시
            inspWindow.UpdateDisplay();
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

