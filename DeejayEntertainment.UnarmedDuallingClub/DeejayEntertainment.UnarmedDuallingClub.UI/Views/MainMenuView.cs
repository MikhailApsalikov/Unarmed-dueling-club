﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Input;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using ImageControl = System.Windows.Controls.Image;
using AssetImage = System.Drawing.Image;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;
using DeejayEntertainment.UnarmedDuallingClub.UI.Constants;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class MainMenuView : GameViewBase
	{
		private readonly IMainMenu mainMenu;
		private AssetImage background;
		private AssetImage udcLabel;
		private Font menuFont;
		private Font versionFont;
		private int cellX;
		private int cellY;

		public override View View => View.MainMenu;

		public MainMenuView(MainController controller, ImageControl image, AssetManager assetManager, IMainMenu mainMenu)
			: base(controller, image, assetManager)
		{
			this.mainMenu = mainMenu;
			cellX = Width / 50;
			cellY = Height / 50;
			menuFont = new Font("Arial", (int)(cellY * 3.2));
			versionFont = new Font("Arial", (int)(cellY * 0.8));
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
					Select();
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

		private void Select()
		{
			switch (mainMenu.Select())
			{
				case 3:
					MainController.CurrentView = new AboutView(MainController, image, assetManager, this);
					break;
				case 4:
					MainController.ExitGame();
					break;
			}
		}

		protected override void LoadResources()
		{
			background = assetManager.GetImageByPath("resources/menu/MMBG.jpg");
			udcLabel = assetManager.GetImageByPath("resources/menu/UDCLabel.gif");
		}

		protected override void PaintContent(Graphics graphics)
		{
			DrawBackground(graphics, background);
			DrawImage(graphics, udcLabel, cellX * 12, 0, cellX * 26, cellY * 26);
			foreach (var option in mainMenu.Options)
			{
				graphics.DrawString(option.Name, menuFont, option.IsSelected ? ColorConstants.MenuSelectedBrush : ColorConstants.MenuItemBrush, cellX * 20, (int)(cellY * (25 + 4.5 * option.Id)));
			}
			graphics.DrawString($"Version {VersionInfo.DisplayVersion}", versionFont, ColorConstants.MenuItemBrush, cellX, cellY * 49);
		}
	}
}