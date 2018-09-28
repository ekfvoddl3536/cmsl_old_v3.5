// 별거 없는 메인 입니다. 멍청해서 노가다 하던 시절
// VB 하다가 처음 C# 으로 넘어와서 적응하고 있던 

using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.ComponentModel;

namespace 서버_구축기_V3._5
{
    public partial class Main1 : MetroForm, IMyInterface
    {
        public Main1()
        {
            Main1.FormBorderStyle = FormBorderStyle.FixedDialog;
            
            this.InitializeComponent();
            Form2.toform1 += new toForm1(TextChange);
        }
        
        // 솔직하게 좀 이해가 안되는 부분, Form2를 열고 파일을 찾는것 보다, 바로 파일을 찾는 창을 띄우는게..
        void TextChange(string lp1)
        {
            this.l1.Text = lp1;
        }
        
        private static Boolean offline = false;
        
        void pupdata()
        {
            lock (this)
            {
                string aF2 = Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml";
                FileInfo F2 = new FileInfo(aF2);
                if (F2.Exists)
                {
                    F2.Delete();
                }
                else
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(exitm3);

                    webClient.Headers.Add("User-Agent",
                       "Mozilla/5.0 (compatible; MSIE 11.0; Windows NT 10.0; WOW64; Trident/7.0)");

                    string sUrl = "http://검열...com";

                    webClient.DownloadFileAsync(new Uri(sUrl), Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml");
                }
            }
        }
        
        void exitm3(object sender, AsyncCompletedEventArgs e)
        {
            string surl300 = Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml";

            if (surl300.Length <= 0)
            {
            //    offline = true;
            // }
            //
            // if (offline)
            // {
                MessageBox.Show("오프라인 경고\r\n프로그램이 오프라인모드로 구동됩니다.\r\n이 문제에 대한 정보를 얻으시려면\r\nhttp://blog.naver.com/ekfvoddl3535에 방문해 주시길 바랍니다");
                return;
            }

            XmlDocument xml = new XmlDocument();

            xml.Load(surl300);

            XmlNodeList node = xml.SelectNodes("/main");
            foreach (XmlNode rd in node)
            {
                string xm = rd["version"]["update"].InnerText;
                string xm1 = rd["version"]["urgent_update"].InnerText;
                string vs = rd["version"]["now"].InnerText;

                int i = Int32.Parse(vs);

                if (i2 >= i)
                {
                    FileInfo DelXML = new FileInfo(Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml");
                    DelXML.Delete();
                    return;
                }
                else
                {

                    if (xm1 == "none")
                    {
                        if (xm == "none")
                        {
                            MessageBox.Show(xm); // ???
                            return;
                        }
                        else
                        {
                            if (DialogResult.Yes == MessageBox.Show("새 업데이트가 있습니다. \r\n업데이트 하시겠습니까?", "업데이트 발견!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                xm = xm.Replace("&amp;", "&");
                                Process.Start("explorer.exe", xm);
                                Application.ExitThread();
                                Application.Exit();
                            }
                            else
                            {
                                FileInfo DelXML1 = new FileInfo(Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml");
                                DelXML1.Delete();
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("긴급 업데이트가 있습니다. \r\n업데이트를 하여주세요!", "업데이트 발견!", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                        {
                            xm1 = xm1.Replace("&amp;", "&");
                            Process.Start("explorer.exe", xm1);
                            Application.ExitThread();
                            Application.Exit();
                        }
                    }
                }
            }
            // return; ?????????
        }
        
        private Boolean JavaNull = false;

        // ??????????
        private void Main1_Load(object sender, EventArgs e)
        { 
            Settings1 kmm = new Settings1();
            if(kmm.lisk == "true")
            {
                new Thread(new ThreadStart(pupdata)).Start();
            }
            kmm.Seton = "False";
            kmm.MRCon = "False";
            kmm.spngon = "False";
            kmm.java = "False";
            kmm.helpr = "False"; 
            kmm.svr = "False";
            kmm.iplist = "False";
            kmm.est = "False"; 
            kmm.Save();
            kmm.Reload();

            Main1.FormBorderStyle = FormBorderStyle.FixedDialog;

            string surl300 = Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml";

            if(surl300.Length <= 0)
            {
            //    offline = true;
            // }

            // if(offline)
            // {
                MessageBox.Show("오프라인 경고\r\n프로그램이 오프라인모드로 구동됩니다.\r\n이 문제에 대한 정보를 얻으시려면\r\nhttp://blog.naver.com/ekfvoddl3535에 방문해 주시길 바랍니다");
                return;
            }

            if (kmm.lisk == "true")
            {
                goto pass2;
            }

            XmlDocument xml = new XmlDocument();

            xml.Load(surl300);

            XmlNodeList node = xml.SelectNodes("/main");
            foreach (XmlNode rd in node)
            {
                string xm = rd["version"]["update"].InnerText;
                string xm1 = rd["version"]["urgent_update"].InnerText;
                string vs = rd["version"]["now"].InnerText;

                
                int i = Int32.Parse(vs);

                if (i2 >= i)
                {
                    FileInfo DelXML = new FileInfo(Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml");
                    DelXML.Delete();
                    goto pass2;
                }
                else
                {

                    if (xm1 == "none")
                    {
                        if (xm == "none")
                        {
                            MessageBox.Show(xm);
                            goto pass2;
                        }
                        else
                        {
                            if (DialogResult.Yes == MessageBox.Show("새 업데이트가 있습니다. \r\n업데이트 하시겠습니까?", "업데이트 발견!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                xm = xm.Replace("&amp;", "&");
                                Process.Start("explorer.exe", xm);
                                Application.ExitThread();
                                Application.Exit();
                            }
                            else
                            {
                                FileInfo DelXML1 = new FileInfo(Application.StartupPath + @"\Program_Data\bin\UpdateCheck.xml");
                                DelXML1.Delete();
                                goto pass2;
                            }
                        }
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("긴급 업데이트가 있습니다. \r\n업데이트를 하여주세요!", "업데이트 발견!", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                        {
                            xm1 = xm1.Replace("&amp;", "&");
                            Process.Start("explorer.exe", xm1);
                            Application.ExitThread();
                            Application.Exit();
                        }
                    }
                }
            }


            pass2:

            // decimal ??? long 이나 ulong 으로도 충분할텐데
            decimal F = Convert.ToDecimal(DateTime.Now.ToString("ss"));
            decimal K = F * 1000;
            decimal K1 = 60000 - K;
            int F2 = Convert.ToInt32(K1);
            timer1_Tick(sender, e);
            timer1.Interval = F2;
            timer1.Start();
            date1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            timeHs.Text = DateTime.Now.ToString("HH:mm");
            url.Hide();

            reload:

            //자동 저장 기능 관련 
            string nodata = Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml";
            FileInfo nodata1 = new FileInfo(nodata);
            if (kmm.svdt == "False")
            {
                goto exit;
            }
            else
            {

                if (kmm.file != "file1")
                {
                    string assf1 = Application.StartupPath + @"\Program_Data\bin\cobin\" + kmm.file + @".Xml";
                    FileInfo asmf = new FileInfo(assf1);
                    if(!asmf.Exists)
                    {
                        MessageBox.Show("로딩 오류! [설정값 저장 기능]을 사용하지 않음으로 변경합니다.","오류",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        kmm.svdt = "False";
                        kmm.file = "file1";
                        kmm.Save();
                        goto exit;
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

                        if(read0.ToString() == null | read1.ToString() == null | read2.ToString() == null | read3.ToString() == null)
                        {
                            MessageBox.Show("로딩 오류! [설정값 저장 기능]을 사용하지 않음으로 변경합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            kmm.svdt = "False";
                            kmm.Save();
                            goto exit;
                        }

                            if (read0.ToString() == "not")
                            {
                                mry_e.Text = read1;
                                ca1.SelectedItem = read3.ToString();
                                l1.Text = read2;
                                goto exit;
                            }
                            else
                            {
                                url.Show();
                                url.Text = read0;
                                mry_e.Text = read1;
                                ca1.SelectedItem = read3.ToString();
                                l1.Text = read2;
                                goto exit;
                            }
                        }

                        goto exit;
                    
                }
                else  // default 값에 해당하는 아래 코드
                {
                    string assf2 = Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml";
                    FileInfo asmf1 = new FileInfo(assf2);
                    if (!asmf1.Exists)
                    {
                        MessageBox.Show("로딩 오류! [설정값 저장 기능]을 사용하지 않음으로 변경합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kmm.svdt = "False";
                        kmm.file = "file1";
                        kmm.Save();
                        goto exit;
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
                                MessageBox.Show("로딩 오류! [설정값 저장 기능]을 사용하지 않음으로 변경합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                kmm.svdt = "False";
                                kmm.Save();
                                goto exit;
                            }

                            if (read0.ToString() == "not")
                            {
                                mry_e.Text = read1;
                                l1.Text = read2;
                                goto exit;
                            }
                            else
                            {
                                url.Show();
                                url.Text = read0;
                                mry_e.Text = read1;
                                l1.Text = read2;
                                goto exit;
                            }
                        }
                    }
                    else
                    {
                        kmm.file = "file1";
                        kmm.Save();
                        goto reload;
                    }
                }
            }
  
            exit:
            if (kmm.opab == "True")
            {
                this.Opacity = Convert.ToDouble(kmm.opa.ToString());
            }
            t1.Hide();
            p1.Hide();
        }
        
        void ui()
        {
            Settings1 kmm = new Settings1();
            string sfile2 = kmm.file + @".Xml";
            FileInfo bfile2 = new FileInfo(sfile2);

            string nodata = Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml";
            FileInfo nodata1 = new FileInfo(nodata);
            if (bfile2.Exists)
            {
                if(sfile2.ToString() == null)
                {
                    MessageBox.Show("파일에 데이터가 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                XmlDocument load1 = new XmlDocument();

                try
                { 
                load1.Load(sfile2);
                XmlNodeList xmlread1 = load1.SelectNodes("/Root/ID");

                    foreach (XmlNode list in xmlread1)
                    {
                        string r0 = list["java"].InnerText;
                        string r1 = list["ram"].InnerText;
                        string r3 = list["ram-or"].InnerText;
                        string r2 = list["jar"].InnerText;

                        if (r0.ToString() == "not")
                        {
                            mry_e.Text = r1;
                            l1.Text = r2;
                            if (r3.ToString() == "MB")
                            {
                                t1.Show();
                                p1.Show();
                                decimal M = mry_e.Value;
                                decimal G = M / 1024;
                                string G1 = string.Format("{0,10:N3}", G);
                                t1.Text = G1;
                            }
                        }
                        else
                        {
                            url.Show();
                            url.Text = r0;
                            mry_e.Text = r1;
                            l1.Text = r2;
                            if (r3.ToString() == "MB")
                            {
                                t1.Show();
                                p1.Show();
                                decimal M = mry_e.Value;
                                decimal G = M / 1024;
                                string G1 = string.Format("{0,10:N3}", G);
                                t1.Text = G1;
                            }
                        }
                    }
                }
                catch
                {
                    DialogResult u = MessageBox.Show("[Err#1:Failed_Read] Message: \r\n \r\n파일 데이터가 손상되어있어 파일을 불러올 수 없습니다 \r\n해당 파일을 삭제하시겠습니까?", "오류[File_Data_Loss]", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (u == DialogResult.Yes)
                    {
                        bfile2.Delete();

                        kmm.file = "file1";
                        kmm.Save();
                        return;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("[Err#2:Failed_Read] Message: File wasn't found.\r\n \r\n 파일을 찾을 수 없습니다", "오류[File_Was_Not_Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void ca1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ca1.Text)
            {
                case "MB":
                    t1.Show();
                    p1.Show();
                    break;
                case "GB":
                    t1.Hide();
                    p1.Hide();
                    return;
            }
            
            // decimal ??????
            decimal M = mry_e.Value;
            decimal G = M / 1024;
            string G1 = string.Format("{0,10:N3}", G);
            t1.Text = G1;
        }
        
        private void mry_e_ValueChanged(object sender, EventArgs e)
        {

            if (mry_e.Value < 0)
            {
                return;
            }

            switch (ca1.Text)
            {
                case "MB":
                    t1.Show();
                    p1.Show();
                    break;
                case "GB":
                    t1.Hide();
                    p1.Hide();
                    return;
            }

            decimal M = mry_e.Value;
            decimal G = M / 1024;
            string G1 = string.Format("{0,10:N3}", G);
            t1.Text = G1;
        }
        
        private void t1_TextChanged(object sender, EventArgs e)
        {
            switch (ca1.Text)
            {
                case "MB":
                    t1.Show();
                    p1.Show();
                    //goto Cale2;
                    break;
                case "GB":
                    t1.Hide();
                    p1.Hide();
                    //goto exit;
                    return;
            }
        //Cale2:
            decimal M = mry_e.Value;
            decimal G = M / 1024;
            string G1 = string.Format("{0,10:N3}", G);
            t1.Text = G1;
        //exit:;
        }
        
        private void Main1_StyleChanged(object sender, EventArgs e)
        {
            switch (ca1.Text)
            {
                case "MB":
                    t1.Show();
                    p1.Show();
                    break;
                case "GB":
                    t1.Hide();
                    p1.Hide();
                    return;
            }

            decimal M = mry_e.Value;
            decimal G = M / 1024;
            string G1 = string.Format("{0,10:N3}", G);
            t1.Text = G1;
        }
        
        // 여기서 부터 수정하는거 포기했습니다, 좀 이해가 안되는 부분이 있더라도 양해 부탁합니다.
        // 솔직히 저도 이해가 안되요.
        private void b32_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b32.Text == "+32")
            {
                goto plus32;
            }
            else
            {
                goto minus32;
            }
        plus32:
            try
            {
                decimal L2 = mry_e.Value + 32;
                mry_e.Value = L2;
                goto end32;
            }
            catch
            {
                if (mry_e.Value + 32 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+32\"에서 \"-32\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b32.Text = "-32";
                    goto end32;
                }
                else
                {
                    decimal L2 = mry_e.Value + 32;
                    mry_e.Value = L2;
                    goto end32;
                }
            }
        minus32:
            if (mry_e.Value - 32 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-32\"에서 \"+32\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b32.Text = "+32";
                goto end32;
            }
            else
            {
                decimal L = mry_e.Value - 32;
                mry_e.Value = L;
                goto end32;
            }
            end32:;
        }
        
        private void b64_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b64.Text == "+64")
            {
                goto plus64;
            }
            else
            {
                goto minus64;
            }
        plus64:
            try
            {
                decimal L2 = mry_e.Value + 64;
                mry_e.Value = L2;
                goto end64;
            }
            catch
            {
                if (mry_e.Value + 64 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+64\"에서 \"-64\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b64.Text = "-64";
                    goto end64;
                }
                else
                {
                    decimal L2 = mry_e.Value + 64;
                    mry_e.Value = L2;
                    goto end64;
                }
            }
        minus64:
            if (mry_e.Value - 64 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-64\"에서 \"+64\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b64.Text = "+64";
                goto end64;
            }
            else
            {
                decimal L = mry_e.Value - 64;
                mry_e.Value = L;
                goto end64;
            }

        end64:;
        }

        private void b128_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b128.Text == "+128")
            {
                goto plus128;
            }
            else
            {
                goto minus128;
            }
        plus128:
            try
            {
                decimal L2 = mry_e.Value + 128;
                mry_e.Value = L2;
                goto end128;
            }
            catch
            {
                if (mry_e.Value + 128 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+128\"에서 \"-128\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b128.Text = "-128";
                    goto end128;
                }
                else
                {
                    decimal L2 = mry_e.Value + 128;
                    mry_e.Value = L2;
                    goto end128;
                }
            }
        minus128:
            if (mry_e.Value - 128 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-128\"에서 \"+128\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b128.Text = "+128";
                goto end128;
            }
            else
            {
                decimal L = mry_e.Value - 128;
                mry_e.Value = L;
                goto end128;
            }

        end128:;
        }

        private void b256_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b256.Text == "+256")
            {
                goto plus256;
            }
            else
            {
                goto minus256;
            }
        plus256:
            try
            {
                decimal L2 = mry_e.Value + 256;
                mry_e.Value = L2;
                goto end256;
            }
            catch
            {
                if (mry_e.Value + 256 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+256\"에서 \"-256\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b256.Text = "-256";
                    goto end256;
                }
                else
                {
                    decimal L2 = mry_e.Value + 256;
                    mry_e.Value = L2;
                    goto end256;
                }
            }
        minus256:
            if (mry_e.Value - 256 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-256\"에서 \"+256\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b256.Text = "+256";
                goto end256;
            }
            else
            {
                decimal L = mry_e.Value - 256;
                mry_e.Value = L;
                goto end256;
            }

        end256:;
        }

        private void b512_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b512.Text == "+512")
            {
                goto plus512;
            }
            else
            {
                goto minus512;
            }
        plus512:
            try
            {
                decimal L2 = mry_e.Value + 512;
                mry_e.Value = L2;
                goto end512;
            }
            catch
            {
                if (mry_e.Value + 512 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+512\"에서 \"-512\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b512.Text = "-512";
                    goto end512;
                }
                else
                {
                    decimal L2 = mry_e.Value + 512;
                    mry_e.Value = L2;
                    goto end512;
                }
            }
        minus512:
            if (mry_e.Value - 512 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-512\"에서 \"+512\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b512.Text = "+512";
                goto end512;
            }
            else
            {
                decimal L = mry_e.Value - 512;
                mry_e.Value = L;
                goto end512;
            }

        end512:;
        }

        private void b1024_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b1024.Text == "+1024")
            {
                goto plus1024;
            }
            else
            {
                goto minus1024;
            }
        plus1024:
            try
            {
                decimal L2 = mry_e.Value + 1024;
                mry_e.Value = L2;
                goto end1024;
            }
            catch
            {
                if (mry_e.Value + 1024 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+1024\"에서 \"-1024\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b1024.Text = "-1024";
                    goto end1024;
                }
                else
                {
                    decimal L2 = mry_e.Value + 1024;
                    mry_e.Value = L2;
                    goto end1024;
                }
            }

        minus1024:
            if (mry_e.Value - 1024 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-1024\"에서 \"+1024\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b1024.Text = "+1024";
                goto end1024;
            }
            else
            {
                decimal L = mry_e.Value - 1024;
                mry_e.Value = L;
                goto end1024;
            }

        end1024:;
        }

        private void b5120_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b5120.Text == "+5120")
            {
                goto plus5120;
            }
            else
            {
                goto minus5120;
            }
            plus5120:
            try
            {
                decimal L2 = mry_e.Value + 5120;
                mry_e.Value = L2;
                goto end5120;
            }
            catch
            {
                if (mry_e.Value + 5120 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+5120\"에서 \"-5120\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b5120.Text = "-5120";
                    goto end5120;
                }
                else
                {
                    decimal L2 = mry_e.Value + 5120;
                    mry_e.Value = L2;
                    goto end5120;
                }
            }

        minus5120:
            if (mry_e.Value - 5120 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-5120\"에서 \"+5120\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b5120.Text = "+5120";
            }
            else
            {
                decimal L = mry_e.Value - 5120;
                mry_e.Value = L;
                goto end5120;
            }

        end5120:;
        }

        private void b8192_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (b8192.Text == "+8192")
            {
                goto plus8192;
            }
            else
            {
                goto minus8192;
            }
        plus8192:
            try
            {
                decimal L2 = mry_e.Value + 8192;
                mry_e.Value = L2;
                goto end8192;
            }
            catch
            {
                if (mry_e.Value + 8192 > 9007199254740992)
                {
                    MessageBox.Show("9007199254740992보다 큰 값으로 만들수 없습니다! \r\n \"+8192\"에서 \"-8192\"로 변경합니다", "에러", MessageBoxButtons.OK);
                    b8192.Text = "-8192";
                    goto end8192;
                }
                else
                {
                    decimal L2 = mry_e.Value + 8192;
                    mry_e.Value = L2;
                    goto end8192;
                }
            }

            minus8192:
            if (mry_e.Value - 8192 < 0)
            {
                MessageBox.Show("0Byte보다 작은 값으로 만들수 없습니다! \r\n \"-8192\"에서 \"+8192\"로 변경합니다", "에러", MessageBoxButtons.OK);
                b8192.Text = "+8192";
            }
            else
            {
                decimal L = mry_e.Value - 8192;
                mry_e.Value = L;
                goto end8192;
            }

        end8192:;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            url.Show();
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.InitialDirectory = @"C:\Program Files\Java\";
            }
            catch
            {
                try
                {
                    ofd.InitialDirectory = @"C:\Program Files (x86)\Java\";
                }
                catch
                {
                    ofd.InitialDirectory = @"C:\";
                }
            }
            finally
            {
                ofd.Title = "사용할 파일을 선택해 주세요";
                ofd.Filter = "자바파일 (java.exe) | java.exe";

                ofd.ShowDialog();

                string path = ofd.FileName;

                url.Text = ofd.FileName;


                switch (url.Text)
                {
                    case "":
                        url.Hide();
                        break;
                }
            }
            GC.Collect();
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Settings1 se = new Settings1();
            if (se.java == "False")
            {
                Form2 Frm2;
                Frm2 = new Form2();
                Frm2.Show();
                se.java = "True";
                se.Save();
            }
        }
        
        private static String not = "not";
        private static string filenr = Application.StartupPath + @"\User_Data\start.txt";
        private static string fileny = Application.StartupPath + @"\User_Data\start.bat";

        FileInfo filenrn = new FileInfo(filenr);
        FileInfo filenya = new FileInfo(fileny);
        private Form3 form3;
        private bool cane;

        private void button10_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Settings1 kmm = new Settings1();
            kmm.customJavaUrl = ((url.ToString() != null) ? "true" : "false");


            string nodata = Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml";
            FileInfo nodata1 = new FileInfo(nodata);


            kmm.Reload();
           


                int a = Convert.ToInt16(mry_e.Value);

                if (a != 0)
                {
                    goto ready1;
                }
                else
                {
                    goto errorP1;
                }

                ready1:
                switch (l1.Text)
                {
                    case "":
                        goto errorL2;
                }

                if (url.Visible)
                {
                    goto csm;
                }

                set:
            if (kmm.guimode == "True")
                {
                switch (ca1.Text)
                    {
                        case "MB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string textValue = " -Xmx" + mry_e.Text + "M -Xms" + mry_e.Text + "M -jar \"" + l1.Text + "\"";
                        //변수 넘기기
                        kmm.Ext = textValue.ToString();
                        kmm.extbool = "true";
                        kmm.Save();
                            //start GUI
                            cmdmode cdm3 = new cmdmode();
                            cdm3.Show();
                            if (kmm.svdt == "True")
                            {
                                XmlDocument doc = new XmlDocument();
                            
                                

                                XmlElement root = doc.CreateElement("Root");
                                XmlElement id = doc.CreateElement("ID");


                                XmlElement java = doc.CreateElement("java");
                                java.InnerText = not;
                                XmlElement ram = doc.CreateElement("ram");
                                ram.InnerText = mry_e.Text;
                                XmlElement ramtype = doc.CreateElement("ram-or");
                                ramtype.InnerText = "MB";
                                XmlElement jar = doc.CreateElement("jar");
                                jar.InnerText = l1.Text;

                                id.AppendChild(java);
                                id.AppendChild(ram);
                                id.AppendChild(ramtype);
                                id.AppendChild(jar);

                                root.AppendChild(id);

                                doc.AppendChild(root);

                           

                            string sfile2 = kmm.file + @".Xml";
                            
                                   
                                        if (kmm.file != "file1")
                                        {
                                            doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                            goto exit;
                                        }
                                        else
                                        {

                                            doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                            goto exit;
                                        
                                        }
                                    
                                
                                goto exit;
                            }
                            else
                            {
                                goto exit;
                            }

                        case "GB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string textValue1 = " -Xmx" + mry_e.Text + "G -Xms" + mry_e.Text + "G -jar \"" + l1.Text + "\"";
                        //add save batch files''
                        kmm.Ext = textValue1.ToString();
                        kmm.extbool = "true";
                        kmm.Save();
                        //start GUI
                        cmdmode cdm3G = new cmdmode();
                            cdm3G.Show();
                        if (kmm.svdt == "True")
                        {
                            XmlDocument doc = new XmlDocument();

                            XmlElement root = doc.CreateElement("Root");
                            XmlElement id = doc.CreateElement("ID");


                            XmlElement java = doc.CreateElement("java");
                            java.InnerText = not;
                            XmlElement ram = doc.CreateElement("ram");
                            ram.InnerText = mry_e.Text;
                            XmlElement ramtype = doc.CreateElement("ram-or");
                            ramtype.InnerText = "GB";
                            XmlElement jar = doc.CreateElement("jar");
                            jar.InnerText = l1.Text;

                            id.AppendChild(java);
                            id.AppendChild(ram);
                            id.AppendChild(ramtype);
                            id.AppendChild(jar);

                            root.AppendChild(id);

                            doc.AppendChild(root);


                            string sfile2 = kmm.file + @".Xml";


                            if (kmm.file != "file1")
                            {
                                doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }

                        }
                        else
                        {

                            goto exit;
                        }
                    }
                }
                else
                {
                    switch (ca1.Text)
                    {
                        case "MB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string savePath = Application.StartupPath + @"\User_Data\start.txt";
                            string textValue = "@ECHO OFF \r\n" + "cd %~dp0 \r\n" + "java" + " -Xms" + mry_e.Text + "M" + " -Xmx" + mry_e.Text + "M -jar " + "\"" + l1.Text + "\"" + "\r\n" + "Pause";
                        FileInfo chksavePath = new FileInfo(savePath);
                        if(chksavePath.Exists)
                        {
                            chksavePath.Delete();
                        }
                        System.IO.File.WriteAllText(savePath, textValue, Encoding.Default);
                        if (kmm.svdt == "True")
                        {
                                XmlDocument doc = new XmlDocument();

                                XmlElement root = doc.CreateElement("Root");
                                XmlElement id = doc.CreateElement("ID");


                                XmlElement java = doc.CreateElement("java");
                                java.InnerText = not;
                                XmlElement ram = doc.CreateElement("ram");
                                ram.InnerText = mry_e.Text;
                            XmlElement ramt = doc.CreateElement("ram-or");
                            ramt.InnerText = "MB";
                                XmlElement jar = doc.CreateElement("jar");
                                jar.InnerText = l1.Text;

                                id.AppendChild(java);
                                id.AppendChild(ram);
                            id.AppendChild(ramt);
                                id.AppendChild(jar);

                                root.AppendChild(id);

                                doc.AppendChild(root);


                            string sfile2 = kmm.file + @".Xml";


                            if (kmm.file != "file1")
                            {
                                doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }


                            goto setm;
                            }
                            else
                            {

                                goto setm;
                            }

                        case "GB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string savePath1 = Application.StartupPath + @"\User_Data\start.txt";
                            string textValue1 = "@ECHO OFF \r\n" + "cd %~dp0 \r\n" + "java" + " -Xms" + mry_e.Text + "G" + " -Xmx" + mry_e.Text + "G -jar " + "\"" + l1.Text + "\"" + "\r\n" + "Pause";
                        FileInfo chksavePath1 = new FileInfo(savePath1);
                        if (chksavePath1.Exists)
                        {
                            chksavePath1.Delete();
                        }
                        System.IO.File.WriteAllText(savePath1, textValue1, Encoding.Default);
                        if (kmm.svdt == "True")
                        {
                                XmlDocument doc = new XmlDocument();

                                XmlElement root = doc.CreateElement("Root");
                                XmlElement id = doc.CreateElement("ID");

                                XmlElement java = doc.CreateElement("java");
                                java.InnerText = not;
                                XmlElement ram = doc.CreateElement("ram");
                                ram.InnerText = mry_e.Text;
                            XmlElement ramt = doc.CreateElement("ram-or");
                            ramt.InnerText = "GB";
                                XmlElement jar = doc.CreateElement("jar");
                                jar.InnerText = l1.Text;

                                id.AppendChild(java);
                                id.AppendChild(ram);
                            id.AppendChild(ramt);
                                id.AppendChild(jar);

                                root.AppendChild(id);

                                doc.AppendChild(root);

                            string sfile2 = kmm.file + @".Xml";


                            if (kmm.file != "file1")
                            {
                                doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }


                            goto setm;
                            }
                            else
                            {

                                goto setm;
                            }
                    }
                    goto exit;
                }

                csm:
                if (kmm.guimode == "True")
                {
                    switch (ca1.Text)
                    {
                        case "MB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string textValue = " -Xmx" + mry_e.Text + "M" + " -Xms" + mry_e.Text + "M -jar " + "\"" + l1.Text + "\"";
                        //add save batch files''
                        kmm.Ext = textValue.ToString();
                        kmm.extbool = "false";
                        kmm.uJava = "\"" + url.Text.ToString() + "\"";
                        kmm.Save();
                            string savePath = Application.StartupPath + @"\User_Data\start.txt";
                        FileInfo chksavePath = new FileInfo(savePath);
                        if (chksavePath.Exists)
                        {
                            chksavePath.Delete();
                        }
                        System.IO.File.WriteAllText(savePath, textValue, Encoding.Default);
                            //txt to bat
                            string upDir = Application.StartupPath + @"\User_Data\";
                            string fileName = upDir + "start.txt";
                            string newName = upDir + "start.bat";
                            FileInfo fi = new FileInfo(fileName);
                        System.IO.FileInfo fe1 = new System.IO.FileInfo(newName);
                        if (fe1.Exists)
                        {
                            fe1.Delete();
                        }
                        fi.MoveTo(newName);
                            //start GUI
                            cmdmode cdm3T = new cmdmode();
                            cdm3T.Show();
                        if (kmm.svdt == "True")
                        {
                                XmlDocument doc1 = new XmlDocument();

                                XmlElement root1 = doc1.CreateElement("Root");
                                XmlElement id1 = doc1.CreateElement("ID");

                                XmlElement java = doc1.CreateElement("java");
                                java.InnerText = url.Text;
                                XmlElement ram1 = doc1.CreateElement("ram");
                                ram1.InnerText = mry_e.Text;
                            XmlElement ramt1 = doc1.CreateElement("ram-or");
                            ramt1.InnerText = "MB";
                                XmlElement jar1 = doc1.CreateElement("jar");
                                jar1.InnerText = l1.Text;

                                id1.AppendChild(java);
                                id1.AppendChild(ram1);
                            id1.AppendChild(ramt1);
                                id1.AppendChild(jar1);

                                root1.AppendChild(id1);

                                doc1.AppendChild(root1);

                            string sfile2 = kmm.file + @".Xml";


                            if (kmm.file != "file1")
                            {
                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }


                            goto exit;
                            }
                            else
                            {

                                goto exit;
                            }

                        case "GB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string textValue1 = " -Xmx" + mry_e.Text + "G" + " -Xms" + mry_e.Text + "G -jar " + "\"" + l1.Text + "\"";

                        kmm.Ext = textValue1.ToString();
                        kmm.extbool = "false";
                        kmm.uJava = "\"" + url.Text.ToString() + "\"";
                        kmm.Save();
                        string savePath1 = Application.StartupPath + @"\User_Data\start.txt";
                        FileInfo chksavePath1 = new FileInfo(savePath1);
                        if (chksavePath1.Exists)
                        {
                            chksavePath1.Delete();
                        }
                        System.IO.File.WriteAllText(savePath1, textValue1, Encoding.Default);

                        string upDir1 = Application.StartupPath + @"\User_Data\";
                            string fileName1 = upDir1 + "start.txt";
                            string newName1 = upDir1 + "start.bat";
                            FileInfo fi1 = new FileInfo(fileName1);
                        System.IO.FileInfo fe = new System.IO.FileInfo(newName1);
                        if (fe.Exists)
                        {
                            fe.Delete();
                        }
                        fi1.MoveTo(newName1);

                        cmdmode cdm3200 = new cmdmode();
                        cdm3200.Show();
                        if (kmm.svdt == "True")
                        {
                                XmlDocument doc1 = new XmlDocument();

                                XmlElement root1 = doc1.CreateElement("Root");
                                XmlElement id1 = doc1.CreateElement("ID");

                                XmlElement java = doc1.CreateElement("java");
                                java.InnerText = url.Text;
                                XmlElement ram1 = doc1.CreateElement("ram");
                                ram1.InnerText = mry_e.Text;
                            XmlElement ramt1 = doc1.CreateElement("ram-or");
                            ramt1.InnerText = "GB";
                                XmlElement jar1 = doc1.CreateElement("jar");
                                jar1.InnerText = l1.Text;

                                id1.AppendChild(java);
                                id1.AppendChild(ram1);
                            id1.AppendChild(ramt1);
                                id1.AppendChild(jar1);

                                root1.AppendChild(id1);
                            doc1.AppendChild(root1);

                            string sfile2 = kmm.file + @".Xml";
                            if (kmm.file != "file1")
                            {
                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }
                            goto exit;
                            }
                            else
                            {

                                goto exit;
                            }
                    }
                }
                else
                {
                    switch (ca1.Text)
                    {
                        case "MB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string savePath = Application.StartupPath + @"\User_Data\start.txt";
                            string textValue = "@ECHO OFF \r\n" + "cd %~dp0 \r\n" + "\"" + url.Text + "\"" + " -Xms" + mry_e.Text + "M" + " -Xmx" + mry_e.Text + "M -jar " + "\"" + l1.Text + "\"" + "\r\n" + "Pause";
                        FileInfo chksavePath = new FileInfo(savePath);
                        if (chksavePath.Exists)
                        {
                            chksavePath.Delete();
                        }
                        System.IO.File.WriteAllText(savePath, textValue, Encoding.Default);
                        if (kmm.svdt == "True")
                        {
                                XmlDocument doc1 = new XmlDocument();

                                XmlElement root1 = doc1.CreateElement("Root");
                                XmlElement id1 = doc1.CreateElement("ID");

                                XmlElement java = doc1.CreateElement("java");
                                java.InnerText = url.Text;
                                XmlElement ram1 = doc1.CreateElement("ram");
                                ram1.InnerText = mry_e.Text;
                            XmlElement ramt1 = doc1.CreateElement("ram-or");
                            ramt1.InnerText = "MB";
                                XmlElement jar1 = doc1.CreateElement("jar");
                                jar1.InnerText = l1.Text;

                                id1.AppendChild(java);
                                id1.AppendChild(ram1);
                            id1.AppendChild(ramt1);
                                id1.AppendChild(jar1);

                                root1.AppendChild(id1);

                                doc1.AppendChild(root1);

                            string sfile2 = kmm.file + @".Xml";
                            if (kmm.file != "file1")
                            {
                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }
                            goto setm;
                            }
                            else
                            {

                                goto setm;
                            }

                        case "GB":
                            if (filenrn.Exists)
                            {
                                filenrn.Delete();
                            }
                            else if (filenya.Exists)
                            {
                                filenya.Delete();
                            }

                            string savePath1 = Application.StartupPath + @"\User_Data\start.txt";
                            string textValue1 = "@ECHO OFF \r\n" + "cd %~dp0 \r\n" + "\"" + url.Text + "\"" + " -Xms" + mry_e.Text + "G" + " -Xmx" + mry_e.Text + "G -jar " + "\"" + l1.Text + "\"" + "\r\n" + "Pause";
                        FileInfo chksavePath1 = new FileInfo(savePath1);
                        if (chksavePath1.Exists)
                        {
                            chksavePath1.Delete();
                        }
                        System.IO.File.WriteAllText(savePath1, textValue1, Encoding.Default);
                        if (kmm.svdt == "True")
                        {
                                XmlDocument doc1 = new XmlDocument();

                                XmlElement root1 = doc1.CreateElement("Root");
                                XmlElement id1 = doc1.CreateElement("ID");

                                XmlElement java = doc1.CreateElement("java");
                                java.InnerText = url.Text;
                                XmlElement ram1 = doc1.CreateElement("ram");
                                ram1.InnerText = mry_e.Text;
                            XmlElement ramt1 = doc1.CreateElement("ram-or");
                            ramt1.InnerText = "GB";
                                XmlElement jar1 = doc1.CreateElement("jar");
                                jar1.InnerText = l1.Text;

                                id1.AppendChild(java);
                                id1.AppendChild(ram1);
                            id1.AppendChild(ramt1);
                                id1.AppendChild(jar1);

                                root1.AppendChild(id1);

                                doc1.AppendChild(root1);

                            string sfile2 = kmm.file + @".Xml";
                            if (kmm.file != "file1")
                            {
                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\" + sfile2);
                                goto exit;
                            }
                            else
                            {

                                doc1.Save(Application.StartupPath + @"\Program_Data\bin\cobin\file1.Xml");
                                goto exit;

                            }
                            goto setm;
                            }
                            else
                            {

                                goto setm;
                            }
                    }
                }
                goto exit;

                setm:
                {
                    string _Filestr = Application.StartupPath + @"\User_Data\start.bat";
                    System.IO.FileInfo fe = new System.IO.FileInfo(_Filestr);
                    if (fe.Exists)
                    {
                    fe.Delete();
                    }

                    string upDir = Application.StartupPath + @"\User_Data\";
                    string fileName = upDir + "start.txt";
                    string newName = upDir + "start.bat";
                    FileInfo fi = new FileInfo(fileName);
                    fi.MoveTo(newName);
                    Process.Start(Application.StartupPath + @"\User_Data\start.bat");
                    goto exit;
                }
                errorP1:
                {
                    MessageBox.Show("메모리 값을 설정해 주세요", "메모리 로딩 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                goto exit;
                errorL2:
                {
                    MessageBox.Show("코어 파일을 선택해주세요", "코어 파일 로딩 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                exit:
                {
                return;
                }
            
        }
        
        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (PP0.Checked == true)
            {
                b32.Text = "-32";
                b64.Text = "-64";
                b128.Text = "-128";
                b256.Text = "-256";
                b512.Text = "-512";
                b1024.Text = "-1024";
                b5120.Text = "-5120";
                b8192.Text = "-8192";
            }
            else
            {
                b32.Text = "+32";
                b64.Text = "+64";
                b128.Text = "+128";
                b256.Text = "+256";
                b512.Text = "+512";
                b1024.Text = "+1024";
                b5120.Text = "+5120";
                b8192.Text = "+8192";
            }
        }
        
        private void Main1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            date1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            timeHs.Text = DateTime.Now.ToString("HH:mm");
            timer1.Interval = 60000;
            timer1.Start();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            cmdmode Open = new cmdmode();
            Open.Show();
        }
        
        private void Main1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings1 mm = new Settings1();
            mm.Seton = "False";
            mm.MRCon = "False";
            mm.spngon = "False";
            mm.java = "False";
            mm.helpr = "False";
            mm.svr = "False";
            mm.iplist = "False";
            mm.est = "False";
            mm.Save(); ;

            string assf1 = Application.StartupPath + @"\Program_Data\bin\cobin\" + mm.file + @".Xml";
            FileInfo asmf = new FileInfo(assf1);
            if (!asmf.Exists || asmf.Length <= 0)
            {
                if (mm.file != "file1")
                {
                    mm.file = "file1";
                    mm.Save();
                }
                mm.svdt = "False";
                mm.Save();
            }
        }
    }
}
