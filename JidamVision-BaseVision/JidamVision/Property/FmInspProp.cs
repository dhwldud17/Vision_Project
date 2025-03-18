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
using JidamVision.Setting;
using JidamVision.Teach;

namespace JidamVision.Property
{
    public enum ColorType
    {
        White =0,
        Black,
        All
    }
    public partial class FmInspProp : UserControl
    {
        private int GV =50;
        private String _selected_color;
        public FmInspProp()
        {
            InitializeComponent();
            LoadSetting();
        }
        public void LoadInspParam()
        {
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow is null)
                return;
            //FmInspAlgo에서 찾는 코드
            FmInspAlgorithm FMAlgo = (FmInspAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspFm);
            if (FMAlgo is null)
                return;
            OpenCvSharp.Size extendSize = FMAlgo.ExtSize;
            
            txtDifferenceGV.Text = Convert.ToString(GV);
            txt_SizeX.Text = extendSize.Width.ToString();
            txt_SizeY.Text = extendSize.Height.ToString();
        }
        private void LoadSetting()
        {
            cb_Color.DataSource = Enum.GetValues(typeof(ColorType)).Cast<ColorType>().ToList();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtDifferenceGV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
