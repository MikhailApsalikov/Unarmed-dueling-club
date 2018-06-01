using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using System;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Media;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class MainMenuView : GameViewBase
	{
		private readonly IMainMenu mainMenu;

		// add font

		public MainMenuView(MainController controller, IMainMenu mainMenu, DrawingGroup drawingGroup) : base(controller, drawingGroup)
		{
			
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
			throw new NotImplementedException();
		}

		protected override void PaintContent(Graphics graphics)
		{
			throw new NotImplementedException();
		}
	}
}
