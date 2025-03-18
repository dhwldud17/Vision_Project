using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Util.Helpers;
using JidamVision.Grab;

namespace JidamVision.Setting
{ //#SETUP# - <<<환경설정 정보를 저장하기 위한 클래스>>> 


    public class SettingXml
    {
        //환경설정 파일 저장 경로
        private const string SETTING_DIR = "Setup";
        private const string SETTING_FILE_NAME = @"Setup\Setting.xml";

        #region Singleton Instance
        private static SettingXml _setting;
        public SettingXml() { }

        public string ModelDir { get; set; } = "";

        public CameraType CamType { get; set; } = CameraType.WebCam;
        public static SettingXml Inst
        {
            get
            {
                if (_setting == null)
                    Load();
                return _setting;
            }
        }
        #endregion

        //환경설정 로딩
        public static void Load()
        {
            if (_setting != null)
                return;

            //환경설정 경로 생성
            string settingFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, SETTING_FILE_NAME);

            if (File.Exists(settingFilePath) == true)
            {
                //환경설정 파일이 존재하면 XmlHelper이용해 로딩
                _setting = XmlHelper.LoadXml<SettingXml>(settingFilePath);
            }
            if (_setting is null)
            {
                //환경설정 파일이 없으면 새로 생성
                _setting = CreateDefaultInstance();
            }
        }
        //환경설정 저장
        public static void Save()
        {
            string settingFilePath = Path.Combine(Environment.CurrentDirectory, SETTING_FILE_NAME);
            if (!File.Exists(settingFilePath))
            {
                //Setup 폴더가 없다면 생성
                string setupDir = Path.Combine(Environment.CurrentDirectory, SETTING_DIR);

                if (!Directory.Exists(setupDir))
                    Directory.CreateDirectory(setupDir);

                //Setting.xml 파일이 없다면 생성
                FileStream fs = File.Create(settingFilePath);
                fs.Close();
            }

            //XmlHelper를 이용해 Xml로 환경설정 정보 저장
            XmlHelper.SaveXml(settingFilePath, Inst);
        }

        //최초 환경설정 파일 생성
        private static SettingXml CreateDefaultInstance()
        {
            SettingXml setting = new SettingXml();
            setting.ModelDir = @"d:\Model";
            return setting;
        }



    }
}
