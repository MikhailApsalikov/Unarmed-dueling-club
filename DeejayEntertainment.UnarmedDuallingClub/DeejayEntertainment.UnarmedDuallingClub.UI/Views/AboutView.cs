using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using ImageControl = System.Windows.Controls.Image;
using AssetImage = System.Drawing.Image;
using DeejayEntertainment.UnarmedDuallingClub.UI.Constants;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using DeejayEntertainment.UnarmedDuallingClub.Common.Constants;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class AboutView : GameViewBase
	{
		public override View View => View.About;
		private List<string> content = new List<string>()
		{
			"Игра Unarmed Duelling Club",
			"Авторы - студенты группы ИВЧТ-21:",
			"1) Апсаликов Михаил - Руководитель проекта, Программист, Дизайнер игровой механики.",
			"2) Духанов Данила - Инженер по звуковым эффектам, Композитор, Актёр озвучивания.",
			"3) Иванов Сергей - Художник спецэффектов, Аниматор, Моушн-дизайнер.",
			"4) Милёхин Дмитрий - Модельер персонажей, Художник по текстурам.",
			"5) Воронов Илья - Главный фотограф.",
			$"Версия {VersionInfo.DisplayVersion}",
			"05.03.2012 - 26.05.2012",
			"(c)Deejay Entertainment. Все права защищены."
		};
		private MainMenuView mainMenu;
		private int indent;
		private int indent2;
		private Font font;
		private AssetImage background;
		private AssetImage udcLabel;

		public AboutView(MainController controller, ImageControl image, AssetManager assetManager, SoundManager soundManager, MainMenuView mainMenu)
			: base(controller, image, assetManager, soundManager)
		{
			this.mainMenu = mainMenu;
			font = new Font("Arial", Height / 35);
			indent = Height / 35;
			indent2 = indent * 7;
		}

		public override void OnKeyPressed(Key key)
		{
			switch (key)
			{
				case Key.Enter:
				case Key.Escape:
				case Key.Space:
					MainController.CurrentView = mainMenu;
					break;
			}
		}

		public override void OnOpen()
		{
		}

		public override void OnClose()
		{
		}

		protected override void LoadResources()
		{
			background = assetManager.GetImageByPath("resources/menu/OtherBG.jpg");
			udcLabel = assetManager.GetImageByPath("resources/menu/UDCLabel.gif");
		}

		protected override void PaintContent(Graphics graphics)
		{
			DrawBackground(graphics, background);
			DrawImage(graphics, udcLabel, Width / 4, 0, Width / 2, Height / 2);
			for (int i = 0; i < content.Count; i++)
			{
				graphics.DrawString(content[i], font, ColorConstants.NormalColorBrush, 50, Height * (10 + i) / 20);
			}
		}
	}
}
