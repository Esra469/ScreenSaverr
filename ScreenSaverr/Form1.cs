using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaverr
{
    public partial class FrmScrSaver : Form
    {
        List<Image> BGimages = new List<Image>();
        List<Britpic> BritPics = new List<Britpic>();
        Random rnd = new Random();
        class Britpic
        {
            public int picnum;
            public float X;
            public float Y;
            public float speed;
        }

        public FrmScrSaver()
        {
            InitializeComponent();
        }

        private void FrmScrSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void FrmScrSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pictrues");
            foreach(string image in images)
            {
                BGimages.Add( new Bitmap(image));
            }

            for(int i = 0; i <100; i++)
            {
                Britpic mp = new Britpic();
                mp.picnum = i % BGimages.Count;
                mp.X = rnd.Next(0, Width);
                mp.Y = rnd.Next(0, Height);

                BritPics.Add(mp);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void FrmScrSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach(Britpic bp in BritPics)
            {
                e.Graphics.DrawImage(BGimages[bp.picnum], bp.X, bp.Y);
                bp.X -= 2;

                if (bp.X < -250)
                {
                    bp.X = Width + rnd.Next(20, 100);
                }
            }
        }
    }
}
