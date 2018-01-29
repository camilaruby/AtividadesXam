using Atividade_Cinco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Atividade_Cinco.Model
{
    public interface IContato
    {
        void GetMobileContacts(ContatoViewModel vm);
    }

    public class Contato
    {
        public Contato()
        {
            Telefones = new List<Telefone>();
        }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string DisplayName { get; set; }
        public List<Telefone> Telefones { get; set; }
        public string Numero
        {
            get
            {
                if (Telefones != null)
                    return Telefones.FirstOrDefault().Numero;

                return string.Empty;
            }
        }

        public ImageSource Foto { get; set; }
    }

    public class Telefone
    {
        public Telefone() { }

        public PhoneType Tipo { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
    }

    public enum PhoneType
    {
        Home = 0,
        HomeFax = 1,
        Work = 2,
        WorkFax = 3,
        Pager = 4,
        Mobile = 5,
        Other = 6
    }
}
