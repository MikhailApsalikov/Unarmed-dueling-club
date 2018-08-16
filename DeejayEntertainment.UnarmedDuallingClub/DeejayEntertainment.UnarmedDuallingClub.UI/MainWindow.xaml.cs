using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using System;
using System.Windows;
using System.Windows.Input;

namespace DeejayEntertainment.UnarmedDuallingClub.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainController MainController { get; set; }

		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnContentRendered(EventArgs e)
		{
			base.OnContentRendered(e);
			MainController = new MainController(Canvas, this);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			MainController?.OnKeyPressed(e.Key);
		}
	}
}
