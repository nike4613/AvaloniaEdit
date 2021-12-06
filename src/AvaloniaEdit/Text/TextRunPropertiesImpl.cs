using System.Globalization;
using Avalonia.Media;
using Avalonia.Media.TextFormatting;

namespace AvaloniaEdit.Text
{
    public class TextRunPropertiesImpl : TextRunProperties
    {
        private Typeface _typeface;
        private double _fontSize;

        public TextRunPropertiesImpl Clone()
        {
            TextRunPropertiesImpl clone = new();

            clone.BackgroundBrushImpl = BackgroundBrushImpl;
            clone.CultureInfoImpl = CultureInfoImpl;
            clone.ForegroundBrushImpl = ForegroundBrushImpl;
            clone.TypefaceImpl = TypefaceImpl;
            clone._fontSize = FontSize;
            clone.FontMetrics = FontMetrics;
            clone.Underline = Underline;
            clone.Strikethrough = Strikethrough;

            return clone;
        }

        public IBrush BackgroundBrushImpl { get; set; }

        public CultureInfo CultureInfoImpl { get; set; }

        public IBrush ForegroundBrushImpl { get; set; }

        public Typeface TypefaceImpl
        {
            get { return _typeface; }
            set
            {
                _typeface = value;
                InvalidateFontMetrics();
            }
        }

        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                InvalidateFontMetrics();
            }
        }

        public bool Underline { get; set; }

        public bool Strikethrough { get; set; }

        public FontMetrics FontMetrics { get; private set; }

        public override Typeface Typeface => TypefaceImpl;

        public override double FontRenderingEmSize => FontSize;

        // TODO: use this instead of Underline/Strikethrough bools
        public override TextDecorationCollection TextDecorations => new();

        public override IBrush ForegroundBrush => ForegroundBrushImpl;

        public override IBrush BackgroundBrush => BackgroundBrushImpl;

        public override CultureInfo CultureInfo => CultureInfoImpl;

        void InvalidateFontMetrics()
        {
            if (_typeface.FontFamily == null || _fontSize == 0)
                return;

            FontMetrics = new FontMetrics(_typeface, _fontSize);
        }
    }
}
