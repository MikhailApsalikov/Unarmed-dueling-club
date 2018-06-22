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
		private Font menuFont;
		private Font versionFont;
		private Brush menuSelectedBrush = Brushes.Green;
		private Brush menuItemBrush = Brushes.White;
		private int cellX;
		private int cellY;

		public MainMenuView(MainController controller, ImageControl image, AssetManager assetManager, IMainMenu mainMenu)
			: base(controller, image, assetManager)
		{
			this.mainMenu = mainMenu;
			cellX = Width / 50;
			cellY = Height / 50;
			menuFont = new Font("Arial", (int)(cellY * 3.2));
			versionFont = new Font("Arial", (int)(cellY * 0.6));
		}

		public override void OnClose()
		{
		}

		public override void OnOpen()
		{
		}

		public override void OnKeyPressed(Key key)
		{
			switch (key)
			{
				case Key.Enter:
				case Key.Space:
					break;
				case Key.Up:
					mainMenu.Up();
					break;
				case Key.Down:
					mainMenu.Down();
					break;
			}
			this.Repaint();
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
			graphics.DrawImage(udcLabel, new Rectangle(cellX * 12, 0, cellX * 26, cellY * 26));
			foreach (var option in mainMenu.Options)
			{
				graphics.DrawString(option.Name, menuFont, option.IsSelected ? menuSelectedBrush : menuItemBrush, cellX * 20, (int)(cellY * (25 + 4.5 * option.Id)));
			}
			// TODO: change version
			graphics.DrawString("Version 2.0.0", versionFont, menuItemBrush, 0, cellY * 49);
		}
	}
}