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
using Plugin.Settings.Abstractions;
namespace FAVAC
{
    public static class Settings 
    {
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

 
        //Chart URL
        public static string ChartURL
        {
            get { return (Mode) ? $"https://www.tradingview.com/widgetembed/?frameElementId=tradingview_131313&symbol={Symbols}&interval={Interval}&hidesidetoolbar={DrawerPanel}&symboledit=1&saveimage={SaveImageButton}&toolbarbg={ToolBarBg}&theme={Theme}&style={StyleOfBars}&timezone=Europe%2FMoscow&locale={Language}" + ((News == 0) ? "" : "&news=1&newsvendors=stocktwits") + ((Hotlist == 0) ? "" : "&hotlist=1") + ((NewsCalendar == 0) ? "" : "&calendar=1") + ((Publish) ? "" : "&enablepublishing=true") : $"https://www.tradingview.com/chart/?symbol={Symbols}&inteval={Interval}&theme={Theme}"; }
        }

        //main
        public static bool Mode
        {
            get { return AppSettings.GetValueOrDefault("mode_mod", true); }
            set { AppSettings.AddOrUpdateValue("mode_mod", value); }
        }
        public static string Symbols
        {
            get { return AppSettings.GetValueOrDefault("symbols", "EURUSD"); }
            set { AppSettings.AddOrUpdateValue("symbols", value); }
        }
        public static string Interval
        {
            get { return AppSettings.GetValueOrDefault("interval", "D"); }
            set { AppSettings.AddOrUpdateValue("interval", value); }
        }
        public static string Language
        {
            get { return AppSettings.GetValueOrDefault("lang", "en"); }
            set { AppSettings.AddOrUpdateValue("lang", value); }
        }
        public static int StyleOfBars
        {
            get { return AppSettings.GetValueOrDefault("style", 1); }
            set { AppSettings.AddOrUpdateValue("style", value); }
        }
        //detailed
        public static int DrawerPanel
        {
            get { return AppSettings.GetValueOrDefault("hidetoolsidebar", 0); }
            set { AppSettings.AddOrUpdateValue("hidetoolsidebar", value); }
        }
        public static int SaveImageButton
        {
            get { return AppSettings.GetValueOrDefault("saveimage", 1); }
            set { AppSettings.AddOrUpdateValue("saveimage", value); }
        }
        public static int News
        {
            get { return AppSettings.GetValueOrDefault("news", 0); }
            set { AppSettings.AddOrUpdateValue("news", value); }
        }
        public static int NewsCalendar
        {
            get { return AppSettings.GetValueOrDefault("calendar", 0); }
            set { AppSettings.AddOrUpdateValue("calendar", value); }
        }
        public static int Hotlist
        {
            get { return AppSettings.GetValueOrDefault("hotlist", 0); }
            set { AppSettings.AddOrUpdateValue("hotlist", value); }
        }
        public static bool Publish
        {
            get { return AppSettings.GetValueOrDefault("enablepublishing", false); }
            set { AppSettings.AddOrUpdateValue("enablepublishing", value); }
        }
        //designed
        public static string Theme
        {
            get { return AppSettings.GetValueOrDefault("theme", "dark"); }
            set { AppSettings.AddOrUpdateValue("theme", value); }
        }
        public static string ToolBarBg
        {
            get { return AppSettings.GetValueOrDefault("toolbarbg", "f1f3f6"); }
            set { AppSettings.AddOrUpdateValue("toolbarbg", value); }
        }

        //watchlist
        public static string Watchlist_Url
        {
            get { return AppSettings.GetValueOrDefault("watchlist_url", ""); }
            set { AppSettings.AddOrUpdateValue("watchlist_url", value);}
        }
    }
}