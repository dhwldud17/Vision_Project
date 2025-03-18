using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JidamVision.Setting
{
    public enum NetworkType
    {
        WCF=0,
        None
    }
    public partial class NetworkSetting : UserControl
    {
        public NetworkSetting()
        {
            InitializeComponent();

            LoadSetting();
        }

        private void LoadSetting()
        {//콤보박스 
            cbNetworkType.DataSource =Enum.GetValues(typeof(NetworkType)).Cast<NetworkType>().ToList();

            //IP 입력 받아오기
            txtIPAddress.Text = SettingXml.Inst.IPAddress;
        }
        private void SaveSetting()
        {//환경설정에 네트워크 타입 저장
            SettingXml.Inst.NetworkType =(NetworkType)cbNetworkType.SelectedItem;
            //환경설정에 IP주소 저장
            SettingXml.Inst.IPAddress = txtIPAddress.Text;
            //환경설정 저장
            SettingXml.Save();
        }
        private void cbNetworkType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }
    }
}
