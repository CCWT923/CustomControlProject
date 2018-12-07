using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomUserControl
{
    class DragControl  : Component
    {
        private Control handleControl;
        public Control SelectControl
        {
            get
            {
                return handleControl;
            }
            set
            {
                handleControl = value;
                this.handleControl.MouseDown += new MouseEventHandler(this.DragControl_MouseDown);
            }
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr a, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void DragControl_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left; //是否是左键被按下
            if(flag)
            {
                DragControl.ReleaseCapture();
                DragControl.SendMessage(this.SelectControl.FindForm().Handle,161,2,0);
            }
        }
    }
}
