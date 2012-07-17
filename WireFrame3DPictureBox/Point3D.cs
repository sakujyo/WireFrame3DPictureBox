using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WireFrame3DPictureBox
{
	class Point3D
	{
		private float x;
		private float y;
		private float z;

		protected float intermediateY	// 投影されたx, y座標を計算するための中間y座標
		{
			get
			{
				//nx = (float)(px * Math.Cos(angle) - py * Math.Sin(angle));
				//ny = (float)(px * Math.Sin(angle) + py * Math.Cos(angle));
				return (float)(z * Math.Tan(az));
				//return (float)(z * Math.Sin(az));
				//return (float)(z * Math.Tan(az) * Math.Cos(az));
			}
		}

		public float ProjectedX
		{
			get
			{
				//return x;
				//TODO: Yをずらした後の回転は、通常の回転と計算が少し違うはず
				//return (float)(x * Math.Sin(ay) + intermediateY * Math.Cos(ay));

				//return x + (float)(- intermediateY * Math.Sin(ay));
				return x;
			}
		}
		public float ProjectedY
		{
			get
			{
				//return y;
				//TODO: Yをずらした後の回転は、通常の回転と計算が少し違うはず
				//return (float)(x * Math.Cos(ay) - intermediateY * Math.Sin(ay));

				return (float)(y * Math.Cos(az) + z * Math.Sin(az));
				//float yy = y + (float)(intermediateY * Math.Cos(ay));
				//return (float)(yy * Math.Cos(az));
				
				//return y + (float)(intermediateY * Math.Cos(ay));
			}
		}

		private double az;
		private double ay;

		public float X
		{
			get
			{
				return x;
			}
		}
		public float Y
		{
			get
			{
				return y;
			}
		}
		public float Z
		{
			get
			{
				return z;
			}
		}

		public Point3D(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public void Set(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		internal void SetProjectionAngle(double az, double ay)
		{
			this.az = az;
			this.ay = ay;
		}
	}
}
