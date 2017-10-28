using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp
{
    public partial class CefSharpForm : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        public CefSharpForm()
        {
            InitializeComponent();
            InitializeChromium();
        }
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
            chromeBrowser = new ChromiumWebBrowser("http://192.168.0.4:7870/index.html");
            //chromeBrowser = new ChromiumWebBrowser("https://www.youtube.com/watch?v=uO4BMId9e0w&t=4742s");
            //chromeBrowser = new ChromiumWebBrowser(@"D:\[00]Window\Desktop\all\DeskTop\unity\webgl-release\index.html");
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Cef.Shutdown();
            base.OnClosing(e);
        }

    }
}
