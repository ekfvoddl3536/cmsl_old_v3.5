using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MetroFramework.Forms.MetroForm;
using System.Net.NetworkInformation;

namespace 서버_구축기_V3._5
{
    public partial class downloadCenter : MetroFramework.Forms.MetroForm
    {
        private PerformanceCounter nctr;

        private delegate void CSafeSetText(string text);
        private delegate void CSafeSetMaximum(Int32 value);
        private delegate void CSafeSetValue(Int32 value);

        private CSafeSetMaximum cssm;
        private CSafeSetValue cssv;
        private CSafeSetText csst;
        private WebClient wc;
        private Boolean setBaseSize;
        private Boolean nowDownloading;

        Stopwatch sw = new Stopwatch();
        
        public downloadCenter()
        {
            csst = new CSafeSetText(CrossSafeSetTextMethod);
            cssm = new CSafeSetMaximum(CrossSafeSetMaximumMethod);
            cssv = new CSafeSetValue(CrossSafeSetValueMethod);

            wc = new WebClient();

            InitializeComponent();
        }
        
        private void downloadCenter_Load(object sender, EventArgs e)
        {
            vv.Hide();
        }
        
        // 이런게 약 50개(더 있을수도 있고) 있어서 2400줄 넘음
        // 코드가 메시지 박스 내 버전 표기, 주소, 파일이름 3가지만 다르기때문에 궂이 2400줄을...
        void metroLink1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (nowDownloading)
            {
                MessageBox.Show("다운로드가 진행 중입니다.", "진행중 알림", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dr = MessageBox.Show("SpongeVanilla[1.8-3.1.0-BETA171]을(를) 다운로드 합니까?", "사용자 확인중...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                sw.Start();

                metroProgressBar1.Value = 0;
                speed.Text = (int)0 + "KB/s";
                setBaseSize = false;
                nowDownloading = true;

                WebClient wc2 = new WebClient();

                wc2.DownloadProgressChanged += new DownloadProgressChangedEventHandler(pbchange);
                wc2.DownloadFileCompleted += new AsyncCompletedEventHandler(exitSpongeVanilla18);

                wc2.Headers.Add("User-Agent",
                   "Mozilla/5.0 (compatible; MSIE 11.0; Windows NT 10.0; WOW64; Trident/7.0)");

                string re = "http://repo.spongepowered.org/maven/org/spongepowered/spongevanilla/1.8-3.1.0-BETA-171/spongevanilla-1.8-3.1.0-BETA-171.jar";

                wc2.DownloadFileAsync(new Uri(re), Application.StartupPath + @"\Program_Data\Core\Sponge\spongevanilla-1.8-3.1.0-BETA-171.jar");
                MessageBox.Show("파일을 다운로드 중입니다... \r\n다운로드가 완료되면 알려드립니다.", "다운로드 시작", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        void CrossSafeSetValueMethod(Int32 value)
        {
            if (metroProgressBar1.InvokeRequired)
                metroProgressBar1.Invoke(cssm, value);
            else
                metroProgressBar1.Value = value;
        }

        void CrossSafeSetMaximumMethod(Int32 value)
        {
            if (metroProgressBar1.InvokeRequired)
                metroProgressBar1.Invoke(cssm, value);
            else
                metroProgressBar1.Maximum = value;
        }

        void CrossSafeSetTextMethod(String text)
        {
            if (vv.InvokeRequired)
                vv.Invoke(csst, text);
            else
                vv.Text = text;
        }

        void pbchange(object sender, DownloadProgressChangedEventArgs e)
        {
            vv.Show();
            if (!setBaseSize)
            {
                CrossSafeSetMaximumMethod((int)e.TotalBytesToReceive);
                setBaseSize = true;
            }
            
            CrossSafeSetValueMethod((int)e.BytesReceived);

            CrossSafeSetTextMethod(String.Format("{0:N3}MB / {1:N3}MB ({2:P})", e.BytesReceived / 1024d / 1024d, e.TotalBytesToReceive / 1024d / 1024d, (Double)e.BytesReceived / (Double)e.TotalBytesToReceive));
            speed.Text = String.Format("{0:N2}KB/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
        }

        void exitSpongeVanilla18(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            nowDownloading = false;
            MessageBox.Show("다운로드 완료", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Gray;
            Process.Start("explorer.exe", "https://repo.spongepowered.org/maven/org/spongepowered/spongevanilla/");
        }
        
        private void metroLink3_Click(object sender, EventArgs e)
        {
            Process.Start("https://forums.spongepowered.org/c/plugins/plugin-releases");
        }
    }
}
