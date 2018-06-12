using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Input;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using ImageControl = System.Windows.Controls.Image;
using AssetImage = System.Drawing.Image;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class MainMenuView : GameViewBase
	{
		private readonly IMainMenu mainMenu;
		private AssetImage background;
		private AssetImage udcLabel;

		// add font

		public MainMenuView(MainController controller, ImageControl image, AssetManager assetManager, IMainMenu mainMenu) 
			: base(controller, image, assetManager)
		{
			this.mainMenu = mainMenu;
		}

		public override void OnClose()
		{
			throw new NotImplementedException();
		}

		public override void OnKeyPressed(Key key)
		{
			throw new NotImplementedException();
		}

		public override void OnOpen()
		{
			throw new NotImplementedException();
		}

		protected override void LoadResources()
		{
			background = assetManager.GetImageByPath("resources/menu/MMBG.jpg");
			udcLabel = assetManager.GetImageByPath("resources/menu/UDCLabel.gif");
		}

		protected override void PaintContent(Graphics graphics)
		{
			ImageAttributes attributes = new ImageAttributes();
			attributes.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);
			graphics.DrawImage(background, new Rectangle(0, 0, Width, Height), 0, 0, background.Width, background.Height,
				GraphicsUnit.Pixel, attributes);
			graphics.DrawImage(udcLabel, new Rectangle(Width * 12 / 50, 0, Width * 26 / 50, Height * 26 / 50));
		}
	}
}