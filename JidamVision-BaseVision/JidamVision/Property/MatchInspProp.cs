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
using JidamVision.Teach;
using OpenCvSharp;

namespace JidamVision.Property
{
    /*
    #MATCH PROP# - <<<템플릿 매칭 개발>>> 
    설정된 ROI 이미지를 이용해, 유사한 이미지를 대상 이미지에서 찾는다.
    [확장영역]은 현재 구현되지 않았음
    [매칭스코어]는 템플릿 매칭 결과가 입력된 스코어보다 큰것만을 유효한 것으로 판단
    [매칭갯수]는 찾고자 하는 패턴의 갯수를 입력
     */
    public partial class MatchInspProp : UserControl
    {
        public MatchInspProp()
        {
            InitializeComponent();

            //#MATCH PROP#8 템플릿 매칭 속성값을 GUI에 설정
            LoadInspParam();
        }

        //#MATCH PROP#7 템플릿 매칭 속성값을 GUI에 설정
        private void LoadInspParam()
        {
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow is null)
                return;

            OpenCvSharp.Size extendSize = inspWindow.MatchAlgorithm.ExtSize;
            int matchScore = inspWindow.MatchAlgorithm.MatchScore;
            int matchCount = inspWindow.MatchAlgorithm.MatchCount;

            txtExtendX.Text = extendSize.Width.ToString();
            txtExtendY.Text = extendSize.Height.ToString();
            txtScore.Text = matchScore.ToString();
            txtMatchCount.Text = matchCount.ToString();
        }

        //#MATCH PROP#10 템플릿 매칭 실행
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //GUI에 설정된 정보를 MatchAlgorithm에 설정
            OpenCvSharp.Size extendSize = new OpenCvSharp.Size();
            extendSize.Width = int.Parse(txtExtendX.Text);
            extendSize.Height = int.Parse(txtExtendY.Text);
            int matchScore = int.Parse(txtScore.Text);
            int matchCount = int.Parse(txtMatchCount.Text);

            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            inspWindow.MatchAlgorithm.ExtSize = extendSize;
            inspWindow.MatchAlgorithm.MatchScore = matchScore;
            inspWindow.MatchAlgorithm.MatchCount = matchCount;

            //템플릿 매칭 실행
            if (inspWindow.DoInpsect())
            {
                List<Rectangle> rectangles;
                int findCount = inspWindow.GetMatchRect(out rectangles);
                if (findCount > 0)
                {
                    //찾은 위치를 이미지상에서 표시
                    var cameraForm = MainForm.GetDockForm<CameraForm>();
                    if (cameraForm != null)
                    {
                        cameraForm.AddRect(rectangles);
                    }
                }
            }
        }

        //#MATCH PROP#9 저장된 ROI이미지 로딩
        private void btnTeach_Click(object sender, EventArgs e)
        {
            InspWindow inspWindow = Global.Inst.InspStage.InspWindow;
            if (inspWindow.PatternLearn())
                MessageBox.Show("티칭 성공");
            else
                MessageBox.Show("티칭 실패");
        }
    }
}
