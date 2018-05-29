using System;
using System.IO;
using System.Threading;
using System.Windows;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Configuration;
using DeejayEntertainment.UnarmedDuallingClub.Sound;

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
			SoundManager sm = new SoundManager(Path.Combine(Environment.CurrentDirectory, "Resources/sounds"),
				Path.Combine(Environment.CurrentDirectory, "Resources/music"));
			sm.SetBackgroundMusic(Music.Fight1);
			Thread.Sleep(3000);
			sm.PlaySound(Sounds.ShadowForm);
			sm.PlaySound(Sounds.Cyclone);
			sm.PlaySound(Sounds.Bleed);

		}
	}
}
