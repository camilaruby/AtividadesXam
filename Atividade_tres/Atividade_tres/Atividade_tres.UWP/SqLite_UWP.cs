using Atividade_tres.Data;
using Atividade_tres.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLite_UWP))]
namespace Atividade_tres.UWP
{
    public class SqLite_UWP : IDependencyServiceSQLite
    {

        public SqLite_UWP() { }
        public SQLite.SQLiteConnection
        GetConexao()
        {
            var arquivodb = "fiapdb.db3";
            string caminho = Path.Combine(
            ApplicationData.Current.LocalFolder.Path,
            arquivodb);
            var conexao = new
            SQLite.SQLiteConnection(caminho);
            return conexao;
        }
        
    }
}
