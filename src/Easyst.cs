using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Net;

namespace 서버_구축기_V3._5
{
    public partial class Easyst : MetroFramework.Forms.MetroForm
    {
        public Easyst()
        {
            InitializeComponent();
        }

        private void Easyst_Load(object sender, EventArgs e)
        {
            try
            {
                Settings1 kmm = new Settings1();

                string apd1 = Application.StartupPath + @"\User_Data\server.properties";
                FileInfo ap = new FileInfo(apd1);
                if (!ap.Exists | ap.Length <= 0)
                {
                    b1.Enabled = false;
                    b1.Text = "파일없음";
                    return;
                }
                else
                {
                    b1.Enabled = false;
                    b1.Text = "로딩중";

                    string stsr;
                    StreamReader fo = new StreamReader(Application.StartupPath + @"\User_Data\server.properties");

                    //무엇...?
                    while (fo.EndOfStream == false)
                    {
                        stsr = fo.ReadLine();

                        if (stsr.Contains("server-ip="))
                        {
                            stsr = stsr.Substring(10);
                            address.Text = stsr.ToString();
                        }
                        else if (stsr.Contains("server-port="))
                        {
                            stsr = stsr.Substring(12);
                            port.Value = Convert.ToDecimal(stsr);
                        }
                        else if (stsr.Contains("level-name="))
                        {
                            stsr = stsr.Substring(11);
                            lvname.Text = stsr.ToString();
                        }
                        else if (stsr.Contains("difficulty="))
                        {
                            stsr = stsr.Substring(11);
                            switch (stsr.ToString())
                            {
                                case "0":
                                    {
                                        diff.Text = "평화로움";
                                        goto next;
                                    }
                                case "1":
                                    {
                                        diff.Text = "쉬움";
                                        goto next;
                                    }
                                case "2":
                                    {
                                        diff.Text = "보통";
                                        goto next;
                                    }
                                case "3":
                                    {
                                        diff.Text = "어려움";
                                        goto next;
                                    }
                            }
                            next:;
                        }
                        else if (stsr.Contains("max-players="))
                        {
                            stsr = stsr.Substring(12);
                            maxplayer.Text = stsr.ToString();
                        }
                        else if (stsr.Contains("gamemode="))
                        {
                            stsr = stsr.Substring(9);
                            switch (stsr.ToString())
                            {
                                case "0":
                                    {
                                        gmmode.Text = "서바이벌 (Survival)";
                                        goto next2;
                                    }
                                case "1":
                                    {
                                        gmmode.Text = "크리에이티브(Creative)";
                                        goto next2;
                                    }

                                case "2":
                                    {
                                        gmmode.Text = "어드벤쳐(Adventrue)";
                                        goto next2;
                                    }

                                case "3":
                                    {
                                        gmmode.Text = "관람[1.8 이상](Spectator)";
                                        goto next2;
                                    }
                            }
                            next2:;
                        }
                        else if (stsr.Contains("online-mode="))
                        {
                            stsr = stsr.Substring(12);
                            if (stsr.ToString() == "true")
                            {
                                online.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                online.Checked = false;
                            }
                        }
                        else if (stsr.Contains("pvp="))
                        {
                            stsr = stsr.Substring(4);
                            if (stsr.ToString() == "true")
                            {
                                pvp.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                pvp.Checked = false;
                            }
                        }
                        else if (stsr.Contains("spawn-animals="))
                        {
                            stsr = stsr.Substring(14);
                            if (stsr.ToString() == "true")
                            {
                                anispwn.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                anispwn.Checked = false;
                            }
                        }
                        else if (stsr.Contains("spawn-npcs="))
                        {
                            stsr = stsr.Substring(11);
                            if (stsr.ToString() == "true")
                            {
                                npspwn.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                npspwn.Checked = false;
                            }
                        }
                        else if (stsr.Contains("spawn-monsters="))
                        {
                            stsr = stsr.Substring(15);
                            if (stsr.ToString() == "true")
                            {
                                monspwn.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                monspwn.Checked = false;
                            }
                        }
                        else if (stsr.Contains("enable-command-block="))
                        {
                            stsr = stsr.Substring(21);
                            if (stsr.ToString() == "true")
                            {
                                cmbk.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                cmbk.Checked = false;
                            }
                        }
                        else if (stsr.Contains("white-list="))
                        {
                            stsr = stsr.Substring(11);
                            if (stsr.ToString() == "true")
                            {
                                wlist.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                wlist.Checked = false;
                            }
                        }
                        else if (stsr.Contains("hardcore="))
                        {
                            stsr = stsr.Substring(9);
                            if (stsr.ToString() == "true")
                            {
                                hardcore.Checked = true;
                            }
                            else if (stsr.ToString() == "false")
                            {
                                hardcore.Checked = false;
                            }
                        }
                        else if (stsr.Contains("op-permission-level="))
                        {
                            stsr = stsr.Substring(20);
                            oplv.Value = Convert.ToDecimal(stsr.ToString());
                        }
                        else if (stsr.Contains("max-world-size="))
                        {
                            stsr = stsr.Substring(15);
                            worldmaxsize.Value = Convert.ToDecimal(stsr.ToString());
                        }
                        else if (stsr.Contains("max-build-height="))
                        {
                            stsr = stsr.Substring(17);
                            maxheight.Value = Convert.ToDecimal(stsr.ToString());
                        }
                        else if (stsr.Contains("spawn-protection="))
                        {
                            stsr = stsr.Substring(17);
                            spawnprotect.Value = Convert.ToDecimal(stsr.ToString());
                        }
                    }
                    fo.BaseStream.Close();


                    b1.Enabled = true;
                    b1.Text = "저장";
                    return;
                }
            }
            catch
            {
                MessageBox.Show("문제가 발생하였습니다. 이지 셋팅을 이용할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(domain == false)
            {
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 46) //8:백스페이스,45:마이너스,46:소수점
                {
                    e.Handled = true;
                }
                return;
            }
            else
            {
                e.Handled = false;
                address.MaxLength = (int)2147483646;
                return;
            }
        }

        Boolean domain = false;
        private void metroToggle9_CheckedChanged(object sender, EventArgs e)
        {
            if (domainMode.Checked == true)
            {
                domain = true;
                address.MaxLength = (int)2147483646;
                return;
            }
            else
            {
                domain = false;
                address.MaxLength = (int)15;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static String data = null;
        private void b1_Click(object sender, EventArgs e)
        {
            b1.Enabled = false;
            try
            {
                string line = string.Empty;
                string dataurl = Application.StartupPath + @"\User_Data\server.properties";
                StreamReader file = new StreamReader(dataurl);
                data = file.ReadToEnd();

                //데이터가 누락되어 있다면 insert 시켜주는 곳
                //솔직히 왜 이렇게 했는지는 모르겠음.... 2018. 07. 24.
                if (!data.Contains("enable-command-block="))
                {
                    data = data.Insert(0, "enable-command-block=") + Environment.NewLine;
                }
                else if (!data.Contains("server-ip="))
                {
                    data = data.Insert(0, "server-ip=" + ((address.Text.ToString() != null) ? address.Text.ToString() : "")) + Environment.NewLine;
                }
                else if (!data.Contains("online-mode="))
                {
                    data = data.Insert(0, "online-mode=" + (online.Checked ? "true" : "false")) + Environment.NewLine;
                }
                else if (!data.Contains("level-name="))
                {
                    data = data.Insert(0, "level-name=" + ((lvname.Text.ToString() != null) ? lvname.Text.ToString() : "")) + Environment.NewLine;
                }
                else if (!data.Contains("pvp="))
                {
                    data = data.Insert(0, "pvp=" + (pvp.Checked ? "true" : "false")) + Environment.NewLine;
                }
                else if (!data.Contains("spawn-animals="))
                {
                    data = data.Insert(0, "spawn-animals=" + (anispwn.Checked ? "true" : "false")) + Environment.NewLine;
                }
                else if (!data.Contains("spawn-npcs="))
                {
                    data = data.Insert(0, "spawn-npcs=" + (npspwn.Checked ? "true" : "false")) + Environment.NewLine;
                }
                else if (!data.Contains("spawn-monsters="))
                {
                    data = data.Insert(0, "spawn-monsters=" + (monspwn.Checked ? "true" : "false")) + Environment.NewLine;
                }
                else if (!data.Contains("enable-command-block="))
                {
                    data = data.Insert(0, "enable-command-block=" + (cmbk.Checked ? "true" : "false") + Environment.NewLine);
                }
                else if (!data.Contains("white-list="))
                {
                    data = data.Insert(0, "white-list=" + (wlist.Checked ? "true" : "false") + Environment.NewLine);
                }
                else if (!data.Contains("hardcore="))
                {
                    data = data.Insert(0, "hardcore=" + (hardcore.Checked ? "true" : "false")) + Environment.NewLine;
                }
                else if (!data.Contains("server-port="))
                {
                    data = data.Insert(0, "server-port=" + ((port.Value.ToString() != null) ? port.Value.ToString() : "25565")) + Environment.NewLine;
                }
                else if (!data.Contains("difficulty="))
                {
                    data = data.Insert(0, "difficulty=" + ((diff.Text.ToString() == "평화로움") ? "0" : (diff.Text.ToString() == "쉬움") ? "1" : (diff.Text.ToString() == "보통") ? "2" : (diff.Text.ToString() == "어려움") ? "3" : "2")) + Environment.NewLine;
                }
                else if (!data.Contains("max-players="))
                {
                    data = data.Insert(0, "max-players=" + ((maxplayer.Text.ToString() != null) ? maxplayer.Text.ToString() : "20"));
                }
                else if (!data.Contains("gamemode="))
                {
                    data = data.Insert(0, "gamemode=" + ((gmmode.Text.ToString() == "서바이벌 (Survival)") ? "0" : (gmmode.Text.ToString() == "크리에이티브 (Creative)") ? "1" : (gmmode.Text.ToString() == "어드벤쳐 (Adventrue)") ? "2" : (gmmode.Text.ToString() == "관람[1.8 이상] (Spectator)") ? "3" : "0")) + Environment.NewLine;
                }
                else if (!data.Contains("op-permission-level="))
                {
                    data = data.Insert(0, "op-permission-level=" + ((oplv.Value.ToString() != null) ? oplv.Value.ToString() : "4")) + Environment.NewLine;
                }
                else if (!data.Contains("max-world-size="))
                {
                    data = data.Insert(0, "max-world-size=" + ((worldmaxsize.Value.ToString() != null) ? worldmaxsize.Value.ToString() : "29999984")) + Environment.NewLine;
                }
                else if (!data.Contains("max-build-height="))
                {
                    data = data.Insert(0, "max-build-height=" + ((maxheight.Value.ToString() != null) ? maxheight.Value.ToString() : "256")) + Environment.NewLine;
                }
                else if (!data.Contains("spawn-protection="))
                {
                    data = data.Insert(0, "spawn-protection=" + ((spawnprotect.Value.ToString() != null) ? spawnprotect.Value.ToString() : "16")) + Environment.NewLine;
                }

                file.BaseStream.Position = 0;
                while(!file.EndOfStream)
                {
                    line = file.ReadLine();
                    if (line.Contains("server-ip="))
                    {
                        if (data.Contains("server-ip=") & line.Contains("server-ip="))
                        {
                            data = data.Replace(line, "server-ip=" + ((address.Text.ToString() != null) ? address.Text.ToString() : ""));
                            continue;
                        }
                    }
                    else if (line.Contains("online-mode="))
                    {
                        if (data.Contains("online-mode=") & line.Contains("online-mode="))
                        {
                            data = data.Replace(line, "online-mode=" + (online.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("level-name="))
                    {
                        if (data.Contains("level-name=") & line.Contains("level-name="))
                        {
                            data = data.Replace(line, "level-name=" + ((lvname.Text.ToString() != null) ? lvname.Text.ToString() : ""));
                            continue;
                        }
                    }
                    else if (line.Contains("pvp="))
                    {
                        if (data.Contains("pvp=") & line.Contains("pvp="))
                        {
                            data = data.Replace(line, "pvp=" + (pvp.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("spawn-animals="))
                    {
                        if (data.Contains("spawn-animals=") & line.Contains("spawn-animals="))
                        {
                            data = data.Replace(line, "spawn-animals=" + (anispwn.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("spawn-npcs="))
                    {
                        if (data.Contains("spawn-npcs=") & line.Contains("spawn-npcs="))
                        {
                            data = data.Replace(line, "spawn-npcs=" + (npspwn.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("spawn-monsters="))
                    {
                        if (data.Contains("spawn-monsters=") & line.Contains("spawn-monsters="))
                        {
                            data = data.Replace(line, "spawn-monsters=" + (monspwn.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("enable-command-block="))
                    {
                        if (data.Contains("enable-command-block=") & line.Contains("enable-command-block="))
                        {
                            data = data.Replace(line, "enable-command-block=" + (cmbk.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("white-list="))
                    {
                        if (data.Contains("white-list=") & line.Contains("white-list="))
                        {
                            data = data.Replace(line, "white-list=" + (wlist.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("hardcore="))
                    {
                        if (data.Contains("hardcore=") & line.Contains("hardcore="))
                        {
                            data = data.Replace(line, "hardcore=" + (hardcore.Checked ? "true" : "false"));
                            continue;
                        }
                    }
                    else if (line.Contains("server-port="))
                    {
                        if (data.Contains("server-port=") & line.Contains("server-port="))
                        {
                            data = data.Replace(line, "server-port=" + ((port.Value.ToString() != null) ? port.Value.ToString() : "25565"));
                            continue;
                        }
                    }
                    else if (line.Contains("difficulty="))
                    {
                        if (data.Contains("difficulty=") & line.Contains("difficulty="))
                        {
                            data = data.Replace(line, "difficulty=" + ((diff.Text.ToString() == "평화로움") ? "0" : (diff.Text.ToString() == "쉬움") ? "1" : (diff.Text.ToString() == "보통") ? "2" : (diff.Text.ToString() == "어려움") ? "3" : "2"));
                            continue;
                        }
                    }
                    else if (line.Contains("max-players="))
                    {
                        if (data.Contains("max-players=") & line.Contains("max-players="))
                        {
                            data = data.Replace(line, "max-players=" + ((maxplayer.Text.ToString() != null) ? maxplayer.Text.ToString() : "20"));
                            continue;
                        }
                    }
                    else if (line.Contains("gamemode=") & !(line.Length > 10))
                    {
                        if (data.Contains("gamemode=") & line.Contains("gamemode="))
                        {
                            data = data.Replace(line, "gamemode=" + ((gmmode.Text.ToString() == "서바이벌 (Survival)") ? "0" : (gmmode.Text.ToString() == "크리에이티브 (Creative)") ? "1" : (gmmode.Text.ToString() == "어드벤쳐 (Adventrue)") ? "2" : (gmmode.Text.ToString() == "관람[1.8 이상] (Spectator)") ? "3" : "0"));
                            continue;
                        }
                    }
                    else if(line.Contains("op-permission-level="))
                    {
                        if(data.Contains("op-permission-level=") & line.Contains("op-permission-level="))
                        {
                            data = data.Replace(line, "op-permission-level=" + ((oplv.Value.ToString() != null) ? oplv.Value.ToString() : "4"));
                            continue;
                        }
                    }
                    else if(line.Contains("max-world-size="))
                    {
                        if(data.Contains("max-world-size=") & line.Contains("max-world-size="))
                        {
                            data = data.Replace(line, "max-world-size=" + ((worldmaxsize.Value.ToString() != null) ? worldmaxsize.Value.ToString() : "29999984"));
                            continue;
                        }
                    }
                    else if(line.Contains("max-build-height="))
                    {
                        if(data.Contains("max-build-height=") & line.Contains("max-build-height="))
                        {
                            data = data.Replace(line, "max-build-height=" + ((maxheight.Value.ToString() != null) ? maxheight.Value.ToString() : "256"));
                            continue;
                        }
                    }
                    else if(line.Contains("spawn-protection="))
                    {
                        if(data.Contains("spawn-protection=") & line.Contains("spawn-protection="))
                        {
                            data = data.Replace(line, "spawn-protection=" + ((spawnprotect.Value.ToString() != null) ? spawnprotect.Value.ToString() : "16"));
                            continue;
                        }
                    }
                }
                file.BaseStream.Close();

                File.WriteAllText(dataurl, data.ToString(), Encoding.Default);

                b1.Enabled = true;
                MessageBox.Show("저장 완료!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception a2)
            {
                b1.Enabled = true;
                MessageBox.Show(a2.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (domain == false)
            {
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
                return;
            }
            else
            {
                e.Handled = false;
                address.MaxLength = (int)2147483646;
                return;
            }
        }

        private void Easyst_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.est = "False";
           se.Save();
        }
    }
}
