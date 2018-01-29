using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atividade_tres.Data;
using Atividade_tres.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQlite_iOS))]
namespace Atividade_tres.iOS
{
    public class SQlite_iOS : IDependencyServiceSQLite
    {
        public SQlite_iOS()
        {

        }
        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db";
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string bibliotecaPessoal = Path.Combine(caminho, "..", "Library");
            var local = Path.Combine(bibliotecaPessoal, arquivodb);

            var conexao = new SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}