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
        {
            cbNetworkType.DataSource =Enum.GetValues(typeof(NetworkType)).Cast<NetworkType>().ToList();
        }

        private void cbNetworkType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
