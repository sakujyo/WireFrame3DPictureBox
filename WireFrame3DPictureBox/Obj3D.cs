using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WireFrame3DPictureBox
{
  class Obj3D
  {
		private List<Point3D> verts;
		private Point3D rotateOrigin;
		private Point3D drawOrigin;
		private double ay;
		private double az;


    public Obj3D()
    {
			verts = new List<Point3D>();
			drawOrigin = new Point3D(0, 0, 0);
			rotateOrigin = new Point3D(0, 0, 0);
    }
		public void AddVertex(Point3D p)
		{
			// ワイヤーフレームを描画する場合は、結ぶ順番でAddVertexする？
			// または
			// public void AddVertex(Point3D p, bool isConnected?)
			
			verts.Add(p);
		}

		internal void draw(Graphics g)
		{
			foreach (var p in verts)
			{
				p.SetProjectionAngle(az, ay);		// 投影角度の指定
				if (verts.Last() == p) break;
				// 頂点を2つ選び、線分で描画する
				Point3D next = verts[verts.IndexOf(p) + 1];
				//float px = p.X;
				//float py = p.Y;
				float px = p.ProjectedX;
				float py = p.ProjectedY;
				px += drawOrigin.X;
				py += drawOrigin.Y;
				//float nx = next.X + drawOrigin.X;
				//float ny = next.Y + drawOrigin.Y;
				float nx = next.ProjectedX + drawOrigin.X;
				float ny = next.ProjectedY + drawOrigin.Y;
				g.DrawLine(Pens.GreenYellow, px, py, nx, ny);
			}
		}
		//public void drawLine(Graphics g, Pens pen, double x1, double y1, double x2, double y2)
		//{
		//  g.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
		//}
		//public void drawLine(Graphics g, Pen pen, double x1, double y1, double x2, double y2)
		//{
		//  g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
		//}

		internal void move()
		{
			rotate(0.1);
		}

		private void rotate(double angle)
		{
			// とりま原点中心の回転
			foreach (var p in verts)
			{
				float nx;
				float ny;
				float px = p.X - rotateOrigin.X;
				float py = p.Y - rotateOrigin.Y;
				nx = (float)(px * Math.Cos(angle) - py * Math.Sin(angle));
				ny = (float)(px * Math.Sin(angle) + py * Math.Cos(angle));
				nx += rotateOrigin.X;
				ny += rotateOrigin.Y;
				p.Set(nx, ny, p.Z);
			}
		}

		public void SetRotateOrigin(Point3D origin)
		{
			this.rotateOrigin = origin;
		}

		internal void SetDrawOrigin(Point3D origin)
		{
			this.drawOrigin = origin;
		}

		internal void SetProjectionAngle(double az, double ay)
		{
			this.az = az;
			this.ay = ay;
		}

		internal void AddProjectionRotateZ(int p)
		{
			this.az += p / 10.0;
		}
	}
}
