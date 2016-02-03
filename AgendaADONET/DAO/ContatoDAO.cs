using AgendaADONET.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaADONET.DAO
{
    public class ContatoDAO
    {
        //recuperar dados do banco e colocar na tabela que pode ser usada no GridView do Form
        //usando com DataTable
        public DataTable GetContatos()
        {
            //abrir conexão
            DbConnection conexao = DAOUtils.GetConexao();
            //ferramenta que vai executar comandos la
            DbCommand comando = DAOUtils.GetComando(conexao);
            //Comando vai ser to tipo texto
            comando.CommandType = CommandType.Text;
            //sql bruto
            comando.CommandText = "SELECT * FROM CONTATOS";
            //ler a resposta do comando
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            //DataTable é o que o GridView precisa
            DataTable dataTable = new DataTable();
            //carrega o reader no dataTable
            dataTable.Load(reader);
            return dataTable;
        }
        //usando com DataSet
        /*public DataSet GetContatos()
        {
            //abrir conexão
            DbConnection conexao = DAOUtils.GetConexao();
            //ferramenta que vai executar comandos la
            DbCommand comando = DAOUtils.GetComando(conexao);
            //Comando vai ser to tipo texto
            comando.CommandType = CommandType.Text;
            //sql bruto
            comando.CommandText = "SELECT * FROM CONTATOS";
            //ler a resposta do comando
            DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)comando);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "CONTATOS");//NOME DA TABELA
            return ds;
        }*/

        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id";
            //comando.Parameters.Add(new SqlParameter("@id",id)); //se previnir de SQL INJECTION no SQL SEVER
            comando.Parameters.Add(new MySqlParameter("@id", id));
            comando.ExecuteNonQuery(); //executar e sem consultar
        }
        public void Inserir(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO CONTATOS(NOME,EMAIL,TELEFONE) VALUES (@nome, @email, @telefone)";
            comando.Parameters.Add(DAOUtils.GetParametro("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParametro("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParametro("@telefone", contato.Telefone));
            comando.ExecuteNonQuery(); //insert não retorna nada
        }
        public void Atualizar(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE CONTATOS SET NOME = @nome,EMAIL = @email ,TELEFONE = @telefone WHERE ID = @id ";
            comando.Parameters.Add(DAOUtils.GetParametro("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParametro("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParametro("@telefone", contato.Telefone));
            comando.Parameters.Add(DAOUtils.GetParametro("@id", contato.Id));
            comando.ExecuteNonQuery();
        }
        public string ContarUsuarios()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT COUNT(*) FROM CONTATOS";
            return comando.ExecuteScalar().ToString(); //retorna só a primeira linha da consulta;
        }
    }
}
