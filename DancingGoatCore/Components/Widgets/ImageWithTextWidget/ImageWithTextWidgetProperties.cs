using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace DancingGoat.Widgets
{
    /// <summary>
    /// Hero image widget properties.
    /// </summary>
    public class ImageWithTextWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Media library name.
        /// </summary>
        public const string MEDIA_LIBRARY_NAME = "BeyondOne";

        /// <summary>
        /// Headline to be displayed.
        /// </summary>
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Headline", Order = 1)]
        public string Headline { get; set; }

        /// <summary>
        /// Type of Headline.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "HeadLine type", Order = 2)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "h1;h1\r\n h2;h2 \r\n h3;h3")]
        public string HeadlineType { get; set; } = "h1";

        /// <summary>
        /// Type of Headline.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "HeadLine type", Order = 3)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "blue;blue\r\n red;red \r\n green;green")]
        public string HeadlineColor { get; set; } = "blue";

        /// <summary>
        /// Guid of  image.
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Widget image", Order = 4)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.LibraryName), MEDIA_LIBRARY_NAME)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg")]
        [Required]
        public IEnumerable<MediaFilesSelectorItem> DesktopImage { get; set; } = new List<MediaFilesSelectorItem>();




        /// <summary>
        /// Text to be displayed.
        /// </summary>
        /// 
        [EditingComponent(RichTextComponent.IDENTIFIER, Label = "Text", Order = 8)]
        public string Text { get; set; }


        /// <summary>
        /// Alt text.
        /// </summary>
           [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "AltText", Order = 9)]
        public string AltText { get; set; }


        /// <summary>
        /// Capture text
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Image Capture Text", Order = 6)]
        public string CaptureText { get; set; }


        /// <summary>
        /// card ratio of the widget.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Card Ratio", Order = 5)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "one-one; 1:1\r\n one-two; 1:2\r\n two-one; 2:1")]
        public string CardRatio { get; set; } = "1:1";

        /// <summary>
        /// Alignemnet of the widget.
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Image Alignment", Order = 7)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "left;left\r\n right;right")]
        public string ImageAlignment { get; set; } = "left";

        
    }
}