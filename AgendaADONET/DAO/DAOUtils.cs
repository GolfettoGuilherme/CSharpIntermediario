using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaADONET.DAO
{
    public class DAOUtils
    {
        /*DbConnection conexao = new SqlConnection(@"Server=.\SQLEXPRESS;Database=TreinaWebCSharpIntermediario;User Id=sa;Password=root; "); //para SQL SEVER
        //DbConnection conexao = new MySqlConnection(@"Server=localhost;Database=TreinaWebCSharpIntermediario;Uid=root;Pwd=root;"); //para MySQL*/
        //metodo que retorna Conexão.
        public static DbConnection GetConexao()
        {
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            DbConnection conexao = null;
            string connectionString = "";
            if (ConfigurationManager.AppSettings["provider"].ToString().Equals("MSSQL"))
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";User Id=" + user + ";Password=" + password + ";";
                conexao = new SqlConnection(connectionString);
            }
            else
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";";
                conexao = new MySqlConnection(connectionString);
            }
            conexao.Open();
            return conexao;
        }

        //metodo para retornar command - ferramenta para executar SQL
        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }

        //metodo para retornar o leitor usado para ler os Selects usados
        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }

        public static DbParameter GetParametro(string nome, object valor)
        {
            DbParameter parametro = null;
            if (ConfigurationManager.AppSettings["provider"].ToString().Equals("MSSQL"))
            {
                parametro = new SqlParameter(nome, valor);
            }
            else
            {
                parametro = new MySqlParameter(nome, valor);
            }
            return parametro;
        }

    }
}
