using Atividade_dois_final.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Atividade_dois_final.ViewModel
{
   public class AlunoViewModel : INotifyPropertyChanged
    {
        #region Propriedades
        public OnAdicionarAlunoCMD OnAdicionarAlunoCMD { get; }
        public ICommand OnNovoAlunoCMD { get; private set; }
        public ICommand OnSairCMD { get; private set; }

        public Aluno AlunoModel { get; set; }
        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>(); 
        #endregion

        public AlunoViewModel()
        {
            AlunoModel = new Aluno();
            OnAdicionarAlunoCMD = new OnAdicionarAlunoCMD(this);
            OnSairCMD = new Command(OnSair);
            OnNovoAlunoCMD = new Command(OnNovo);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void Adicionar(Aluno alunoP)
        {
            try
            {
                if (alunoP == null)
                    throw new Exception("Usuário inválido. Favor Cadastrar novamente");

                alunoP.Id = Guid.NewGuid();
                Alunos.Add(alunoP);
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro. =(", "OK");
            }
        }


        private async void OnSair()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnNovo()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }
    }

    public class OnAdicionarAlunoCMD : ICommand
    {
        private AlunoViewModel alunoVM;
        public OnAdicionarAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            alunoVM.Adicionar(parameter as Aluno);
        }
    }
}

