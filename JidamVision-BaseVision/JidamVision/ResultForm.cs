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
    public partial class ResultForm : DockContent
    {
        public ResultForm()
        {
            InitializeComponent();

           CloseButton = false;
           // CloseButtonVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var logForm = MainForm.GetDockForm<LogForm>();
            if (logForm != null)
            {


            }
        }
    }
}
