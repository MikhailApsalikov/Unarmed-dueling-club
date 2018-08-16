using System;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;
using System.Drawing.Imaging;
using AssetImage = System.Drawing.Image;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using System.Diagnostics;
using System.Windows.Controls;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public abstract class GameViewBase
	{
		[DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject([In] IntPtr hObject);

		protected readonly MainController MainController;
		protected readonly Canvas image;
		protected readonly AssetManager assetManager;
		protected readonly SoundManager soundManager;
		protected int Width;
		protected int Height;
		protected static object lockObj = new object();

		protected GameViewBase(MainController mainController, Canvas image, AssetManager assetManager, SoundManager soundManager)
		{
			this.MainController = mainController;
			this.image = image;
			this.assetManager = assetManager;
			this.soundManager = soundManager;
			Width = (int)mainController.Width;
			Height = (int)mainController.Height;
			LoadResources();
		}

		protected abstract void LoadResources();

		public abstract View View { get; }

		public abstract void OnClose();

		public abstract void OnKeyPressed(Key key);

		public abstract void OnOpen();

		public void Repaint()
		{
			if (this.MainController.CurrentView != this)
			{
				return;
			}
			Stopwatch sw = Stopwatch.StartNew();

			lock (lockObj)
			{
				image.Dispatcher.Invoke(() =>
				{
					if (this.MainController.CurrentView != this)
					{
						return;
					}
					PaintContent(this.image);
					sw.Stop();
					Trace.WriteLine(sw.ElapsedMilliseconds);
				});
			}
		}

		protected abstract void PaintContent(Graphics graphics);

		protected abstract void PaintContent(Canvas canvas);

		public ImageSource ImageSourceForBitmap(Bitmap bmp)
		{
			var handle = bmp.GetHbitmap();
			try
			{
				return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			}
			finally
			{
				DeleteObject(handle);
			}
		}

		protected void DrawBackground(Graphics graphics, AssetImage background)
		{
			ImageAttributes attributes = new ImageAttributes();
			attributes.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);
			graphics.DrawImage(background, new Rectangle(0, 0, Width, Height), 0, 0, background.Width, background.Height,
				GraphicsUnit.Pixel, attributes);
		}

		protected void DrawImage(Graphics graphics, AssetImage asset, double x, double y, double width, double height)
		{
			graphics.DrawImage(asset, new Rectangle((int)x, (int)y, (int)width, (int)height));
		}

		protected void DrawImage(Graphics graphics, AssetImage asset, int x, int y, int width, int height)
		{
			graphics.DrawImage(asset, new Rectangle(x, y, width, height));
		}

		protected static int RealXToGameX(int x, int width)
		{
			return x - width / 2;
		}

		protected static int GameXToRealX(int x, int width)
		{
			return x + width / 2;
		}

		protected static int RealYToGameY(int y, int height)
		{
			return y - height / 2;
		}

		protected static int GameYToRealY(int y, int height)
		{
			return y + height / 2;
		}
	}
}
