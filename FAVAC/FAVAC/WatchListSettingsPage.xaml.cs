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

namespace FAVAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchListSettingsPage : ContentPage
    {
        private int _position;
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }
        public List<CommonViewItem> Elements { get; set; }
        public WatchListSettingsPage()
        {
            InitializeComponent();

            Elements = new List<CommonViewItem> {
            new CommonViewItem {Label = "Index", Symbols ="Forex" + '\n' + "f"},
            new CommonViewItem {Label = "Index", Symbols ="Forex"}
            };

            foreach (string _label in Settings.Watchlist_Data.Split('|'))
            {
                Elements.Add(new CommonViewItem { Label = "RR", Symbols=_label });
   
            }
            //for (int i = 0; i < 10; i++)
            //{
            //    string _label = Settings.Watchlist_Data.Split('|')[i];
            //    foreach (string _symbol in _label.Split('\n'))
            //    {

            //    }
            //}

            this.BindingContext = this;
        }

        public class CommonViewItem
        {
            public string Label { get; set; }
            public string Symbols { get; set; }
        }
    }
}