using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using NETF_ScreenCapture;


namespace NETF_ScreenCapture
{
	public partial class Form1 : MetroForm
	{
		private object obj = null;
		public enum ImageType
		{
			JPG,
			PNG
		}
		public int SaveImageType = 0;
		private int ImageListIndex = 0;


		public Form1()
		{
			InitializeComponent();
			metroContextMenu1.Opening += MetroContextMenu2_Opening;
			DragMoveEvent(this.Controls);
		}

		public void DragMoveEvent(Control.ControlCollection controls)
		{
			this.Cursor = Cursors.SizeAll;
			this.MouseDown += Control_MouseClick;
			foreach (Control control in controls) // recursive
			{

				control.TabStop = false;
				if (control is Button == true)
				{
					control.Cursor = Cursors.Default;
					control.MouseDown -= Control_MouseClick;
					continue;
				}


				if (typeof(MetroComboBox).IsInstanceOfType(control) == true)
				{
					control.Cursor = Cursors.Default;
					control.MouseDown -= Control_MouseClick;
					continue;
				}

				DragMoveEvent(control.Controls);
				control.MouseDown += Control_MouseClick;
				control.Cursor = Cursors.SizeAll;
			}
		}

		private void Control_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(this.Handle, WM_NCLBUTTONDOWN, (int)HitTestType.HTCAPTION, 0);
			}
		}

		private void MetroContextMenu2_Opening(object sender, CancelEventArgs e)
		{
			if (obj == metroListView1)
			{
				e.Cancel = true;
				obj = null;
			}
		}


		[DllImport("user32.dll")]
		public static extern UInt16 GetAsyncKeyState(Int32 vKey);
		public static bool IsKeyPressed(Int32 KeyCode)
		{
			return (GetAsyncKeyState(KeyCode) == 32768) ? true : false;
		}


		private int width = -1;
		private int height = -1;
		private int type = 0;

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct ptpt
		{
			public short width;
			public short height;
		}

		enum HitTest
		{
			Caption = 2,
			Transparent = -1,
			Nowhere = 0,
			Client = 1,
			Left = 10,
			Right = 11,
			Top = 12,
			TopLeft = 13,
			TopRight = 14,
			Bottom = 15,
			BottomLeft = 16,
			BottomRight = 17,
			Border = 18
		}

		private int casetype = 0;


		private const int WM_GETMINMAXINFO = 0x0024;
		private const int WM_MOVING = 0x0216;
		private const int WM_WINDOWPOSCHANGED = 0x0047;
		private const int WM_SIZING = 0x0214;

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X;
			public int Y;

			public POINT(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}

			public static implicit operator System.Drawing.Point(POINT p)
			{
				return new System.Drawing.Point(p.X, p.Y);
			}

			public static implicit operator POINT(System.Drawing.Point p)
			{
				return new POINT(p.X, p.Y);
			}
		}


		[StructLayout(LayoutKind.Sequential, Pack =1)]
		public struct MINMAXINFO
		{
			public POINT ptReserved;
			public POINT ptMaxSize;
			public POINT ptMaxPosition;
			public POINT ptMinTrackSize;
			public POINT ptMaxTrackSize;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct WINDOWPOS
		{
			public IntPtr hwnd;
			public IntPtr hwndInsertAfter;
			public int x;
			public int y;
			public int cx;
			public int cy;
			public uint flags;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}


		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref MINMAXINFO lParam);
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


		private int prevRight = 0;
		private int cursorRight = int.MinValue;
		private bool bOver = false;

		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_WINDOWPOSCHANGED:
					WINDOWPOS wp = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
					//Console.WriteLine($"{ wp.cx}");
					wp.cx = 500;
					wp.cy = 500;
					wp.cx = 1000;
					wp.cy = 1000;
					Marshal.StructureToPtr(wp, m.LParam, false);
					break;
				case WM_MOVING:
					RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
					//rc.Left = 0;
					//rc.Top = 100;
					Console.WriteLine($"Moving: {rc.Left}, {rc.Top}");
					Marshal.StructureToPtr(rc, m.LParam, true);
					break;
				case WM_SIZING:
					RECT rc2 = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

					if (casetype == 0)
					{
						if (prevRight != 0 && Math.Abs(prevRight - rc2.Right) > 100 && bOver == false)
						{
							//int d = (rc2.Right - prevRight) / 3;
							//rc2.Right = (prevRight += d);
							bOver = true;
							Console.WriteLine($"OVer ON1 :: {cursorRight}");
							prevRight = 0;
						}

						if (bOver == true)
						{
							if (cursorRight != int.MinValue)
							{
								Console.WriteLine($"Size: {rc2.Right} {cursorRight} right! / {Cursor.Position.X}pos");
								if (cursorRight > 0)
								{
									rc2.Right -= cursorRight;
								} else
								{
									rc2.Right += Math.Abs(cursorRight);
								}
							}
						} else
						{
							width = rc2.Right - rc2.Left;

						}
					}
					if (casetype == 1)
					{
						rc2.Right = rc2.Left + width;
						prevRight = rc2.Right;
						cursorRight = Cursor.Position.X - rc2.Right;
					}
					Marshal.StructureToPtr(rc2, m.LParam, true);
					Console.WriteLine($"Sizing: {rc2.Right}, {rc2.Bottom} :: {prevRight} : cur-{Cursor.Position.X}");
					break;
				case WM_GETMINMAXINFO:
					MINMAXINFO mmi2 = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
					mmi2.ptMinTrackSize.X = 400;
					mmi2.ptMinTrackSize.Y = 270;

					mmi2.ptMaxTrackSize.X = 1920;
					mmi2.ptMaxTrackSize.Y = 1920;

					//if (casetype == 0)
					//{
					//	mmi2.ptMinTrackSize.X = 400;
					//	mmi2.ptMinTrackSize.Y = 270;

					//	mmi2.ptMaxTrackSize.X = 1920;
					//	mmi2.ptMaxTrackSize.Y = 1920;
					//}
					//else if (casetype == 1 && isResizing) // width moving
					//{
					//	mmi2.ptMinTrackSize.X = 400;
					//	mmi2.ptMinTrackSize.Y = height;

					//	mmi2.ptMaxTrackSize.X = 1920;
					//	mmi2.ptMaxTrackSize.Y = height;
					//}
					//else if (casetype == 2 && isResizing) // height moving
					//{
					//	mmi2.ptMinTrackSize.X = width;
					//	mmi2.ptMinTrackSize.Y = 270;

					//	mmi2.ptMaxTrackSize.X = width;
					//	mmi2.ptMaxTrackSize.Y = 1920;
					//	//}
					Marshal.StructureToPtr(mmi2, m.LParam, true);
					break;
			}
			base.WndProc(ref m);
		}


		GlobalKeyboardHook globalHook = new GlobalKeyboardHook();
		private void Form1_Load(object sender, EventArgs e)
		{
			metroComboBox1.SelectedIndex = 0;
			SaveImageType = 0;
			globalHook.SetHook();
			globalHook.KeyDown += GlobalHook_KeyDown;
			globalHook.KeyUp += GlobalHook_KeyUp;
		}

		private void GlobalHook_KeyUp(object sender, KeyEventArgs e)
		{
			Console.WriteLine("keyboardUp!");
			if (casetype != 0)
			{
				casetype = 0;
			}
			//if (e.KeyCode == Keys.LShiftKey)
			//{
			//	isResizing = false;
			//	isShiftPress = false;
			//	//SendMessage(this.Handle, WM_NCLBUTTONDOWN, (int)HitTestType.HTBOTTOMRIGHT, 0);
			//}
		}

		private byte[] ObjectToByteArray(Object obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);

			return ms.ToArray();
		}

		private bool isShiftPress = false;
		private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.W)
			{
				casetype = 1;
			}
			else if (e.KeyCode == Keys.H)
			{
				casetype = 2;
			}
			else if (e.KeyCode == Keys.LShiftKey)
			{
				isShiftPress = true;
				
			}
			else if (e.KeyCode == Keys.Space)
			{
				SendMessage(this.Handle, WM_NCLBUTTONDOWN, (int)HitTestType.HTBOTTOMRIGHT, 0);
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			// 보이는 영역 캡쳐
			WindowCapture();
		}

		public void WindowCapture()
		{
			Image image = new Bitmap(panel1.Width, panel1.Height);
			Graphics graphics = Graphics.FromImage(image);

			int height = tableLayoutPanel1.GetRowHeights()[0];

			Point srcPoint = PointToScreen(new Point(tableLayoutPanel1.Location.X, tableLayoutPanel1.Location.Y + height));
			graphics.CopyFromScreen(srcPoint, new Point(0, 0), panel1.Size);

			DateTime dt = DateTime.Now;
			string filename = $@"{dt:hh-mm-ss}.jpg";
			image.Save(filename, ImageFormat.Png);

			imageList1.Images.Add(image);
			metroListView1.Items.Insert(0, filename, ImageListIndex++);




		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
		}

		private void metroListView1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Right))
			{
				obj = sender;
				var ss = metroListView1.GetItemAt(e.X, e.Y);
				ContextMenuStrip st = new ContextMenuStrip();
				st.Items.Add(ss.Text + " 클립보드로 복사하기");
				st.Show(sender as Control, new Point(e.X, e.Y));
				//metroContextMenu2.Show(metroListView1, new Point(e.X, e.Y));
			}
		}

		private void metroButton1_Click_1(object sender, EventArgs e)
		{
			WindowCapture();

		}

		private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SaveImageType = metroComboBox1.SelectedIndex;
		}

		public const int WM_NCLBUTTONDOWN = 0xA1;
		enum HitTestType
		{
			HTERROR = -2,
			HTTRANSPARENT = -1,
			HTNOWHERE = 0,
			HTCLIENT = 1,
			HTCAPTION = 2,
			HTSYSMENU = 3,
			HTGROWBOX = 4,
			HTMENU = 5,
			HTHSCROLL = 6,
			HTVSCROLL = 7,
			HTMINBUTTON = 8,
			HTMAXBUTTON = 9,
			HTLEFT = 10,
			HTRIGHT = 11,
			HTTOP = 12,
			HTTOPLEFT = 13,
			HTTOPRIGHT = 14,
			HTBOTTOM = 15,
			HTBOTTOMLEFT = 16,
			HTBOTTOMRIGHT = 17,
			HTBORDER = 18,
			HTOBJECT = 19,
			HTCLOSE = 20,
			HTHELP = 21
		}


		[DllImport("User32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("User32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);



		private void Form1_Resize(object sender, EventArgs e)
		{

			metroLabel1.Text = panel1.Size.Width + " x " + panel1.Size.Height;
		}

		private bool isResizing = false;
		private void Form1_ResizeBegin(object sender, EventArgs e)
		{
			Console.WriteLine("Begin");
			if (isResizing == false)
			{
				isResizing = true;
			}	

		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			Console.WriteLine("End");
			isResizing = false;
			cursorRight = int.MinValue;
			bOver = false;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{

		}
	}
}
