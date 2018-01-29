using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Atividade_Cinco.App_Code;
using Atividade_Cinco.Droid.App_Code;

[assembly: Dependency(typeof(Localizacao_Android))]
namespace Atividade_Cinco.Droid.App_Code
{
    public class Localizacao_Android : ILocalizacao
    {
        public void GetCoordenada()
        {
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var context = Forms.Context as Activity;
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;


                locator.GetPositionAsync(100000).ContinueWith(t => {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
                System.Diagnostics.Debug.WriteLine(t.Result.Latitude);
            }, TaskScheduler.FromCurrentSynchronizationContext());

            
        }

        void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordenada", coordenada);
        }
    }
}