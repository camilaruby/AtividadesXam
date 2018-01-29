using Atividade_tres.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atividade_tres.View.Aluno
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAlunoView : ContentPage
	{
        public static AlunoViewModel AlunoVM { get; set; }
        public NovoAlunoView ()
		{    
          InitializeComponent ();
		}
	}
}