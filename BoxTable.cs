using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Mask_Node
    {
        private int x;
        private int y;
        private int number;
        public Mask_Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public int X
        {
            get { return this.x; }
        }
        public int Y
        {
            get { return this.y; }
        }
    }
    class BoxTable
    {
        MainForm MF;
        Box[] box;
        Mask_Node[] mask;

        public BoxTable(MainForm MF)
        {
            this.MF = MF;
            mask = new Mask_Node[25];
            box = new Box[25];

            
            MaskCreate();
            this.MF.KeyDown += new System.Windows.Forms.KeyEventHandler(MF_KeyDown);
        }
        private void MF_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int pos = 0;
            int mpos = 0;
            for (int i = 0; i < 25; ++i)
            {
                if (mask[i].Number == 0) pos = i;
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Right)
            {
                if (pos % 5 != 4) mpos = pos + 1;
                else mpos = pos;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Left)
            {
                if (pos % 5 != 0) mpos = pos - 1;
                else mpos = pos;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                mpos = pos + 5;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                mpos = pos - 5;
            }
            else
            {
                return;
            }
            MoveFunction(pos, mpos);
        }
        public void Random()
        {
            int pos = 0;
            int mpos = 0;
            for (int i = 0; i < 25; ++i)
            {
                if (mask[i].Number == 0)
                    pos = i;
            }
            Random r = new Random();
            switch (r.Next(4))
            {
                case 0: if (pos % 5 != 4) { mpos = pos + 1; } break;
                case 1: if (pos % 5 != 0) { mpos = pos - 1; } break;
                case 2: mpos = pos + 5; break;
                case 3: mpos = pos - 5; break;
            }
            MoveFunction(pos, mpos);
        }
        private void MoveFunction(int pos, int mpos)
        {
            if (mpos > -1 && mpos < 25)
            {
                box[0].Move(mask[mpos].X, mask[mpos].Y);
                box[mask[mpos].Number].Move(mask[pos].X, mask[pos].Y);
                mask[pos].Number = mask[mpos].Number;
                mask[mpos].Number = 0;
            }
        }
        private void MaskCreate()
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 25; ++i)
            {
                if (i % 5 == 0 && i != 0)
                {
                    x = 0;
                    y += 50;
                }
                mask[i] = new Mask_Node(x, y);
                mask[i].Number = i;
                box[i] = new Box(i, x, y, MF);
                x += 50;
            }
        }

        public void Render()
        {
            for(int i = 0; i < 25; ++i)
                box[i].Render();
        }
    }
}
