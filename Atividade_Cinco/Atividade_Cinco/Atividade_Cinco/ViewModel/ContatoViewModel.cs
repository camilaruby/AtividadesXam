using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Atividade_Cinco.Model;
using Atividade_Cinco.App_Code;

namespace Atividade_Cinco.ViewModel
{
    public class ContatoViewModel : INotifyPropertyChanged
    {
        private Contato contato;
        public Contato Contato
        {
            get { return contato; }
            set
            {
                contato = value as Contato;
                OnLigarCMD.LigarCanExecuteChanged();
                EventPropertyChanged();
            }
        }
        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        
        
        public OnDetalheCMD OnDetalheCMD { get; }
        public OnLigarCMD OnLigarCMD { get; }

        public ContatoViewModel()
        {
            OnLigarCMD = new OnLigarCMD(this);
            OnDetalheCMD = new OnDetalheCMD(this);
        }

        public async void Ligar(Contato paramContato)
        {
            if (!string.IsNullOrWhiteSpace(paramContato.Numero))
            {
                if (await App.Current.MainPage.DisplayAlert(
                    "Chamando...", "Ligar para " + paramContato.Numero + "?", "Sim", "Não"))
                {
                    var phone = DependencyService.Get<ITelefone>();
                    if (phone != null) phone.Ligar(paramContato.Numero);
                }
            }
        }

        public void GetDetalhe(Contato paramContato)
        {
            if (paramContato != null)
            {
                App.Current.MainPage.Navigation.PushAsync(
                    new View.DetalheView() { BindingContext = paramContato });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OnLigarCMD : ICommand
    {
        private ContatoViewModel contatoVM;
        public OnLigarCMD(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void LigarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            contatoVM.Ligar(parameter as Contato);
        }
    }

    public class OnDetalheCMD : ICommand
    {
        private ContatoViewModel contatoVM;
        public OnDetalheCMD(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DetalheCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            contatoVM.GetDetalhe(parameter as Contato);
        }
    }
}
