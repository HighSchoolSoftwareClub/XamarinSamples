using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RadialProgressExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            btnStart.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                if (radialProgress.Maximum == radialProgress.Value)
                {
                    btnStart.IsEnabled = true;
                    return false;
                }
                radialProgress.Value++;
                return true;
            });
        }
    }
}
