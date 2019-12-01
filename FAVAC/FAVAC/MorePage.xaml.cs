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
    public partial class MorePage : ContentPage
    {
        public List<CommonMenuItem> ElementsOthers { get; set; }
        public List<CommonMenuItem> Elements { get; set; }

        public MorePage()
        {
            InitializeComponent();

            ToolbarItem toolbarItemSettings = new ToolbarItem
            {
                Text = "Settings",
                Priority = 1,
                Order = ToolbarItemOrder.Primary,
                IconImageSource = "ic_settings.png"
            };
            ToolbarItem toolbarItemShare = new ToolbarItem
            {
                Text = "Share",
                Priority = 0,
                Order = ToolbarItemOrder.Primary,
                IconImageSource = "ic_share.png"
            };
            ToolbarItems.Add(toolbarItemSettings);
            ToolbarItems.Add(toolbarItemShare);

            Elements = new List<CommonMenuItem> {
            new CommonMenuItem {Title="Stock Market", ImagePath="ic_chart_gantt.png" },
            new CommonMenuItem {Title="Forex Cross Rates", ImagePath="ic_checkerboard.png" },
            new CommonMenuItem {Title="Forex Heat Map", ImagePath="ic_chart_scatter_plot.png" },
            new CommonMenuItem {Title="Screener", ImagePath="ic_chevron_double_up.pngg" },
            new CommonMenuItem {Title="Cryptocurrency Market", ImagePath="ic_bitcoin.png" }
        };

            ElementsOthers = new List<CommonMenuItem>
            {
                  new CommonMenuItem {Title="Site", ImagePath="ic_select.png" },
            new CommonMenuItem {Title="About", ImagePath="ic_information.png" }
            };
            this.BindingContext = this;
        }

        public class CommonMenuItem
        {
            public string Title { get; set; }
            public string ImagePath { get; set; }
        }
        
        private void itemsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
                ((ListView)sender).SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}