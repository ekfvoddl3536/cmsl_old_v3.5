using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MetroFramework.Forms.MetroForm;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace 서버_구축기_V3._5
{
    public partial class Form6 : MetroFramework.Forms.MetroForm
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            string _Filestr = Application.StartupPath + @"\User_Data\server.properties";
            System.IO.FileInfo fi = new System.IO.FileInfo(_Filestr);
            if (fi.Exists)
            {
                Process.Start(Application.StartupPath + @"\User_Data\server.properties");
            }
            else
            {
                MessageBox.Show("최소 1번이상 서버를 구동하여주세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\User_Data\plugins");
            if (di.Exists)
            {
                Process.Start("explorer.exe", Application.StartupPath + @"\User_Data\plugins");
                return;
            }
            else
            {
                MessageBox.Show("최소 1번이상 서버를 구동하여주세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            Process.Start("explorer.exe", Application.StartupPath + @"\User_Data");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            DialogResult a = MessageBox.Show("MoJang의 EULA에 동의하십니까?", "EULA 동의", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if(a == DialogResult.Yes)
            {
                string _KOP = Application.StartupPath + @"\User_Data\eula.txt";
                System.IO.FileInfo li = new System.IO.FileInfo(_KOP);
                if (li.Exists)
                {
                    string oFi = Application.StartupPath + @"\Program_Data\bin\eula.txt";
                    System.IO.FileInfo fileinfo = new System.IO.FileInfo(_KOP);
                    fileinfo.Delete();
                    System.IO.File.Copy(oFi, _KOP, true);
                    GC.Collect();
                    goto SS;
                }
                else
                {
                    MessageBox.Show("EULA파일이 존재하지 않습니다! \r\n1.7.10~ 버전으로 1회 이상 \r\n서버를 구동하여 주십시오!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult b = MessageBox.Show("EULA를 사전 동의하시겠습니까?", "EULA 사전 동의", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (b == DialogResult.OK)
                    {
                        string EKOP = Application.StartupPath + @"\User_Data\eula.txt";
                        System.IO.FileInfo Eli = new System.IO.FileInfo(_KOP);
                        if (Eli.Exists)
                        {
                            string oFi = Application.StartupPath + @"\Program_Data\bin\eula.txt";
                            System.IO.FileInfo fileinfo = new System.IO.FileInfo(EKOP);
                            fileinfo.Delete();
                            System.IO.File.Copy(oFi, EKOP, true);
                            GC.Collect();
                            goto SS;
                        }
                    }
                    goto exit;
                }
                SS:
                {
                    MessageBox.Show("EULA에 동의 하셨습니다!", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
                }
            }
            exit:;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            Settings1 se = new Settings1();
            if (se.est == "False")
            {
                Easyst eee = new Easyst();
                eee.Show();
                se.est = "True";
                se.Save();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            DialogResult dr = MessageBox.Show("서버 폴더를 초기화 시키겠습니까?\r\n(서버 초기화)", "Really?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string path;
                path = Application.StartupPath + @"\User_Data";

                string[] xfiles = Directory.GetFiles(path);

                if (xfiles.Length != 0)
                {
                    foreach (string xfile in xfiles)
                    {
                        File.Delete(xfile);
                        return;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            Settings1 se = new Settings1();
            if (se.iplist == "False")
            {
                iplist ip = new iplist();
                ip.Show();
                se.iplist = "True";
                se.Save();
            }
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.svr = "False";
            se.Save();
        }
    }
}
