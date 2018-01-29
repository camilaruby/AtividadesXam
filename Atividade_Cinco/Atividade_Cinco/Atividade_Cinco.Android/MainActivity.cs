using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;


using Android.Content;
using Atividade_Cinco.App_Code;
using Plugin.Media.Abstractions;
using Xamarin.Media;


[assembly: Dependency(typeof(Atividade_Cinco.Droid.MainActivity))]
namespace Atividade_Cinco.Droid
{
    [Activity(Label = "Atividade_Cinco", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        public void CapturarFoto()
        {
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var context = Forms.Context as Activity;
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            var captura = new MediaPicker(context);

            var intent = captura.GetTakePhotoUI(new Xamarin.Media.StoreCameraMediaOptions
            {
                DefaultCamera = Xamarin.Media.CameraDevice.Rear
            });
            context.StartActivityForResult(intent, 1);
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled) return;

#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var mediaPath = await data.GetMediaFileExtraAsync( Forms.Context);
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            System.Diagnostics.Debug.WriteLine(mediaPath.Path);

            MessagingCenter.Send<ICamera, string>(this, "cameraFoto", mediaPath.Path);
        }
    }
}

