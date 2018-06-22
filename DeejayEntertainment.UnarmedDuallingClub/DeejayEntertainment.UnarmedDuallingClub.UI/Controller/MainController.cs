﻿using System;
using System.Windows;
using DeejayEntertainment.UnarmedDuallingClub.UI.Views;
using System.Windows.Input;
using System.Windows.Controls;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.GameCore;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Controller
{
	public class MainController
	{
		private readonly Image image;
		private readonly AssetManager assetManager;
		private GameViewBase currentView;
		private GameViewBase CurrentView
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
			}
		}
		public int Width { get; }
		public int Height { get; }

		public MainController(Image image, Window window)
		{
			this.image = image;
			Width = (int)window.ActualWidth;
			Height = (int)window.ActualHeight;
			assetManager = new AssetManager(Environment.CurrentDirectory);
			CurrentView = new MainMenuView(this, image, assetManager, new MainMenu());
			Repaint();
		}

		public void Repaint()
		{
			CurrentView.Repaint();
		}

		public void OnKeyPressed(Key key)
		{
			CurrentView.OnKeyPressed(key);
		}
	}
}