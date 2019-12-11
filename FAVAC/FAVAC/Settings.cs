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
using System;
using System.Collections.Generic;

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

        //Chart DATA
        public static string ChartDATA
        {
            get
            {
                Dictionary<int, string> _data = new Dictionary<int, string>();

                _data.Add(0, Mode.ToString());
                _data.Add(1, Symbols.ToString());
                _data.Add(2, Interval.ToString());
                _data.Add(3, Language.ToString());
                _data.Add(4, StyleOfBars.ToString());
                _data.Add(5, DrawerPanel.ToString());
                _data.Add(6, SaveImageButton.ToString());
                _data.Add(7, News.ToString());
                _data.Add(8, NewsCalendar.ToString());
                _data.Add(9, Hotlist.ToString());
                _data.Add(10, Publish.ToString());
                _data.Add(11, Theme.ToString());
                _data.Add(12, ToolBarBg.ToString());

                string _main1 = null;
                for (int i = 0; i < 13; i++)
                {
                    if (_main1 == null)
                    {
                        _main1 = _data[i];
                    }
                    else
                    {
                        _main1 += "|" + _data[i];
                    }
                }

                return _main1 + "*" + ChartURL;
            }
            set
            {
                string[] DATA = value.Split('*')[0].Split('|');
                Mode = (DATA[0] == "true") ? true : false;
                Symbols = DATA[1];
                Interval = DATA[2];
                Language = DATA[3];
                StyleOfBars = Convert.ToInt32(DATA[4]);
                DrawerPanel = Convert.ToInt32(DATA[5]);
                SaveImageButton = Convert.ToInt32(DATA[6]);
                News = Convert.ToInt32(DATA[7]);
                NewsCalendar = Convert.ToInt32(DATA[8]);
                Hotlist = Convert.ToInt32(DATA[9]);
                Publish = (DATA[10] == "true") ? true : false; ;
                Theme = DATA[11];
                ToolBarBg = DATA[12];
            }
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
            get
            {
                string[] labels = Watchlist_Label.Split('|');
                int index = 0;
                string symbolAdder = null;
                foreach (string label in labels)
                {
                    symbolAdder += $"%7B%22title%22%3A%22{label}%22%2C%22symbols%22%3A%5B%7B%22s";

                    foreach (string data in Watchlist_Data.Split('|')[index].Split('\n'))
                    {
                        try
                        {
                            symbolAdder += "%22%3A%22" + data.Split(':')[0] + "%3A" + data.Split(':')[1] + "%22%7D%2C%7B%22s";
                        }
                        catch
                        {
                            symbolAdder += "%22%3A%22" + data + "%22%7D%2C%7B%22s";
                        }
                    }

                    symbolAdder = symbolAdder.Remove(symbolAdder.Length - 16) + "%22%7D%5D%2C%22";
                    symbolAdder += $"originalTitle%22%3A%22{label}%22%7D%2C";
                    index++;
                }
                symbolAdder = symbolAdder.Remove(symbolAdder.Length - 9) + "%22%7D%5D%2C%22";

                string readyUrl = $"https://s.tradingview.com/embed-widget/market-overview/?locale={Language}#%7B%22colorTheme%22%3A%22{Theme}%22%2C%22dateRange%22%3A%22{Watchlist_Interval}%22%2C%22showChart%22%3Atrue%2C%22width%22%3A%22400%22%2C%22height%22%3A%22660%22%2C%22largeChartUrl%22%3A%22https%3A%2F%2F_%2F%7Btvexchange%7D%3A%7Btvsymbol%7D%22%2C%22isTransparent%22%3Afalse%2C%22plotLineColorGrowing%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22plotLineColorFalling%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22gridLineColor%22%3A%22rgba(42%2C%2046%2C%2057%2C%201)%22%2C%22scaleFontColor%22%3A%22rgba(120%2C%20123%2C%20134%2C%201)%22%2C%22belowLineFillColorGrowing%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22belowLineFillColorFalling%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22symbolActiveColor%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22tabs%22%3A%5B" +
                  symbolAdder +
                    $"utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22market-overview%22%7D";

                return readyUrl;
            }
        }
        public static string Watchlist_Label
        {
            get { return AppSettings.GetValueOrDefault("watchlist_label", $"Indices|Commodities|Bonds|Forex"); }
            set { AppSettings.AddOrUpdateValue("watchlist_label", value); }
        }
        public static string Watchlist_Data
        {
            get { return AppSettings.GetValueOrDefault("watchlist_data", $"OANDA:SPX500USD\nOANDA:NAS100USD\nFOREXCOM:DJI\nINDEX:NKY\nINDEX:DEU30\nOANDA:UK100GBP|CME_MINI:ES1!\nCME:6E1!\nCOMEX:GC1!\nNYMEX:CL1!\nNYMEX:NG1!\nCBOT:ZC1!|CME:GE1!\nCBOT:ZB1!\nCBOT:UB1!\nEUREX:FGBL1!\nEUREX:FBTP1!\nEUREX:FGBM1!|FX:EURUSD\nFX:USDJPY\nFX:USDCHF\nFX:AUDUSD\nFX:USDCAD"); }
            set { AppSettings.AddOrUpdateValue("watchlist_data", value); }
        }
        public static string Watchlist_Interval
        {
            get { return AppSettings.GetValueOrDefault("watchlist_interval", "12m"); }
            set { AppSettings.AddOrUpdateValue("watchlist_interval", value); }
        }
    }
}