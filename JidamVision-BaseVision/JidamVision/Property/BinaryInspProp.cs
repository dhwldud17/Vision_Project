using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JidamVision.Property
{
    public partial class BinaryInspProp : UserControl
    {
        public event EventHandler<RangeChangedEventArgs> RangeChanged;

        // 속성값을 이용하여 이진화 임계값 설정

        public int LowerValue => trackBarLower.Value; //trackBarLower의 Value값을 가져옴
        public int UpperValue => trackBarUpper.Value; //trackBarUpper의 Value값을 가져옴
        public BinaryInspProp()
        {
            InitializeComponent();

            //TrackBar 초기설정

            trackBarLower.ValueChanged += OnValueChanged; //trackBarLower의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행
            trackBarUpper.ValueChanged += OnValueChanged; //trackBarUpper의 ValueChanged 이벤트가 발생하면 OnValueChanged 함수 실행

            trackBarLower.Value = 0; //trackBarLower의 Value값을 0으로 초기화
            trackBarUpper.Value = 255; //trackBarUpper의 Value값을 255로 초기화
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            RangeChanged?.Invoke(this, new RangeChangedEventArgs(trackBarLower.Value, trackBarUpper.Value)); //null값이 아니면 RangeChanged 이벤트 발생
        }

        private void trackBarLower_Scroll(object sender, EventArgs e)
        {

        }

        private void BinaryInspProp_Load(object sender, EventArgs e)
        {

        }
    }

    public class RangeChangedEventArgs : EventArgs //RangeChanged 이벤트를 위한 클래스
    {
        public int LowerValue { get; }
        public int UpperValue { get; }

        public RangeChangedEventArgs(int lowerValue, int upperValue)
        {
            LowerValue = lowerValue;
            UpperValue = upperValue;
        }
    }
}
