using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using JidamVision.Core;
using JidamVision.Property;

namespace JidamVision
{
    public enum InspPropType
    {
        InspNone = 0,
        InspBinary,
        InspMatch
    }
    public partial class PropertiesForm : DockContent
    {
        public PropertiesForm()
        {
            InitializeComponent();
            SetInspType(InspPropType.InspBinary); //InspType을 설정
        }
        public void SetInspType(InspPropType inspPropType)
        {
            //Panel 초기화
            panelContainer.Controls.Clear();
            UserControl _inspProp = null;

            //옵션에 맞는 UserControl 생성
            switch (inspPropType)
            {
                case InspPropType.InspBinary:
                    _inspProp = new BinaryInspProp();
                    ((BinaryInspProp)_inspProp).RangeChanged += RangeSlider_RangeChanged;
                    break;
                case InspPropType.InspMatch:
                    _inspProp = new MatchInspProp();
                    break;
                default:
                    MessageBox.Show("유효하지 않은 옵션입니다.");
                    return;
            }

            //Panel에 UserControl 추가
            if(_inspProp != null)
            {
                _inspProp.Dock = DockStyle.Fill; //패널을 꽉 채움
                panelContainer.Controls.Add(_inspProp);
            }
        }
        private void RangeSlider_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            //RangeChanged 이벤트 발생 시 처리할 내용
            //속성값을 이용하여 이진화 임계값 설정
            int lowerValue = e.LowerValue;
            int upperValue = e.UpperValue;

            Global.Inst.InspStage.PreView?.SetBinary(lowerValue, upperValue); //InspStage의 PreView에 있는 SetBinary함수를 호출하여 lowerValue와 upperValue를 전달
        }
    }
}
