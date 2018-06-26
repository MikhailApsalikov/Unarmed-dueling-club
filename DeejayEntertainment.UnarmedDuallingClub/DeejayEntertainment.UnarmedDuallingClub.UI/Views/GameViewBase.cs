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
using ImageControl = System.Windows.Controls.Image;
using AssetImage = System.Drawing.Image;
using DeejayEntertainment.UnarmedDuallingClub.Sound;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public abstract class GameViewBase
	{
		[DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject([In] IntPtr hObject);

		protected readonly MainController MainController;
		protected readonly ImageControl image;
		protected readonly AssetManager assetManager;
		protected readonly SoundManager soundManager;
		protected int Width;
		protected int Height;
		protected static object lockObj = new object();

		protected GameViewBase(MainController mainController, ImageControl image, AssetManager assetManager, SoundManager soundManager)
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
			Bitmap bitmap = new Bitmap(MainController.Width, MainController.Height);
			Graphics graphics = Graphics.FromImage(bitmap);

			lock (lockObj)
			{
				PaintContent(graphics);
			}

			image.Dispatcher.Invoke(() =>
			{
				image.Source = ImageSourceForBitmap(bitmap);
			});
		}

		protected abstract void PaintContent(Graphics graphics);

		public ImageSource ImageSourceForBitmap(Bitmap bmp)
		{
			var handle = bmp.GetHbitmap();
			try
			{
				return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			}
			finally { DeleteObject(handle); }
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
	}
}
