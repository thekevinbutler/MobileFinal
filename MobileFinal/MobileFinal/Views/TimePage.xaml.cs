using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
namespace MobileFinal.Views
{
    public partial class TimePage : ContentPage
    {
		SKBitmap clockMarkings = new SKBitmap();
		SKPaint clockBack = new SKPaint
		{
			Style = SKPaintStyle.Fill,
			Color = SKColors.Purple
		};
        public TimePage()
        {
            InitializeComponent();
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

			canvas.DrawCircle(0, 0, 100, clockBack);
		}
	}
}
