using Avalonia.Media;
using Avalonia.Media.TextFormatting;

namespace AvaloniaEdit.Text
{
    public sealed class TextParagraphPropertiesImpl : TextParagraphProperties
    {
        public double DefaultIncrementalTab { get; set; }

        public bool FirstLineInParagraph { get; set; }

        public TextRunProperties DefaultTextRunPropertiesImpl { get; set; }

        public override TextRunProperties DefaultTextRunProperties => DefaultTextRunPropertiesImpl;

        public TextWrapping TextWrappingImpl { get; set; }

        public override TextWrapping TextWrapping => TextWrappingImpl;

        public double Indent { get; set; }

        public TextAlignment TextAlignmentImpl { get; set; }

        public override TextAlignment TextAlignment => TextAlignmentImpl;

        public double LineHeightImpl { get; set; }

        public override double LineHeight => LineHeightImpl;
    }
}
