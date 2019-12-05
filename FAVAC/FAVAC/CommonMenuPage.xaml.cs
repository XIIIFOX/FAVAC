using Plugin.Settings;
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
    public partial class CommonMenuPage : ContentPage
    {
        public CommonMenuPage()
        {
            InitializeComponent();
            Main_side_save(false);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Main_side_save(true);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CrossSettings.Current.Remove("symbols");
            CrossSettings.Current.Remove("lang");
            Main_side_save(false);
        }

        void Main_side_save(bool _yes)
        {
            if (_yes)
            {
                Settings.Symbols = m_symbols.Text;
                Settings.Language = m_lang.Text;
                //Добавить крипто режим и реализовать интервал, тему для всех
            }
            else
            {
                m_symbols.Text = Settings.Symbols;
                m_lang.Text = Settings.Language;
            }
        }
    }
}