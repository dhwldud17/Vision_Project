using JidamVision.Core;
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

namespace JidamVision
{
    public partial class MainForm : Form
    {
        private static DockPanel _dockPanel;

        public MainForm()
        {
            InitializeComponent();

            _dockPanel = new DockPanel
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_dockPanel);

            // Visual Studio 2015 테마 적용
            _dockPanel.Theme = new VS2015BlueTheme();

            LoadDockingWindows();

            Global.Inst.Initialize();
        }

        private void LoadDockingWindows()
        {
            //도킹해제 금지 설정
            _dockPanel.AllowEndUserDocking = false;

            //메인폼 설정
            var cameraWindow = new CameraForm();
            cameraWindow.Show(_dockPanel, DockState.Document);

            //검사 결과창 30% 비율로 추가
            var resultWindow = new ResultForm();
            resultWindow.Show(cameraWindow.Pane, DockAlignment.Bottom, 0.3);

            //모델트리창 추가
            var modelTreeWindow = new ModelTreeForm();
            modelTreeWindow.Show(resultWindow.Pane,DockAlignment.Right, 0.3);
            //결과창 우측에 40% 비율로 추가


            //속성창 추가
            var propWindow = new PropertiesForm();
            propWindow.Show(_dockPanel, DockState.DockRight);

            //속성창과 같은탭에 추가하기
            var statisticWindow = new StatisticForm();
            statisticWindow.Show(_dockPanel, DockState.DockRight);

            propWindow.Activate();

            //로그창 50% 비율로 추가
            var logWindow = new LogForm();
            logWindow.Show(propWindow.Pane, DockAlignment.Bottom, 0.5);
        }

        //제네릭 함수 사용를 이용해 입력된 타입의 폼 객체 얻기
        public static T GetDockForm<T>() where T : DockContent
        {
            var findForm = _dockPanel.Contents.OfType<T>().FirstOrDefault();
            return findForm;
        }

        //모든 DockContent 리스트 얻기
        private void GetDockContentState()
        {
            var dockedForms = _dockPanel.Contents.OfType<DockContent>().ToList();

            foreach (var form in dockedForms)
            {
                //MessageBox.Show($"Docked Form: {form.Text}");
                Console.WriteLine($"Docked Form: {form.Text}");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "이미지 파일 선택";
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Global.Inst.InspStage.SetImageBuffer(filePath);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "이미지 저장";
                saveFileDialog.Filter = "PNG 파일|*.png|JPEG 파일|*.jpg|Bitmap 파일|*.bmp";
                saveFileDialog.DefaultExt = "png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Global.Inst.InspStage.SaveCurrentImage(filePath);
                }
            }
        }

        private void imageFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
