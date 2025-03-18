using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JidamVision.Grab;

namespace JidamVision.Setting
{//#SETUP#3 환경설정창에 추가할 카메라설정 UserContorl 추가
    //카메라 타입 설정
    public partial class CameraSetting : UserControl
    {
        public CameraSetting()
        {
            InitializeComponent();
            //최초 로딩시, 환경설정 정보 로딩
            LoadSetting();
        }
        private void LoadSetting()
        {
            //카메라 타입을 콤보박스에 추가
            cbCameraType.DataSource = Enum.GetValues(typeof(CameraType)).Cast<CameraType>().ToList();
            //환경설정에서 현재 카메라 타입 얻기
            cbCameraType.SelectedIndex = (int)SettingXml.Inst.CamType;
        }

        private void SaveSetting()
        {
            //환경설정에 카메라 타입 저장
            SettingXml.Inst.CamType = (CameraType)cbCameraType.SelectedIndex;
            //환경설정 저장
            SettingXml.Save();
        }



        //작용버튼 선택 시 저장하기
        private void btnApply_Click_1(object sender, EventArgs e)
        {
            SaveSetting();
        }
    }
}
