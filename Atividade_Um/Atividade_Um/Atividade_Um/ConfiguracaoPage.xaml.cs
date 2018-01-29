using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atividade_Um
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracaoPage : ContentPage
    {
        

        public ConfiguracaoPage()
        {
            InitializeComponent();
        }

        public void switchEmail_OnChanged(object sender, ToggledEventArgs e)
        {
            if (swEmail.On)
            {
                txtemail.IsEnabled = true;
            }
            else
            {
                txtemail.IsEnabled = false;
            }
        }

    }
}