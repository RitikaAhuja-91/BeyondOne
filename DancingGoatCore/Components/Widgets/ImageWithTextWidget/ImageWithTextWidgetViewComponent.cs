using System;
using System.Linq;

using CMS.MediaLibrary;
using CMS.SiteProvider;

using DancingGoat.Models;
using DancingGoat.Widgets;

using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

[assembly: RegisterWidget(ImageWithTextWidgetViewComponent.IDENTIFIER, typeof(ImageWithTextWidgetViewComponent), "Image with Text", typeof(ImageWithTextWidgetProperties), Description = "Displays an image, text, and headline.", IconClass = "icon-badge")]

namespace DancingGoat.Widgets
{
    /// <summary>
    /// Controller for hero image widget.
    /// </summary>
    public class ImageWithTextWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "DancingGoat.HomePage.ImageWithText";


        private readonly MediaFileRepository mediaFileRepository;
        private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;


        /// <summary>
        /// Creates an instance of <see cref="BannerWidgetController"/> class.
        /// </summary>
        /// <param name="mediaFileRepository">Repository for media files.</param>
        /// <param name="mediaFileUrlRetriever">The media file URL retriever.</param>
        public ImageWithTextWidgetViewComponent(MediaFileRepository mediaFileRepository, IMediaFileUrlRetriever mediaFileUrlRetriever)
        {
            this.mediaFileRepository = mediaFileRepository;
            this.mediaFileUrlRetriever = mediaFileUrlRetriever;
        }


        public ViewViewComponentResult Invoke(ImageWithTextWidgetProperties properties)
        {
            var image = GetImage(properties);

            return View("~/Components/Widgets/ImageWithTextWidget/_ImageWithTextWidget.cshtml", new ImageWithTextWidgetViewModel
            {
                DesktopImage = image == null ? null : mediaFileUrlRetriever.Retrieve(image).RelativePath,
                Text = properties.Text,
                AltText = properties.AltText,
                CaptureText = properties.CaptureText,
                ImageAlignment = properties.ImageAlignment,
                Headline = properties.Headline,
                CardRatio = properties.CardRatio,
                HeadlineColor = properties.HeadlineColor,
                HeadlineType = properties.HeadlineType
            });
        }


        private MediaFileInfo GetImage(ImageWithTextWidgetProperties properties)
        {
            var imageGuid = properties.DesktopImage.FirstOrDefault()?.FileGuid ?? Guid.Empty;
            if (imageGuid == Guid.Empty)
            {
                return null;
            }

            return mediaFileRepository.GetMediaFile(imageGuid, SiteContext.CurrentSiteID);
        }
    }
}