using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApplication1
{
    class MainForm : Form
    {
        BoxTable BT;
        public MainForm()
        {
            GDIBuffer.Instance(ClientRectangle.Width, ClientRectangle.Height);

            BT = new BoxTable(this);
            new System.Threading.Timer(new TimerCallback(random), null, 1000, Timeout.Infinite);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Render();
        }
        public void random(object obj)
        {
            for (int i = 0; i < 500; ++i)
            {
                BT.Random();
                Thread.Sleep(1);
            }
        }
        public void Render()
        {
            FrameUpdate();
            FrameRender();
        }
        private void FrameUpdate()
        {
            GDIBuffer.Instance().getGraphics.Clear(System.Drawing.Color.Black);
            BT.Render();
        }

        private void FrameRender()
        {
            System.Drawing.Graphics g = CreateGraphics();
            g.DrawImage(GDIBuffer.Instance().GetImages,new System.Drawing.Point(0,0));
            g.Dispose();
        }
    }
}
