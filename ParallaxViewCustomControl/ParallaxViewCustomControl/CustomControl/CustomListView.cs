using Syncfusion.Maui.Core;
using System.Collections;

namespace ParallaxViewCustomControl
{
    public class CustomListView : ListView, IParallaxView
    {
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

        private void CustomListView_Scrolled(object? sender, ScrolledEventArgs e)
        {
            if (sender is ListView listView && Scrolling != null)
            {
                Scrolling.Invoke(this, new ParallaxScrollingEventArgs(e.ScrollX, e.ScrollY, false));
            }
        }

        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            var minimumSize = new Size(40, 40);
            Size request = Size.Zero;

            if (ItemsSource is IList list && HasUnevenRows == false && RowHeight > 0 && !IsGroupingEnabled)
            {
                request = new Size(widthConstraint, list.Count * RowHeight + ItemMargin);
            }

            this.ScrollableContentSize = new SizeRequest(request, minimumSize);
            return base.MeasureOverride(widthConstraint, heightConstraint);
        }
    }
}
