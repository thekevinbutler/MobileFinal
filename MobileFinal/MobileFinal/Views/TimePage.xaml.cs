using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;

namespace MobileFinal.Views
{
    public partial class TimePage : ContentPage
    {
		SKPaint clockBack = new SKPaint
		{
			Style = SKPaintStyle.Fill,
			Color = SKColors.Purple
		};

		SKPaint whiteHands = new SKPaint
		{
			Style = SKPaintStyle.Stroke,
			Color = SKColors.White,
			StrokeWidth = 2,
			StrokeCap = SKStrokeCap.Round,
			IsAntialias = true
		};
        public TimePage()
        {
            InitializeComponent();
			Device.StartTimer(TimeSpan.FromSeconds(1.0f/60.0f),()=>
			{
				ClockView.InvalidateSurface();
				return true;
			});
        }
		public void On_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear(SKColors.MediumPurple);

			int width = e.Info.Width;
			int height = e.Info.Height;

			canvas.Translate(width / 2, height / 2);
			canvas.Scale(width / 200f);

			DateTime dateTime = DateTime.Now;
			DigitalTimeLabel.Text = dateTime.ToLongTimeString();
			//draw back
			canvas.DrawCircle(0, 0, 100, clockBack);
			//draw hour
			canvas.Save();
			canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2.0f);
			whiteHands.StrokeWidth = 5;
			canvas.DrawLine(0, 0, 0, -50, whiteHands);
			canvas.Restore();
			//draw Minutes
			canvas.Save();
			canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10.0f);
			whiteHands.StrokeWidth = 5;
			canvas.DrawLine(0, 0, 0, -80, whiteHands);
			canvas.Restore();
			//draw seconds
			canvas.Save();
			canvas.RotateDegrees(6 *(dateTime.Second + dateTime.Millisecond / 1000.0f));
			whiteHands.StrokeWidth = 3;
			canvas.DrawLine(0, 0, 0, -90, whiteHands);
			canvas.Restore();
		}
	}
}
