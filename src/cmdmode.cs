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
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Management;
using System.Runtime.InteropServices;

namespace 서버_구축기_V3._5
{
    public partial class cmdmode : MetroFramework.Forms.MetroForm
    {
        private string Data;
        private Boolean helpdata;
        private delegate void textbox(string value);
        private delegate void textbox0(string val2);
        private delegate void inpt(string input);

        private textbox csst;
        private textbox0 amm;
        private inpt iput;

        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        // Environment.Is64BitOperatingSystem 라고 C#에서 지원하는 기능이 있습니다.
        // Environment.Is64BitOperatingSystem 쓰세요...
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }

        public cmdmode()
        {
            InitializeComponent();
        }

        void textbox1(String value)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(textbox1), new object[] { value });
                return;
            }
            textBox1.Text += "\r\n" + value;
            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.ScrollToCaret();
        }

        void txtbox(String val2)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(textbox1), new object[] { val2 });
            }
            textBox1.Text = "";
        }

        void stpr(String text)
        {
            if (this.inputcmd.InvokeRequired)
                this.inputcmd.Invoke(iput, text);
            else
                this.inputcmd.Text = text;
        }

        private string Java = kmm.uJava.ToString();
        private string shell = kmm.Ext.ToString();
        private static string start = Application.StartupPath + @"\User_Data\start.bat";
        private static string fuler = Application.StartupPath + @"\User_Data\";
        private static FileInfo startinfo = new FileInfo(start);

        private Boolean osverok = false;
        private Boolean JavaUnKnow = false;
        private Boolean checkernow = false;

        private void system_checker()
        {
            if (!checkernow)
            {
                checkernow = true;
                Control.CheckForIllegalCrossThreadCalls = false;
                string texter = string.Empty;
                texter += "----------information----------\r\nOS INFO:\r\n";

                string osver = string.Empty;
                if (Environment.OSVersion.Version.Major <= 4)
                {
                    osverok = false;
                    osver = "Windows" + ((Environment.OSVersion.Version.Minor == 0) ? " 95 / Windows NT 4.0" : (Environment.OSVersion.Version.Minor >= 10) ? " 98" : (Environment.OSVersion.Version.Minor >= 90) ? " Me" : "?");
                    goto javachker;
                }
                else if (Environment.OSVersion.Version.Major == 5)
                {
                    osverok = false;
                    osver = "Windows" + ((Environment.OSVersion.Version.Minor == 0) ? " 2000" : (Environment.OSVersion.Version.Minor == 1) ? "XP" : (Environment.OSVersion.Version.Minor == 2) ? " Professional x64 Edition / Windows Server 2003 R2 / Windows Home Server / Windows Server 2003" : "?");
                    goto javachker;
                }
                else if (Environment.OSVersion.Version.Major == 6)
                {
                    osverok = true;
                    osver = "Windows" + ((Environment.OSVersion.Version.Minor == 0) ? " Vista / Windows Server 2008" : (Environment.OSVersion.Version.Minor == 1) ? " 7 / Windows Server 2008 R2" : (Environment.OSVersion.Version.Minor == 2) ? " 8 / Windows 8.1 / Windows 10 / Windows Server 2012 / Windows Server 2012 R2 / Windows Server 2016" : "?");
                    goto javachker;
                }
                else if (Environment.OSVersion.Version.Major >= 10)
                {
                    osverok = true;
                    osver = "Windows 10 / Windows Server 2016";
                    goto javachker;
                }
                javachker:
                texter += osver.ToString() + Environment.NewLine + (is64BitOperatingSystem ? "== 64Bit ==\r\n" : "== 32Bit ==\r\n") + "\r\nJava INFO: ";
                if (kmm.customJavaUrl == "false")
                {
                    string javab = null;
                    string javafolder32 = @"C:\Program Files\Java\";
                    string javafolder64 = @"C:\Program Files (x86)\Java\";
                    DirectoryInfo java32 = new DirectoryInfo(javafolder32);
                    DirectoryInfo java64 = new DirectoryInfo(javafolder64);
                    if ((java32.Exists) | (java64.Exists))
                    {
                        DirectoryInfo[] Java = (java32.Exists ? java32.GetDirectories("*", System.IO.SearchOption.AllDirectories) : java64.Exists ? java64.GetDirectories("*", System.IO.SearchOption.AllDirectories) : java64.GetDirectories("*", System.IO.SearchOption.AllDirectories));
                        foreach (DirectoryInfo dinfo in Java)
                        {
                            if (dinfo.Name.Contains("jre"))
                            {
                                if (dinfo.Name.Contains("jre1.8.0_"))
                                {
                                    string javachk1 = dinfo.FullName + @"\bin\java.exe";
                                    FileInfo javachkb = new FileInfo(javachk1);
                                    if (javachkb.Exists)
                                    {
                                        string javal8 = dinfo.Name.Replace("jre1.8.0_", "");
                                        texter += "Java8 update" + javal8.ToString();
                                        goto close;
                                    }
                                }
                                else if ((dinfo.Name.Equals("jre7")) || (dinfo.Name.Equals("jre6")) || (dinfo.Name.Equals("jre5")) || (dinfo.Name.Equals("jre4")) || (dinfo.Name.Equals("jre3")) || (dinfo.Name.Equals("jre2")) || (dinfo.Name.Equals("jre1")))
                                {
                                    string javach = dinfo.FullName + @"\bin\java.exe";
                                    FileInfo javchb = new FileInfo(javach);
                                    if (javchb.Exists)
                                    {
                                        string javala = dinfo.Name.Replace("jre", "");
                                        javab = "Java" + ((javala.ToString() == "7") ? "7" : (javala.ToString() == "6") ? "6" : (javala.ToString() == "5") ? "5" : (javala.ToString() == "4") ? "4" : (javala.ToString() == "3") ? "3" : (javala.ToString() == "2") ? "2" : (javala.ToString() == "1") ? "1" : @"?");
                                        if (javab.ToString() == "Java?")
                                        {
                                            javab = "자바가 없습니다.";
                                            JavaUnKnow = true;
                                            break;
                                        }
                                    }
                                    else if (!javchb.Exists)
                                    {
                                        javab = "자바가 없습니다.";
                                        JavaUnKnow = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if((!java32.Exists) | (!java64.Exists))
                    {
                        javab = "자바가 설치되지 않았거나 탐지가 불가능합니다. 자바를 기본경로에 설치하지 않으셨다면 메인에 [Java.exe직접 선택]으로 자바경로를 수동으로 잡아주시길 바랍니다.";
                        JavaUnKnow = true;
                    }
                    texter += Environment.NewLine + javab;
                    javab = null;
                    close:

                    try
                    {
                        string procName = string.Empty;
                        ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor");
                        foreach (ManagementObject obj in win32Proc.Get())
                        {
                            procName = obj["Name"].ToString();
                            break;
                        }
                        texter += Environment.NewLine + Environment.NewLine + "CPU INFO:\r\n" + procName.ToString() + Environment.NewLine + "----------information----------";
                        textBox1.AppendText(Environment.NewLine + texter.ToString());
                        if (!JavaUnKnow)
                        {
                            if (metroToggle2.InvokeRequired)
                            {
                                metroToggle2.Invoke((MethodInvoker)delegate
                                {
                                    metroToggle2.Enabled = true;
                                });
                            }
                            else if (!metroToggle2.InvokeRequired)
                            {
                                metroToggle2.Enabled = true;
                            }
                        }
                        checkernow = false;
                        GC.Collect();
                        return;
                    }
                    catch
                    {
                        texter += Environment.NewLine + "\r\nCPU 정보를 가져오는데 실패했습니다.\r\n----------information----------\r\n";
                        textBox1.AppendText(Environment.NewLine + texter.ToString());
                        if (metroToggle2.InvokeRequired)
                        {
                            metroToggle2.Invoke((MethodInvoker)delegate
                            {
                                metroToggle2.Enabled = true;
                            });
                        }
                        else if (!metroToggle2.InvokeRequired)
                        {
                            metroToggle2.Enabled = true;
                        }
                        checkernow = false;
                        GC.Collect();
                    }
                }
            }
            else if(checkernow)
            {
                textBox1.AppendText(Environment.NewLine + "시스템 정보를 가져오는 중입니다.");
                return;
            }
        }

        private void cmdmode_Load(object sender, EventArgs e)
        {
            {
                textBox1.Text = "시스템 정보를 체크하는 중입니다.";
                if (metroToggle2.InvokeRequired)
                {
                    metroToggle2.Invoke((MethodInvoker)delegate
                    {
                        metroToggle2.Enabled = false;
                    });
                }
                else if (!metroToggle2.InvokeRequired)
                {
                    metroToggle2.Enabled = false;
                }
            }
            new Thread(new ThreadStart(system_checker)).Start();
            textbox1("\r\n\r\nGUI MODE [INFO :: v2018]\r\nGUI 구동 구현 성공! \r\n \r\n \r\n \r\n!help 명령어로 [프로그램 내 명령어]를 확인하실 수 있습니다.\r\n");

            ff:
            string s = Application.StartupPath + @"\User_Data\start.txt";
            FileInfo m = new FileInfo(s);
            m.Delete();


            if (JavaUnKnow)
            {
                if (metroToggle2.InvokeRequired)
                {
                    metroToggle2.Invoke((MethodInvoker)delegate
                    {
                        metroToggle2.Enabled = false;
                    });
                }
                else if (!metroToggle2.InvokeRequired)
                {
                    metroToggle2.Enabled = false;
                }
                return;
            }
        }

        private static bool starting = false;
        private static bool adding = true;

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle2.Checked == true)
            {
                if (starting)
                {
                    MessageBox.Show("이미 실행 중 입니다", "실행 중", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    starting = true;
                    new Thread(new ThreadStart(cc2)).Start();
                    metroToggle2.Enabled = false;
                    return;
                }
            }
            else
            {
                try
                {
                    Process[] pen = Process.GetProcessesByName("java");
                    if (pen.Length > 0)
                    {
                        for (int l = pen.Length; l == 0; l--)
                        {
                            pen[l].Kill();
                        }
                    }
                    Application.ExitThread();
                    Environment.Exit(0);
                    return;
                }
                catch
                {

                }
            }
        }

        private static Process q = new Process();

        private void cc2()
        {
            lock (this)
            {
                try
                {
                    serverend = false;
                    q = new Process();
                    Process[] pen = Process.GetProcessesByName("java");
                    if (pen.Length > 0)
                    {
                        pen[0].Kill();
                    }

                    ProcessStartInfo a = q.StartInfo;
                    if (kmm.extbool == "false")
                    {
                        a.FileName = (this.Java ?? "") ?? "";
                        a.Arguments = "-Djline.terminal=jline.UnsupportedTerminal" + shell.ToString();
                    }
                    else if(kmm.extbool == "true")
                    {
                        a.FileName = "cmd.exe";
                    }
                    a.WorkingDirectory = Application.StartupPath + "\\User_Data";
                    a.UseShellExecute = false;
                    a.CreateNoWindow = true;
                    a.WindowStyle = ProcessWindowStyle.Hidden;
                    a.RedirectStandardInput = true;
                    a.RedirectStandardError = true;
                    a.RedirectStandardOutput = true;

                    q.ErrorDataReceived += new DataReceivedEventHandler(errordata);
                    q.OutputDataReceived += new DataReceivedEventHandler(errordata);

                    q.Start();
                    textbox1("GUI MODE [INFO :: X2017LT]\r\nGUI 구동 구현 성공! \r\n \r\n!경고! 프로그램 강제종료는 많은 오류를 발생시킵니다! \r\n※Sponge는 처음 로딩할 때 파일을 하나 다운받습니다. 프로그램이 멈춘게 아닙니다! \r\n \r\n \r\n");

                    if (kmm.extbool == "true")
                    {
                        q.StandardInput.WriteLine("cd " + fuler.ToString());
                        q.StandardInput.WriteLine("java -Djline.terminal=jline.UnsupportedTerminal" + shell.ToString());

                        clrtexto("");
                    }

                    q.BeginErrorReadLine();
                    q.BeginOutputReadLine();

                    goto exit;
                }
                catch (Exception mes)
                {
                    q.StandardInput.Close();
                    q.StandardOutput.Close();
                    q.CancelErrorRead();
                    q.CancelOutputRead();
                    q.CloseMainWindow();
                    q.Close();
                    Control.CheckForIllegalCrossThreadCalls = false;
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }

                    textBox1.AppendText(Environment.NewLine + "알 수 없는 오류로 인해 종료되었습니다.\r\n오류 정보:" + mes.Message.ToString() + Environment.NewLine + Environment.NewLine + "http://ekfvoddl3535.cafe24.com/xe/home (느림) 또는 http://blog.naver.com/ekfvoddl3535 (비교적 빠름) 에 오류 정보와 같이 제보해 주시길 바랍니다.");
                }
            }
            exit:;
        }
        private static string s = null;

        private void clrtexto(String value)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(clrtexto), new object[] { value });
            }
            textBox1.Text = value;
        }

        private Boolean serverend = false;
        private void errordata(object sendingProcess, DataReceivedEventArgs e)
        {
            this.Invoke((Action)delegate
            {
                if (e.Data.Contains("FAILED TO BIND TO PORT"))
                {
                    textBox1.AppendText("[알림/버그 정보 :: REPORT] 포트 오류 입니다.");
                }
                else if (e.Data.Contains("eula.txt"))
                {
                    textBox1.AppendText("[알림/버그 정보 :: REPORT] 마인크래프트 EULA 동의가 필요합니다. \r\n[알림/버그 정보 :: REPORT] '메인 - 서버 관리 - EULA 동의'로 간편하게 해결 가능합니다.\r\n[알림/버그 정보 :: REPORT] 위 방법은 MOJANG의 EULA를 동의하시는 경우에만 해주시길 바랍니다.");
                }
                else if (e.Data.Contains("Done"))
                {
                    textBox1.AppendText("[" + System.DateTime.Now.ToString("HH:mm:ss") + " INFO]: 서버가 정상적으로 열렸습니다.");
                    loadcmomp = true;
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Stopping server"))
                {
                    serverend = true;
                    textBox1.AppendText("[" + System.DateTime.Now.ToString("HH:mm:ss") + " INFO]: 서버가 닫혔습니다. ");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Previous builds of JRE version 1.8 will not work"))
                {
                    textBox1.AppendText("[오류 정보] 자바8을 설치해주세요(또는 업데이트 해주시길 바랍니다.)");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Error occurred during initialization of VM Could not reserve enough space for"))
                {
                    textBox1.AppendText("[오류 정보] 설정하신 메모리가 실제 메모리 용량보다 큽니다.");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Error: Could not create the Java Virtual Machine."))
                {
                    textBox1.AppendText("[알 수 없는 오류 목록]");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Error occurred during initialization of VM"))
                {
                    textBox1.AppendText("[메모리 값을 확인해 주세요]");

                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Exception in thread \"main\" java.lang.NoClassDefFoundError"))
                {
                    textBox1.AppendText("[탐지만 되는 오류입니다]");
                    textBox1.AppendText("[자바를 탐지하지 못해서 발생하는 오류일 가능성이 있습니다. 자바가 설치되어 있으시다면, 자바경로를 수동으로 설정해보시는것을 추천드립니다.] ");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                    }
                }
                else if (e.Data.Contains("Invalid or corrupt jarfile"))
                {
                    textBox1.AppendText("[탐지만 되는 오류입니다]");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                        starting = false;
                        metroToggle2.Checked = false;

                        textBox1.Clear();

                        q.StandardInput.Close();
                        q.StandardOutput.Close();
                        q.StandardError.Close();
                        q.CancelErrorRead();
                        q.CancelOutputRead();
                        q.CloseMainWindow();
                        q.Close();

                        intxt.Clear();

                        textBox1.Clear();
                        textBox1.Clear();
                    }
                    else
                    {
                        metroToggle2.Enabled = true;
                        starting = false;
                        metroToggle2.Checked = false;

                        textBox1.Clear();

                        q.StandardInput.Close();
                        q.StandardOutput.Close();
                        q.StandardError.Close();
                        q.CancelErrorRead();
                        q.CancelOutputRead();
                        q.CloseMainWindow();
                        q.Close();

                        intxt.Clear();

                        textBox1.Clear();
                        textBox1.Clear();
                    }
                }
                else if (e.Data.Contains("Exception"))
                {
                    textBox1.AppendText("[오류] 정보>");
                    if (metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Invoke((MethodInvoker)delegate
                        {
                            metroToggle2.Enabled = true;
                        });
                        starting = false;
                        metroToggle2.Checked = false;

                        textBox1.Clear();

                        q.StandardInput.Close();
                        q.StandardOutput.Close();
                        q.StandardError.Close();
                        q.CancelErrorRead();
                        q.CancelOutputRead();
                        q.CloseMainWindow();
                        q.Close();

                        intxt.Clear();

                        textBox1.Clear();
                        textBox1.Clear();
                    }
                    else if (!metroToggle2.InvokeRequired)
                    {
                        metroToggle2.Enabled = true;
                        starting = false;
                        metroToggle2.Checked = false;

                        textBox1.Clear();

                        q.StandardInput.Close();
                        q.StandardOutput.Close();
                        q.StandardError.Close();
                        q.CancelErrorRead();
                        q.CancelOutputRead();
                        q.CloseMainWindow();
                        q.Close();

                        intxt.Clear();

                        textBox1.Clear();
                        textBox1.Clear();
                    }
                }

                //출력
                textBox1.AppendText(Environment.NewLine + e.Data.ToString());
                if (e.Data.Contains(">java"))
                {
                    clrtexto("제작 : Super Comic\r\n");
                }
                else if (helpdata == true & e.Data == null)
                {
                    textBox1.AppendText("[INFO] help 대신 ?를 사용해 보세요!");
                    helpdata = false;
                }
                exit:;
            });
        }

        static Boolean loadcmomp = false;
        static Boolean edxi = false;

        private static Settings1 kmm = new Settings1();
        static Boolean performanceinfoform = false;
        static String edxiurl = string.Empty;
        static String errorCode0 = string.Empty;
        static String ErrorData = string.Empty;
        static String errorCode1 = string.Empty;
        static String isue = string.Empty;
        static String res = string.Empty;

        private static void edxir0()
        {
            CheckForIllegalCrossThreadCalls = false;
            return;
        }

        private static void edxir1()
        {
            CheckForIllegalCrossThreadCalls = false;
            return;
        }

        private async void command()
        {
            if (intxt.Text == "!help")
            {
                intxt.Clear();

                textBox1.AppendText("\r\n!help - 프로그램 내 명령어를 봅니다.\r\n" +
                 "!clr - 출력창을 지웁니다.\r\n" +
                 "!info - 프로그램 정보를 봅니다.\r\n" +
                 "!logging - 현재 출력된 내용을 \"" + Application.StartupPath + @"\logging" + kmm.logging + ".txt\"에 기록합니다.\r\n" +
                 "!log - 로그 옵션을 봅니다.\r\n" +
                 "!systeminfo - 시스템 정보를 출력시켜줍니다.(!sinfo 도 됩니다)\r\n");
                return;
            }
            else if (intxt.Text == "!clr")
            {
                intxt.Clear();

                textBox1.Clear();
            }
            else if (intxt.Text == "!info")
            {
                intxt.Clear();

                textBox1.AppendText("\r\n프로그램 버전: V4.5 PREMIUM\r\nGUI MODE Version: V2.0\r\n"); //업데이트 수정
                return;
            }
            else if (intxt.Text == "!systeminfo" | intxt.Text == "!sinfo")
            {
                intxt.Clear();
                new Thread(new ThreadStart(system_checker)).Start();
                return;
            }
            else if (intxt.Text == "!logging")
            {
                intxt.Clear();

                StreamWriter Abc;

                int VB = Convert.ToInt16(kmm.logging);
                VB++;
                Abc = File.CreateText(Application.StartupPath + @"\logging" + kmm.logging + @".txt");
                await Abc.WriteLineAsync(textBox1.Text);
                Abc.Close();
                kmm.logging = VB.ToString();
                kmm.Save();
                textBox1.AppendText("\r\n로그를 기록했습니다.\r\n");
                return;
            }
            else if (intxt.Text == "!log")
            {
                intxt.Clear();

                textBox1.AppendText("\r\n!log -reset : 로그를 초기화 시킵니다.\r\n");
                return;
            }
            else if(intxt.Text == "!srvdata")
            {
                intxt.Clear();

                textBox1.AppendText("\r\n" + shell.ToString());
                return;
            }
            else if (intxt.Text == "!log -reset")
            {
                lock (this)
                {
                    intxt.Clear();

                    int p = Convert.ToInt16(kmm.logging);
                    for (int i = 1; i != p; i++)
                    {
                        string K = Application.StartupPath + @"\logging" + i + @".txt";
                        FileInfo kdel = new FileInfo(K);
                        if (kdel.Exists)
                        {
                            kdel.Delete();
                        }
                    }
                    textBox1.AppendText("\r\n로그를 초기화 했습니다.");
                }
                kmm.logging = "1";
                kmm.Save();
                return;
            }
            // 서버 명령어
            else if (starting)
            {
                if (intxt.Text == "help")
                {
                    helpdata = true;
                }
                q.StandardInput.WriteLine(this.intxt.Text);
                this.intxt.Clear();

                return;
            }
            else
            {
                intxt.Clear();
                textBox1.AppendText("\r\n알 수 없는 명령어입니다, !help로 프로그램 내 명령어를 확인하실 수 있습니다\r\n");
                return;
            }
        }

        private async void inputcmd_Click(object sender, EventArgs e)
        {
            command();
        }

        private void intxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }

        private async void intxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                command();
            }
        }

        private void cmdmode_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (starting)
                {
                    DialogResult dr = MessageBox.Show("서버를 OFF로 전환하고 창을 닫아주세요", "오류 방지", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Retry)
                    {
                        if (starting)
                        {
                            MessageBox.Show("서버를 OFF로 전환하고 창을 닫아주세요", "오류 방지", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch
            {
                e.Cancel = false;
            }
        }
    }
}
