using Atividade_dois_final.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace Atividade_dois_final
{
	public partial class App : Application
	{
        #region ViewModels
        public static AlunoViewModel AlunoVM { get; set; }
        #endregion

        public App ()
		{
			InitializeComponent();
            InitializeApplication();
            MainPage = new NavigationPage(new View.AlunoView() { BindingContext = App.AlunoVM });
        }

        private void InitializeApplication()
        {
            if (AlunoVM == null) AlunoVM = new AlunoViewModel();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
