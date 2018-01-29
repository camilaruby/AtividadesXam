using Atividade_Cinco.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atividade_Cinco.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{
        public DetalheView()
        {
            InitializeComponent();
            GetLocalizacao();
        }

        private void GetLocalizacao()
        {
            GetCoordenada();
        }

        private void GetCoordenada()
        {
            ILocalizacao geolocation = DependencyService.Get<ILocalizacao>();
            geolocation.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordenada",
                (objeto, geo) =>
                {
                    lblLatitude.Text = geo.Latitude;
                    lblLongitude.Text = geo.Longitude;
                    btnMapa.Text = "Ver no Mapa";
                });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (await DisplayAlert("Trocar imagem", "Desaja alterar a foto?", "Sim", "Não"))
            {
                ICamera capturar = DependencyService.Get<ICamera>();
                capturar.CapturarFoto();

                MessagingCenter.Subscribe<ICamera, string>(this, "cameraFoto",
                    (objeto, image) =>
                    {
                        this.imgFoto.Source = ImageSource.FromFile(image);
                    });
            }
        }

        private void btnMapa_Clicked(object sender, EventArgs e)
        {
            if (lblLatitude.Text == "Lat") GetCoordenada();
            else
            {
                string mapaUri = string.Empty;

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                        mapaUri = string.Format("http://maps.apple.com/?ll={0}{1}", lblLatitude.Text, lblLongitude.Text);
                        break;
                    case Device.Android:
                        mapaUri = string.Format("geo:0,0?q={0},{1}?z=10", lblLatitude.Text, lblLongitude.Text);
                        break;
                    case Device.UWP:
                        mapaUri = string.Format("bingmaps:?q={0},{1}", lblLatitude.Text, lblLongitude.Text);
                        break;
                    default:
                        break;
                }
                Device.OpenUri(new Uri(mapaUri));
            }
        }
    }
}