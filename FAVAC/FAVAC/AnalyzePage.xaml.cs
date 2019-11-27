//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
// __/\\\\\\\___/\\\///////\\\_\/\\\///////////______/\\\///\\\____\///\\\___/\\\/__                                                                                                                                                                                  
//  _\/////\\\__\///______/\\\__\/\\\_______________/\\\/__\///\\\____\///\\\\\\/____                                                                                                                                                                                 
//   _____\/\\\_________/\\\//___\/\\\\\\\\\\\______/\\\______\//\\\_____\//\\\\______                                                                                                                                                                                
//    _____\/\\\________\////\\\__\/\\\///////______\/\\\_______\/\\\______\/\\\\______                                                                                                                                                                               
//     _____\/\\\___________\//\\\_\/\\\_____________\//\\\______/\\\_______/\\\\\\_____                                                                                                                                                                              
//      _____\/\\\__/\\\______/\\\__\/\\\______________\///\\\__/\\\_______/\\\////\\\___                                                                                                                                                                             
//       _____\/\\\_\///\\\\\\\\\/___\/\\\________________\///\\\\\/______/\\\/___\///\\\_                                                                                                                                                                            
//        _____\///____\/////////_____\///___________________\/////_______\///_______\///__       
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace FAVAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalyzePage : ContentPage
    {
        string symbol = "EURUSD";
        bool ready = false;
        public AnalyzePage()
        {
            InitializeComponent();
            webCardsLoad();
        }

        WebView _webView(int id)
        {
            WebView webView = new WebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(-2,0,-1,0)
            };
            switch (id)
            {
                case 0:
                    webView.HeightRequest = (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait) ? 240 : 190;
                    webView.Source = $"https://s.tradingview.com/embed-widget/symbol-info/?locale=en&amp;symbol={symbol}#%7B%22symbol%22%3A%22{symbol}%22%2C%22width%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22height%22%3A206%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22symbol-info%22%7D";
                    break;
                case 1:
                    webView.HeightRequest = 410;
                    webView.Source = $"https://s.tradingview.com/embed-widget/technical-analysis/?locale=en#%7B%22interval%22%3A%225m%22%2C%22width%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22height%22%3A%22100%25%22%2C%22symbol%22%3A%22{symbol}%22%2C%22showIntervalTabs%22%3Atrue%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22technical-analysis%22%7D";
                    break;
                case 2:
                    webView.HeightRequest = 460;
                    webView.Source = $"https://s.tradingview.com/embed-widget/financials/?locale=en#%7B%22symbol%22%3A%22{symbol}%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22largeChartUrl%22%3A%22%22%2C%22displayMode%22%3A%22adaptive%22%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22financials%22%7D";
                    break;
                case 3:
                    webView.HeightRequest = 800;
                    webView.Source = $"https://s.tradingview.com/embed-widget/symbol-profile/?locale=en&amp;symbol={symbol}#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22symbol-profile%22%7D";
                    break;
            }
          //  webView.Navigating += (s, e) => { e.Cancel = (ready) ? true : false; if (!ready) ready = true; };

            return webView;
        }

        void webCardsLoad()
        {
            webCards.Children.Clear();
            for(int i = 0; i<4; i++) { webCards.Children.Add(_webView(i)); } 
        }

        private void m_symbols_Completed(object sender, EventArgs e)
        {
            symbol = (sender as Entry).Text;
            webCardsLoad();
        }
    }
}