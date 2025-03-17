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
using System.Web;
using JidamVision.Teach;
using System.IO;
using OpenCvSharp;

namespace JidamVision
{
    public partial class CameraForm : DockContent
    {//# SAVE ROI#1 현재 선택된 이미지 채널 저장을 위한 변수
        eImageChannel _currentImageChannel = eImageChannel.Color;
        public CameraForm()
        {
            InitializeComponent();
            imageViewer.ModifyROI += ImageViewer_ModifyROI;
            rbtnColor.Checked = true;
           
        }
        // GUI상에서 선택된 채널 라디오 버튼에 따른 채널 정보를 반환

        private void ImageViewer_ModifyROI(object sender, DiagramEntityEventArgs e)
        {
            switch (e.ActionType)
            {
                case EntityActionType.Add:
                    Global.Inst.InspStage.AddInspWindow(e.WindowType, e.Rect);
                    break;

                case EntityActionType.Modify:
                    Global.Inst.InspStage.ModifyInspWindow(e.InspWindow, e.Rect);
                    break;

                case EntityActionType.Delete:
                    Global.Inst.InspStage.DelInspWindow(e.InspWindow);
                    break;
            }
        }
        private eImageChannel GetCurrentChannel()
        {
            if (rbtnRedChannel.Checked)
            {
                return eImageChannel.Red;
            }
            else if (rbtnBlueChannel.Checked)
            {
                return eImageChannel.Blue;
            }
            else if (rbtnGreenChannel.Checked)
            {
                return eImageChannel.Green;
            }
            else if (rbtnGrayChannel.Checked)
            {
                return eImageChannel.Gray;
            }

            return eImageChannel.Color;
        }

        private void rbtnColor_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void rbtnRedChannel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void rbtnBlueChannel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void rbtnGreenChannel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void rbtnGrayChannel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public void UpdateDisplay(Bitmap bitmap = null)
        {
            if (bitmap == null)
            {
                //# SAVE ROI#3 채널 정보 변수에 저장
                //참고 프로젝트에서 _currentImageChannel를 모두 찾아서, 수정할것
                _currentImageChannel = GetCurrentChannel();
                bitmap = Global.Inst.InspStage.GetBitmap(0, _currentImageChannel);
                if (bitmap == null)
                    return;
            }

            imageViewer.LoadBitmap(bitmap);

            //#BINARY FILTER#12 이진화 프리뷰에서 각 채널별로 설정이 적용되도록, 현재 이미지를 프리뷰 클래스 설정
            //현재 선택된 이미지로 Previwe이미지 갱신
            Mat curImage = Global.Inst.InspStage.GetMat();
            Global.Inst.InspStage.PreView.SetImage(curImage);

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

        private void CameraForm_Resize(object sender, EventArgs e)
        {
            int margin = 10;

            int xPos = Location.X + this.Width - btnGrab.Width - margin;

            btnGrab.Location = new System.Drawing.Point(xPos, btnGrab.Location.Y);
            btnLive.Location = new System.Drawing.Point(xPos, btnLive.Location.Y);
            btnSetRoi.Location = new System.Drawing.Point(xPos, btnSetRoi.Location.Y);
            btnSave.Location = new System.Drawing.Point(xPos, btnSave.Location.Y);
            btnInspect.Location = new System.Drawing.Point(xPos, btnInspect.Location.Y);
            groupBox1.Location = new System.Drawing.Point(xPos, groupBox1.Location.Y);
            
            imageViewer.Width = this.Width - btnGrab.Width - margin * 2;
            imageViewer.Height = this.Height - margin * 2;

            imageViewer.Location = new System.Drawing.Point(margin, margin);
        }

        private void btnSetRoi_Click(object sender, EventArgs e)
        {
            //ROI 토글 설정
            imageViewer.RoiMode = !imageViewer.RoiMode;
            imageViewer.Invalidate();  //주석처리시 버튼 클릭시 화면 갱신 안됨
            //화면 갱신 
            //Invalidate()를 호출하면 Windows Forms의 OnPaint() 이벤트가 다시 실행되면서 화면이 갱신됩니다.
            //즉, ROI 선택 후에 화면을 즉시 업데이트할지 여부에 영향을 미치는 코드
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

        }
        public OpenCvSharp.Mat GetDisplayImage()
        {
            return Global.Inst.InspStage.ImageSpace.GetMat(0, _currentImageChannel);
        }

        // ROI를 가져오는 공통 함수 
        public bool TryGetROI(out Mat roiImage, out Rect roiRect)
        {
            roiImage = null;
            roiRect = new Rect(); // 기본값

            OpenCvSharp.Mat currentImage = Global.Inst.InspStage.GetMat(0, _currentImageChannel);
            if (currentImage == null)
                return false;

            Rectangle roi = imageViewer.GetRoiRect();
            if (roi.Width == 0 || roi.Height == 0)
                return false;

            roiRect = new Rect(roi.X, roi.Y, roi.Width, roi.Height);
            roiImage = new Mat(currentImage, roiRect);
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 현재 채널 이미지에서, 설정된 ROI 영역을 파일로 저장
            //->ROI사각형으로 자른 부분 저장
            OpenCvSharp.Mat currentImage = Global.Inst.InspStage.GetMat(0, _currentImageChannel);
            if (currentImage != null)
            {
                //현재 설정된 ROI 영역을 가져옴
                Rectangle roiRect = imageViewer.GetRoiRect();
                if (roiRect.IsEmpty == true)
                    return;

                //전체 이미지에서 ROI 영역만을 roiImage에 저장
                Mat roiImage = new Mat(currentImage, new Rect(roiRect.X, roiRect.Y, roiRect.Width, roiRect.Height));

                //현재 실행파일이 있는 경로에, 저장할 경로 만들기
                string savePath = Path.Combine(Directory.GetCurrentDirectory(), Define.ROI_IMAGE_NAME);
                //이미지 저장
                Cv2.ImWrite(savePath, roiImage);
            }
        }
            public void AddRect(List<Rect> rects)
        {
            //#BINARY FILTER#18 imageViewer는 Rectangle 타입으로 그래픽을 그리므로, 
            //아래 코드를 이용해, Rect -> Rectangle로 변환하는 람다식
            var rectangles = rects.Select(r => new Rectangle(r.X, r.Y, r.Width, r.Height)).ToList();
            imageViewer.AddRect(rectangles);

        }
        public void AddRoi(InspWindowType inspWindowType)
        {
            //ROI 추가
            imageViewer.NewRoi(inspWindowType);
        }
        private void btnInspect_Click(object sender, EventArgs e)
        {
            Global.Inst.InspStage.InspWorker.RunInspect(); //전체 검사 함수 실행
        }
        //#MODEL#13 모델 정보를 이용해, ROI 갱신
        public void UpdateDiagramEntity()
        {
            Model model = Global.Inst.InspStage.CurModel;
            List<InspWindow> windowList = model.InspWindowList;
            if(windowList.Count <= 0) 
                return;

            List<DiagramEntity> diagramEntityList = new List<DiagramEntity>();

            foreach (InspWindow window in model.InspWindowList)
            {
                DiagramEntity diagramEntity = new DiagramEntity();
                Rect rect = window.WindowArea;
                diagramEntity.LinkedWindow = window;
                diagramEntity.EntityROI = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                diagramEntity.EntityColor = imageViewer.GetWindowColor(window.InspWindowType);
                diagramEntityList.Add(diagramEntity);
            }

            imageViewer.SetDiagramEntityList(diagramEntityList);
        }
    }
}
