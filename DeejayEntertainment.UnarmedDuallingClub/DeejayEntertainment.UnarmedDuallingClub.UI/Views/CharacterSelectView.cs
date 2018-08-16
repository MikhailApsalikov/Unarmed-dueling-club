using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Common.Constants;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;
using DeejayEntertainment.UnarmedDuallingClub.GameCore;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using DeejayEntertainment.UnarmedDuallingClub.UI.Constants;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;
using AssetImage = System.Drawing.Image;
using System.Windows.Controls;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class CharacterSelectView : GameViewBase
	{
		private ControllerConfiguration firstController = ConfigurationManager.FirstPlayerConfiguration;
		private ControllerConfiguration secondController = ConfigurationManager.SecondPlayerConfiguration;
		private readonly MainMenuView mainMenu;
		private readonly ICharacterSelectMenu selectMenuPlayer1;
		private readonly ICharacterSelectMenu selectMenuPlayer2;

		private int cellX;
		private int cellY;
		private AssetImage background;
		private AssetImage udcLabel;
		private AssetImage selectFirstImage;
		private AssetImage selectSecondImage;
		private Font mainFont;
		private Task repaintTask;
		private CancellationTokenSource tokenSource;
		private bool isLocked = false;

		public CharacterSelectView(MainController mainController, Canvas image, AssetManager assetManager, MainMenuView mainMenu, ICharacterSelectMenu selectMenuPlayer1, ICharacterSelectMenu selectMenuPlayer2, SoundManager soundManager) : base(mainController, image, assetManager, soundManager)
		{
			this.mainMenu = mainMenu;
			this.selectMenuPlayer1 = selectMenuPlayer1;
			this.selectMenuPlayer2 = selectMenuPlayer2;
			cellX = Width / 20;
			cellY = Height / 20;
			mainFont = new Font("Arial", (int)(cellY));
		}

		protected override void LoadResources()
		{
			background = assetManager.GetImageByPath("resources/menu/SelectBG.jpg");
			udcLabel = assetManager.GetImageByPath("resources/menu/UDCLabel.gif");
			selectFirstImage = assetManager.GetImageByPath("resources/menu/SelectionYou.gif");
			selectSecondImage = assetManager.GetImageByPath("resources/menu/SelectionEnemy.png");
		}

		public override View View => View.CharacterSelect;

		public override void OnClose()
		{
			tokenSource.Cancel();
			repaintTask = null;
		}

		public override void OnKeyPressed(Key key)
		{
			if (isLocked)
			{
				return;
			}
			switch (key)
			{
				case Key.Escape:
					MainController.CurrentView = mainMenu;
					break;
			}
			if (key == firstController.Left)
			{
				selectMenuPlayer1.Previous();
			}
			if (key == firstController.Right)
			{
				selectMenuPlayer1.Next();
			}
			if (key == firstController.A)
			{
				selectMenuPlayer1.Select();
			}

			if (key == secondController.Left)
			{
				selectMenuPlayer2.Previous();
			}
			if (key == secondController.Right)
			{
				selectMenuPlayer2.Next();
			}
			if (key == secondController.A)
			{
				selectMenuPlayer2.Select();
			}
			Repaint();

			if (selectMenuPlayer1.Selected && selectMenuPlayer2.Selected)
			{
				OnBothSelected();
			}
		}

		private void OnBothSelected()
		{
			isLocked = true;
			Task.Delay(Timeouts.CharacterSelectTimeout).ContinueWith((result) =>
			{
				soundManager.PlaySound(Sounds.CharacterSelected);
				MainController.CurrentView = new PreFightView(MainController, image, assetManager, soundManager);
			});
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

		protected override void PaintContent(Graphics graphics)
		{
			ICharacterState player1 = selectMenuPlayer1.CurrentCharacter;
			ICharacterState player2 = selectMenuPlayer2.CurrentCharacter;

			DrawBackground(graphics, background);
			DrawImage(graphics, udcLabel, 0, 0, cellX * 5, cellY * 5);
			graphics.DrawString("Выберите персонажей", mainFont, ColorConstants.CharacterSelectLabels, cellX * 7, cellY * 2);
			for (int i = 0; i < selectMenuPlayer1.Characters.Count; i++)
			{
				DrawImage(graphics, selectMenuPlayer1.Characters[i].Icon, cellX * i * 2 + cellX, cellY * 4, cellX * 2, cellX * 2);
			}

			if (!selectMenuPlayer1.Selected)
			{
				DrawImage(graphics, selectFirstImage, cellX * selectMenuPlayer1.Selection * 2 + cellX, cellY * 4, cellX * 2,
					cellX * 2);
			}

			DrawImage(graphics, player1.Image, cellX * 1, cellY * 10, cellY * 10, cellY * 10);
			graphics.DrawString(selectMenuPlayer1.Characters[selectMenuPlayer1.Selection].PlayerName, mainFont, selectMenuPlayer1.Selected? ColorConstants.Selected : ColorConstants.NonSelected, cellX, cellY * 8);

			if (!selectMenuPlayer2.Selected)
			{
				DrawImage(graphics, selectSecondImage, cellX * selectMenuPlayer2.Selection * 2 + cellX, cellY * 4, cellX * 2, cellX * 2);
			}
			graphics.DrawString(selectMenuPlayer2.Characters[selectMenuPlayer2.Selection].PlayerName, mainFont, selectMenuPlayer2.Selected ? ColorConstants.Selected : ColorConstants.NonSelected, cellX * 15, cellY * 8);
			DrawImage(graphics, player2.Image, cellX * 13, cellY * 10, cellY * 10, cellY * 10);
		}
	}
}
