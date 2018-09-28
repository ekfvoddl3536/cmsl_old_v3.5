using 서버_구축기_V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Configuration;
using System.Threading;

namespace 서버_구축기_V3._5
{
    static class Program
    {
        private static Settings1 mpm = new Settings1();
        private static string eulaskip = mpm.lisk;
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Process[] pen2 = Process.GetProcessesByName("java");
                if (pen2.Length > 0)
                {
                    DialogResult qs = MessageBox.Show("Java.exe 프로세서가 작동되고 있습니다.\r\nGUI 구동시 자동 종료 되지만, 지금 종료하시겠습니까?", "사용자 응답을 기다리는 중...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (qs == DialogResult.Yes)
                    {
                        pen2[0].Kill();
                    }
                }

                bool cancel = false;
                string[,] rev = new string[3, 10];
                rev[1, 1] = @"\MetroFramework.Design.dll";
                rev[1, 2] = @"\MetroFramework.dll";
                rev[2, 1] = @"\Program_Data";
                rev[2, 2] = @"\Program_Data\bin";
                rev[1, 3] = @"\Program_Data\bin\eula.txt";
                rev[2, 3] = @"\Program_Data\bin\cobin";
                rev[1, 4] = @"\Program_Data\bin\cobin\sfile.txt";
                rev[2, 4] = @"\Program_Data\Core";
                rev[2, 5] = @"\Program_Data\Core\Craftbukkit";
                rev[2, 6] = @"\Program_Data\Core\Spigot";
                rev[2, 7] = @"\Program_Data\Core\Sponge";
                rev[2, 8] = @"\Program_Data\Core\Sponge\Forge";
                rev[2, 9] = @"\User_Data";

                for (int i = 0; i < 14; i++)
                {
                    if (i >= 9 & i <= 12)
                    {
                        string pp = rev.GetValue(1, (i - 8)).ToString();
                        FileInfo mp = new FileInfo(Application.StartupPath + rev.GetValue(1, (i - 8)).ToString());
                        if (!mp.Exists)
                        {
                            if (pp.ToString() == @"\Program_Data\bin\cobin\sfile.txt")
                            {
                                System.IO.File.WriteAllText(Application.StartupPath + pp.ToString(), "file1", Encoding.Default);
                            }
                            else if (pp.ToString() == @"\Program_Data\bin\eula.txt")
                            {
                                System.IO.File.WriteAllText(Application.StartupPath + pp.ToString(), @"#By changing the setting below to TRUE you are indicating your agreement to our EULA" + Environment.NewLine + @"(https://account.mojang.com/documents/minecraft_eula)." + Environment.NewLine + @"#Sun Jan 10 13:49:24 KST 2016" + Environment.NewLine + @"eula=true", Encoding.Default);
                            }
                            else if (pp.ToString() == @"\MetroFramework.Design.dll" | pp.ToString() == @"\MetroFramework.dll")
                            {
                                MessageBox.Show(pp.ToString() + Environment.NewLine + "...가(이) 없습니다. 재설치를 권장드립니다.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Process.Start("explorer.exe", "http://ekfvoddl3535.cafe24.com/xe/server_maker");
                                cancel = true;
                            }
                        }
                    }
                    else if (i >= 0 & i <= 8)
                    {
                        DirectoryInfo mpd = new DirectoryInfo(Application.StartupPath + rev.GetValue(2, (i + 1)).ToString());
                        if (!mpd.Exists)
                        {
                            mpd.Create();
                        }
                    }
                    if (cancel)
                    {
                        Application.ExitThread();
                        Application.Exit();
                        return;
                    }
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                string resetting = Application.StartupPath + @"\reset.rstd";
                FileInfo reset = new FileInfo(resetting);
                if (reset.Exists)
                {
                    Settings1 a1 = new Settings1();
                    try
                    {
                        a1.Reset();
                        a1.Save();
                        goto aty1;
                    }
                    catch
                    {
                        a1.Reset();
                    }
                    aty1:
                    MessageBox.Show("프로그램 설정이 초기화 되었습니다.");
                    reset.Delete();
                    try
                    {
                        a1.Upgrade();
                        a1.Save();
                    }
                    catch
                    {

                    }
                    Application.ExitThread();
                    Application.Exit();
                }
                // Application.Run(new Main1());
                if (eulaskip.ToString() == "true")
                {
                    Application.Run(new Main1());
                    return;
                }
                Application.Run(new Form3());
            }
            catch (Exception errore)
            {
                MessageBox.Show(errore.Message.ToString(), "오류 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
