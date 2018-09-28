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
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace 서버_구축기_V3._5
{
    public partial class iplist : MetroForm
    {
        public iplist()
        {
            InitializeComponent();
        }

        private void iplist_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(o)).Start();
        }

        void o()
        {
            textBox1.Text += "※실제 네트워크 속도와 다를 수 있습니다.\r\n\r\n";
            //cmd ipconfig로 대체
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (NetworkInterface adapter in interfaces)
            {
                var ipProps = adapter.GetIPProperties();

                decimal ko = 0;

                foreach (var ip in ipProps.UnicastAddresses)
                {
                    if ((adapter.OperationalStatus == OperationalStatus.Up)
                        && (ip.Address.AddressFamily == AddressFamily.InterNetwork))
                    {
                        ko = 0;
                        ko = adapter.Speed / 1000000;
                        if (ko >= 1000)
                        {
                            textBox1.Text += "주소 :: " + ip.Address.ToString() + "\r\n연결 :: " + adapter.Name.ToString() + "\r\n이름 :: " + adapter.Description.ToString() + "\r\n속도 :: " + adapter.Speed / 1000000000 + ".0Gbps" + "\r\n\r\n--------------------------------------------------\r\n\r\n";
                            continue;
                        }
                        else
                        {
                            textBox1.Text += "주소 :: " + ip.Address.ToString() + "\r\n이름 :: " + adapter.Name.ToString() + "\r\n어댑터 이름 :: " + adapter.Description.ToString() + "\r\n속도 :: " + ko + "Mbps" + "\r\n\r\n--------------------------------------------------\r\n\r\n";
                            continue;
                        }
                    }
                }
            }

            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.ScrollToCaret();
        }

        private void iplist_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1 se = new Settings1();
            se.iplist = "False";
            se.Save();
        }
    }
}
