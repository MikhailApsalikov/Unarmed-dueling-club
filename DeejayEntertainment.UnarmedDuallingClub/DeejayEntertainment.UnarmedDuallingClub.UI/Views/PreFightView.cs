using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Common.Constants;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using DeejayEntertainment.UnarmedDuallingClub.UI.Enums;
using AssetImage = System.Drawing.Image;
using Image = System.Windows.Controls.Image;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public class PreFightView : GameViewBase
	{
		private const double ScaleDelta = 0.01;
		private const double ScaleMaximum = 2;
		private AssetImage background;
		private Task repaintTask;
		private CancellationTokenSource tokenSource;
		private double scale;

		public PreFightView(MainController mainController, Image image, AssetManager assetManager, SoundManager soundManager)
			:base (mainController, image, assetManager, soundManager)
		{
			scale = 1;
		}

		public override View View => View.PreFight;

		public override void OnClose()
		{
			tokenSource.Cancel();
			repaintTask = null;
		}

		public override void OnKeyPressed(Key key)
		{
		}

		public override void OnOpen()
		{
			tokenSource = new CancellationTokenSource();
			repaintTask = new Task(() =>
			{
				while (!tokenSource.IsCancellationRequested)
				{
					MainController.Repaint();
					if (scale < ScaleMaximum)
					{
						scale += ScaleDelta;
					}
					Thread.Sleep(Timeouts.FightRepaintInterval);
				}
			}, tokenSource.Token);
			repaintTask.Start();
		}

		protected override void LoadResources()
		{
			background = assetManager.GetImageByPath("resources/arena/arena1.jpg");
		}

		protected override void PaintContent(Graphics graphics)
		{
			DrawImage(graphics, background, GameXToRealX((int)(-scale * Width / 2), Width), GameYToRealY((int)(-scale * Height / 2), Height), (int)(Width * scale), (int)(Height * scale));
		}
	}
}
