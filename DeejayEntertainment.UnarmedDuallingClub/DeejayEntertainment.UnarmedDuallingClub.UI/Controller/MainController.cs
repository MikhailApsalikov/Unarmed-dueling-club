using System;
using System.Windows;
using DeejayEntertainment.UnarmedDuallingClub.UI.Views;
using System.Windows.Input;
using System.Windows.Controls;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.GameCore;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using System.IO;
using System.Threading;
using DeejayEntertainment.UnarmedDuallingClub.Common.Constants;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Controller
{
	public class MainController
	{
		private readonly Image image;
		private readonly AssetManager assetManager;
		private readonly SoundManager soundManager;
		private Window window;
		private GameViewBase currentView;
		public GameViewBase CurrentView
		{
			get
			{
				return currentView;
			}
			set
			{
				currentView?.OnClose();
				currentView = value;
				currentView.OnOpen();
				Repaint();
				PickMusic(currentView);
			}
		}

		public int Width { get; }
		public int Height { get; }

		public MainController(Image image, Window window)
		{
			this.image = image;
			this.window = window;
			Width = (int)window.ActualWidth;
			Height = (int)window.ActualHeight;
			assetManager = new AssetManager(Environment.CurrentDirectory);
			soundManager = new SoundManager(Path.Combine(Environment.CurrentDirectory, "Resources\\sounds"), Path.Combine(Environment.CurrentDirectory, "Resources/music"));
			CurrentView = new MainMenuView(this, image, assetManager, soundManager, new MainMenu(soundManager));
			Repaint();
		}

		public void Repaint()
		{
			CurrentView.Repaint();
		}

		private void PickMusic(GameViewBase currentView)
		{
			switch (currentView.View)
			{
				case Enums.View.MainMenu:
					soundManager.SetBackgroundMusic(Music.MainMenuTheme);
					break;
				case Enums.View.About:
					soundManager.SetBackgroundMusic(Music.AboutMenuTheme);
					break;
				case Enums.View.Character:
					soundManager.SetBackgroundMusic(Music.AboutMenuTheme);
					break;
			}
		}

		public void OnKeyPressed(Key key)
		{
			CurrentView.OnKeyPressed(key);
		}

		public void ExitGame()
		{
			window.Visibility = Visibility.Hidden;
			Thread.Sleep(Timeouts.ExitTimeOut);
			soundManager.Dispose();
			window.Close();
		}
	}
}
