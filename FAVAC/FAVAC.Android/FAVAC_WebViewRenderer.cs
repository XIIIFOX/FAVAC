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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FAVAC;
using FAVAC.Droid;
using Android.Graphics;
using Android.Widget;

[assembly: ExportRenderer(typeof(FAVAC_WebView), typeof(FAVAC_WebViewRenderer))]
namespace FAVAC.Droid
{
    public class FAVAC_WebViewRenderer : ViewRenderer<FAVAC_WebView, Android.Webkit.WebView>
    {
        readonly Context _context;
        public FAVAC_WebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<FAVAC_WebView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                var webView = e.OldElement as FAVAC_WebView;
                webView.Cleanup();
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var webView = new Android.Webkit.WebView(_context);
                    webView.Settings.JavaScriptEnabled = true;
                    webView.Settings.SetAppCacheEnabled(true);
                    webView.Settings.DomStorageEnabled = true;
                    webView.Settings.DatabaseEnabled = true;;
                    webView.Settings.AllowFileAccess = true;
                    webView.Settings.AllowContentAccess = true;
                    webView.Settings.UseWideViewPort = true;
                    webView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    webView.Settings.DefaultTextEncodingName = "utf-8";
                    webView.SetWebViewClient(new FAVAC_WebViewClient(this));
                    SetNativeControl(webView);
                }
                Control.LoadUrl(Element.Uri);
            }
        }

        internal class FAVAC_WebViewClient : WebViewClient
        {
            private readonly FAVAC_WebViewRenderer fAVAC_WebViewRenderer;

            public FAVAC_WebViewClient(FAVAC_WebViewRenderer fAVAC_WebViewRenderer)
            {
                this.fAVAC_WebViewRenderer = fAVAC_WebViewRenderer ?? throw new ArgumentNullException("render");
            }

            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                base.OnPageFinished(view, url);

                var source = new UrlWebViewSource { Url = url };
                var args = new WebNavigatedEventArgs(WebNavigationEvent.NewPage, source, url, WebNavigationResult.Success);
                fAVAC_WebViewRenderer.Element.SendNavigated(args);

                ((IElementController)fAVAC_WebViewRenderer.Element).SetValueFromRenderer(FAVAC_WebView.PageTitleProperty, view.Title);
            }

            public override void OnPageStarted(Android.Webkit.WebView view, string url, Bitmap favicon)
            {
                base.OnPageStarted(view, url, favicon);

                var args = new WebNavigatingEventArgs(WebNavigationEvent.NewPage, new UrlWebViewSource { Url = url }, url);
                fAVAC_WebViewRenderer.Element.SendNavigating(args);
            }
        }
    }
}