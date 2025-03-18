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

        private String _selected_color;
        public FmInspProp()
        {
            InitializeComponent();
           
        }
        public void LoadInspParam()
        { cb_Color.DataSource = Enum.GetValues(typeof(ColorType)).Cast<ColorType>().ToList();
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow is null)
                return;
            //FmInspAlgo에서 찾는 코드
            FmInspAlgorithm FMAlgo = (FmInspAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspFm);
            if (FMAlgo is null)
                return;
            OpenCvSharp.Size extendSize = FMAlgo.ExtSize;
            int SizeX = FMAlgo.SizeX;
            int SizeY = FMAlgo.SizeY;

            int GV_Value = FMAlgo.GV;
            txtDifferenceGV.Text = Convert.ToString(GV_Value);


            txt_SizeX.Text = SizeX.ToString();
            txt_SizeY.Text = SizeY.ToString();
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtDifferenceGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow is null)
                return;
            //FmInspAlgo에서 찾는 코드
            FmInspAlgorithm FMAlgo = (FmInspAlgorithm)inspWindow.FindInspAlgorithm(InspectType.InspFm);
            if (FMAlgo is null)
                return;


            OpenCvSharp.Size extendSize = new OpenCvSharp.Size();
            int GV_Value = FMAlgo.GV;
            GV_Value = int.Parse(txtDifferenceGV.Text);
            extendSize.Width = int.Parse(txt_SizeX.Text);
            extendSize.Height = int.Parse(txt_SizeY.Text);
        }

        private void txt_SizeX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
