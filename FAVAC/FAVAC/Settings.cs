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
            get {
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
                for(int i =0;i<13; i++)
                {
                    if (_main1 == null) {
                        _main1 = _data[i];
                    }
                    else
                    {
                        _main1 += "|" + _data[i];
                    }
                }

                return _main1 + "*" + ChartURL; }
            set {
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
            get {
     //         string readyUrl =  $"https://s.tradingview.com/embed-widget/market-overview/?locale=uk#%7B%22colorTheme%22%3A%22dark%22%2C%22dateRange%22%3A%2212m%22%2C%22showChart%22%3Atrue%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22largeChartUrl%22%3A%22%22%2C%22isTransparent%22%3Afalse%2C%22plotLineColorGrowing%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22plotLineColorFalling%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22gridLineColor%22%3A%22rgba(42%2C%2046%2C%2057%2C%201)%22%2C%22scaleFontColor%22%3A%22rgba(120%2C%20123%2C%20134%2C%201)%22%2C%22belowLineFillColorGrowing%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22belowLineFillColorFalling%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22symbolActiveColor%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)" +
     //               $"%22%2C%22tabs%22%3A%5B%7B%22title%22%3A%22Forex%22%2C%22symbols%22%3A%5B%7B%22s%22%3A%22FX%3AEURUSD%22%7D%2C%7B%22s%22%3A%22FX%3AGBPUSD%22%7D%2C%7B%22s%22%3A%22FX%3AUSDJPY%22%7D%2C%7B%22s%22%3A%22FX%3AUSDCHF%22%7D%2C%7B%22s%22%3A%22FX%3AAUDUSD%22%7D%2C%7B%22s%22%3A%22FX%3AUSDCAD%22%7D%2C%7B%22s%22%3A%22FX%3AEURUSD%22%7D%5D%2C%22originalTitle%22%3A%22Forex%22%7D%5D%2C%22" +
     //               $"utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22market-overview%22%7D";
     string readyUrl =  $"https://s.tradingview.com/embed-widget/market-overview/?locale=uk#%7B%22colorTheme%22%3A%22dark%22%2C%22dateRange%22%3A%2212m%22%2C%22showChart%22%3Atrue%2C%22width%22%3A%22400%22%2C%22height%22%3A%22660%22%2C%22largeChartUrl%22%3A%22https%3A%2F%2F_%2F%7Btvexchange%7D%3A%7Btvsymbol%7D%22%2C%22isTransparent%22%3Afalse%2C%22plotLineColorGrowing%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22plotLineColorFalling%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22gridLineColor%22%3A%22rgba(42%2C%2046%2C%2057%2C%201)%22%2C%22scaleFontColor%22%3A%22rgba(120%2C%20123%2C%20134%2C%201)%22%2C%22belowLineFillColorGrowing%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22belowLineFillColorFalling%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22symbolActiveColor%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22tabs" +
                    $"%22%3A%5B%7B%22title%22%3A%22Indices%22%2C%22" +
                    $"symbols%22%3A%5B%7B%22s" +
                    $"%22%3A%22OANDA%3ASPX500USD%22%7D%2C%7B%22s%22%3A%22OANDA%3ANAS100USD%22%7D%2C%7B%22s%22%3A%22FOREXCOM%3ADJI%22%7D%2C%7B%22s%22%3A%22INDEX%3ANKY%22%7D%2C%7B%22s%22%3A%22INDEX%3ADEU30%22%7D%2C%7B%22s%22%3A%22OANDA%3AUK100GBP%22%7D%5D%2C%22" +
                    $"originalTitle%22%3A%22Indices%22%7D%2C%7B%22title%22%3A%22Commodities%22%2C%22symbols%22%3A%5B%7B%22s%22%3A%22CME_MINI%3AES1!%22%7D%2C%7B%22s%22%3A%22CME%3A6E1!%22%7D%2C%7B%22s%22%3A%22COMEX%3AGC1!%22%7D%2C%7B%22s%22%3A%22NYMEX%3ACL1!%22%7D%2C%7B%22s%22%3A%22NYMEX%3ANG1!%22%7D%2C%7B%22s%22%3A%22CBOT%3AZC1!%22%7D%5D%2C%22originalTitle%22%3A%22Commodities%22%7D%2C%7B%22title%22%3A%22Bonds%22%2C%22symbols%22%3A%5B%7B%22s%22%3A%22CME%3AGE1!%5Ct%22%7D%2C%7B%22s%22%3A%22CBOT%3AZB1!%5Ct%22%7D%2C%7B%22s%22%3A%22CBOT%3AUB1!%22%7D%2C%7B%22s%22%3A%22EUREX%3AFGBL1!%22%7D%2C%7B%22s%22%3A%22EUREX%3AFBTP1!%22%7D%2C%7B%22s%22%3A%22EUREX%3AFGBM1!%22%7D%5D%2C%22originalTitle%22%3A%22Bonds%22%7D%2C%7B%22title%22%3A%22Forex%22%2C%22symbols%22%3A%5B%7B%22s%22%3A%22FX%3AEURUSD%22%7D%2C%7B%22s%22%3A%22FX%3AGBPUSD%22%7D%2C%7B%22s%22%3A%22FX%3AUSDJPY%22%7D%2C%7B%22s%22%3A%22FX%3AUSDCHF%22%7D%2C%7B%22s%22%3A%22FX%3AAUDUSD%22%7D%2C%7B%22s%22%3A%22FX%3AUSDCAD%22%7D%5D%2C%22originalTitle%22%3A%22Forex%22%7D%5D%2C%22" +
                    $"utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22market-overview%22%7D";
                string[] labels = Watchlist_Label.Split('|');
                int index = 0;
                string symbolAdder = null;
                foreach(string label in labels)
                {
                    symbolAdder += $"%22%3A%5B%7B%22title%22%3A%22{label}%22%2C%22symbols%22%3A%5B%7B%22s";
                
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

                    symbolAdder += symbolAdder.Remove(symbolAdder.Length - 1, 1) + "%22%7D%5D%2C%22";
                    index -= -1;//originaly
                }
                return readyUrl;
            }
        }
        public static string Watchlist_Label
        {
            get { return AppSettings.GetValueOrDefault("watchlist_label", $"Indices|Commodities|Bonds|Forex"); }
            set { AppSettings.AddOrUpdateValue("watchlist_label", value);}
        }
        public static string Watchlist_Data
        {
            get { return AppSettings.GetValueOrDefault("watchlist_data", $"FX:EURUSD\nFX:EURUSD\nFX:USDJPY\nFX:USDCHF\nFX:AUDUSD\nFX:USDCAD\nFX:EURUSD|dd|dd|dd"); }
            set { AppSettings.AddOrUpdateValue("watchlist_data", value);}
        }
    }
}