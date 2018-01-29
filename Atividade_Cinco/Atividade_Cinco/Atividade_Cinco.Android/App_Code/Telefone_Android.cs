using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Net;
using Android.Telephony;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Atividade_Cinco.Droid.App_Code;
using Atividade_Cinco.App_Code;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(Telefone_Android))]
namespace Atividade_Cinco.Droid.App_Code
{
    public class Telefone_Android : ITelefone
    {
        public bool Ligar(string numero)
        {
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var context = Forms.Context;
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            if (context == null)
                return false;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + numero));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }

            return false;
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any()) return true;

            var manager = TelephonyManager.FromContext(context);
            return manager.PhoneType != PhoneType.None;
        }
    }
}