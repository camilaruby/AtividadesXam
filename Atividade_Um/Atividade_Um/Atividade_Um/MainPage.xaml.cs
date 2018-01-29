using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Atividade_Um
{
	public partial class MainPage : ContentPage
	{
        Email mailmdl;

        public MainPage()
		{
			InitializeComponent();
            if (mailmdl == null)
                mailmdl = new Email();
        }

        void btnEnviar_Clicked(object sender, EventArgs args)
        {

            if (!string.IsNullOrEmpty(mailmdl.LoginEmail))
                DisplayAlert("Mensagem", $"E-mail enviado para {mailmdl.LoginEmail}", "Ok");
            else
                DisplayAlert("Mensagem", "Envio não autorizado", "Ok");

        }

        void btnConfiguracao_Clicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ConfiguracaoPage() { BindingContext = mailmdl });
        }
    }
}
