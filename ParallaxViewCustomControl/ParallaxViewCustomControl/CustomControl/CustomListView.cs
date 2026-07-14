using Syncfusion.Maui.Core;
using System.Collections;

namespace ParallaxViewCustomControl
{
    public class CustomListView : CollectionView, IParallaxView
    {
        public static readonly BindableProperty RowHeightProperty =
            BindableProperty.Create(nameof(RowHeight), typeof(double), typeof(CustomListView), 0d);

        public double RowHeight
        {
            get => (double)GetValue(RowHeightProperty);
            set => SetValue(RowHeightProperty, value);
        }

        public double ItemMargin { get; set; }
        public Size ScrollableContentSize { get; set; }

        public event EventHandler<ParallaxScrollingEventArgs>? Scrolling;

        public CustomListView()
        {
            this.Scrolled += CustomListView_Scrolled;

#if ANDROID
            var info = DeviceDisplay.Current.MainDisplayInfo;
            ItemMargin = info.Density * 4;
#endif
        }

        private void CustomListView_Scrolled(object? sender, ItemsViewScrolledEventArgs e)
        {
            if (sender is CollectionView collectionView && Scrolling != null)
            {
                Scrolling.Invoke(this, new ParallaxScrollingEventArgs(e.HorizontalOffset, e.VerticalOffset, false));
            }
        }

        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            var minimumSize = new Size(40, 40);
            Size request = Size.Zero;

            if (ItemsSource is IList list && RowHeight > 0)
            {
                request = new Size(widthConstraint, list.Count * RowHeight + ItemMargin);
            }

            this.ScrollableContentSize = new Size(request.Width, Math.Max(request.Height, minimumSize.Height));
            return base.MeasureOverride(widthConstraint, heightConstraint);
        }
    }
}
