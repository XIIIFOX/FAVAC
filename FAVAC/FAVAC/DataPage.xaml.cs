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
                        resultOfQRScanning(result.Text);
                    });
                };

                await Navigation.PushAsync(scannerPage);
            }
            catch (Exception ex)
            { 
                throw;
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

        async void resultOfQRScanning(string result)
        {
            var option = await DisplayAlert("Succes!", "Do you want try this chart or set settings?" + result, "Set settings", "Try");
            if (option)
            {
                Settings.ChartDATA = result;
            }
            else
            {
                await Navigation.PushAsync(new MainWebPage());
                MessagingCenter.Send<string>(result.Split('*')[1], "ChangeWebViewKey");
            }
        }
    }
}