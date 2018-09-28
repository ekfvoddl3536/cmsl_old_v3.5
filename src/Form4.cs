using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Timers;
using static MetroFramework.Forms.MetroForm;
using System.Threading;
using System.Timers;

namespace 서버_구축기_V3._5
{ 
    public partial class Form4 : MetroFramework.Forms.MetroForm, IDisposable
    {
        StringBuilder total = new StringBuilder(4096);
        String texter = String.Empty;
        Int32 R2x;
        System.Timers.Timer timer = new System.Timers.Timer();
        public Form4()
        {
            InitializeComponent();
        }

        void timer00_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true))
            {
                total.Clear();
                total.Append(ramCounter.NextValue().ToString());
                texter = total.ToString() + "MB";
                switch (metroComboBox1.Text)
                {
                    case "":
                        textBox1.Text = "0";
                        label1.Text = texter.ToString();
                        goto exit;

                    case "1/8 (12.5%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 8).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "1/5 (20.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 5).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "1/4 (25.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 4).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "1/3 (33.3%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 3).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "3/8 (37.5%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 8 * 3).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "2/5 (40.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 5 * 2).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "1/2 (50.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 2).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "3/5 (60.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 5 * 3).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "5/8 (62.5%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 8 * 5).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "2/3 (66.6%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 3 * 2).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "3/4 (75.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 4 * 3).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "4/5 (80.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 5 * 4).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "7/8 (87.5%)":
                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 8 * 7).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "9/10 (90.0%)":

                        textBox1.Text = Math.Ceiling((double)ramCounter.NextValue() / 10 * 9).ToString();
                        label1.Text = texter.ToString();
                        goto exit;

                    case "직접입력":
                        label1.Text = texter.ToString();
                        goto exit;
                }
                exit:
                if (metroToggle2.Checked)
                {
                    R2x = int.Parse(total.ToString()) - int.Parse(textBox1.Text);
                    CC.ForeColor = R2x <= 2048 ? Color.Red : Color.LawnGreen;
                    CC.Text = string.Format("{0:#,##0}", R2x) + "MB";
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(timeseter)).Start();
            timer = new System.Timers.Timer();
            timer.Interval = 400;
            timer.Elapsed += new ElapsedEventHandler(timer00_Elapsed);
            timer.Start();
        }

        void timeseter()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = "0";
            using (PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true))
            {
                label1.Text = ramCounter.NextValue().ToString() + "MB";
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked)
            {
                timer.Start();
                goto exit;
            }
            else
            {
                timer.Stop();
                goto exit;
            }
        exit:;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KK = Regex.Replace(label1.Text.ToString(), @"\D", "");
            int R2x = int.Parse(KK) - int.Parse(textBox1.Text);
            CC.Text = string.Format("{0:#,##0}", R2x) + "MB";
            if (R2x <= 2048)
            {
                CC.ForeColor = Color.Red;
            }
            else
            {
                CC.ForeColor = Color.LawnGreen;
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.MRCon = "False";
            se.Save();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if(new Regex(@"[MB]+").IsMatch(label1.Text))
            {
                using (PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true))
                {
                    label1.Text = ramCounter.NextValue().ToString() + "MB";
                }
            }
        }
    }
}
