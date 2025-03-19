using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JidamVision.Setting;
using JidamVision.Core;

namespace JidamVision
{
    public partial class NewModel : Form
    {
        public NewModel()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string modelName = txtModelName.Text.Trim(); // 모델명(공백제거)
            if (modelName == "")
            {
                MessageBox.Show("모델 이름을 입력하세요.");
                return;
            }

            string modelDir = SettingXml.Inst.ModelDir; // 모델 디렉토리
            if (Directory.Exists(modelDir) == false)
            {
                MessageBox.Show("모델 저장 폴더가 존재하지 않습니다.");
                return;
            }
            // 모델 경로

            string modelPath = Path.Combine(modelDir, modelName, modelName + ".xml");
            if (File.Exists(modelPath))
            {
                MessageBox.Show("이미 존재하는 모델 이름입니다.");
                return;
            }
            string saveDir = Path.Combine(modelDir, modelName);
            if(!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }

            string modelInfo = txtModelInfo.Text.Trim(); // 모델 설명(공백제거)
            

            Global.Inst.InspStage.CurModel.CreateModel(modelPath, modelName, modelInfo);
            Global.Inst.InspStage.CurModel.Save();
            this.Close();
        }
    }
}
