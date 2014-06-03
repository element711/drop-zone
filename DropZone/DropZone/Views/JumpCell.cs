using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents a jump.
    /// </summary>
    public class JumpCell : ViewCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JumpCell"/> class.
        /// </summary>
        public JumpCell()
        {
            Image image = new Image
            {
                HorizontalOptions = LayoutOptions.Start
            };
            image.SetBinding(Image.SourceProperty, new Binding("ThumbnailImage"));
            image.WidthRequest = image.HeightRequest = 100;

            StackLayout jumpLayout = CreateJumpDescriptionLayout();

            StackLayout viewLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {image, jumpLayout}
            };

            View = viewLayout;
        }

        private static StackLayout CreateJumpDescriptionLayout()
        {
            Label jumpNumber = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(NamedSize.Large)
            };
            jumpNumber.SetBinding(Label.TextProperty, "JumpNumber");
            
            Label jumpDescription = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            jumpDescription.SetBinding(Label.TextProperty, "Description");

            StackLayout nameLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = {jumpNumber, jumpDescription}
            };
            return nameLayout;
        }
    }
}