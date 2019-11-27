﻿//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
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
        ToolbarItem toolbarItem_switchView = new ToolbarItem
        {
            Text = "PROFILE",
            Priority = 0,
            Order = ToolbarItemOrder.Primary
        };
        string symbol = "AAPL";
        bool ready = false;
        public AnalyzePage()
        {
            InitializeComponent();
            webCardsLoad();

            toolbarItem_switchView.Clicked += (s, e) => {
                if ((s as ToolbarItem).Text == "PROFILE")
                {
                    (s as ToolbarItem).Text = "MAIN";
                    Title = "PROFILE";
                } else
                {
                    (s as ToolbarItem).Text = "PROFILE";
                    Title = "MAIN";
                }
                webCardsLoad();
            };
            ToolbarItems.Add(toolbarItem_switchView);
        }

        WebView _webView(int id)
        {
            UriBuilder uriBuilder = new UriBuilder("https", "s.tradingview.com");
            WebView webView = new WebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.Black,
                Margin = new Thickness(-2,0,-1,0)
            };
            switch (id)
            {
                case 0:
                    HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource();
                    htmlWebViewSource.Html = @"<html><body"  + " style=\"padding: 0; margin: 0; background-color: #1E222D;\"" + ">" +
                        "<div class=\"tradingview-widget-container\">" + 
                        "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-symbol-info.js\" async>{" +
                        $"\"symbol\": \"{symbol}\",\"width\": \"100%\",\"locale\": \"{Settings.Language}\",\"colorTheme\": \"dark\",\"isTransparent\": false" +
                        "}</script>" +
                        "</div></body></html>";
                    webView.HeightRequest = (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait) ? 240 : 123;
                    webView.Source = htmlWebViewSource;
                    // https://s.tradingview.com/embed-widget/symbol-info/?locale=en&amp;symbol=EURRUB#%7B%22symbol%22%3A%22EURRUB%22%2C%22width%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22height%22%3A206%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22symbol-info%22%7D
                    // https://s.tradingview.com/embed-widget/mini-symbol-overview/?locale=ru#%7B%22symbol%22%3A%22AAAP%22%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22dateRange%22%3A%2212m%22%2C%22colorTheme%22%3A%22dark%22%2C%22trendLineColor%22%3A%22%2337a6ef%22%2C%22underLineColor%22%3A%22rgba(55%2C%20166%2C%20239%2C%200.15)%22%2C%22isTransparent%22%3Afalse%2C%22autosize%22%3Atrue%2C%22largeChartUrl%22%3A%22%22%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22mini-symbol-overview%22%7D
                    break;
                case 1:
                    uriBuilder.Path = "/embed-widget/technical-analysis/";
                    uriBuilder.Query = $"?locale={Settings.Language}#%7B%22interval%22%3A%225m%22%2C%22width%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22height%22%3A%22100%25%22%2C%22symbol%22%3A%22{symbol}%22%2C%22showIntervalTabs%22%3Atrue%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22technical-analysis%22%7D";
                    webView.HeightRequest = 420;
                    webView.Source = uriBuilder.Uri;
                    // $"https://s.tradingview.com/embed-widget/technical-analysis/?locale=en#%7B%22interval%22%3A%225m%22%2C%22width%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22height%22%3A%22100%25%22%2C%22symbol%22%3A%22{symbol}%22%2C%22showIntervalTabs%22%3Atrue%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22technical-analysis%22%7D";
                    break;
                case 2:
                    uriBuilder.Path = "/embed-widget/financials/";
                    uriBuilder.Query = $"?locale={Settings.Language}#%7B%22symbol%22%3A%22{symbol}%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22largeChartUrl%22%3A%22%22%2C%22displayMode%22%3A%22adaptive%22%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22financials%22%7D";
                    webView.HeightRequest = 489;
                    webView.Source = uriBuilder.Uri;
                    // $"https://s.tradingview.com/embed-widget/financials/?locale=en#%7B%22symbol%22%3A%22{symbol}%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22largeChartUrl%22%3A%22%22%2C%22displayMode%22%3A%22adaptive%22%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22financials%22%7D";
                    break;
                case 3:
                    uriBuilder.Path = "/embed-widget/symbol-profile/";
                    uriBuilder.Query = $"?locale={Settings.Language}&amp;symbol={symbol}#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22symbol-profile%22%7D";
                    webView.HeightRequest = 800;
                    webView.Source = uriBuilder.Uri;
                    // $"https://s.tradingview.com/embed-widget/symbol-profile/?locale=en&amp;symbol={symbol}#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22symbol-profile%22%7D";
                    break;
            }
          //  webView.Navigating += (s, e) => { e.Cancel = (ready) ? true : false; if (!ready) ready = true; };

            return webView;
        }

        void webCardsLoad()
        {
            webCards.Children.Clear();
            if (toolbarItem_switchView.Text == "PROFILE")
            {
                webCards.Children.Add(_webView(0));
                webCards.Children.Add(_webView(1));
            } else
            {
                webCards.Children.Add(_webView(2));
                webCards.Children.Add(_webView(3));
            }
        }

        private void m_symbols_Completed(object sender, EventArgs e)
        {
            symbol = (sender as Entry).Text;
            webCardsLoad();
        }
    }
}