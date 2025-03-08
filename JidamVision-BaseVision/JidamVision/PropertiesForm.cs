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
        InspMatch,
        InspFilter
    }
    public partial class PropertiesForm : DockContent
    {
        public PropertiesForm()
        {
            InitializeComponent();
            //속성창 설정
            SetInspType(InspPropType.InspFilter);
        }
        public void SetInspType(InspPropType inspPropType)
        {
            LoadOptionControl(inspPropType);
        }

        //옵션창에서 입력된 타입의 속성창 생성
        private void LoadOptionControl(InspPropType inspPropType)
        {
            // Panel 초기화
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
                case InspPropType.InspFilter:
                    _inspProp = new FilterInsProp();
                    ((FilterInsProp)_inspProp).FilterSelected += FilterSelect_FilterChanged;
                    break;
                default:
                    MessageBox.Show("유효하지 않은 옵션입니다.");
                    return;
            }

            // UserControl을 Panel에 추가
            if (_inspProp != null)
            {
                _inspProp.Dock = DockStyle.Fill; // 패널을 꽉 채움
                panelContainer.Controls.Add(_inspProp);
            }
        }
        private void FilterSelect_FilterChanged(object sender, FilterSelectedEventArgs e)
        {
            //선택된 필터값 inspStage의 ApplyFilter로 보냄
            string filter1 = e.FilterSelected1;
            int filter2 = e.FilterSelected2;
            Global.Inst.InspStage.PreView?.ApplyFilter(filter1, filter2);

        }
        private void RangeSlider_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            // 속성값을 이용하여 이진화 임계값 설정
            int lowerValue = e.LowerValue;
            int upperValue = e.UpperValue;
            Global.Inst.InspStage.PreView?.SetBinary(lowerValue, upperValue);
        }
    }
}
