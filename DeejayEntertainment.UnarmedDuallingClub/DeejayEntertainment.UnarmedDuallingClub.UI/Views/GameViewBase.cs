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
using ImageControl = System.Windows.Controls.Image;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;

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
		protected int Width;
		protected int Height;

		protected GameViewBase(MainController mainController, ImageControl image, AssetManager assetManager)
		{
			this.MainController = mainController;
			this.image = image;
			this.assetManager = assetManager;
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
			Bitmap bitmap = new Bitmap(MainController.Width, MainController.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			PaintContent(graphics);
			image.Source = ImageSourceForBitmap(bitmap);
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
	}
}
