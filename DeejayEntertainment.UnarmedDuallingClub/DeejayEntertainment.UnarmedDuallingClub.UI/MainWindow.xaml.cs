using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace DeejayEntertainment.UnarmedDuallingClub.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainController ViewManager;

		public MainWindow()
		{
			InitializeComponent();
			ViewManager = new MainController(Display);
		}
	}
}
