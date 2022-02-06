using Xamarin.Essentials;
using Xamarin.Forms;

namespace dashy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
     
            DeviceDisplay.KeepScreenOn = true;
        }
    }
}
