using System.Windows;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Configuration;

namespace DeejayEntertainment.UnarmedDuallingClub.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			var a = new GameBalanceConfigurationManager();
			var b = a.GetConfiguration();
		}
	}
}
