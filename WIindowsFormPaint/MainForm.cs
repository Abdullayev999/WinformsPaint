using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WIindowsFormPaint
{
    public partial class MainForm : Form
    {
        public Color Color { get; set; }=Color.Black;
        public int Size { get; set; } = 3;
        public MainForm()
        {
            InitializeComponent();
            DrawColorImage();
            toolStripComboBox1.Items.AddRange(Enumerable.Range(1,20).Select(x=> x as  object).ToArray());
           
            Timer  timer=new Timer();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            //timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            var r = random.Next(0, 255);
            var g = random.Next(0, 255);
            var o = random.Next(0, 255);


            Graphics graphics = CreateGraphics();

            Brush brush = new SolidBrush(Color.FromArgb(r, g, o));
            graphics.FillRectangle(brush, 0, 0, Width, Height);

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var paintForm = new PaintForm();
            paintForm.MdiParent = this;
            paintForm.Show();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color = dialog.Color;
                DrawColorImage();
            }
        }

        private void DrawColorImage()
        {
            var paint = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(paint);
            g.Clear(Color);
            toolStripButton1.Image = paint;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Size = (int)toolStripComboBox1.SelectedItem;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)//Nesoxranyayet
        {
            //var diaalog=new SaveFileDialog();
            //var result=diaalog.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    var fileName = diaalog.FileName;
            //    var Width = ActiveMdiChild.Width;
            //    var Height = ActiveMdiChild.Height;
            //    var graphics = ActiveMdiChild.CreateGraphics();
            //    var image = new Bitmap(Width,Height,graphics);
            //    image.Save(fileName,ImageFormat.Png);

            //}


            var diaalog = new SaveFileDialog();
            var result = diaalog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = diaalog.FileName;
                var Width = ActiveMdiChild.Width;
                var Height = ActiveMdiChild.Height;
                Image bmp = new Bitmap(Width, Height);
                var gg = Graphics.FromImage(bmp);

                var rect = ActiveMdiChild.RectangleToScreen(ActiveMdiChild.ClientRectangle);
                gg.CopyFromScreen(rect.Location, Point.Empty, ActiveMdiChild.Size);
                bmp.Save(fileName, ImageFormat.Png);

            }
        }
    }
}
