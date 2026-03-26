using System.Collections.ObjectModel;
using System.Reflection;

namespace ParallaxViewCustomControl
{
    public class ParallaxViewModel
    {
        int count;
        public ImageSource Image { get; set; }

        public ObservableCollection<Contacts> Items { get; set; }
        public ParallaxViewModel()
        {
            Assembly assembly = typeof(ParallaxViewModel).GetTypeInfo().Assembly;

            Image = ImageSource.FromResource("ParallaxViewCustomControl.Resources.Images.parallax.jpg", assembly);
            
            Items = new ObservableCollection<Contacts>()
            {
                new Contacts() { Name = "Thriller", Author = "Michael Jackson" },
                new Contacts() { Name = "Like a Prayer", Author = "Madonna" },
                new Contacts() { Name = "When Doves Cry", Author = "Prince" },
                new Contacts() { Name = "I Wanna Dance", Author = "Whitney Houston" },
                new Contacts() { Name = "It’s Gonna Be Me", Author = "N Sync"},
                new Contacts() { Name = "Everybody", Author = "Backstreet Boys"},
                new Contacts() { Name = "Rolling in the Deep", Author = "Adele" },
                new Contacts() { Name = "Don’t Stop Believing", Author = "Journey" },
                new Contacts() { Name = "Billie Jean", Author = "Michael Jackson" },
                new Contacts() { Name = "Sorry", Author = "Justin Bieber" },
                new Contacts() { Name = "Firework", Author = "Katy Perry"},
                new Contacts() { Name = "The A Team", Author = "Ed Sheeran" },
                new Contacts() { Name = "Thriller", Author = "Michael Jackson" },
                new Contacts() { Name = "Like a Prayer", Author = "Madonna" },
                new Contacts() { Name = "When Doves Cry", Author = "Prince" },
                new Contacts() { Name = "I Wanna Dance", Author = "Whitney Houston" },
                new Contacts() { Name = "It’s Gonna Be Me", Author = "N Sync" },
                new Contacts() { Name = "Everybody", Author = "Backstreet Boys" },
                new Contacts() { Name = "Rolling in the Deep", Author = "Adele" },
                new Contacts() { Name = "Don’t Stop Believing", Author = "Journey"},
            };

            count = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                if (i >= 10)
                {
                    Items[i].ItemImage = ImageSource.FromResource("ParallaxViewCustomControl.Resources.Images.parallax" + count + ".png", assembly);
                    count++;
                }
                else
                {
                    Items[i].ItemImage = ImageSource.FromResource("ParallaxViewCustomControl.Resources.Images.parallax" + i + ".png", assembly);
                }
            }
        }
    }
}
