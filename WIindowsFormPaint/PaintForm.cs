using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIindowsFormPaint
{
    public partial class PaintForm : Form
    {
        public Point OldLocation { get; set; }
        public GraphicsState State { get; set; }
        public PaintForm()
        {
            InitializeComponent();
        }
        
        private void PaintForm_MouseDown(object sender, MouseEventArgs e)
        {
            OldLocation = e.Location;
        }

        private void PaintForm_MouseMove(object sender, MouseEventArgs e)
        {
            

            if (e.Button == MouseButtons.Left)
            {
              var color = (ParentForm as MainForm).Color;
              var size = (ParentForm as MainForm).Size;

                Graphics graphics = CreateGraphics();
                Pen pen = new Pen(color,size);
                graphics.DrawLine(pen, OldLocation, e.Location);
                OldLocation = e.Location;

                State = graphics.Save();
          }
        }
    }
}
