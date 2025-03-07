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
using OpenCvSharp.Extensions;

namespace JidamVision
{
    public partial class CameraForm : DockContent
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        public void UpdateDisplay(Bitmap bitmap = null)
        {
            if (bitmap == null)
            {
                if (rbtRed.Checked)
                    bitmap = Global.Inst.InspStage.ImageSpace.GetBitmap(0, eImageChannel.Red);
                else if (rbtGreen.Checked)
                    bitmap = Global.Inst.InspStage.ImageSpace.GetBitmap(0, eImageChannel.Green);
                else if (rbtBlue.Checked)
                    bitmap = Global.Inst.InspStage.ImageSpace.GetBitmap(0, eImageChannel.Blue);
                else if (rbtGray.Checked)
                    bitmap = Global.Inst.InspStage.ImageSpace.GetBitmap(0, eImageChannel.Gray);
                else
                    bitmap = Global.Inst.InspStage.ImageSpace.GetBitmap(0);

                if (bitmap == null)
                    return;
            }

            imageViewer.LoadBitmap(bitmap);
        }

        private void CameraForm_Resize(object sender, EventArgs e)
        {
            int margin = 10;
            int xPos = Location.X + this.Width - btnGrab.Width - margin;

            btnGrab.Location = new Point(xPos, btnGrab.Location.Y);
            btnLive.Location = new Point(xPos, btnLive.Location.Y);
            grbChannel.Location = new Point(xPos, btnLive.Location.Y + btnLive.Height * 2);
            btnSetRoi.Location = new Point(xPos, btnSetRoi.Location.Y);

            imageViewer.Width = this.Width - btnGrab.Width - margin * 2;
            imageViewer.Height = this.Height - margin * 2;

            imageViewer.Location = new Point(margin, margin);

        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            Global.Inst.InspStage.Grab(0);
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            Global.Inst.InspStage.LiveMode = !Global.Inst.InspStage.LiveMode; //LiveMode가 true면 false로, false면 true로 바꿔줌 -> Toggle모드.On/Off
            //Global.Inst.InspStage는 애플리케이션 내에서 유일한 InspStage 인스턴스를 의미하며, 이를 통해 카메라나 이미지 캡처, 검사 기능 등을 관리하는 객체에 접근
            if (Global.Inst.InspStage.LiveMode) //LiveMode가 true면
                Global.Inst.InspStage.Grab(0); //Grab함수 실행 
        }

        
        private void btnSetRoi_Click(object sender, EventArgs e)
        {
            //ROI 토글 설정
            imageViewer.RoiMode = !imageViewer.RoiMode;
            imageViewer.Invalidate(); //유효하지 않은 영역을 다시 그림
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

        }
    }
}
