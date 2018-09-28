using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using System.Text.RegularExpressions;

namespace 서버_구축기_V3._5
{
    public partial class loadForm : MetroFramework.Forms.MetroForm
    {
        public loadForm()
        {
            InitializeComponent();
        }

        private static Main1 df = new Main1();


        Settings1 se = new Settings1();

        private void loadForm_Load(object sender, EventArgs e)
        {
            Settings1 n = new Settings1();
            try
            {
                string value = Application.StartupPath + @"\Program_Data\bin\cobin\" + n.file.ToString() + @".Xml";
                FileInfo val = new FileInfo(value);
                if (!val.Exists || val.Length <= 0)
                {
                    info.Text = "File [" + n.file.ToString() + "] 설정됨";
                    return;
                }
                else if (val.Exists & val.Length > 0)
                {
                    info.Text = "File [" + n.file + "] 로드됨";
                }
                return;
            }
            catch
            {
                info.Text = "File [Err] 로드됨";
                return;
            }
        }

        private void b1_Click_1(object sender, EventArgs e)
        {
            if (se.file == "file1")
            {
                Thread p = new Thread(new ThreadStart(df.ui));
                info.Text = "File [1] 로드됨";
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("다음 구동(실행)부터 File[1]에 저장하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    se.file = "file1";
                    se.Save();
                    info.Text = "File [1] 설정됨";
                    return;
                }
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (se.file == "file2")
            {
                Thread p = new Thread(new ThreadStart(df.ui));
                info.Text = "File [2] 로드됨";
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("다음 구동(실행)부터 File[2]에 저장하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    se.file = "file2";
                    se.Save();
                    info.Text = "File [2] 설정됨";
                    return;
                }
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (se.file == "file3")
            {
                Thread p = new Thread(new ThreadStart(df.ui));
                info.Text = "File [3] 로드됨";
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("다음 구동(실행)부터 File[3]에 저장하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    se.file = "file3";
                    se.Save();
                    info.Text = "File [3] 설정됨";
                    return;
                }
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (se.file == "file4")
            {
                Thread p = new Thread(new ThreadStart(df.ui));
                info.Text = "File [4] 로드됨";
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("다음 구동(실행)부터 File[4]에 저장하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    se.file = "file4";
                    se.Save();
                    info.Text = "File [4] 설정됨";
                    return;
                }
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (se.file == "file5")
            {
                Thread p = new Thread(new ThreadStart(df.ui));
                info.Text = "File [5] 로드됨";
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("다음 구동(실행)부터 File[5]에 저장하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    se.file = "file";
                    se.Save();
                    info.Text = "File [5] 설정됨";
                    return;
                }
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (se.file == "file6")
            {
                Thread p = new Thread(new ThreadStart(df.ui));
                info.Text = "File [6] 로드됨";
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("다음 구동(실행)부터 File[6]에 저장하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    se.file = "file6";
                    se.Save();
                    info.Text = "File [6] 설정됨";
                    return;
                }
            }
        }
        

        private void cr_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("초기화 하시겠습니까?", "확인중..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                se.file = "file1";
                se.Save();

                info.Text = "File [file1] 설정됨";
            }
        }

        private void b0_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중", "준비중", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void dn_Click(object sender, EventArgs e)
        {
            if(se.file == "file1")
            {
                se.file = "file1";
                se.Save();
            }
            else if(se.file == "file2")
            {
                se.file = "file2";
                se.Save();
            }
            else if (se.file == "file3")
            {
                se.file = "file3";
                se.Save();
            }
            else if (se.file == "file4")
            {
                se.file = "file4";
                se.Save();
            }
            else if (se.file == "file5")
            {
                se.file = "file5";
                se.Save();
            }
            else if (se.file == "file6")
            {
                se.file = "file6";
                se.Save();
            }
            Application.OpenForms["loadForm"].Close();
        }

        private void info_Click(object sender, EventArgs e)
        {
            Settings1 kmm = new Settings1();

            if (kmm.file != "file1")
            {
                string assf1 = Application.StartupPath + @"\Program_Data\bin\cobin\" + kmm.file + @".Xml";
                FileInfo asmf = new FileInfo(assf1);
                if (!asmf.Exists || asmf.Length <= 0)
                {
                    MessageBox.Show("자바: 설정되지 않음" + Environment.NewLine + "메모리(RAM): 설정되지 않음" + Environment.NewLine + "코어파일: 설정되지 않음" + Environment.NewLine + Environment.NewLine + kmm.file.ToString() + @".xml파일 존재 여부: False", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                XmlDocument loadxml = new XmlDocument();

                loadxml.Load(assf1);

                XmlNodeList xmlread = loadxml.SelectNodes("/Root");

                foreach (XmlNode list in xmlread)
                {
                    string read0 = list["ID"]["java"].InnerText;
                    string read1 = list["ID"]["ram"].InnerText;
                    string read3 = list["ID"]["ram-or"].InnerText;
                    string read2 = list["ID"]["jar"].InnerText;

                    if (read0.ToString() == null | read1.ToString() == null | read2.ToString() == null | read3.ToString() == null)
                    {
                        MessageBox.Show("자바: 설정되지 않음" + Environment.NewLine + "메모리(RAM): 설정되지 않음" + Environment.NewLine + "코어파일: 설정되지 않음" + Environment.NewLine + Environment.NewLine + kmm.file.ToString() + @".xml파일 존재 여부: True", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (read0.ToString() == "not")
                    {
                        MessageBox.Show("자바: 설정되지 않음" + Environment.NewLine + "메모리(RAM): " + read1.ToString() + read3.ToString() + Environment.NewLine + "코어파일: " + read2.ToString() + Environment.NewLine + Environment.NewLine + @"file1.xml파일 존재 여부: True", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("자바: " + read0.ToString() + Environment.NewLine + "메모리(RAM): " + read1.ToString() + read3.ToString() + Environment.NewLine + "코어파일: " + read2.ToString() + Environment.NewLine + Environment.NewLine + @"file1.xml파일 존재 여부: True", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
            else  // default 값에 해당하는 아래 코드
            {
                string assf2 = Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml";
                FileInfo asmf1 = new FileInfo(assf2);
                if (!asmf1.Exists || asmf1.Length <= 0)
                {
                    MessageBox.Show("자바: 설정되지 않음" + Environment.NewLine + "메모리(RAM): 설정되지 않음" + Environment.NewLine + "코어파일: 설정되지 않음" + Environment.NewLine + Environment.NewLine + @"file1.xml파일 존재 여부: False", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (kmm.file == "file1")
                {
                    XmlDocument loadxml1 = new XmlDocument();

                    loadxml1.Load(assf2);
                    XmlNodeList xmlread = loadxml1.SelectNodes("/Root");

                    foreach (XmlNode list in xmlread)
                    {
                        string read0 = list["ID"]["java"].InnerText;
                        string read1 = list["ID"]["ram"].InnerText;
                        string read3 = list["ID"]["ram-or"].InnerText;
                        string read2 = list["ID"]["jar"].InnerText;

                        if (read0.ToString() == null | read1.ToString() == null | read2.ToString() == null | read3.ToString() == null)
                        {
                            MessageBox.Show("자바: 설정되지 않음" + Environment.NewLine + "메모리(RAM): 설정되지 않음" + Environment.NewLine + "코어파일: 설정되지 않음" + Environment.NewLine + Environment.NewLine + @"file1.xml파일 존재 여부: True", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (read0.ToString() == "not")
                        {
                            MessageBox.Show("자바: 설정되지 않음" + Environment.NewLine + "메모리(RAM): " + read1.ToString() + read3.ToString() + Environment.NewLine + "코어파일: " + read2.ToString() + Environment.NewLine + Environment.NewLine + @"file1.xml파일 존재 여부: True", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("자바: " + read0.ToString() + Environment.NewLine + "메모리(RAM): " + read1.ToString() + read3.ToString() + Environment.NewLine + "코어파일: " + read2.ToString() + Environment.NewLine + Environment.NewLine + @"file1.xml파일 존재 여부: True", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void loadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.loaddataform = "False";
            se.Save();
        }
    }
}
