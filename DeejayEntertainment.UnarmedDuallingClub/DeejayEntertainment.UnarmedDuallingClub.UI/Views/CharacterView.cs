using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Common.Constants;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using DeejayEntertainment.UnarmedDuallingClub.UI.Constants;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;
using AssetImage = System.Drawing.Image;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class CharacterView : GameViewBase
	{
		private readonly int cellX;
		private readonly int cellY;
		private readonly Font descriptionFont;
		private readonly ICharacterDescriptionMenu descriptionMenu;
		private readonly MainMenuView mainMenu;

		private readonly Font regularFont;
		private readonly StringFormat stringFormatCenter;
		private readonly StringFormat stringFormatNormal;
		private readonly Font titleFont;
		private AssetImage background;
		private Task repaintTask;
		private CancellationTokenSource tokenSource;

		public CharacterView(MainController controller, Canvas image, AssetManager assetManager, MainMenuView mainMenu,
			ICharacterDescriptionMenu descriptionMenu, SoundManager soundManager)
			: base(controller, image, assetManager, soundManager)
		{
			this.descriptionMenu = descriptionMenu;
			this.mainMenu = mainMenu;
			cellX = Width / 50;
			cellY = Height / 50;
			regularFont = new Font("Arial", (int) (cellY * 1.4));
			descriptionFont = new Font("Arial", (int) (cellY * 1.2));
			titleFont = new Font("Arial", cellY * 4, FontStyle.Bold);
			stringFormatCenter = new StringFormat
			{
				Alignment = StringAlignment.Center
			};
			stringFormatNormal = new StringFormat
			{
				Alignment = StringAlignment.Near
			};
		}

		public override View View => View.Character;

		public override void OnClose()
		{
			tokenSource.Cancel();
			repaintTask = null;
		}

		public override void OnKeyPressed(Key key)
		{
			switch (key)
			{
				case Key.Left:
					descriptionMenu.Previous();
					break;
				case Key.Right:
					descriptionMenu.Next();
					break;
				case Key.Escape:
				case Key.Enter:
				case Key.Space:
					MainController.CurrentView = mainMenu;
					break;
			}
			Repaint();
		}

		public override void OnOpen()
		{
			tokenSource = new CancellationTokenSource();
			repaintTask = new Task(() =>
			{
				while (!tokenSource.IsCancellationRequested)
				{
					MainController.Repaint();
					Thread.Sleep(Timeouts.RepaintInterval);
				}
			}, tokenSource.Token);
			repaintTask.Start();
		}

		protected override void LoadResources()
		{
			background = assetManager.GetImageByPath("resources/menu/OtherBG.jpg");
		}

		protected override void PaintContent(Graphics graphics)
		{
			ICharacterState player = descriptionMenu.CurrentCharacter;

			DrawBackground(graphics, background);
			DrawImage(graphics, player.Image, cellX * -1, cellY * 2, cellX * 15, cellX * 15);
			graphics.DrawString(player.PlayerName, titleFont, ColorConstants.NormalColorBrush,
				new RectangleF(cellX * 12, cellY * 2, Width - cellX * 12, cellY * 6), stringFormatCenter);
			graphics.DrawString(player.CharacterDescription, descriptionFont, ColorConstants.NormalColorBrush,
				new RectangleF(cellX * 12, cellY * 8, Width - cellX * 12, Height - cellY * 8), stringFormatCenter);
			graphics.DrawString(player.StatsDescription, regularFont, ColorConstants.NormalColorBrush,
				new RectangleF(cellX * 12, cellY * 19, Width - cellX * 12, Height - cellY * 19), stringFormatNormal);
			graphics.DrawString(player.AbilitiesDescription, regularFont, ColorConstants.NormalColorBrush,
				new RectangleF(cellX * 2, cellY * 30, Width - cellX * 2, Height - cellY * 30), stringFormatNormal);
		}
	}
}