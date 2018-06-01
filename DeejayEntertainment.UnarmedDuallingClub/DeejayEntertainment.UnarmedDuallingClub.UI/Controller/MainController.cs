using DeejayEntertainment.UnarmedDuallingClub.UI.Views;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;


namespace DeejayEntertainment.UnarmedDuallingClub.UI.Controller
{
	public class MainController
	{
		public readonly Image display;
		private DrawingGroup DrawingGroup => (display.Source as DrawingImage).Drawing as DrawingGroup;
		private GameViewBase CurrentView { get; set; }

		public MainController(Image display)
		{
			this.display = display;
			CurrentView = new MainMenuView(this, null, DrawingGroup);
		}

		public void Repaint()
		{
			CurrentView.Repaint();
		}

		public void ChangeView(GameViewBase view)
		{
			CurrentView.OnClose();
			CurrentView = view;
			CurrentView.OnOpen();
			Repaint();
		}

		public void OnKeyPressed(Key key)
		{
			CurrentView.OnKeyPressed(key);
		}
	}
}
