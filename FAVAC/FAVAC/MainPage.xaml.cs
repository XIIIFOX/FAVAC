//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
// __/\\\\\\\___/\\\///////\\\_\/\\\///////////______/\\\///\\\____\///\\\___/\\\/__                                                                                                                                                                                  
//  _\/////\\\__\///______/\\\__\/\\\_______________/\\\/__\///\\\____\///\\\\\\/____                                                                                                                                                                                 
//   _____\/\\\_________/\\\//___\/\\\\\\\\\\\______/\\\______\//\\\_____\//\\\\______                                                                                                                                                                                
//    _____\/\\\________\////\\\__\/\\\///////______\/\\\_______\/\\\______\/\\\\______                                                                                                                                                                               
//     _____\/\\\___________\//\\\_\/\\\_____________\//\\\______/\\\_______/\\\\\\_____                                                                                                                                                                              
//      _____\/\\\__/\\\______/\\\__\/\\\______________\///\\\__/\\\_______/\\\////\\\___                                                                                                                                                                             
//       _____\/\\\_\///\\\\\\\\\/___\/\\\________________\///\\\\\/______/\\\/___\///\\\_                                                                                                                                                                            
//        _____\///____\/////////_____\///___________________\/////_______\///_______\///__        
using BottomBar.XamarinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FAVAC
{
    [DesignTimeVisible(false)]
    public partial class MainPage : BottomBarPage
    {
        public MainPage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    quotes_page.IconImageSource = "round_receipt_24.xml";
                    chart_page.IconImageSource = "round_show_chart_24.xml";
                    news_ideas_page.IconImageSource = "round_change_history_24.xml";
                    signals_page.IconImageSource = "round_donut_large_24.xml";
                    more_page.IconImageSource = "round_reorder_24.xml";
                    break;
                case Device.iOS:
                    quotes_page.IconImageSource = "round_receipt_24.xml";
                    chart_page.IconImageSource = "round_show_chart_24.xml";
                    news_ideas_page.IconImageSource = "round_change_history_24.xml";
                    signals_page.IconImageSource = "round_donut_large_24.xml";
                    more_page.IconImageSource = "round_reorder_24.xml";
                    break;
                case Device.UWP:
                    quotes_page.IconImageSource = "round_receipt_24.png";
                    chart_page.IconImageSource = "round_show_chart_24.png";
                    news_ideas_page.IconImageSource = "round_change_history_24.png";
                    signals_page.IconImageSource = "round_donut_large_24.png";
                    more_page.IconImageSource = "round_reorder_24.png";
                    break;
            }

            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    if (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape) {; }
                    else;
                    break;
                case TargetIdiom.Tablet:
                    break;
                case TargetIdiom.Desktop:
                    FixedMode = true;
                    break;
                case TargetIdiom.TV:
                    FixedMode = true;
                    break;
            }
        }
    }
}
