using JidamVision.Core;
using JidamVision.Teach;
using OpenCvSharp;
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
    public partial class ModelTreeForm : DockContent //도킹(docking) 기능을 지원하는 창 ,다른 창의 내부에 부착할수잇음. -메인에 부착
    {                         //:Form: 독립적으로 창 떠잇음. 

        private ContextMenuStrip _contextMenu;
        public ModelTreeForm()
        {
            InitializeComponent();

            //초기 트리 노트의 기본값 "Root"
            tvModelTree.Nodes.Add("Root");

            //컨텍스트 메뉴초기화 //팝업메뉴 종류
            _contextMenu = new ContextMenuStrip();
            ToolStripMenuItem addBaseRoiItem = new ToolStripMenuItem("Base", null, AddNode_Click) { Tag = "Base" };
            ToolStripMenuItem addSubRoiItem = new ToolStripMenuItem("Sub", null, AddNode_Click) { Tag = "Sub" };
            ToolStripMenuItem addIdRoiItem = new ToolStripMenuItem("ID", null, AddNode_Click) { Tag = "ID" };

            _contextMenu.Items.Add(addBaseRoiItem);
            _contextMenu.Items.Add(addSubRoiItem);
            _contextMenu.Items.Add(addIdRoiItem);
        }

        private void tvModelTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tvModelTree_MouseDown(object sender, MouseEventArgs e)
        {
            //Root 노드에서 마우스 오른쪽 버튼 클릭 시 팝업 메뉴 생성되게
            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = tvModelTree.GetNodeAt(e.X, e.Y);
                if (clickedNode != null && clickedNode.Text == "Root") 
                {
                    tvModelTree.SelectedNode = clickedNode;
                    _contextMenu.Show(tvModelTree, e.Location);
                }
            }
        }
        //팝업메뉴에서 메뉴선택시 실행되는 함수 
        private void AddNode_Click(object sender, EventArgs e)
        {
            if (tvModelTree.SelectedNode != null & sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                string nodeType = menuItem.Tag?.ToString();
                if (nodeType == "Base")
                {
                    AddNewROI(InspWindowType.Base);
                }
                else if (nodeType == "Sub")
                {
                    AddNewROI(InspWindowType.Sub);
                }
                else if (nodeType == "ID")
                {
                    AddNewROI(InspWindowType.ID);
                }
            }
        }

        //imageViewer에 ROI 추가 기능 실행
        private void AddNewROI(InspWindowType inspWindowType)
        {
            CameraForm cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.AddRoi(inspWindowType);
            }

        }

        //#MODEL#14 현재 모델 전체의 ROI를 트리 모델에 업데이트
        public void UpdateDiagramEntity()
        {
            tvModelTree.Nodes.Clear();
            TreeNode rootNode = tvModelTree.Nodes.Add("Root");

            Model model = Global.Inst.InspStage.CurModel;
            List<InspWindow> windowList = model.InspWindowList;
            if (windowList.Count <= 0)
            {
                return;
            }
            foreach (InspWindow window in model.InspWindowList)
            {
                if (window is null)
                    continue;

                string uid = window.UID;

                TreeNode node = new TreeNode(uid);
                rootNode.Nodes.Add(node);
            }

            tvModelTree.ExpandAll();
        }
    }
}
