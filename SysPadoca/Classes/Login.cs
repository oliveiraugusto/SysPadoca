using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SysPadoca.Classes
{
    class Login : Conexao
    {
        //Metodo para verificar o login e senha do usuário
        public bool Logar(string login, string senha)
        {
            SqlConnection conn = new SqlConnection(strConn); //instancio a classe de conexao com banco, passando a string de conexao como parametro
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM dbo.usuarios WHERE login = @login AND senha = @senha", conn); //instancio a classe comando sql, e passo meu script SQL por parametro
            cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login; //Seto na classe os meu paramentro @login
            cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha; //Seto na classe os meu paramentro @senha

            conn.Open(); // Abro a conexao com o banco de dados

            int resultSQL = (int)cmd.ExecuteScalar(); // passo para minha variavel o resultado do select

            if (resultSQL == 1) // Se o resultado da consulta for igual a 1 (Afinal, só pode haver um usuario com esse login e senha
            {
                conn.Close(); //fecho a conexao com o banco de dados
                return true; // e retorno true
            }
            else // se o select devolver qualquer coisa diferente de 1
            {
                conn.Close(); //fecho a conexao com o banco de dados
                return false; // retorno false
            }
        }
    }
}
