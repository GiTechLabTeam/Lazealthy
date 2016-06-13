using System;
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
    public partial class FormMain : Form
    {
        private int _TimerCount = 0;
        private int _ConfiguredIntervalMinute = 40;

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
            this.notifyIconLazealthy.Text = startNotifier?"Lazealthy is running.": "Lazealthy stopped.";
            this.startNotifierToolStripMenuItem.Enabled = !startNotifier;
            this.stopNotifierToolStripMenuItem.Enabled = startNotifier;
            if (startNotifier)
                this.timerNotifier.Start();
            else
                this.timerNotifier.Stop();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormSetting_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowDeskTop();
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
            var currentSecond = _TimerCount % 60;
            var currentMinute = _TimerCount / 60;
            var currentHour = currentMinute / 60;
            var currentMinuteShow = currentMinute % 60;
            this.labelTimerCounter.Text = currentHour.ToString().PadLeft(2, '0') + ":" + currentMinuteShow.ToString().PadLeft(2, '0') + ":" + currentSecond.ToString().PadLeft(2, '0');
            if (_TimerCount <= 0)
            {
                stopNotifierToolStripMenuItem_Click(null, null);
                ShowDeskTop();
                DialogResult dr = MessageBox.Show(this, "Have a break and click Yes to start a new round.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    startNotifierToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            SetUIStatus(true);
            Hide();
            //this.WindowState = FormWindowState.Minimized;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                            "Lazealthy (Lazy + Healthy) is a tool & App which helps lazy or busy people to be healthy." + System.Environment.NewLine + System.Environment.NewLine +
                            "Github: https://github.com/GiTechLabTeam/Lazealthy",
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
    }
}
