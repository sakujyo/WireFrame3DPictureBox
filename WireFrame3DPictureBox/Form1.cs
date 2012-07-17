using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WireFrame3DPictureBox
{
  public partial class Form1 : Form
  {
    private List<Obj3D> Objs;
		private int oldEX = 0;
		private int oldEY = 0;

    public Form1()
    {
      InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;
			// 以下はサンプル
			Objs = new List<Obj3D>();
			var o1 = new Obj3D();

			//単純な立方体のワイヤーフレーム・データ
			//var p1 = new Point3D(10, 20, 0);
			var p1 = new Point3D(100, 100, 100);
			var p2 = new Point3D(100, -100, 100);
			var p3 = new Point3D(-100, -100, 100);
			var p4 = new Point3D(-100, 100, 100);
			var p5 = new Point3D(100, 100, 100);
			var p6 = new Point3D(100, 100, -100);
			var p7 = new Point3D(100, -100, -100);
			var p8 = new Point3D(-100, -100, -100);
			var p9 = new Point3D(-100, 100, -100);
			var pa = new Point3D(100, 100, -100);
			var pb = new Point3D(100, -100, -100);
			var pc = new Point3D(100, -100, 100);
			var pd = new Point3D(-100, -100, 100);
			var pe = new Point3D(-100, -100, -100);
			var pf = new Point3D(-100, 100, -100);
			var pg = new Point3D(-100, 100, 100);

			o1.AddVertex(p1);
			o1.AddVertex(p2);
			o1.AddVertex(p3);
			o1.AddVertex(p4);
			o1.AddVertex(p5);
			o1.AddVertex(p6);
			o1.AddVertex(p7);
			o1.AddVertex(p8);
			o1.AddVertex(p9);
			o1.AddVertex(pa);
			o1.AddVertex(pb);
			o1.AddVertex(pc);
			o1.AddVertex(pd);
			o1.AddVertex(pe);
			o1.AddVertex(pf);
			o1.AddVertex(pg);
			o1.SetProjectionAngle(0.4 * Math.PI, 0.3 * Math.PI);
			Objs.Add(o1);

			timer1.Interval = 33;
			timer1.Start();
		}

    private void timer1_Tick(object sender, EventArgs e)
    {
			Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			pictureBox1.Image = bmp;
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.Black);
			foreach (var o in Objs)
			{
				o.SetRotateOrigin(new Point3D(0, 0, 0));
				o.SetDrawOrigin(new Point3D(bmp.Width / 2, bmp.Height / 2, 0));
				o.move();
				o.draw(g);
			}
    }

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			//Console.WriteLine("PictureBox Mouse Move");
			if (e.Button == MouseButtons.Right)
			{
				//Console.WriteLine("Buttons.Right");
				foreach (var o in Objs)
				{
					o.AddProjectionRotateZ(e.Y - oldEY);
					oldEY = e.Y;
				}
			}
		}
  }
}
