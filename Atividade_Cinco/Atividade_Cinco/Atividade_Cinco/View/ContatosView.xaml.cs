using Atividade_Cinco.Model;
using Atividade_Cinco.ViewModel;
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
	public partial class ContatosView : ContentPage
	{
        public ContatoViewModel contatosVM = new ContatoViewModel();
        public ContatosView()
        {
            BindingContext = contatosVM;
            InitializeComponent();

            GetContatos(contatosVM);
        }
        
        private void GetContatos(ContatoViewModel vm)
        {
            IContato lista = DependencyService.Get<IContato>();
            lista.GetMobileContacts(vm);
        }
        
    }
}