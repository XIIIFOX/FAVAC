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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace FAVAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public DataPage()
        {
            InitializeComponent();

            ToolbarItem toolbarItemScan = new ToolbarItem
            {
                Text = "SCAN",
                Priority = 0,
                IconImageSource = "ic_qrcode_scan.png",
                Order = ToolbarItemOrder.Primary
            };
            toolbarItemScan.Clicked += ToolbarItemScan_Clicked;
            ToolbarItems.Add(toolbarItemScan);
            m_url.Text = Settings.ChartURL;
            qr_image.Children.Add(GenerateQR(Settings.ChartDATA));
        }

        private async void ToolbarItemScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scannerPage = new ZXingScannerPage();

                scannerPage.Title = "Scan QR";
                scannerPage.OnScanResult += (result) =>
                {
                    scannerPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                        ResultOfQRScanning(result.Text);
                    });
                };

                await Navigation.PushAsync(scannerPage);
            }
            catch (Exception ex)
            {
                Log.Warning("Middle", ex.Message);
            }
        }
        ZXingBarcodeImageView GenerateQR(string codeValue)
        {
            var qrCode = new ZXingBarcodeImageView
            {
                BarcodeFormat = BarcodeFormat.QR_CODE,
                BarcodeOptions = new QrCodeEncodingOptions
                {
                    Height = 350,
                    Width = 350
                },
                BarcodeValue = codeValue,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            qrCode.WidthRequest = 350;
            qrCode.HeightRequest = 350;
            return qrCode;
        }

        async void ResultOfQRScanning(string result)
        {
            var option = await DisplayAlert("Succes!", "Do you want try this chart or set settings?" + result, "Set settings", "Try");
            if (option)
            {
                Settings.ChartDATA = result;
                m_url.Text = Settings.ChartURL;
                GenerateQR(Settings.ChartDATA);
            }
            else
            {
                await Navigation.PushAsync(new MainWebPage());
                MessagingCenter.Send<string>(result.Split('*')[1], "ChangeWebViewKey");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(m_url.Text);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Share.RequestAsync(new ShareTextRequest
            {
                Uri = m_url.Text,
                Title = "Share This Url"
            });
        }
    }
}