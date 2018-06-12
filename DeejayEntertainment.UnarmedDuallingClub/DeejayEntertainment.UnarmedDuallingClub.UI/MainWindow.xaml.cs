using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using System;
using System.Windows;

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
			MainController = new MainController(Display, this);
		}
	}
}
