using CMS.MediaLibrary;

namespace DancingGoat.Widgets
{
    /// <summary>
    /// View model for Image with text widget.
    /// </summary>
    public class ImageWithTextWidgetViewModel
    {

        public string Headline { get; set; }
        public string DesktopImage { get; set; }

        public string Text { get; set; }

        public string HeadlineColor { get; set; }
        public string HeadlineType { get; set; }
        public string AltText { get; set; }
        public string CaptureText { get; set; }
        public string ImageAlignment { get; set; }
        public string CardRatio { get; set; }
    }
}