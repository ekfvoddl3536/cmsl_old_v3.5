using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MetroFramework.Forms.MetroForm;

namespace 서버_구축기_V3._5
{
    public delegate void toForm1(string lp1);
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public static event toForm1 toform1;
        public Form2()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.InitialDirectory = Application.StartupPath + @"\Program_Data\Core";
            }
            catch
            {
                ofd.InitialDirectory = @"C:\";
            }
            ofd.Title = "사용할 구동 파일을 선택해 주세요";
            ofd.Filter = "구동 파일 (.jar) | *.jar";

            ofd.ShowDialog();

            string path = ofd.FileName;

            url1.Text = ofd.FileName;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Settings1 k = new Settings1();
            if (k.sltac == "True")
            {
                toform1(url1.Text);
                this.Close();
            }
            else
            {
                toform1(url1.Text);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(url1.ToString() != null)
            {
                url1.Text = null;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.java = "False";
            se.Save();
        }
    }
}
