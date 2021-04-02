using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIPainter
{
    public partial class FormMain : Form
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        
        IntPtr d = GetDC(IntPtr.Zero);

        Graphics gfx = Graphics.FromHdc(GetDC(IntPtr.Zero));

        bool WorkStop = true;

        Thread thread;

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkStop = true;
            thread = new Thread(new ThreadStart(drawOnDesktop));
            thread.Start();
        }

        private void drawOnDesktop()
        {
            Point lastPoint = new Point(500, 500);

            while (WorkStop)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);

                gfx.DrawLine(new Pen(Brushes.DeepSkyBlue), lastPoint, p);
                lastPoint = p;
            }
        }

        private void Back()
        {
            while (true)
            {
                Thread.Sleep(2000);
            }
        }

        private void StopBTN_Click(object sender, EventArgs e)
        {
            WorkStop = false;
            thread = new Thread(new ThreadStart(Back));
        }
    }
}
