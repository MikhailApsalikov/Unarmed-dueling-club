using DeejayEntertainment.UnarmedDuallingClub.UI.Controller;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DeejayEntertainment.UnarmedDuallingClub.UI.Views
{
	public abstract class GameViewBase
	{
		protected readonly MainController viewManager;
		protected readonly DrawingGroup drawingGroup;


		public GameViewBase(MainController viewManager, DrawingGroup drawingGroup)
		{
			this.viewManager = viewManager;
			this.drawingGroup = drawingGroup;
			LoadResources();
		}

		protected abstract void LoadResources();

		public abstract void OnClose();

		public abstract void OnKeyPressed(Key key);

		public abstract void OnOpen();

		public void Repaint()
		{
			Bitmap bitmap = new Bitmap((int)drawingGroup., (int)drawingGroup.ActualHeight);
			Graphics graphics = Graphics.FromImage(bitmap);
			PaintContent(graphics);
			canvas.

				/*Image buffer = new Bitmap(width, height, BufferedImage.TYPE_3BYTE_BGR);
			Graphics doubleBufferingGraphics = buffer.getGraphics();
			paintOnBuffer(doubleBufferingGraphics);
			gr.drawImage(buffer, 0, 0, this);*/
		}
		protected abstract void PaintContent(Graphics graphics);
	}
}
