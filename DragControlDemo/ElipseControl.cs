using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DragControlDemo
{
    /// <summary>
    /// 为控件添加圆角效果
    /// </summary>
    class ElipseControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect, 
                int nRightRect, 
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );
        private Control _cntrl;
        private int _CornerRadius = 30;

        public Control TargetControl
        {
            get =>  _cntrl;
            set
            {
                _cntrl = value;
                _cntrl.SizeChanged += (sender, eventArgs) => _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }

        public int CornerRadius
        {
            get => _CornerRadius;
            set
            {
                _CornerRadius = value;
                if(_cntrl != null)
                {
                    _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
                }
            }
        }

    }
}
