using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FAVAC
{
    public class FAVAC_WebView : WebView
    {
        Action<string> action;
        public static readonly BindableProperty PageTitleProperty = BindableProperty.Create(
           propertyName: "PageTitle",
           defaultValue: string.Empty,
           returnType: typeof(string),
           declaringType: typeof(string),
           defaultBindingMode: BindingMode.OneWayToSource);
        public static readonly BindableProperty UriProperty = BindableProperty.Create(
         propertyName: "Uri",
         returnType: typeof(string),
         declaringType: typeof(FAVAC_WebView),
         defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        public string PageTitle
        {
            get => (string)GetValue(PageTitleProperty);
            set => SetValue(PageTitleProperty, value);
        }

        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }

        public void Cleanup()
        {
            action = null;
        }

        public void InvokeAction(string data)
        {
            if (action == null || data == null)
            {
                return;
            }
            action.Invoke(data);
        }
    }
}