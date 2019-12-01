using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FAVAC
{
    public class WebViewHand : ContentPage
    {
        public WebViewHand()
        {
            WebView webView = new WebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(-2)
            };
            MessagingCenter.Subscribe<string>(this, "SetWebViewKey", _source => Device.BeginInvokeOnMainThread(() =>
            {
                string[] data = _source.Split('|');
                Title = data[0];
                webView.Source = data[1];
            }));
            Content = webView;
        }
    }
}