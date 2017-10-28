using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUnity
{
    /// <summary>
    /// https://docs.unity3d.com/Manual/CommandLineArguments.html
    /// </summary>
    public partial class ContainerForm : Form
    {
        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);

        public ContainerForm()
        {
            InitializeComponent();

            try
            {
                process = new Process();
                process.StartInfo.FileName = "gunshot.exe";
                //process.StartInfo.FileName = "K.Shot.exe"; // 유니티만 된다.

                process.StartInfo.Arguments = "-parentHWND " + selectablePanel.Handle.ToInt32() + " " + Environment.CommandLine;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                process.WaitForInputIdle();

                // 시간을 주어야 실행이 가능하다.
                //Thread.Sleep(5000);

                // Doesn't work for some reason ?!
                //unityHWND = process.MainWindowHandle;
                EnumChildWindows(selectablePanel.Handle, WindowEnum, IntPtr.Zero);

                //unityHWNDLabel.Text = "Unity HWND: 0x" + unityHWND.ToString("X8");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
        }

        private void ActivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
        }

        private void DeactivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            ActivateUnityWindow();
            return 0;
        }

        private void selectablePanel1_Resize(object sender, EventArgs e)
        {
            MoveWindow(unityHWND, 0, 0, selectablePanel.Width, selectablePanel.Height, true);
            ActivateUnityWindow();
        }

        // Close Unity application
        private void ContainerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                process.CloseMainWindow();

                Thread.Sleep(1000);
                while (process.HasExited == false)
                    process.Kill();
            }
            catch (Exception)
            {

            }
        }

        private void ContainerForm_Activated(object sender, EventArgs e)
        {
            ActivateUnityWindow();
        }

        private void ContainerForm_Deactivate(object sender, EventArgs e)
        {
            DeactivateUnityWindow();
        }

        private void ContainerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
