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
using JidamVision.Teach;

namespace JidamVision
{
    public partial class NewModel : Form
    {
        public bool _saveAsMode = false;
        public NewModel(bool saveAs = false )
        {
            InitializeComponent();

            _saveAsMode = saveAs;

            if (_saveAsMode)
            {
                this.Text = "모델 다른 이름으로 저장";
                btnCreate.Text = "저장";

                Model model = Global.Inst.InspStage.CurModel;

                txtModelName.Text = model.ModelName;
                txtModelInfo.Text = model.ModelInfo;
            }
            else
            {
                this.Text = "신규 모델 생성";
                btnCreate.Text = "생성";
            }
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
            MessageBox.Show($"모델 저장 폴더 경로: {modelDir}"); // 확인용 메시지
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

            //모델이름 정하지않앗는데 save하려할때. ->(Model New 안하고 Model Save하려할때 )



            string modelInfo = txtModelInfo.Text.Trim(); // 모델 설명(공백제거)


            if (_saveAsMode)
            {
                Global.Inst.InspStage.CurModel.CreateModel(modelPath, modelName, modelInfo);
                Global.Inst.InspStage.CurModel.Save();

            }
            else
            {
                if (Global.Inst.InspStage.CurModel == null)
                {
                    MessageBox.Show("현재 모델이 없습니다. 먼저 모델을 생성하세요.");
                    return;
                }
                Global.Inst.InspStage.CurModel.CreateModel(modelPath, modelName, modelInfo);
                Global.Inst.InspStage.CurModel.Save();
            }
            this.Close();
        }
    }
}
