using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Atividade_tres.Data
{
    public interface IDependencyServiceSQLite
    {
        SQLiteConnection GetConexao();
    }
}
