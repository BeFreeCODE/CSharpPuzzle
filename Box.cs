using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ConsoleApplication1
{
    class Box
    {
        private int number;
        private float x;
        private float y;

        private const int BoxSize = 50;
        private const int FontSize = 20;

        private MainForm MF;

        public Box(int number, float x, float y,MainForm MF)
        {
            this.x = x;
            this.y = y;
            this.number = number;
            this.MF = MF;
        }
        public void Move(float x, float y)
        {
            this.x = x;
            this.y = y;
            MF.Render();
        }
        public void Render()
        {
            Pen pen = new Pen(Brushes.Red);

            if (number != 0)
            {
                int a = (int)Math.Log10(number);
                float pointX = x + (BoxSize / 2 - (FontSize / 2 + a + FontSize / 2));
                float pointY = y + BoxSize / 2 - FontSize / 2;

                Font font = new Font(new FontFamily("돋움"), FontSize, FontStyle.Bold, GraphicsUnit.Pixel);

                GDIBuffer.Instance().getGraphics.DrawString(number.ToString(), font, new SolidBrush(Color.Red), new PointF(pointX, pointY));
                GDIBuffer.Instance().getGraphics.DrawRectangle(pen, x, y, BoxSize, BoxSize);
            }
        }
    }
}
