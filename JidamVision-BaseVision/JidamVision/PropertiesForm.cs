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
using static JidamVision.Property.BinaryInspProp;

namespace JidamVision
{
    public enum InspectType
    {
        InspNone = -1,
        InspBinary,
        InspMatch,
        InspFilter,
        InspCount //속성창 개수알수있게 추가. 

    }
    public partial class PropertiesForm : DockContent
    {
        public PropertiesForm()
        {
            InitializeComponent();
            //속성창 설정 - 여기말고 InspStage.cs에서 변경해야됨
            // SetInspType(InspectType.InspFilter);
        }
        public void SetInspType(InspectType inspPropType)
        {
            LoadOptionControl(inspPropType);
        }

        //옵션창에서 입력된 타입의 속성창 생성


        private void LoadOptionControl(InspectType inspType)
        {
            string tabName = inspType.ToString();
            //이미 있는 TabPage인지 확인
            foreach (TabPage tabPage in tabPropControl.TabPages)
            {
                if (tabPage.Text == tabName)
                {
                    tabPropControl.SelectedTab = tabPage;
                    return;
                }
            }
            //새로운 UserControl 생성
            UserControl _insProp = CreateUserControl(inspType);
            if (_insProp == null)
                return;
            //Tab 생성
            TabPage newTab = new TabPage(tabName);
            {
                Dock = DockStyle.Fill;
            };
            _insProp.Dock = DockStyle.Fill;
            newTab.Controls.Add(_insProp);
            tabPropControl.TabPages.Add(newTab);
            tabPropControl.SelectedTab = newTab;//새 탭 선택 
        }


        //속성탭 타입에 맞게 UseControl 생성하여 반환
        private UserControl CreateUserControl(InspectType inspPropType)
        {
            UserControl _inspProp = null;
            switch (inspPropType)
            {
                case InspectType.InspBinary:
                    BinaryInspProp blobProp = new BinaryInspProp();
                    blobProp.LoadInspParam();
                    blobProp.RangeChanged += RangeSlider_RangeChanged;
                    _inspProp = blobProp;
                    break;
                case InspectType.InspMatch:
                    MatchInspProp matchProp = new MatchInspProp();
                //    matchProp.LoadInspParam();
                    _inspProp = matchProp;
                    break;
                case InspectType.InspFilter:
                    FilterInsProp filterProp = new FilterInsProp();
                    //filterProp.LoadInspParam();
                    filterProp.FilterSelected += FilterSelect_FilterChanged;
                    _inspProp = filterProp;
                    break;
                default:
                    MessageBox.Show("유효하지 않은 옵션입니다.");
                    break;
            }
            return _inspProp;
        }
        private void FilterSelect_FilterChanged(object sender, FilterSelectedEventArgs e)
        {
            //선택된 필터값 PrieviewImage의 ApplyFilter로 보냄
            string filter1 = e.FilterSelected1;
            int filter2 = e.FilterSelected2;

            Global.Inst.InspStage.PreView?.ApplyFilter(filter1, filter2);

        }
        //#BINARY FILTER#16 이진화 속성 변경시 발생하는 이벤트 수정
        private void RangeSlider_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            // 속성값을 이용하여 이진화 임계값 설정
            int lowerValue = e.LowerValue;
            int upperValue = e.UpperValue;
            bool invert = e.Invert;
            ShowBinaryMode showBinMode = e.ShowBinMode;
            Global.Inst.InspStage.PreView?.SetBinary(lowerValue, upperValue, invert, showBinMode);
        }
    }
}
