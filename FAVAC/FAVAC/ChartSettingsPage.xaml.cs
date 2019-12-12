//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
// __/\\\\\\\___/\\\///////\\\_\/\\\///////////______/\\\///\\\____\///\\\___/\\\/__                                                                                                                                                                                  
//  _\/////\\\__\///______/\\\__\/\\\_______________/\\\/__\///\\\____\///\\\\\\/____                                                                                                                                                                                 
//   _____\/\\\_________/\\\//___\/\\\\\\\\\\\______/\\\______\//\\\_____\//\\\\______                                                                                                                                                                                
//    _____\/\\\________\////\\\__\/\\\///////______\/\\\_______\/\\\______\/\\\\______                                                                                                                                                                               
//     _____\/\\\___________\//\\\_\/\\\_____________\//\\\______/\\\_______/\\\\\\_____                                                                                                                                                                              
//      _____\/\\\__/\\\______/\\\__\/\\\______________\///\\\__/\\\_______/\\\////\\\___                                                                                                                                                                             
//       _____\/\\\_\///\\\\\\\\\/___\/\\\________________\///\\\\\/______/\\\/___\///\\\_                                                                                                                                                                            
//        _____\///____\/////////_____\///___________________\/////_______\///_______\///__       
using Plugin.Settings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FAVAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartSettingsPage : ContentPage
    {
        public ChartSettingsPage()
        {
            InitializeComponent();
            Loader();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var option = await DisplayAlert("Removing...", "Do you want restore settings ?", "Yes", "No");
            if (option)
            {
                CrossSettings.Current.Clear();
                Loader();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Main_side_save(true);
            Detailed_side_save(true);
            Design_side_save(true);
            MessagingCenter.Send<string>(Settings.ChartURL, "ChangeWebViewKey");
        }
        void Loader()
        {
            Main_side_save(false);
            Detailed_side_save(false);
            Design_side_save(false);
        }

        void Main_side_save(bool _yes)
        {
            if (_yes)
            {
                Settings.Mode = m_mode.IsToggled;
                Settings.Symbols = m_symbols.Text;
                Settings.Interval = m_interval.Text;
                Settings.Language = m_lang.Text;
                Settings.StyleOfBars = m_style.SelectedIndex;
            }
            else
            {
                m_mode.IsToggled = Settings.Mode;
                detailed_card.IsVisible = m_mode.IsToggled;
                theme_card.IsVisible = m_mode.IsToggled;
                m_stackofbars.IsVisible = m_mode.IsToggled;
                m_stackofdesign.IsVisible = !m_mode.IsToggled;
                m_stackoflang.IsVisible = m_mode.IsToggled;
                m_symbols.Text = Settings.Symbols;
                m_interval.Text = Settings.Interval;
                m_lang.Text = Settings.Language;
                m_style.SelectedIndex = Settings.StyleOfBars;
            }
        }

        void Detailed_side_save(bool _yes)
        {
            if (_yes)
            {
                Settings.DrawerPanel = (d_drawer_panel.IsChecked) ? 0 : 1;
                Settings.SaveImageButton = (d_saveimage.IsToggled) ? 1 : 0;
                Settings.News = (d_news.IsToggled) ? 1 : 0;
                Settings.NewsCalendar = (d_economiccalendar.IsToggled) ? 1 : 0;
                Settings.Hotlist = (d_hotlist.IsToggled) ? 1 : 0;
                Settings.Publish = !d_publish.IsChecked;
            }
            else
            {
                d_drawer_panel.IsChecked = (Settings.DrawerPanel == 0) ? true : false;
                d_saveimage.IsToggled = (Settings.SaveImageButton == 1) ? true : false;
                d_news.IsToggled = (Settings.News == 1) ? true : false;
                d_economiccalendar.IsToggled = (Settings.NewsCalendar == 1) ? true : false;
                d_hotlist.IsToggled = (Settings.Hotlist == 1) ? true : false;
                d_publish.IsChecked = !Settings.Publish;
            }
        }
        void Design_side_save(bool _yes)
        {
            if (_yes)
            {
                Settings.Theme = (o_theme.IsToggled) ? "dark" : "light";
                Settings.Theme = (m_theme.IsToggled) ? "dark" : "light";
            }
            else
            {
                o_theme.IsToggled = (Settings.Theme == "Dark") ? true : false;
                m_theme.IsToggled = (Settings.Theme == "dark") ? true : false;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("What color of background u wanna?", "Cancel", "Reset", "Blue", "Red", "Yellow", "Custom");
            switch (action)
            {
                case "Reset":
                    Settings.ToolBarBg = "f1f3f6";
                    break;
                case "Blue":
                    Settings.ToolBarBg = "Blue";
                    break;
                case "Red":
                    Settings.ToolBarBg = "Red";
                    break;
                case "Yellow":
                    Settings.ToolBarBg = "Yellow";
                    break;
                case "Custom":
                    string result = await DisplayPromptAsync("Custom color", "Use HEX or sample names of colors(for example: cyan)");
                    Settings.ToolBarBg = result;
                    break;
            }
        }

        private void Mode_Toggled(object sender, ToggledEventArgs e)
        {
            detailed_card.IsVisible = m_mode.IsToggled;
            theme_card.IsVisible = m_mode.IsToggled;
            m_stackofbars.IsVisible = m_mode.IsToggled;
            m_stackofdesign.IsVisible = !m_mode.IsToggled;
            m_stackoflang.IsVisible = m_mode.IsToggled;
        }
        private void Theme_Toggled(object sender, ToggledEventArgs e)
        {
            if (sender == m_theme) o_theme.IsToggled = m_theme.IsToggled; else m_theme.IsToggled = o_theme.IsToggled;
        }
    }
}