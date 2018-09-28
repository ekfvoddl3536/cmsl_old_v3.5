using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MetroFramework.Forms.MetroForm;

namespace 서버_구축기_V3._5
{
    public partial class Setting : MetroFramework.Forms.MetroForm
    {
        Settings1 setting = new Settings1();
        private IMyInterface ser1 = null;
        
        // public Setting() { }
        
        public Setting(IMyInterface ser1)
        {
            InitializeComponent();
            this.ser1 = ser1;
        }


        public void metroTrackBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            this.metroLabel2.Text = metroTrackBar1.Value.ToString() + "%";
            GC.Collect();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            Settings1 kam = new Settings1();
            button1.Hide();
            if (kam.lisk == "true")
            {
                metroToggle1.Checked = true;
                goto next;
            }
            else
            {
                metroToggle1.Checked = false;
                goto next;
            }
        next:
            {
                if (kam.opab == "True")
                {
                    try
                    {
                        decimal f = Convert.ToDecimal(kam.opa);
                        decimal K = f * 100;
                        string PP = string.Format("{0:#,##0}", K);
                        metroLabel2.Text = "[" + PP + "]%";
                        metroTrackBar1.Value = Convert.ToInt16(PP);
                        GC.Collect();
                    }
                    catch
                    {
                        metroLabel2.Text = "[100]%";
                        metroTrackBar1.Value = 100;
                    }
                    goto aff;
                }
                else
                {
                    goto exit;
                }
                aff:
                {
                    if (kam.sltac == "True")
                    {
                        metroToggle2.Checked = true;
                        goto exit;
                    }
                    else
                    {
                        metroToggle2.Checked = false;
                        goto exit;
                    }
                }
                exit:
                {
                    if (kam.guimode == "True")
                    {
                        metroToggle3.Checked = true;
                        goto exit2;
                    }
                    else
                    {
                        metroToggle3.Checked = false;
                        goto exit2;
                    }
                }
                exit2:
                {
                    if (kam.svdt == "True")
                    {
                        metroToggle4.Checked = true;
                        goto exit3;
                    }
                    else
                    {
                        metroToggle4.Checked = false;
                        goto exit3;
                    }
                }
                exit3:;
            }
        }

        private void metroTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            Settings1 kam = new Settings1();
            kam.opa = Convert.ToString(metroTrackBar1.Value * 0.01);
            kam.Save();
            string aak = Convert.ToString(metroTrackBar1.Value * 0.01);
            ser1.SetData(aak);
            GC.Collect();
        }
        

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            switch (metroToggle1.Checked)
            {
                case true:
                    setting.lisk = "true";
                    setting.Save();
                    goto exit;

                case false:
                    setting.lisk = "false";
                    setting.Save();
                    goto exit;
            }
        exit:;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("현재 내용을 저장하시겠습니까?", "확인 메세지", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Settings1 kam = new Settings1();
                if (kam.opab == "True")
                    {
                        string str = metroLabel2.Text;
                        if (str == "[100]%")
                        {
                        kam.opab = "False";
                        kam.Save();
                        goto exit;
                        }
                        else
                        {
                            if (str == "100%")
                            {
                            kam.opab = "False";
                            kam.Save();
                            goto exit;
                            }
                            else
                            {
                            kam.opab = "True";
                            kam.Save();
                            goto exit;
                            }
                        }
                }
                else
                {
                    kam.opab = "True";
                    kam.Save();
                    goto exit;
                }
            }
        exit:;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Settings1 kam = new Settings1();
            try
            {

                metroLabel2.Text = "[100]%";
                metroTrackBar1.Value = 100;
                metroToggle1.Checked = false;
                metroToggle2.Checked = false;
                metroToggle3.Checked = false;

                kam.lisk = "false";
                kam.sltac = "True";
                kam.opab = "False";
                kam.guimode = "True";
                kam.Save();

                goto complete;
            }
            catch
            {

                MessageBox.Show("기본값으로 설정 하였습니다.","기본값", MessageBoxButtons.OK, MessageBoxIcon.Information);
                goto exit;
            }
        complete:
            {
                MessageBox.Show("기본값으로 설정 하였습니다.", "기본값", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        exit:;
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle2.Checked == true)
            {
                setting.sltac = "True";
                setting.Save();
                goto exit;
            }
            else
            {
                setting.sltac = "False";
                setting.Save();
                goto exit;
                
            }
        exit:;
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            switch (metroToggle3.Checked)
            {
                case true:
                    setting.guimode = "True";
                    setting.Save();
                    goto exit;

                case false:
                    setting.guimode = "False";
                    setting.Save();
                    goto exit;
            }
        exit:;
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            Settings1 kmm1 = new Settings1();
            if (metroToggle4.Checked == true)
            {
                setting.svdt = "True";
                setting.Save();
                button1.Show();
                goto exit;
            }
            else
            {
                setting.svdt = "False";
                setting.Save();

                loadForm ff2 = new loadForm();
                ff2.Close();
                kmm1.loaddataform = "False";
                kmm1.Save();
           

                button1.Hide();
                goto exit;
            }
            exit:;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings1 kmm1 = new Settings1();
            loadForm ff1 = new loadForm();
            ff1.Show();
            kmm1.loaddataform = "True";
            kmm1.Save();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://hangeul.naver.com/2014/nanum");
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.Seton = "False";
            se.Save();
        }
    }
}
