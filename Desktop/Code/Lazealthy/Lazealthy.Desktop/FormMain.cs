using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lazealthy.Desktop
{
    //https://github.com/praeclarum/sqlite-net
    //https://github.com/praeclarum/sqlite-net/wiki

    public partial class FormMain : Form
    {
        private int _TimerCount = 0;
        private int _ConfiguredIntervalMinute = 40;

        string NotificationMessage
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["NotificationMessage"].ToString().Replace("\\r\\n", System.Environment.NewLine);
                }
                catch
                {
                    return "Stand up and have a break and click Yes to start a new round.";
                }
            }
        }

        /// <summary>
        /// It seems that this method does not work in Windows 10.
        /// </summary>
        private void ShowDeskTop()
        {
            Type shellType = Type.GetTypeFromProgID("Shell.Application");
            object shellObject = System.Activator.CreateInstance(shellType);
            shellType.InvokeMember("ToggleDesktop", System.Reflection.BindingFlags.InvokeMethod, null, shellObject, null);
        }

        private void SetUIStatus(bool startNotifier)
        {
            int.TryParse(ConfigurationManager.AppSettings["NotifierIntervalMinute"].ToString(), out _ConfiguredIntervalMinute);
            _TimerCount = _ConfiguredIntervalMinute * 60;
            this.labelTimerCounter.Text = GetCurrentTimeCount(_TimerCount);
            this.notifyIconLazealthy.Text = startNotifier?"Lazealthy is running.": "Lazealthy stopped.";
            this.startNotifierToolStripMenuItem.Enabled = !startNotifier;
            this.stopNotifierToolStripMenuItem.Enabled = startNotifier;
            if (startNotifier)
            {
                this.timerNotifier.Start();
                this.notifyIconLazealthy.ShowBalloonTip(3000);
            }
            else
            {
                this.timerNotifier.Stop();
            }
        }

        private string GetCurrentTimeCount(int timeCount)
        {
            var currentSecond = timeCount % 60;
            var currentMinute = timeCount / 60;
            var currentHour = currentMinute / 60;
            var currentMinuteShow = currentMinute % 60;
            return currentHour.ToString().PadLeft(2, '0') + ":" + currentMinuteShow.ToString().PadLeft(2, '0') + ":" + currentSecond.ToString().PadLeft(2, '0');
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormSetting_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIconLazealthy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerNotifier_Tick(object sender, EventArgs e)
        {
            _TimerCount--;                       
            this.labelTimerCounter.Text = GetCurrentTimeCount(_TimerCount);
            if (_TimerCount <= 0)
            {
                stopNotifierToolStripMenuItem_Click(null, null);
                ShowDeskTop();
                DialogResult dr = MessageBox.Show(this, NotificationMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    startNotifierToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            SetUIStatus(true);
            this.WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                            "Lazealthy (Lazy + Healthy) is a tool & App which helps lazy or busy people to be healthy." + System.Environment.NewLine + System.Environment.NewLine +
                            "Why not stop sitting like a potato? Stand up to have something to drink!" + System.Environment.NewLine + System.Environment.NewLine +
                            "Author: Yang SHEN",
                            "About Lazealthy",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void startNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUIStatus(true);
        }

        private void stopNotifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUIStatus(false);
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            var configurationFolder = asm.Location.Substring(0, asm.Location.LastIndexOf(@"\")) + @"\";
            if (Directory.Exists(configurationFolder))
            {
                try
                {
                    System.Diagnostics.Process.Start("Explorer.exe", configurationFolder);
                }
                catch { }
            }
        }
    }
}
